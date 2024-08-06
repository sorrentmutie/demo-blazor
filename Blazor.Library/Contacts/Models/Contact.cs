using System.ComponentModel.DataAnnotations;

namespace Blazor.Library.Contacts.Models;

public class Contact
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Il nome è obbligatorio")]
    public string Name { get; set; } = default!;
    [Required(ErrorMessage = "La città è obbligatoria")]
    public string City { get; set; } = default!;
}
