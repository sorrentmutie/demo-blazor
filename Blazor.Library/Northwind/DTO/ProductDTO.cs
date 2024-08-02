namespace Blazor.Library.Northwind.DTO;

public class ProductDTO
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int IdFornitore { get; set; }

    public string NomeFornitore { get; set; } = string.Empty;
}
