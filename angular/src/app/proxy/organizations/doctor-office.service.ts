import type { CreateOrEditDoctorOfficeDto, DoctorOfficeDto } from './dtos/models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DoctorOfficeService {
  apiName = 'Default';
  

  create = (input: CreateOrEditDoctorOfficeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DoctorOfficeDto>({
      method: 'POST',
      url: '/api/app/doctor-office',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/doctor-office/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DoctorOfficeDto>({
      method: 'GET',
      url: `/api/app/doctor-office/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<DoctorOfficeDto>>({
      method: 'GET',
      url: '/api/app/doctor-office',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateOrEditDoctorOfficeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DoctorOfficeDto>({
      method: 'PUT',
      url: `/api/app/doctor-office/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
