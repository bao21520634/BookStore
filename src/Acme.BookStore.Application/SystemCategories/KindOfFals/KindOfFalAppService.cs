using System;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Acme.BookStore.SystemCategories.KindOfFals.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.SystemCategories.KindOfFals;

public class KindOfFalAppService : CrudAppService<
    KindOfFal,
    KindOfFalDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateKindOfFalDto,
    UpdateKindOfFalDto>,
    IKindOfFalAppService
{
    protected IKindOfFalRepository _kindOfFalRepository;
    protected KindOfFalManager _kindOfFalManager;

    public KindOfFalAppService(
              IKindOfFalRepository kindOfFalRepository, KindOfFalManager kindOfFalManager)
              : base(kindOfFalRepository)
    {
        GetPolicyName = BookStorePermissions.SystemCategories.Default;
        GetListPolicyName = BookStorePermissions.SystemCategories.Default;

        CreatePolicyName = BookStorePermissions.SystemCategories.Create;
        UpdatePolicyName = BookStorePermissions.SystemCategories.Update;
        DeletePolicyName = BookStorePermissions.SystemCategories.Delete;

        _kindOfFalRepository = kindOfFalRepository;
        _kindOfFalManager = kindOfFalManager;
    }

    [Authorize(BookStorePermissions.SystemCategories.Create)]
    public override async Task<KindOfFalDto> CreateAsync(CreateKindOfFalDto input)
    {
        var kindOfFal = await _kindOfFalManager.CreateAsync(
            input.Code,
            input.Description,
            input.Note
        );

        return ObjectMapper.Map<KindOfFal, KindOfFalDto>(kindOfFal);
    }

    [Authorize(BookStorePermissions.SystemCategories.Update)]
    public override async Task<KindOfFalDto> UpdateAsync(Guid id, UpdateKindOfFalDto input)
    {

        var kindOfFal = await _kindOfFalManager.UpdateAsync(
            id,
            input.Deactive,
            input.Code,
            input.Description,
            input.Note,
            input.ConcurrencyStamp
        );

        return ObjectMapper.Map<KindOfFal, KindOfFalDto>(kindOfFal);
    }
}
