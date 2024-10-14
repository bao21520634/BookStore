using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.SystemCategories.KindOfFals;

public class EfCoreKindOfFalRepository
    : EfCoreRepository<BookStoreDbContext, KindOfFal, Guid>,
        IKindOfFalRepository
{
    public EfCoreKindOfFalRepository(
        IDbContextProvider<BookStoreDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<List<KindOfFal>> GetListAsync(
        int skipCount = 0,
        int maxResultCount = int.MaxValue,
        string? sorting = null,
        string? filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    kindOfFal => kindOfFal.Code != null && filter != null && kindOfFal.Code.Contains(filter)
                )
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}
