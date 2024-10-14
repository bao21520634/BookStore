using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.SystemCategories;

public class SystemCategory : AuditedAggregateRoot<Guid>, IHasConcurrencyStamp
{
    public string? Description { get; set; }
    public string? Note { get; set; }
    public string? Code { get; set; }
    public bool Deactive { get; set; }

    protected SystemCategory()
    {

    }

    public SystemCategory(Guid id, string? code = null, string? description = null, string? note = null)
    {

        Id = id;
        Code = code;
        Description = description;
        Note = note;
    }
}
