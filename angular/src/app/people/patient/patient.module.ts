import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PatientRoutingModule } from './patient-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { PatientComponent } from './patient.component';

@NgModule({
  declarations: [
    PatientComponent,
  ],
  imports: [
    SharedModule,
    CommonModule,
    PatientRoutingModule
  ]
})
export class PatientModule { }
