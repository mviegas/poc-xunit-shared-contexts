using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace XUnit.SharedContexts.Tests.Divergic;

/// <summary>
/// Uses <see href="https://github.com/roryprimrose/Divergic.Logging.Xunit" />
/// </summary>
public class TestOutputFixture : WebApplicationFactory<Program>
{
    public ITestOutputHelper Output { get; set; }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureLogging(AddXUnitLogging);
    }
    
    protected virtual void AddXUnitLogging(ILoggingBuilder logging)
    {
        logging.ClearProviders();
        logging.AddXunit(Output);
    }
}

[CollectionDefinition(nameof(TestOutputFixture))]
public class TestOutputFixtureCollection : ICollectionFixture<TestOutputFixture>
{
}

[Collection(nameof(TestOutputFixture))]
public class TestOutputFixtureClass1
{
    private readonly TestOutputFixture _fixture;
    private const string Url = "/";

    public TestOutputFixtureClass1(TestOutputFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _fixture.Output = output;
    }

    [Fact]
    public async Task Test1()
    {
        using var client = _fixture.CreateClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, Url);
        using var response = await client.SendAsync(request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Test2()
    {
        using var client = _fixture.CreateClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, Url);
        using var response = await client.SendAsync(request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}

[Collection(nameof(TestOutputFixture))]
public class TestOutputFixtureClass2
{
    private readonly TestOutputFixture _fixture;
    private const string Url = "/";

    public TestOutputFixtureClass2(TestOutputFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _fixture.Output = output;
    }

    [Fact]
    public async Task Test1()
    {
        using var client = _fixture.CreateClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, Url);
        using var response = await client.SendAsync(request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Test2()
    {
        using var client = _fixture.CreateClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, Url);
        using var response = await client.SendAsync(request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}