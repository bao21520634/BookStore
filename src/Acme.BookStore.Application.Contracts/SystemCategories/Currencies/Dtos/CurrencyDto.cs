using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.SystemCategories.Currencies.Dtos;

public class CurrencyDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
{
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public float? ExchangeRate { get; set; }
    public bool Deactive { get; set; }
    public string? Note { get; set; }
    public string ConcurrencyStamp { get; set; } = null!;
}
