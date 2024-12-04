using CloudNative.CloudEvents.AspNetCore;
using CloudNative.CloudEvents.Core;

using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace CloudNative.CloudEvents.AspNetCoreSample
{
    // FIXME: This doesn't get called for binary CloudEvents without content, or with a different data content type.
    // FIXME: This shouldn't really be tied to JSON. We need to work out how we actually want this to be used.
    // See 

    /// <summary>
    /// A <see cref="TextInputFormatter"/> that parses HTTP requests into CloudEvents.
    /// </summary>
    public class CloudEventJsonInputFormatter(ILogger<CloudEventJsonInputFormatter> logger) : TextInputFormatter
    {
        private readonly ILogger<CloudEventJsonInputFormatter> _logger = logger;
        private readonly CloudEventFormatter _formatter;

        /// <summary>
        /// Constructs a new instance that uses the given formatter for deserialization.
        /// </summary>
        /// <param name="formatter"></param>
        public CloudEventJsonInputFormatter()
        {
            _formatter = Validation.CheckNotNull(formatter, nameof(formatter));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/cloudevents+json"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        /// <inheritdoc />
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            Validation.CheckNotNull(context, nameof(context));
            Validation.CheckNotNull(encoding, nameof(encoding));

            var request = context.HttpContext.Request;

            try
            {
                var cloudEvent = await request.ToCloudEventAsync(_formatter);
                return await InputFormatterResult.SuccessAsync(cloudEvent);
            }
            catch (Exception)
            {
                return await InputFormatterResult.FailureAsync();
            }
        }

        /// <inheritdoc />
        protected override bool CanReadType(Type type)
             => type == typeof(CloudEvent) && base.CanReadType(type);
    }
}
