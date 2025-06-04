using MediatorSample.Application.Commands;
using MediatorSample.Domain.Entities;
using MediatR;

namespace MediatorSample.Application.Handlers;

public class AddPlayerHandler : IRequestHandler<AddPlayerCommand, Guid>
{
    // TODO: Propriedade pública apenas para facilitar testes. 
    // Futuramente, será substituída por acesso via repositório.
    public static readonly List<Player> _players = new();

    public Task<Guid> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
    {
        var newPlayer = new Player
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Position = request.Position
        };

        _players.Add(newPlayer);

        Console.WriteLine($"Jogador adicionado: {newPlayer.Name} - {newPlayer.Position}");

        return Task.FromResult(newPlayer.Id);
    }

    public static IReadOnlyList<Player> GetPlayers() => _players.AsReadOnly();

    public static void ClearPlayers() => _players.Clear();
}
