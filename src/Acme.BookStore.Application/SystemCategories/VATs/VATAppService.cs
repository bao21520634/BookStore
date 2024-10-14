using System;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Acme.BookStore.SystemCategories.VATs.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.SystemCategories.VATs;

[RemoteService(isEnabled: false)]
[Authorize(BookStorePermissions.SystemCategories.Default)]
public class VATAppService : CrudAppService<
    VAT,
    VATDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateVATDto,
    UpdateVATDto>,
    IVATAppService
{
    protected IVATRepository _vatRepository;
    protected VATManager _vatManager;

    public VATAppService(
              IVATRepository vatRepository, VATManager vatManager)
              : base(vatRepository)
    {
        GetPolicyName = BookStorePermissions.SystemCategories.Default;
        GetListPolicyName = BookStorePermissions.SystemCategories.Default;
        CreatePolicyName = BookStorePermissions.SystemCategories.Create;
        UpdatePolicyName = BookStorePermissions.SystemCategories.Update;
        DeletePolicyName = BookStorePermissions.SystemCategories.Delete;

        _vatRepository = vatRepository;
        _vatManager = vatManager;
    }

    [Authorize(BookStorePermissions.SystemCategories.Create)]
    public override async Task<VATDto> CreateAsync(CreateVATDto input)
    {
        var vat = await _vatManager.CreateAsync(
            input.Code,
            input.Value,
            input.Description,
            input.Note
        );

        return ObjectMapper.Map<VAT, VATDto>(vat);
    }

    [Authorize(BookStorePermissions.SystemCategories.Update)]
    public override async Task<VATDto> UpdateAsync(Guid id, UpdateVATDto input)
    {

        var vat = await _vatManager.UpdateAsync(
            id,
            input.Deactive,
            input.Code,
            input.Value,
            input.Description,
            input.Note,
            input.ConcurrencyStamp
        );

        return ObjectMapper.Map<VAT, VATDto>(vat);
    }
}