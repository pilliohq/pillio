import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MedicationComponent } from './medication.component'; // Updated component import

const routes: Routes = [
  { path: '', component: MedicationComponent } // Updated component reference
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MedicationRoutingModule { } // Updated module class name
