# CSharp CloudEvent Function

Welcome to your new CSharp Function! The boilerplate function code can be found in ReceiveCloudEvent function in 
[`CloudEventController.cs`](Controllers/CloudEventController.cs). This Function responds to CloudEvent requests.

The CloudEvents specification defines three content modes for transferring events: structured, binary and batch.

## Structured content mode
The event metadata attributes and event data are
placed into the HTTP request or response body using an
[event format](#14-event-formats) that supports
[structured-mode messages][ce-message].

## Binary content mode (NOT SUPPORTED)
The value of the event `data` is placed into the
HTTP request, or response, body as-is, with the `datacontenttype` attribute
value declaring its media type in the HTTP `Content-Type` header; all other
event attributes are mapped to HTTP headers.

## Batched content mode (NOT SUPPORTED)
The event metadata attributes and event data of
multiple events are batched into a single HTTP request or response body using
an [event format](#14-event-formats) that supports batching
[structured-mode messages][ce-message].

[`appsettings.json`](appsettings.json), [`appsettings.Development.json`](`appsettings.Development.json`) and the Properties folder aren't necessary for building the function, but are there for you to test your code locally.

## Development

Update the running analog of the function using the `func` CLI or client
library, and it can be invoked from your browser or from the command line:

```console
curl http://myfunction.example.com/
```

For more, see [the complete documentation]('https://github.com/knative/func/tree/main/docs')


