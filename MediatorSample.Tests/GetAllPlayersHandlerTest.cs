using MediatorSample.Application.Handlers;
using MediatorSample.Application.Queries;
using MediatorSample.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorSample.Tests;

public class GetAllPlayersHandlerTest
{
    private readonly IMediator _mediator;

    public GetAllPlayersHandlerTest()
    {
        var services = new ServiceCollection();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(GetAllPlayersHandler).Assembly));
        var provider = services.BuildServiceProvider();

        _mediator = provider.GetRequiredService<IMediator>();
    }

    [Fact]
    public async Task Should_Return_All_Players()
    {
        // Arrange
        AddPlayerHandler._players.Add(new Player { Id = Guid.NewGuid(), Name = "Rodrigo", Position = "Goalkeeper" });
        AddPlayerHandler._players.Add(new Player { Id = Guid.NewGuid(), Name = "Test", Position = "Forward" });


        // Act
        var result = await _mediator.Send(new GetAllPlayersQuery());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(result, p => p.Name == "Rodrigo" && p.Position == "Goalkeeper");
        Assert.Contains(result, p => p.Name == "Test" && p.Position == "Forward");
    }
}
