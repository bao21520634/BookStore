using System;
using Acme.BookStore.SystemCategories.Currencies.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.SystemCategories.Currencies;

public interface ICurrencyAppService : ICrudAppService<
        CurrencyDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateCurrencyDto,
        UpdateCurrencyDto>
{

}
