import type { Gender } from '../enums/gender.enum';
import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';
import type { InsuranceType } from '../enums/insurance-type.enum';
import type { CareHomeDto, DoctorOfficeDto, StationDto } from '../organizations/dtos/models';
import type { PharmacyDto } from '../organizations/pharmacies/dtos/models';

export interface CreateOrEditPatientDto {
  firstName: string;
  lastName: string;
  email?: string;
  phone?: string;
  doB?: string;
  gender: Gender;
  heightInCm: number;
  weightInKg: number;
  weightInKgIncrease: number;
  streetAndHouseNumber?: string;
  additionalInformation?: string;
  useAsDeliveryAddress: boolean;
  city?: string;
  postalCode?: string;
  country?: string;
  careHomeId?: string;
  pharmacyId?: string;
  doctorOfficeId?: string;
  insuranceCardId?: string;
  timePlanId?: string;
  stationId?: string;
  avatarId?: string;
  leadNurseId?: string;
  familyRelationship?: string;
  familyFirstName?: string;
  familyLastName?: string;
  familyPhone?: string;
  familyEmail?: string;
  metaData: PatientMetaDataDto;
}

export interface InsuranceCardDto extends EntityDto<string> {
  companyName: string;
  type: InsuranceType;
  number?: string;
  freeOfCharge: boolean;
}

export interface PatientDto extends AuditedEntityDto<string> {
  tenantId?: string;
  firstName: string;
  lastName: string;
  email?: string;
  phone?: string;
  doB?: string;
  gender: Gender;
  heightInCm: number;
  weightInKg: number;
  weightInKgIncrease: number;
  streetAndHouseNumber?: string;
  additionalInformation?: string;
  useAsDeliveryAddress: boolean;
  city?: string;
  postalCode?: string;
  country?: string;
  careHomeId?: string;
  careHome: CareHomeDto;
  pharmacyId?: string;
  pharmacy: PharmacyDto;
  doctorOfficeId?: string;
  doctorOffice: DoctorOfficeDto;
  insuranceCardId?: string;
  insuranceCard: InsuranceCardDto;
  timePlanId?: string;
  timePlan: TimePlanDto;
  stationId?: string;
  station: StationDto;
  fullName?: string;
  avatarId?: string;
  leadNurseId?: string;
  familyRelationship?: string;
  familyFirstName?: string;
  familyLastName?: string;
  familyPhone?: string;
  familyEmail?: string;
  metaData: PatientMetaDataDto;
}

export interface PatientMetaDataDto {
  healthStatuses: string[];
  bloodPressure?: string;
  bloodPressureIncrease: number;
  bloodSugarIncrease: number;
  bloodSugar?: string;
  symptoms: string[];
}

export interface TimePlanDto extends EntityDto<string> {
  tenantId?: number;
  wakeupTime?: string;
  sleepTime?: string;
  dosingSchedule1Value?: string;
  dosingSchedule2Value?: string;
  dosingSchedule3Value?: string;
  dosingSchedule4?: string;
  displaySchedule?: string;
}
