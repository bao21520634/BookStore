using System;

namespace Acme.BookStore.SystemCategories.KindOfFals.Dtos;

public class UpdateKindOfFalDto
{
    public string? Code { get; set; }
    public string? Description { get; set; }
    public string? Note { get; set; }
    public bool Deactive { get; set; }
    public string ConcurrencyStamp { get; set; } = null!;
}
