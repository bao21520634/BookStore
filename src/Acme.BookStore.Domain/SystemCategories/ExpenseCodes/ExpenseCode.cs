using System;

namespace Acme.BookStore.SystemCategories.ExpenseCodes;

public class ExpenseCode : SystemCategory
{

    public ExpenseCode()
    {

    }

    internal ExpenseCode(Guid id, string? code, string? description = null, string? note = null)
    {
        Id = id;
        Code = code;
        Description = description;
        Note = note;
    }
}
