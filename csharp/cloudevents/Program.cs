// Copyright (c) Cloud Native Foundation.
// Licensed under the Apache 2.0 license.
// See LICENSE file in the project root for full license information.

using CloudNative.CloudEvents.AspNetCoreSample;
using CloudNative.CloudEvents.NewtonsoftJson;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opts =>
    opts.InputFormatters.Insert(0, new CloudEventJsonInputFormatter(new JsonEventFormatter())));

// Register the health check services
builder.Services.AddHealthChecks();  // This registers the health check services

var app = builder.Build();

// Health checks
app.MapHealthChecks("/health/liveness");
app.MapHealthChecks("/health/readiness");

app.MapControllers();

app.Run();

// Generated `Program` class when using top-level statements
// is internal by default. Make this `public` here for tests.
public partial class Program { }
