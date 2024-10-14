using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.SystemCategories.Departments;

public class EfCoreDepartmentRepository
    : EfCoreRepository<BookStoreDbContext, Department, Guid>,
        IDepartmentRepository
{
    public EfCoreDepartmentRepository(
        IDbContextProvider<BookStoreDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<List<Department>> GetListAsync(
        int skipCount = 0,
        int maxResultCount = int.MaxValue,
        string? sorting = null,
        string? filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    department => department.Code != null && filter != null && department.Code.Contains(filter)
                )
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}
