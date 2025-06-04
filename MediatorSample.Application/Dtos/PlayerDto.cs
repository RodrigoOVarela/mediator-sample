namespace MediatorSample.Application.Dtos;

public class PlayerDto
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Position { get; init; }
}
