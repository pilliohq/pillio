import type { AuditedEntityDto } from '@abp/ng.core';

export interface CareHomeDto extends AuditedEntityDto<string> {
  name?: string;
  address?: string;
  floors?: string;
  notes?: string;
  deliveryDay: any;
  deliveryTime?: string;
  careHomeTenantId?: string;
}

export interface CreateOrEditCareHomeDto {
  name: string;
  address?: string;
  floors?: string;
  notes?: string;
  deliveryDay: any;
  deliveryTime?: string;
  careHomeTenantId?: string;
  avatarId?: string;
}
