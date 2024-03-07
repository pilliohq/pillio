import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PharmacyRoutingModule } from './pharmacy-routing.module'; // Updated import
import { PharmacyComponent } from './pharmacy.component'; // Updated import
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    PharmacyComponent // Updated component name
  ],
  imports: [
    SharedModule,
    CommonModule,
    PharmacyRoutingModule // Updated module name
  ]
})
export class PharmacyModule { // Updated module name
}
