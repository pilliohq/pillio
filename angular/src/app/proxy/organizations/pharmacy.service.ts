import type { CreateOrEditPharmacyDto, PharmacyDto } from './pharmacies/dtos/models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PharmacyService {
  apiName = 'Default';
  

  create = (input: CreateOrEditPharmacyDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PharmacyDto>({
      method: 'POST',
      url: '/api/app/pharmacy',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/pharmacy/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PharmacyDto>({
      method: 'GET',
      url: `/api/app/pharmacy/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<PharmacyDto>>({
      method: 'GET',
      url: '/api/app/pharmacy',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateOrEditPharmacyDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PharmacyDto>({
      method: 'PUT',
      url: `/api/app/pharmacy/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
