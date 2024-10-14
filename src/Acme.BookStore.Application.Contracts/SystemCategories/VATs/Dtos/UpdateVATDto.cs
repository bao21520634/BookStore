using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.SystemCategories.VATs.Dtos;

public class UpdateVATDto
{
    public bool Deactive { get; set; }
    public string? Code { get; set; } = null!;
    public float Value { get; set; }
    public string? Description { get; set; }
    public string? Note { get; set; }

    public string ConcurrencyStamp { get; set; } = null!;
}