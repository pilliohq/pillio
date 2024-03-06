import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CareHomeRoutingModule } from './care-home-routing.module';
import { CareHomeComponent } from './care-home.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    CareHomeComponent
  ],
  imports: [
    SharedModule,
    CommonModule,
    CareHomeRoutingModule
  ]
})
export class CareHomeModule { }
