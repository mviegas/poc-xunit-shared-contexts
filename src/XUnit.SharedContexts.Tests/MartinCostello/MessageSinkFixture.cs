using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XUnit.SharedContexts.Tests.MartinCostello;

/// <summary>
/// Uses <see href="https://github.com/martincostello/xunit-logging" />
/// </summary>
public class MessageSinkFixture : WebApplicationFactory<Program>
{
    private readonly IMessageSink _messageSink;

    public MessageSinkFixture(IMessageSink messageSink)
    {
        _messageSink = messageSink;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureLogging(AddXUnitLogging);
    }
    
    protected virtual void AddXUnitLogging(ILoggingBuilder logging)
    {
        logging.ClearProviders();
        logging.AddXUnit(_messageSink);
    }
}

[CollectionDefinition(nameof(MessageSinkFixture))]
public class MessageSinkFixtureCollection : ICollectionFixture<MessageSinkFixture>
{
}

[Collection(nameof(MessageSinkFixture))]
public class MessageSinkFixtureClass1
{
    private readonly MessageSinkFixture _fixture;
    private const string Url = "/";

    public MessageSinkFixtureClass1(MessageSinkFixture fixture)
    {
        _fixture = fixture;
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

[Collection(nameof(MessageSinkFixture))]
public class MessageSinkFixtureClass2
{
    private readonly MessageSinkFixture _fixture;
    private const string Url = "/";

    public MessageSinkFixtureClass2(MessageSinkFixture fixture)
    {
        _fixture = fixture;
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