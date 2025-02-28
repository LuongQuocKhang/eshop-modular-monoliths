namespace eshop.Shared.DDD;

public class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly List<IDomainEvent> _domainEvents = [];
    
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    
    public IDomainEvent[] ClearDomainEvents()
    {
        var dequeuedDomainEvents = _domainEvents.ToArray();

        Array.Clear(dequeuedDomainEvents);
        
        return dequeuedDomainEvents;
    }
}