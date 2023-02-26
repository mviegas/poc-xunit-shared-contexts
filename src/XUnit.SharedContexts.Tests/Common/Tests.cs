using Xunit.Abstractions;

namespace XUnit.SharedContexts.Tests.Common;

public class Tests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Tests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public void Test1()
    {
        _testOutputHelper.WriteLine("Test1");
    }
    
    [Fact]
    public void Test2()
    {
        _testOutputHelper.WriteLine("Test2");
    }
}