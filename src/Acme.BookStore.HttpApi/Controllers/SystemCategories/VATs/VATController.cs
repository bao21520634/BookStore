using System;
using System.Threading.Tasks;
using Acme.BookStore.SystemCategories.VATs;
using Acme.BookStore.SystemCategories.VATs.Dtos;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Controllers.SystemCategories.VATs;

[RemoteService(isEnabled: true)]
[ControllerName("VATs")]
[Route("api/vats")]
public class VATController : BookStoreController, IVATAppService
{
    protected readonly IVATAppService _vatAppService;

    public VATController(IVATAppService vatAppService)
    {
        _vatAppService = vatAppService;
    }

    [HttpPost]
    public virtual Task<VATDto> CreateAsync(CreateVATDto input)
    {
        return _vatAppService.CreateAsync(input);
    }

    [HttpDelete("{id}")]
    public virtual Task DeleteAsync(Guid id)
    {
        return _vatAppService.DeleteAsync(id);
    }

    [HttpGet("{id}")]
    public virtual Task<VATDto> GetAsync(Guid id)
    {
        return _vatAppService.GetAsync(id);
    }

    [HttpGet]
    public virtual Task<PagedResultDto<VATDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return _vatAppService.GetListAsync(input);
    }

    [HttpPut("{id}")]
    public virtual Task<VATDto> UpdateAsync(Guid id, UpdateVATDto input)
    {
        return _vatAppService.UpdateAsync(id, input);
    }
}