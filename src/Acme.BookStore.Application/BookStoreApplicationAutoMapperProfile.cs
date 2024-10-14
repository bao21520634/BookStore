using Acme.BookStore.Authors;
using Acme.BookStore.Authors.Dtos;
using Acme.BookStore.Books;
using Acme.BookStore.Books.Dtos;
using Acme.BookStore.GalleryImages;
using Acme.BookStore.GalleryImages.Dtos;
using Acme.BookStore.SystemCategories.Currencies;
using Acme.BookStore.SystemCategories.Currencies.Dtos;
using Acme.BookStore.SystemCategories.Departments;
using Acme.BookStore.SystemCategories.Departments.Dtos;
using Acme.BookStore.SystemCategories.ExpenseCodes;
using Acme.BookStore.SystemCategories.ExpenseCodes.Dtos;
using Acme.BookStore.SystemCategories.KindOfFals;
using Acme.BookStore.SystemCategories.KindOfFals.Dtos;
using Acme.BookStore.SystemCategories.VATs;
using Acme.BookStore.SystemCategories.VATs.Dtos;
using AutoMapper;

namespace Acme.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();
        CreateMap<CreateUpdateGalleryImageDto, GalleryImage>().ReverseMap();
        CreateMap<GalleryImage, GalleryImageDto>().ReverseMap();

        CreateMap<Currency, CurrencyDto>();

        CreateMap<Department, DepartmentDto>();

        CreateMap<ExpenseCode, ExpenseCodeDto>();

        CreateMap<KindOfFal, KindOfFalDto>();

        CreateMap<VAT, VATDto>();
    }
}
