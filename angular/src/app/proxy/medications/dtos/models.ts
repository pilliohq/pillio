import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { OrderStatus } from '../../enums/order-status.enum';
import type { MedicationPlanWorkflowInfo } from '../models';
import type { MedicationPlanStatus } from '../../enums/medication-plan-status.enum';
import type { MedicationPlanFrequency } from '../../enums/medication-plan-frequency.enum';
import type { PrescriptionStatus } from '../../enums/prescription-status.enum';

export interface GetAllMedicationPlanProductsInput extends PagedAndSortedResultRequestDto {
  isFilling?: boolean;
  isWaitingPrescription?: boolean;
  isWaitingConfirmation?: boolean;
  isWaitingForDelivery?: boolean;
  isDelivery?: boolean;
}

export interface GetMedicationPlanProductForViewDto {
  medicationPlanProduct: MedicationPlanProductDto;
  medicationPlanPatientName?: string;
  productName?: string;
  responsiblePerson?: string;
  orderStatus: OrderStatus;
  patientAvatarUrl?: string;
  deliveryDate?: string;
  orderWorkflow: MedicationPlanWorkflowInfo;
}

export interface MedicationPlanProductDto extends EntityDto<string> {
  usedCount: number;
  count: number;
  availableCount: number;
  startDate?: string;
  status: MedicationPlanStatus;
  frequency: MedicationPlanFrequency;
  billPack: boolean;
  exactlySamePrescription: boolean;
  notes?: string;
  weeklyFrequencyDays: string[];
  currentBatchEndDate?: string;
  prescriptionStatus: PrescriptionStatus;
  orderStatus: OrderStatus;
  productName?: string;
  medicationPlanId?: string;
  productId?: string;
  dosingSchedule1Value: number;
  dosingSchedule2Value: number;
  dosingSchedule3Value: number;
  dosingSchedule4Value: number;
  patientId?: string;
  patientName?: string;
}
