using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace Acme.BookStore.GalleryImages.Dtos;

public class CreateUpdateGalleryImageDto
{
    [NotNull]
    [StringLength(GalleryImageConsts.MaxDescriptionLength)]
    public string? Description { get; set; }

    public Guid CoverImageMediaId { get; set; }
}
