import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CareHomeComponent } from './care-home.component';

const routes: Routes = [{ path: '', component: CareHomeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CareHomeRoutingModule { }
