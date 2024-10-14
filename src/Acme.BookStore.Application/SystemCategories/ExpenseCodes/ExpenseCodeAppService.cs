using System;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Acme.BookStore.SystemCategories.ExpenseCodes.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.SystemCategories.ExpenseCodes;

public class ExpenseCodeAppService : CrudAppService<
    ExpenseCode,
    ExpenseCodeDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateExpenseCodeDto,
    UpdateExpenseCodeDto>,
    IExpenseCodeAppService
{
    protected IExpenseCodeRepository _expenseCodeRepository;
    protected ExpenseCodeManager _expenseCodeManager;

    public ExpenseCodeAppService(
              IExpenseCodeRepository expenseCodeRepository, ExpenseCodeManager expenseCodeManager)
              : base(expenseCodeRepository)
    {
        GetPolicyName = BookStorePermissions.SystemCategories.Default;
        GetListPolicyName = BookStorePermissions.SystemCategories.Default;
        CreatePolicyName = BookStorePermissions.SystemCategories.Create;
        UpdatePolicyName = BookStorePermissions.SystemCategories.Update;
        DeletePolicyName = BookStorePermissions.SystemCategories.Delete;

        _expenseCodeRepository = expenseCodeRepository;
        _expenseCodeManager = expenseCodeManager;
    }

    [Authorize(BookStorePermissions.SystemCategories.Create)]
    public override async Task<ExpenseCodeDto> CreateAsync(CreateExpenseCodeDto input)
    {
        var expenseCode = await _expenseCodeManager.CreateAsync(
            input.Code,
            input.Description,
            input.Note
        );

        return ObjectMapper.Map<ExpenseCode, ExpenseCodeDto>(expenseCode);
    }

    [Authorize(BookStorePermissions.SystemCategories.Update)]
    public override async Task<ExpenseCodeDto> UpdateAsync(Guid id, UpdateExpenseCodeDto input)
    {
        var expenseCode = await _expenseCodeManager.UpdateAsync(
            id,
            input.Deactive,
            input.Code,
            input.Description,
            input.Note,
            input.ConcurrencyStamp
        );

        return ObjectMapper.Map<ExpenseCode, ExpenseCodeDto>(expenseCode);
    }
}
