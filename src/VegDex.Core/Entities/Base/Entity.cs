namespace VegDex.Core.Entities.Base;

public abstract class Entity : EntityBase<int>
{
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    public int Id { get; set; }
}
