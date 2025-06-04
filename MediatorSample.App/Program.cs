using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MediatorSample.Application.Commands;
using MediatorSample.Application.Queries;
using MediatorSample.Application.Handlers;

var services = new ServiceCollection();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddPlayerHandler).Assembly));

var provider = services.BuildServiceProvider();
var mediator = provider.GetRequiredService<IMediator>();

await mediator.Send(new AddPlayerCommand("Jogador 01", "Atacante"));
await mediator.Send(new AddPlayerCommand("Jogador 02", "Goleiro"));
await mediator.Send(new AddPlayerCommand("Jogador 03", "Zagueiro"));

var players = await mediator.Send(new GetAllPlayersQuery());

Console.WriteLine("\nTime de Futebol:");
Console.WriteLine("Jogadores:");
foreach (var player in players)
    Console.WriteLine($"- {player.Name} ({player.Position})");
