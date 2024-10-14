using System;

namespace Acme.BookStore.SystemCategories.ExpenseCodes.Dtos;

public class CreateExpenseCodeDto
{
    public string? Code { get; set; } = null!;
    public string? Description { get; set; }
    public string? Note { get; set; }
}
