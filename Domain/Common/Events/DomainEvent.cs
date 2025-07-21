namespace Domain.Common.Events;

public class DomainEvent : IDomainEvent
{
    public DateTime OccurredOn { get; set; } = DateTime.UtcNow;
}