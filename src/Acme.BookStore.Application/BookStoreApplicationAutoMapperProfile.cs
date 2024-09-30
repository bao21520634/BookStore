using Acme.BookStore.Authors;
using Acme.BookStore.Authors.Dtos;
using Acme.BookStore.Books;
using Acme.BookStore.Books.Dtos;
using Acme.BookStore.GalleryImages;
using Acme.BookStore.GalleryImages.Dtos;
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
    }
}
