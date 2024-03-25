import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedicationRoutingModule } from './medication-routing.module'; // Updated import
import { SharedModule } from 'src/app/shared/shared.module';
import { MedicationComponent } from './medication.component'; // Updated component import

@NgModule({
  declarations: [
    MedicationComponent, // Updated component reference
  ],
  imports: [
    SharedModule,
    CommonModule,
    MedicationRoutingModule // Updated routing module import
  ]
})
export class MedicationModule { } // Updated module class name
