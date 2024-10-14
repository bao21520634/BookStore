import type { CreateExpenseCodeDto, ExpenseCodeDto, UpdateExpenseCodeDto } from './dtos/models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ExpenseCodeService {
  apiName = 'Default';
  

  create = (input: CreateExpenseCodeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ExpenseCodeDto>({
      method: 'POST',
      url: '/api/app/expense-code',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/expense-code/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ExpenseCodeDto>({
      method: 'GET',
      url: `/api/app/expense-code/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ExpenseCodeDto>>({
      method: 'GET',
      url: '/api/app/expense-code',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UpdateExpenseCodeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ExpenseCodeDto>({
      method: 'PUT',
      url: `/api/app/expense-code/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
