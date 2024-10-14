import type { CreateVATDto, UpdateVATDto, VATDto } from './dtos/models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class VATService {
  apiName = 'Default';
  

  create = (input: CreateVATDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VATDto>({
      method: 'POST',
      url: '/api/vats',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/vats/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VATDto>({
      method: 'GET',
      url: `/api/vats/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<VATDto>>({
      method: 'GET',
      url: '/api/vats',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UpdateVATDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VATDto>({
      method: 'PUT',
      url: `/api/vats/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
