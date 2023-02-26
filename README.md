# PoC: xUnit Shared Contexts

This proof of concept aims to understand the behavior of some aspects in xUnit tests with [shared contexts](https://xunit.net/docs/shared-context).

## Logging to Test Output

**Goal**: validate how xUnit can be used to leverage its [test output](https://xunit.net/docs/capturing-output) as a logging provider for integration tests with ASP.NET Core.

### Results

- Tests with the [MartinCostello.Logging.XUnit](https://github.com/martincostello/xunit-logging) package:
  - Supports `ITestOutputHelper`? ✅
  - Supports `IMessageSink`? ✅
    - For integration tests with `WebApplicationFactory` it is needed to inject `IMessageSink` in the fixture class and override the `ConfigureWebHost` method to configure the logging provider with the injected object;

- Tests with the [Divergic.Logging.Xunit](https://github.com/roryprimrose/Divergic.Logging.Xunit) package:
  - Supports `ITestOutputHelper`? ⚠️
    - Does not support it in shared contexts, as it throws exception "There is no currently active test". Possible explanation [here](https://github.com/xunit/xunit/issues/2146#issuecomment-687201581) due to object lifetimes.
  - Supports `IMessageSink`? ❌

- Common:
  - Output via `IMessageSink` requires a `xunit.runner.json` configuration file in the test project, as per [xUnit docs](https://xunit.net/docs/configuration-files#diagnosticMessages).
  - Output via `IMessageSink` [is not displayed in JetBrain Rider test output](https://github.com/xunit/xunit/issues/565#issuecomment-926205098).