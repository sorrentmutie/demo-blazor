namespace Blazor.Library.Products.Models;

public class Product
{
    public required string Name { get; set; }
    public decimal Price { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImagePath { get; set; } = default!;
    public int Id { get; init; }
}
