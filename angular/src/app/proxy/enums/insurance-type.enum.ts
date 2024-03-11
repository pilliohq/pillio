import { mapEnumToOptions } from '@abp/ng.core';

export enum InsuranceType {
  Public = 0,
  Private = 1,
}

export const insuranceTypeOptions = mapEnumToOptions(InsuranceType);
