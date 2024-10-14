using System;
using Acme.BookStore.SystemCategories.VATs.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.SystemCategories.VATs;

public interface IVATAppService : ICrudAppService<
        VATDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateVATDto,
        UpdateVATDto>
{

}
