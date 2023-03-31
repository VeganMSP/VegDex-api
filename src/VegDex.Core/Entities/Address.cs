using VegDex.Core.Entities.Base;

namespace VegDex.Core.Entities;

public class Address : Entity
{
    public Address() { }
    public City City { get; set; }
    public string? Name { get; set; }
    public string? State { get; set; }
    public string? Street1 { get; set; }
    public string? Street2 { get; set; }
    public string? ZipCode { get; set; }
    public static Address Create(
        int addressId,
        City city,
        string? name = null,
        string? street1 = null,
        string? street2 = null,
        string? state = null,
        string? zipCode = null)
    {
        var address = new Address
        {
            Id = addressId,
            Name = name,
            City = city,
            Street1 = street1,
            Street2 = street2,
            State = state,
            ZipCode = zipCode
        };
        return address;
    }
}
