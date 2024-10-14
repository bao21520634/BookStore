using System;
using Acme.BookStore.SystemCategories.ExpenseCodes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.SystemCategories.ExpenseCodes;

public interface IExpenseCodeAppService : ICrudAppService<
        ExpenseCodeDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateExpenseCodeDto,
        UpdateExpenseCodeDto>
{

}
