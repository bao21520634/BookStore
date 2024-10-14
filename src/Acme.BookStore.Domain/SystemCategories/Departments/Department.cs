using System;

namespace Acme.BookStore.SystemCategories.Departments;

public class Department : SystemCategory
{
    public Department()
    {

    }

    internal Department(Guid id, string? code = null, string? description = null, string? note = null)
    {
        Id = id;
        Code = code;
        Description = description;
        Note = note;
    }
}
