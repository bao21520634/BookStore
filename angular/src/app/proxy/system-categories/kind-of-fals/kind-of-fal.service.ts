import type { CreateKindOfFalDto, KindOfFalDto, UpdateKindOfFalDto } from './dtos/models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class KindOfFalService {
  apiName = 'Default';
  

  create = (input: CreateKindOfFalDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, KindOfFalDto>({
      method: 'POST',
      url: '/api/app/kind-of-fal',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/kind-of-fal/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, KindOfFalDto>({
      method: 'GET',
      url: `/api/app/kind-of-fal/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<KindOfFalDto>>({
      method: 'GET',
      url: '/api/app/kind-of-fal',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UpdateKindOfFalDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, KindOfFalDto>({
      method: 'PUT',
      url: `/api/app/kind-of-fal/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
