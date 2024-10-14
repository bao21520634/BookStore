using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.SystemCategories.Currencies;

public class EfCoreCurrencyRepository
    : EfCoreRepository<BookStoreDbContext, Currency, Guid>,
        ICurrencyRepository
{
    public EfCoreCurrencyRepository(
        IDbContextProvider<BookStoreDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<List<Currency>> GetListAsync(
        int skipCount = 0,
        int maxResultCount = int.MaxValue,
        string? sorting = null,
        string? filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    currency => currency.Code != null && filter != null && currency.Code.Contains(filter)
                )
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}
