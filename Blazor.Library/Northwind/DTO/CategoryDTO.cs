using System.ComponentModel.DataAnnotations;

namespace Blazor.Library.Northwind.DTO;

public class CategoryDTO
{
    public int Id { get; set; }

    [MaxLength(15)]
    public required string Name { get; set; }


    public required string Description { get; set; }

    public int NumberOfProducts { get; set; }

    public IEnumerable<ProductDTO> Products { get; set; } = Enumerable.Empty<ProductDTO>();
}
