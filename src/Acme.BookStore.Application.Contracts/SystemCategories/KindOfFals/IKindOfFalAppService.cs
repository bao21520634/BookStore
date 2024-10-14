using System;
using Acme.BookStore.SystemCategories.KindOfFals.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.SystemCategories.KindOfFals;

public interface IKindOfFalAppService : ICrudAppService<
        KindOfFalDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateKindOfFalDto,
        UpdateKindOfFalDto>
{

}
