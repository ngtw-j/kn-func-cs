// Copyright (c) Cloud Native Foundation.
// Licensed under the Apache 2.0 license.
// See LICENSE file in the project root for full license information.
// Modified by ngtw@pcs-security.com, Dec 2024

using CloudNative.CloudEvents.AspNetCoreSample;
using CloudNative.CloudEvents.NewtonsoftJson;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opts =>
    opts.InputFormatters.Insert(0, new CloudEventJsonInputFormatter(new JsonEventFormatter())));
// builder.Services.AddControllers();

// Register the health check services
builder.Services.AddHealthChecks();  // This registers the health check services
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;

    // Add specific CloudEvent headers to log in the request
    logging.RequestHeaders.Add("ce-id");
    logging.RequestHeaders.Add("ce-source");
    logging.RequestHeaders.Add("ce-type");
    logging.RequestHeaders.Add("ce-specversion");
    logging.RequestHeaders.Add("ce-time");

    // Add specific CloudEvent headers to log in the response
    logging.ResponseHeaders.Add("ce-id");
    logging.ResponseHeaders.Add("ce-source");
    logging.ResponseHeaders.Add("ce-type");
    logging.ResponseHeaders.Add("ce-specversion");
    logging.ResponseHeaders.Add("ce-time");

    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

    logging.MediaTypeOptions.AddText("application/cloudevents+json"); 
    // FIXME add more mediatypes

    logging.CombineLogs = true;
});

var app = builder.Build();

// Health checks
app.MapHealthChecks("/health/liveness");
app.MapHealthChecks("/health/readiness");

app.MapControllers();

app.Run();
