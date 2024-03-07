import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PharmacyComponent } from './pharmacy.component'; // Update component import

const routes: Routes = [{ path: '', component: PharmacyComponent }]; // Update component name

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PharmacyRoutingModule { } // Update module name
