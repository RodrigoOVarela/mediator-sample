using MediatorSample.Application.DTOs;
using MediatR;

namespace MediatorSample.Application.Queries;

public record GetAllPlayersQuery() : IRequest<List<PlayerDto>>;
