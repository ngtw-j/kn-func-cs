# kn-func-lang
This repo contains the following additional Language Packs for Knative Functions:
- C# (csharp)

Add this repo to kn func repositories by running 
```sh
func repository add `https://github.com/ngtw-j/kn-func-cs`
```
This will give kn func access to all the "runtime" language pack in the repo.

## Summary
A Knative Function Language Pack provides runtime and invocation capabilities for user-provided Function code.

- A Language Pack must be accessible as a git repository or a path to a location on disk.
- A Language Pack must provide one or more code templates generated via func create.
- A Language Pack must expose an invokable function interface for function developers in the code template.
- A Language Pack project must be buildable in the form of an OCI container image via func build.
- A Language Pack OCI container image must be runnable via func run.
- A Language Pack may provide create, build, runtime and invocation metadata with a manifest.yaml file.
- A Language Pack project may be executable natively on a local host via host-specific tooling (e.g. npm start).

## Componenets
A Knative Function Language Pack consists, broadly, of two conceptual components:

- Build and runtime metadata provided via its directory structure and, optionally, a manifest.yaml file, all of which support the Function's lifecycle described below.
- Project templates for Functions and supporting code. This is the function developer's UX - a Function project, which in most cases should look just like any other project of its type.
