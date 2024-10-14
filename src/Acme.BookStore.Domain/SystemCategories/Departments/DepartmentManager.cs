using Acme.BookStore.SystemCategories.KindOfFals;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.SystemCategories.Departments;

public class DepartmentManager : DomainService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentManager(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<Department> CreateAsync(
        string? code = null,
        string? description = null,
        string? note = null
    )
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));
        var existingEntity = await _departmentRepository.FirstOrDefaultAsync(c => c.Code == code);
        if (existingEntity != null)
        {
            throw new BusinessException("App:0001").WithData("data", code);
        }
        var department = new Department(
            GuidGenerator.Create(),
            code,
            description,
            note
        );

        return await _departmentRepository.InsertAsync(department);
    }

    public async Task<Department> UpdateAsync(
        Guid id,
        bool deactive,
        string? code = null,
        string? description = null,
        string? note = null,
        string? concurrencyStamp = null
    )
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));

        var department = await _departmentRepository.GetAsync(id);

        department.Deactive = deactive;
        department.Code = code;
        department.Description = description;
        department.Note = note;

        department.SetConcurrencyStampIfNotNull(concurrencyStamp);
        return await _departmentRepository.UpdateAsync(department);
    }
}