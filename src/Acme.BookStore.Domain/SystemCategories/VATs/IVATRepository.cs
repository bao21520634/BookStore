using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.SystemCategories.VATs;

public interface IVATRepository : IRepository<VAT, Guid>
{
    Task<List<VAT>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string? filter = null
    );
}
