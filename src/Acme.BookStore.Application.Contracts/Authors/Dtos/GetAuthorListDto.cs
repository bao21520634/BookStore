using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Authors.Dtos;

public class GetAuthorListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
