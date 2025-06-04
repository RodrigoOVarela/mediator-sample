namespace MediatorSample.Domain.Entities;

public class Player
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Position { get; set; }
}
