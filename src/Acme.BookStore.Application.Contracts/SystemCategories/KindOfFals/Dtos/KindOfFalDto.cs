using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.SystemCategories.KindOfFals.Dtos;

public class KindOfFalDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
{
    public string? Code { get; set; }
    public string? Description { get; set; }
    public string? Note { get; set; }
    public bool Deactive { get; set; }
    public string ConcurrencyStamp { get; set; } = null!;
}
