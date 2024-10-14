using System;

namespace Acme.BookStore.SystemCategories.Departments.Dtos;

public class CreateDepartmentDto
{
    public string? Code { get; set; } = null!;
    public string? Description { get; set; }
    public string? Note { get; set; }
}
