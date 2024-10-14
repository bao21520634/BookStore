import type { FullAuditedEntityDto } from '@abp/ng.core';

export interface CreateExpenseCodeDto {
  code?: string;
  description?: string;
  note?: string;
}

export interface ExpenseCodeDto extends FullAuditedEntityDto<string> {
  deactive: boolean;
  code?: string;
  description?: string;
  note?: string;
  concurrencyStamp?: string;
}

export interface UpdateExpenseCodeDto {
  deactive: boolean;
  code?: string;
  description?: string;
  note?: string;
  concurrencyStamp?: string;
}
