using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.SystemCategories.Currencies;

public class CurrencyManager : DomainService
{
    private readonly ICurrencyRepository _currencyRepository;

    public CurrencyManager(ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }

    public async Task<Currency> CreateAsync(
        string? code,
        float? exchangeRate,
        string? description = null,
        string? note = null
    )
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));

        var existingCurrency = await _currencyRepository.FirstOrDefaultAsync(c => c.Code == code);
        if (existingCurrency != null)
        {
            throw new BusinessException(code).WithData("data", code);
        }

        var currency = new Currency(
            GuidGenerator.Create(),
            code,
            exchangeRate,
            description,
            note
        );

        return await _currencyRepository.InsertAsync(currency);
    }

    public async Task<Currency> UpdateAsync(
        Guid id,
        bool deactive,
        string? code,
        float? exchangeRate,
        string? description = null,
        string? note = null,
        string? concurrencyStamp = null
    )
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));

        var currency = await _currencyRepository.GetAsync(id);

        currency.Code = code;
        currency.ExchangeRate = exchangeRate;
        currency.Deactive = deactive;
        currency.Description = description;
        currency.Note = note;

        currency.SetConcurrencyStampIfNotNull(concurrencyStamp);
        return await _currencyRepository.UpdateAsync(currency);
    }
}
