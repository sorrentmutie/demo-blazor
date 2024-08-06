using System.ComponentModel.DataAnnotations;

namespace Blazor.Library.Northwind.DTO;

public class CategoryDTO
{
    public int Id { get; set; }

    [MaxLength(15, ErrorMessage = "La lunghezza massima è di {1} caratteri")]
    [Required(ErrorMessage = "Il nome è obbligatorio")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "La descrizione è obbligatoria")]
    public required string Description { get; set; }

    public int NumberOfProducts { get; set; }

    public IEnumerable<ProductDTO> Products { get; set; } = Enumerable.Empty<ProductDTO>();
}
