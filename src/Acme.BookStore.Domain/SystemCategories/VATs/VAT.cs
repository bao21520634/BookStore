using System;

namespace Acme.BookStore.SystemCategories.VATs;

public class VAT : SystemCategory
{
    public float? Value { get; set; }

    public VAT()
    {

    }

    internal VAT(Guid guid, string? code, float value, string? description, string? note = null)
    {
        Id = guid;
        Code = code;
        Value = value;
        Description = description;
        Note = note;
    }
}
