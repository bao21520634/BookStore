using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.GalleryImages.Dtos;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.CmsKit.Comments;
using Volo.CmsKit.Reactions;

namespace Acme.BookStore.GalleryImages;

[Authorize(BookStorePermissions.GalleryImages.Default)]
public class GalleryImageAppService : CrudAppService<
        GalleryImage,
        GalleryImageDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateGalleryImageDto>,
        IGalleryImageAppService
{
    public GalleryImageAppService(
            IRepository<GalleryImage, Guid> repository)
            : base(repository)
    {
        GetPolicyName = BookStorePermissions.GalleryImages.Default;
        GetListPolicyName = BookStorePermissions.GalleryImages.Default;
        CreatePolicyName = BookStorePermissions.GalleryImages.Create;
        UpdatePolicyName = BookStorePermissions.GalleryImages.Update;
        DeletePolicyName = BookStorePermissions.GalleryImages.Delete;
    }

    public async Task<List<GalleryImageWithDetailsDto>> GetDetailedListAsync()
    {
        var queryable = await Repository.GetQueryableAsync();

        var query = from image in queryable.OfType<GalleryImage>()
                    select new GalleryImageWithDetailsDto
                    {
                        Id = image.Id,
                        Description = image.Description,
                        CoverImageMediaId = image.CoverImageMediaId,
                        CommentCount = queryable.OfType<Comment>()
                            .Count(c => c.EntityType == GalleryImageConsts.GalleryImageEntityType && c.EntityId == image.Id.ToString()),
                        LikeCount = queryable.OfType<UserReaction>()
                            .Count(r => r.EntityType == GalleryImageConsts.GalleryImageEntityType && r.EntityId == image.Id.ToString())
                    };

        var queryResult = await AsyncExecuter.ToListAsync(query);

        return queryResult;
    }
}
