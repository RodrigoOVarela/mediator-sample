using MediatorSample.Application.Dtos;
using MediatR;

namespace MediatorSample.Application.Queries;

public record GetAllPlayersQuery() : IRequest<List<PlayerDto>>;
