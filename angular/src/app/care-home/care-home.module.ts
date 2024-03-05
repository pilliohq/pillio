import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CareHomeRoutingModule } from './care-home-routing.module';
import { CareHomeComponent } from './care-home.component';


@NgModule({
  declarations: [
    CareHomeComponent
  ],
  imports: [
    CommonModule,
    CareHomeRoutingModule
  ]
})
export class CareHomeModule { }
