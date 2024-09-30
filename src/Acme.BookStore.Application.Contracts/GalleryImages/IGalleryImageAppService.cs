using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.BookStore.GalleryImages.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.GalleryImages;

public interface IGalleryImageAppService : ICrudAppService<
        GalleryImageDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateGalleryImageDto>
{
    Task<List<GalleryImageWithDetailsDto>> GetDetailedListAsync();
}
