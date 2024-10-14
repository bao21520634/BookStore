using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.SystemCategories.Currencies;

public interface ICurrencyRepository : IRepository<Currency, Guid>
{
    Task<List<Currency>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string? filter = null
    );
}
