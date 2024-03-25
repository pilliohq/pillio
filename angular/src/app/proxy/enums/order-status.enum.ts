import { mapEnumToOptions } from '@abp/ng.core';

export enum OrderStatus {
  Processing = 0,
  PriorityProcessing = 1,
  Confirmed = 2,
  Delivery = 3,
  Active = 4,
  Low = 5,
  Completed = 6,
  None = 8,
}

export const orderStatusOptions = mapEnumToOptions(OrderStatus);
