using System;

namespace Acme.BookStore.SystemCategories.Currencies;

public class Currency : SystemCategory
{
    public Currency()
    {

    }

    internal Currency(Guid guid, string? code, float? exchangeRate, string? description, string? note = null)
    {
        Id = guid;
        Code = code;
        ExchangeRate = exchangeRate;
        Description = description;
        Note = note;
    }

    public float? ExchangeRate { get; set; }
}
