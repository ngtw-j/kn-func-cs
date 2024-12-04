# CSharp CloudEvent Function

Welcome to your new CSharp Function! The boilerplate function code can be found in
[`Program.cs`](Program.cs). This Function responds to CloudEvent requests.

The CloudEvents specification defines three content modes for transferring events: structured, binary and batch. The HTTP protocol binding supports all three content modes. 

## Binary content mode
The value of the event `data` is placed into the
HTTP request, or response, body as-is, with the `datacontenttype` attribute
value declaring its media type in the HTTP `Content-Type` header; all other
event attributes are mapped to HTTP headers.

## Structured content mode
The event metadata attributes and event data are
placed into the HTTP request or response body using an
[event format](#14-event-formats) that supports
[structured-mode messages][ce-message].

## Batched content mode
The event metadata attributes and event data of
multiple events are batched into a single HTTP request or response body using
an [event format](#14-event-formats) that supports batching
[structured-mode messages][ce-message].

[`appsettings.json`](appsettings.json), [`appsettings.Development.json`](`appsettings.Development.json`) and the Properties folder aren't necessary for building the function, but are there for you to test your code locally.

## Development
<!-- 
Develop new features by adding a test to [`handle_test.go`](handle_test.go) for
each feature, and confirm it works with `go test`. -->

Update the running analog of the function using the `func` CLI or client
library, and it can be invoked from your browser or from the command line:

```console
curl http://myfunction.example.com/
```

For more, see [the complete documentation]('https://github.com/knative/func/tree/main/docs')


