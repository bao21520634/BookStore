import type { FullAuditedEntityDto } from '@abp/ng.core';

export interface CreateDepartmentDto {
  code?: string;
  description?: string;
  note?: string;
}

export interface DepartmentDto extends FullAuditedEntityDto<string> {
  deactive: boolean;
  code?: string;
  description?: string;
  note?: string;
  concurrencyStamp?: string;
}

export interface UpdateDepartmentDto {
  deactive: boolean;
  code?: string;
  description?: string;
  note?: string;
  concurrencyStamp?: string;
}
