using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Acme.BookStore.Permissions;

public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(BookStorePermissions.GroupName, L("Permission:BookStore"));

        var booksPermission = bookStoreGroup.AddPermission(BookStorePermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(BookStorePermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(BookStorePermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(BookStorePermissions.Books.Delete, L("Permission:Books.Delete"));

        var authorsPermission = bookStoreGroup.AddPermission(
    BookStorePermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(
            BookStorePermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(
            BookStorePermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(
            BookStorePermissions.Authors.Delete, L("Permission:Authors.Delete"));

        var galleryImagePermission = bookStoreGroup.AddPermission(BookStorePermissions.GalleryImages.Default, L("Permission:GalleryImages.ImageManagement"));
        galleryImagePermission.AddChild(BookStorePermissions.GalleryImages.Management, L("Permission:GalleryImages.Management"));
        galleryImagePermission.AddChild(BookStorePermissions.GalleryImages.Create, L("Permission:GalleryImages.Create"));
        galleryImagePermission.AddChild(BookStorePermissions.GalleryImages.Update, L("Permission:GalleryImages.Edit"));
        galleryImagePermission.AddChild(BookStorePermissions.GalleryImages.Delete, L("Permission:GalleryImages.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookStoreResource>(name);
    }

}
