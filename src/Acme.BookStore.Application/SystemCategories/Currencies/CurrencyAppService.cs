using System;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Acme.BookStore.SystemCategories.Currencies.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.SystemCategories.Currencies;

public class CurrencyAppService : CrudAppService<
    Currency,
    CurrencyDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateCurrencyDto,
    UpdateCurrencyDto>,
    ICurrencyAppService
{
    protected ICurrencyRepository _currencyRepository;
    protected CurrencyManager _currencyManager;

    public CurrencyAppService(
              ICurrencyRepository currencyRepository, CurrencyManager currencyManager)
              : base(currencyRepository)
    {
        GetPolicyName = BookStorePermissions.SystemCategories.Default;
        GetListPolicyName = BookStorePermissions.SystemCategories.Default;
        CreatePolicyName = BookStorePermissions.SystemCategories.Create;
        UpdatePolicyName = BookStorePermissions.SystemCategories.Update;
        DeletePolicyName = BookStorePermissions.SystemCategories.Delete;

        _currencyRepository = currencyRepository;
        _currencyManager = currencyManager;
    }

    [Authorize(BookStorePermissions.SystemCategories.Create)]
    public override async Task<CurrencyDto> CreateAsync(CreateCurrencyDto input)
    {
        var currency = await _currencyManager.CreateAsync(
            input.Code,
            input.ExchangeRate,
            input.Description,
            input.Note
        );

        return ObjectMapper.Map<Currency, CurrencyDto>(currency);
    }

    [Authorize(BookStorePermissions.SystemCategories.Update)]
    public override async Task<CurrencyDto> UpdateAsync(Guid id, UpdateCurrencyDto input)
    {
        var currency = await _currencyManager.UpdateAsync(
            id,
            input.Deactive,
            input.Code,
            input.ExchangeRate,
            input.Description,
            input.Note,
            input.ConcurrencyStamp
        );

        return ObjectMapper.Map<Currency, CurrencyDto>(currency);
    }
}
