using MediatR;
using MediatorSample.Application.Handlers;
using MediatorSample.Application.Dtos;

namespace MediatorSample.Application.Queries;

public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersQuery, List<PlayerDto>>
{
    public Task<List<PlayerDto>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
    {
        var players = AddPlayerHandler.GetPlayers();

        var playersDto = players.Select(p => new PlayerDto
        {
            Id = p.Id,
            Name = p.Name,
            Position = p.Position
        }).ToList();

        return Task.FromResult(playersDto);
    }
}
