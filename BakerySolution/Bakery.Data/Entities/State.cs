using Bakery.Data.Interfaces;

internal class State : IState
{
    public int Id { get; private set; }
    public string Description { get; set; }
    public DateTime UpdatedAt { get; private set; }
    public List<IEvent> Events { get; private set; }
    public int CatalogId { get; set; }

    public State(string description, int catalogId)
    {
        int timePart = DateTime.UtcNow.Ticks.GetHashCode();
        int randomPart = new Random().Next(1000, 9999);
        
        Id = (timePart ^ randomPart);
        Description = description;
        UpdatedAt = DateTime.UtcNow;
        CatalogId = catalogId;
        Events = new List<IEvent>();
    }
}
