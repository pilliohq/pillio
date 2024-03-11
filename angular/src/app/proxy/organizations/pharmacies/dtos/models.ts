import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

export interface PharmacyDto extends AuditedEntityDto<string> {
  name?: string;
  address?: string;
  notes?: string;
  pharmacyTenantId?: number;
}

export interface CreateOrEditPharmacyDto extends EntityDto<number> {
  name: string;
  address?: string;
  notes?: string;
  pharmacyTenantId?: number;
  avatarId?: number;
}
