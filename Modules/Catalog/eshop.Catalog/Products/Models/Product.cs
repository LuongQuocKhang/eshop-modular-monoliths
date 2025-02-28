using eshop.Catalog.Products.Events;

namespace eshop.Catalog.Products.Models;

public class Product : Aggregate<Guid>
{
    public string Name { get; private set; } = string.Empty;

    public List<string> Category { get; private set; } = [];

    public string Description { get; private set; } = string.Empty;

    public string ImageFile { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public static Product Create(Guid id, string name, List<string> category,
        string description, string imageFile, decimal price)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(Name));
        ArgumentOutOfRangeException.ThrowIfNegative(price, nameof(price));

        var product = new Product()
        {
            Id = id,
            Category = category,
            Price = price,
            Description = description,
            Name = name,
            ImageFile = imageFile
        };
        
        product.AddDomainEvent(new ProductCreatedEvent(product));
        
        return product;
    }

    public void Update(string name, List<string> category,
        string description, string imageFile, decimal price)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(Name));
        ArgumentOutOfRangeException.ThrowIfNegative(price, nameof(price));
        
        Name = name;
        Description = description;
        ImageFile = imageFile;
        Price = price;

        if (price == Price) return;
        
        Price = price;
        AddDomainEvent(new ProductPriceChangedEvent(this));
    }
}