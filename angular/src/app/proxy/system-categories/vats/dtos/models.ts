import type { FullAuditedEntityDto } from '@abp/ng.core';

export interface CreateVATDto {
  code?: string;
  value: number;
  description?: string;
  note?: string;
}

export interface UpdateVATDto {
  deactive: boolean;
  code?: string;
  value: number;
  description?: string;
  note?: string;
  concurrencyStamp?: string;
}

export interface VATDto extends FullAuditedEntityDto<string> {
  deactive: boolean;
  code?: string;
  value: number;
  description?: string;
  note?: string;
  concurrencyStamp?: string;
}
