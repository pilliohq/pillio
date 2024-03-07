import { LIST_QUERY_DEBOUNCE_TIME, ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PharmacyService } from '@proxy/organizations'; // Update import
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { PharmacyDto } from '@proxy/organizations/pharmacies/dtos';

@Component({
  selector: 'app-pharmacy', // Update component selector
  templateUrl: './pharmacy.component.html', // Update template URL
  providers: [
    ListService,
    { provide: LIST_QUERY_DEBOUNCE_TIME, useValue: 500 },
  ],
})
export class PharmacyComponent implements OnInit {
  pharmacy = { items: [], totalCount: 0 } as PagedResultDto<PharmacyDto>; // Update type

  isModalOpen = false;
  selectedPharmacy = {} as PharmacyDto; // Update type
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    public readonly list: ListService,
    private pharmacyService: PharmacyService // Update service
  ) { }

  ngOnInit() {
    const pharmacyStreamCreator = query => this.pharmacyService.getList(query); // Update service method

    this.list.hookToQuery(pharmacyStreamCreator).subscribe(response => {
      this.pharmacy = response;
    });
  }

  createPharmacy() { // Update method name
    this.selectedPharmacy = {} as PharmacyDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editPharmacy(id: string) { // Update method name
    this.pharmacyService.get(id).subscribe(pharmacy => { // Update service method
      this.selectedPharmacy = pharmacy;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedPharmacy.name || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedPharmacy.id) {
      this.pharmacyService.update(this.selectedPharmacy.id, this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    } else {
      this.pharmacyService.create(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this.pharmacyService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
