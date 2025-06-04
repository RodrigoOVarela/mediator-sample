using MediatR;

namespace MediatorSample.Application.Commands;

public record AddPlayerCommand(string Name, string Position) : IRequest<Guid>;
