import type { FullAuditedEntityDto } from '@abp/ng.core';

export interface CreateKindOfFalDto {
  code?: string;
  description?: string;
  note?: string;
}

export interface KindOfFalDto extends FullAuditedEntityDto<string> {
  code?: string;
  description?: string;
  note?: string;
  deactive: boolean;
  concurrencyStamp?: string;
}

export interface UpdateKindOfFalDto {
  code?: string;
  description?: string;
  note?: string;
  deactive: boolean;
  concurrencyStamp?: string;
}
