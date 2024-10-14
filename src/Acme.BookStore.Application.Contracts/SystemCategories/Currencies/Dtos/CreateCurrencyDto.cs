using System;

namespace Acme.BookStore.SystemCategories.Currencies.Dtos;

public class CreateCurrencyDto
{
    public string? Code { get; set; } = null!;
    public string? Description { get; set; }
    public float ExchangeRate { get; set; }
    public string? Note { get; set; }
}
