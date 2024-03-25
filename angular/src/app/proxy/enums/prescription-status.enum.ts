import { mapEnumToOptions } from '@abp/ng.core';

export enum PrescriptionStatus {
  NotRequired = 0,
  Required = 1,
  PrescriptionCompleted = 2,
  PrescriptionDelayed = 3,
}

export const prescriptionStatusOptions = mapEnumToOptions(PrescriptionStatus);
