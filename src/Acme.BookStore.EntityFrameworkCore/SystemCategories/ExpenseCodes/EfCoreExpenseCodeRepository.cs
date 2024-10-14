using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.SystemCategories.ExpenseCodes;

public class EfCoreExpenseCodeRepository
    : EfCoreRepository<BookStoreDbContext, ExpenseCode, Guid>,
        IExpenseCodeRepository
{
    public EfCoreExpenseCodeRepository(
        IDbContextProvider<BookStoreDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<List<ExpenseCode>> GetListAsync(
        int skipCount = 0,
        int maxResultCount = int.MaxValue,
        string? sorting = null,
        string? filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    vat => vat.Code != null && filter != null && vat.Code.Contains(filter)
                )
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}
