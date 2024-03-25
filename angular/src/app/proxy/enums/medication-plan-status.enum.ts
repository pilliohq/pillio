import { mapEnumToOptions } from '@abp/ng.core';

export enum MedicationPlanStatus {
  Active = 0,
  Low = 1,
  Processing = 2,
}

export const medicationPlanStatusOptions = mapEnumToOptions(MedicationPlanStatus);
