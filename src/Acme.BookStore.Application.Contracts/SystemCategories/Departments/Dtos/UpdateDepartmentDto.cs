using System;

namespace Acme.BookStore.SystemCategories.Departments.Dtos;

public class UpdateDepartmentDto
{
    public bool Deactive { get; set; }
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public string? Note { get; set; }
    public string ConcurrencyStamp { get; set; } = null!;
}
