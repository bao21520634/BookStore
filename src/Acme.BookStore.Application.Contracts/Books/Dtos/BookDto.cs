using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Books.Dtos;

public class BookDto : EntityDto<Guid>

{
    public required string Name { get; set; }
    public BookType Type { get; set; }
    public DateTime PublishDate { get; set; }
    public float Price { get; set; }

    public Guid AuthorId { get; set; }
    public string? AuthorName { get; set; }

}