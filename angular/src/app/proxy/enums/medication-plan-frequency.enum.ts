import { mapEnumToOptions } from '@abp/ng.core';

export enum MedicationPlanFrequency {
  Daily = 0,
  Weekly = 1,
  OnDemand = 2,
}

export const medicationPlanFrequencyOptions = mapEnumToOptions(MedicationPlanFrequency);
