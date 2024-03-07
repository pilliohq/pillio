import { LIST_QUERY_DEBOUNCE_TIME, ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DoctorOfficeService } from '@proxy/organizations'; // Update import
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { DoctorOfficeDto } from '@proxy/organizations/dtos';

@Component({
  selector: 'app-doctor-office', // Update component selector
  templateUrl: './doctor-office.component.html', // Update template URL
  providers: [
    ListService,
    { provide: LIST_QUERY_DEBOUNCE_TIME, useValue: 500 },
  ],
})
export class DoctorOfficeComponent implements OnInit {
  doctorOffice = { items: [], totalCount: 0 } as PagedResultDto<DoctorOfficeDto>; // Update type

  isModalOpen = false;
  selectedDoctorOffice = {} as DoctorOfficeDto; // Update type
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    public readonly list: ListService,
    private doctorOfficeService: DoctorOfficeService // Update service
  ) { }

  ngOnInit() {
    const doctorOfficeStreamCreator = query => this.doctorOfficeService.getList(query); // Update service method

    this.list.hookToQuery(doctorOfficeStreamCreator).subscribe(response => {
      this.doctorOffice = response;
    });
  }

  createDoctorOffice() { // Update method name
    this.selectedDoctorOffice = {} as DoctorOfficeDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editDoctorOffice(id: string) { // Update method name
    this.doctorOfficeService.get(id).subscribe(doctorOffice => { // Update service method
      this.selectedDoctorOffice = doctorOffice;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedDoctorOffice.name || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedDoctorOffice.id) {
      this.doctorOfficeService.update(this.selectedDoctorOffice.id, this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    } else {
      this.doctorOfficeService.create(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this.doctorOfficeService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
