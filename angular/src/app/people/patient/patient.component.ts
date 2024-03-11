import { LIST_QUERY_DEBOUNCE_TIME, ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PatientDto, PatientService } from '@proxy/people';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  providers: [
    // [Required]
    ListService,

    // [Optional]
    // Provide this token if you want a different debounce time.
    // Default is 300. Cannot be 0. Any value below 100 is not recommended.
    { provide: LIST_QUERY_DEBOUNCE_TIME, useValue: 500 },
  ],
})
export class PatientComponent implements OnInit {
  patients = { items: [], totalCount: 0 } as PagedResultDto<PatientDto>;

  isModalOpen = false;
  selectedPatient = {} as PatientDto;
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    public readonly list: ListService,
    private patientService: PatientService
  ) { }

  ngOnInit() {
    const patientStreamCreator = query => this.patientService.getList(query);

    this.list.hookToQuery(patientStreamCreator).subscribe(response => {
      this.patients = response;
    });
  }

  createPatient() {
    this.selectedPatient = {} as PatientDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editPatient(id: string) {
    this.patientService.get(id).subscribe(patient => {
      this.selectedPatient = patient;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedPatient.firstName || '', Validators.required],
      // Include other properties as needed
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedPatient.id) {
      this.patientService.update(this.selectedPatient.id, this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    } else {
      this.patientService.create(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this.patientService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
