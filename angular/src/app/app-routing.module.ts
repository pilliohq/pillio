import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  {
    path: 'care-homes',
    loadChildren: () => import('./care-home/care-home.module').then(m => m.CareHomeModule),
  },
  {
    path: 'doctor-offices',
    loadChildren: () => import('./doctor-office/doctor-office.module').then(m => m.DoctorOfficeModule),
  },
  {
    path: 'phamacies',
    loadChildren: () => import('./pharmacy/pharmacy.module').then(m => m.PharmacyModule),
  },
  {
    path: 'patients',
    loadChildren: () => import('./people/patient/patient.module').then(m => m.PatientModule),
  },
  {
    path: 'medication-plans',
    loadChildren: () => import('./medications/medication.module').then(m => m.MedicationModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule { }
