# kn-func-lang
This repo contains the following additional Language Packs for Knative Functions:
- C# (csharp)

Add this repo to kn func repositories by running 
```sh
func repository add aaaas https://github.com/ngtw-j/kn-func-lang
```
This will give kn func access to all the "runtime" language pack in the repo.

By default, kn func will use the http template. A different template such as cloudevents can be specified by using the -t flag. See `func create -h` for more info. 

The cloudevents template is copied from this [sample](https://github.com/knative/docs/tree/main/code-samples/serving/cloudevents/cloudevents-dotnet)

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


## Stacks
 What Paketo stacks are available?

The Paketo project releases several stacks. We currently officially support Ubuntu 22.04 (Jammy Jellyfish). Tiny, Base, and Full stack variants differ in the number of packages installed in the OS layer. The available stacks, from smallest to largest, are:

    Jammy Tiny(opens in a new tab)
        Build image based on Ubuntu 22.04 Jammy Jellyfish; run image comparable to distroless(opens in a new tab)
        Ideal for most Golang apps, Java GraalVM Native Images(opens in a new tab)
    Jammy Base(opens in a new tab)
        Based on Ubuntu 22.04 Jammy Jellyfish
        Ideal for Java and .NET Core apps, Golang apps that require C libraries, Node.js, Python, Ruby, and JavaScript front end apps without many native extensions
    Jammy Full(opens in a new tab)
        Based on Ubuntu 22.04 Jammy Jellyfish
        Ideal for PHP apps, Node.js, Python, Ruby, and JavaScript front end apps with native extensions

In general, it is a best practice to select the smallest stack that supports the apps you are trying to build.

Taken from https://paketo.io/docs/concepts/stacks/