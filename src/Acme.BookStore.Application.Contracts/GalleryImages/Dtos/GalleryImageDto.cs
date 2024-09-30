using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.GalleryImages.Dtos;

public class GalleryImageDto : CreationAuditedEntityDto<Guid>
{
    public string? Description { get; set; }
    public Guid CoverImageMediaId { get; set; }
}
