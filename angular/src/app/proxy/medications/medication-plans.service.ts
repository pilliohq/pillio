import type { GetAllMedicationPlanProductsInput, GetMedicationPlanProductForViewDto } from './dtos/models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MedicationPlansService {
  apiName = 'Default';
  

  getMedicationProductsByInput = (input: GetAllMedicationPlanProductsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<GetMedicationPlanProductForViewDto>>({
      method: 'GET',
      url: '/api/app/medication-plans/medication-products',
      params: { isFilling: input.isFilling, isWaitingPrescription: input.isWaitingPrescription, isWaitingConfirmation: input.isWaitingConfirmation, isWaitingForDelivery: input.isWaitingForDelivery, isDelivery: input.isDelivery, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
