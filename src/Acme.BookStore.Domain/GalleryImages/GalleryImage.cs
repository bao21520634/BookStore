using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.GalleryImages;

public class GalleryImage : CreationAuditedAggregateRoot<Guid>
{
    public string? Description { get; set; }
    public Guid CoverImageMediaId { get; set; }

    protected GalleryImage()
    {
    }

    public GalleryImage(Guid id, Guid coverImageMediaId, [NotNull] string description) : base(id)
    {
        CoverImageMediaId = coverImageMediaId;
        Description = Check.NotNullOrWhiteSpace(description, nameof(description), maxLength: BookStoreConsts.MaxDescriptionLength);
    }
}
