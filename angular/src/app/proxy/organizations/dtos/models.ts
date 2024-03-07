import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

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

export interface CreateOrEditDoctorOfficeDto extends EntityDto<string> {
  name: string;
  firstName?: string;
  lastName?: string;
  email?: string;
  phone?: string;
  doctorTenantId?: number;
  avatarId?: number;
}

export interface DoctorOfficeDto extends AuditedEntityDto<string> {
  name?: string;
  firstName?: string;
  lastName?: string;
  email?: string;
  phone?: string;
  doctorTenantId?: number;
}
