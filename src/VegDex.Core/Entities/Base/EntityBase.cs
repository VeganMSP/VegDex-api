namespace VegDex.Core.Entities.Base;

public abstract class EntityBase<TId> : IEntityBase<TId>
{
    private int? _requestedHashCode;
    public virtual TId Id { get; protected set; }
    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is EntityBase<TId>)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (GetType() != obj.GetType()) return false;
        var item = (EntityBase<TId>)obj;
        if (item.IsTransient() || IsTransient()) return false;
        return item == this;
    }
    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = Id.GetHashCode() ^ 31;
            return _requestedHashCode.Value;
        }
        return base.GetHashCode();
    }
    public bool IsTransient() => Id.Equals(default(TId));
    public static bool operator ==(EntityBase<TId>? left, EntityBase<TId>? right) =>
        left?.Equals(right) ?? Equals(right, null);
    public static bool operator !=(EntityBase<TId> left, EntityBase<TId>? right) => !(left == right);
}
