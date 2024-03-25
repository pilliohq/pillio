import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/care-home',
        name: '::Menu:CareHome',
        iconClass: 'fas fa-book',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/care-homes',
        name: '::Menu:CareHomes',
        parentName: '::Menu:CareHome',
        layout: eLayoutType.application,
      },
      {
        path: '/pharmacy', // Updated path
        name: '::Menu:Pharmacy', // Updated name
        iconClass: 'fas fa-book', // Keep the icon class if it's appropriate
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/pharmacies', // Updated path
        name: '::Menu:Pharmacies', // Updated name
        parentName: '::Menu:Pharmacy', // Updated parentName
        layout: eLayoutType.application,
      },
      {
        path: '/doctor-office', // Updated path
        name: '::Menu:DoctorOffice', // Updated name
        iconClass: 'fas fa-book', // Keep the icon class if it's appropriate
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/doctor-offices', // Updated path
        name: '::Menu:DoctorOffices', // Updated name
        parentName: '::Menu:DoctorOffice', // Updated parentName
        layout: eLayoutType.application,
      },
      {
        path: '/patients', // Updated path
        name: '::Patient', // Updated name
        iconClass: 'fas fa-book', 
        layout: eLayoutType.application,
      },
      {
        path: '/medication-plans', // Updated path
        name: '::MedicationPlan', // Updated name
        iconClass: 'fas fa-book', 
        layout: eLayoutType.application,
      },
    ]);
  };
}
