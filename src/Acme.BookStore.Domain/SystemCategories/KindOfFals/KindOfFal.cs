using System;

namespace Acme.BookStore.SystemCategories.KindOfFals;

public class KindOfFal : SystemCategory
{
    public KindOfFal()
    {

    }

    internal KindOfFal(Guid id, string? code = null, string? description = null, string? note = null)
    {

        Id = id;
        Code = code;
        Description = description;
        Note = note;
    }
}
