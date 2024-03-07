import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DoctorOfficeRoutingModule } from './doctor-office-routing.module';
import { DoctorOfficeComponent } from './doctor-office.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    DoctorOfficeComponent
  ],
  imports: [
    SharedModule,
    CommonModule,
    DoctorOfficeRoutingModule
  ]
})
export class DoctorOfficeModule { }
