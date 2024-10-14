using Acme.BookStore.SystemCategories.KindOfFals;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.SystemCategories.KindOfFals;

public class KindOfFalManager : DomainService
{
    private readonly IKindOfFalRepository _kindOfFalRepository;

    public KindOfFalManager(IKindOfFalRepository kindOfFalRepository)
    {
        _kindOfFalRepository = kindOfFalRepository;
    }

    public async Task<KindOfFal> CreateAsync(
        string? code = null,
        string? description = null,
        string? note = null
    )
    {
        var existingEntity = await _kindOfFalRepository.FirstOrDefaultAsync(c => c.Code == code);
        if (existingEntity != null)
        {
            ArgumentNullException.ThrowIfNull(code);
            throw new BusinessException("App:0001").WithData("data", code);
        }
        var kindOfFal = new KindOfFal(
         GuidGenerator.Create(),
         code, description, note
         );

        return await _kindOfFalRepository.InsertAsync(kindOfFal);
    }

    public async Task<KindOfFal> UpdateAsync(
        Guid id,
        bool deactive,
        string? code = null,
        string? description = null,
        string? note = null,
        string? concurrencyStamp = null
    )
    {

        var kindOfFal = await _kindOfFalRepository.GetAsync(id);

        kindOfFal.Deactive = deactive;
        kindOfFal.Code = code;
        kindOfFal.Description = description;
        kindOfFal.Note = note;

        kindOfFal.SetConcurrencyStampIfNotNull(concurrencyStamp);
        return await _kindOfFalRepository.UpdateAsync(kindOfFal);
    }

}