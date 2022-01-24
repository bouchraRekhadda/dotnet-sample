This is a sample repo to demonstrate the issue with signed assemblies load on .NET Core.

On .NET Framework, `Assembly.Load` would fail with `FileLoadException` to load a different version of an already loaded strong named assembly; on .NET Core it seems to ignore the signature, which means that it will return which ever version that was loaded in the active `AssemblyLoadContext`.

### Reproduction
Build the project with `dotnet build`, the assembly will be signed at compilation with the `demo.snk` (for real world examples make sure you don't share your private key), then run tests with `dotnet test -f netcoreapp3.1`

### Excpected behavior
>Test Run Summary
 Overall result: Passed
 Test Count: 1, Passed: 1, Failed: 0, Warnings: 0, Inconclusive: 0, Skipped: 0

### Actual behavior

> Expected: <System.IO.FileLoadException>
  But was:  null

