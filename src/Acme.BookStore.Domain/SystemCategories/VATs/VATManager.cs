using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.SystemCategories.VATs;

public class VATManager : DomainService
{
    private readonly IVATRepository _vatRepository;

    public VATManager(IVATRepository vatRepository)
    {
        _vatRepository = vatRepository;
    }

    public async Task<VAT> CreateAsync(
        string? code,
        float value,
        string? description = null,
        string? note = null
    )
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));

        var existingVAT = await _vatRepository.FirstOrDefaultAsync(c => c.Code == code);
        if (existingVAT != null)
        {
            throw new BusinessException(code).WithData("data", code);
        }

        var vat = new VAT(
            GuidGenerator.Create(),
            code,
            value,
            description,
            note
        );

        return await _vatRepository.InsertAsync(vat);
    }

    public async Task<VAT> UpdateAsync(
           Guid id,
           bool deactive,
           string? code,
           float value,
           string? description = null,
           string? note = null,
           string? concurrencyStamp = null
       )
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));

        var vat = await _vatRepository.GetAsync(id);

        vat.Deactive = deactive;
        vat.Code = code;
        vat.Value = value;
        vat.Description = description;
        vat.Note = note;

        vat.SetConcurrencyStampIfNotNull(concurrencyStamp);
        return await _vatRepository.UpdateAsync(vat);
    }
}
