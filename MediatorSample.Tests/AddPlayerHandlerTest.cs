using MediatorSample.Application.Commands;
using MediatorSample.Application.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace MediatorSample.Tests;

public class AddPlayerHandlerTest
{
    private readonly IMediator _mediator;

    public AddPlayerHandlerTest()
    {
        var services = new ServiceCollection();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddPlayerHandler).Assembly));
        var provider = services.BuildServiceProvider();
        _mediator = provider.GetRequiredService<IMediator>();
    }

    [Fact]
    public async Task Should_Add_Player_Successfully()
    {
        //Arrange
        var command = new AddPlayerCommand("Rodrigo", "Goalkeeper");

        //Action
        var playerId = await _mediator.Send(command);

        //Assert
        Assert.NotEqual(Guid.Empty, playerId);

        var addedPlayer = AddPlayerHandler.GetPlayers().FirstOrDefault(p => p.Id == playerId);
        Assert.NotNull(addedPlayer);
        Assert.Equal("Rodrigo", addedPlayer.Name);
        Assert.Equal("Goalkeeper", addedPlayer.Position);
    }
}
