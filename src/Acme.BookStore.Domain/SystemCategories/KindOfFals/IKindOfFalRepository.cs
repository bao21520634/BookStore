using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.SystemCategories.KindOfFals;

public interface IKindOfFalRepository : IRepository<KindOfFal, Guid>
{
    Task<List<KindOfFal>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string? filter = null
    );
}
