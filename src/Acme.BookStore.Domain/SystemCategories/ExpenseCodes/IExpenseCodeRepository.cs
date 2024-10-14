using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.SystemCategories.ExpenseCodes;

public interface IExpenseCodeRepository : IRepository<ExpenseCode, Guid>
{
    Task<List<ExpenseCode>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string? filter = null
    );
}
