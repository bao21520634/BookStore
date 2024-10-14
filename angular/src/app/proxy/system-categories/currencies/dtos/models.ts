import type { FullAuditedEntityDto } from '@abp/ng.core';

export interface CreateCurrencyDto {
  code?: string;
  description?: string;
  exchangeRate: number;
  note?: string;
}

export interface CurrencyDto extends FullAuditedEntityDto<string> {
  code?: string;
  description?: string;
  exchangeRate?: number;
  deactive: boolean;
  note?: string;
  concurrencyStamp?: string;
}

export interface UpdateCurrencyDto {
  code?: string;
  description?: string;
  exchangeRate?: number;
  deactive: boolean;
  note?: string;
  concurrencyStamp?: string;
}
