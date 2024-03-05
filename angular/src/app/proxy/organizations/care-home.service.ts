import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CareHomeDto, CreateOrEditCareHomeDto } from '../app/organizations/dtos/models';

@Injectable({
  providedIn: 'root',
})
export class CareHomeService {
  apiName = 'Default';
  

  create = (input: CreateOrEditCareHomeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CareHomeDto>({
      method: 'POST',
      url: '/api/app/care-home',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/care-home/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CareHomeDto>({
      method: 'GET',
      url: `/api/app/care-home/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CareHomeDto>>({
      method: 'GET',
      url: '/api/app/care-home',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateOrEditCareHomeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CareHomeDto>({
      method: 'PUT',
      url: `/api/app/care-home/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
