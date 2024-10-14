using System;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Acme.BookStore.SystemCategories.Departments.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.SystemCategories.Departments;

public class DepartmentAppService : CrudAppService<
    Department,
    DepartmentDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateDepartmentDto,
    UpdateDepartmentDto>,
    IDepartmentAppService
{
    protected IDepartmentRepository _departmentRepository;
    protected DepartmentManager _departmentManager;

    public DepartmentAppService(
              IDepartmentRepository departmentRepository, DepartmentManager departmentManager)
              : base(departmentRepository)
    {
        GetPolicyName = BookStorePermissions.SystemCategories.Default;
        GetListPolicyName = BookStorePermissions.SystemCategories.Default;
        CreatePolicyName = BookStorePermissions.SystemCategories.Create;
        UpdatePolicyName = BookStorePermissions.SystemCategories.Update;
        DeletePolicyName = BookStorePermissions.SystemCategories.Delete;

        _departmentRepository = departmentRepository;
        _departmentManager = departmentManager;
    }

    [Authorize(BookStorePermissions.SystemCategories.Create)]
    public override async Task<DepartmentDto> CreateAsync(CreateDepartmentDto input)
    {
        var department = await _departmentManager.CreateAsync(
            input.Code,
            input.Description,
            input.Note
        );

        return ObjectMapper.Map<Department, DepartmentDto>(department);
    }

    [Authorize(BookStorePermissions.SystemCategories.Update)]
    public override async Task<DepartmentDto> UpdateAsync(Guid id, UpdateDepartmentDto input)
    {
        var department = await _departmentManager.UpdateAsync(
            id,
            input.Deactive,
            input.Code,
            input.Description,
            input.Note,
            input.ConcurrencyStamp
        );

        return ObjectMapper.Map<Department, DepartmentDto>(department);
    }
}
