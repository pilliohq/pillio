import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorOfficeComponent } from './doctor-office.component';

const routes: Routes = [{ path: '', component: DoctorOfficeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorOfficeRoutingModule { }
