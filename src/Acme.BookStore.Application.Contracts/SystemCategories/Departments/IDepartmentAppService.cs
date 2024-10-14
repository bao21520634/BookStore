using System;
using Acme.BookStore.SystemCategories.Departments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.SystemCategories.Departments;

public interface IDepartmentAppService : ICrudAppService<
        DepartmentDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateDepartmentDto,
        UpdateDepartmentDto>
{

}
