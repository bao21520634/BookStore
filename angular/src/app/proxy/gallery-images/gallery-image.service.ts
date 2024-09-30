import type { CreateUpdateGalleryImageDto, GalleryImageDto, GalleryImageWithDetailsDto } from './dtos/models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class GalleryImageService {
  apiName = 'Default';
  

  create = (input: CreateUpdateGalleryImageDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, GalleryImageDto>({
      method: 'POST',
      url: '/api/app/gallery-image',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/gallery-image/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, GalleryImageDto>({
      method: 'GET',
      url: `/api/app/gallery-image/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDetailedList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, GalleryImageWithDetailsDto[]>({
      method: 'GET',
      url: '/api/app/gallery-image/detailed-list',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<GalleryImageDto>>({
      method: 'GET',
      url: '/api/app/gallery-image',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateGalleryImageDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, GalleryImageDto>({
      method: 'PUT',
      url: `/api/app/gallery-image/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
