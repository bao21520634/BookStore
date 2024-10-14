using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.SystemCategories.ExpenseCodes;

public class ExpenseCodeManager : DomainService
{
    private readonly IExpenseCodeRepository _expenseCodeRepository;

    public ExpenseCodeManager(IExpenseCodeRepository expenseCodeRepository)
    {
        _expenseCodeRepository = expenseCodeRepository;
    }

    public async Task<ExpenseCode> CreateAsync(
        string? code,
        string? description = null,
        string? note = null
    )
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));

        var existingExpenseCode = await _expenseCodeRepository.FirstOrDefaultAsync(c => c.Code == code);
        if (existingExpenseCode != null)
        {
            throw new BusinessException(code).WithData("data", code);
        }

        var expenseCode = new ExpenseCode(
            GuidGenerator.Create(),
            code,
            description,
            note
        );

        return await _expenseCodeRepository.InsertAsync(expenseCode);
    }

    public async Task<ExpenseCode> UpdateAsync(
           Guid id,
           bool deactive,
           string? code,
           string? description = null,
           string? note = null,
           string? concurrencyStamp = null
       )
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));

        var expenseCode = await _expenseCodeRepository.GetAsync(id);

        expenseCode.Deactive = deactive;
        expenseCode.Code = code;
        expenseCode.Description = description;
        expenseCode.Note = note;

        expenseCode.SetConcurrencyStampIfNotNull(concurrencyStamp);
        return await _expenseCodeRepository.UpdateAsync(expenseCode);
    }
}
