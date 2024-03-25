import { LIST_QUERY_DEBOUNCE_TIME, ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MedicationPlansService } from '@proxy/medications'; // Updated import
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { GetMedicationPlanProductForViewDto } from '@proxy/medications/dtos';

@Component({
  selector: 'app-medication', // Updated component selector
  templateUrl: './medication.component.html', // Updated template URL
  providers: [
    ListService,
    { provide: LIST_QUERY_DEBOUNCE_TIME, useValue: 500 },
  ],
})
export class MedicationComponent implements OnInit {
  medicationProducts = { items: [], totalCount: 0 } as PagedResultDto<GetMedicationPlanProductForViewDto>; // Updated property type

  isModalOpen = false;
  selectedMedication = {} as GetMedicationPlanProductForViewDto; // Updated property type
  form: FormGroup;
  searchInput = {
    maxResultCount: 10, // Set your desired default value for maxResultCount
    skipCount: 0, // Set your desired default value for skipCount
    sorting: '', // Set your desired default value for sorting
    isFilling: false,
    isWaitingPrescription: false,
    isWaitingConfirmation: false,
    isWaitingForDelivery: false,
    isDelivery: false
  };
  constructor(
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    public readonly list: ListService,
    private medicationPlanService: MedicationPlansService // Updated service import
  ) { }

  ngOnInit() {
    const medicationStreamCreator = query => this.medicationPlanService.getMedicationProductsByInput(this.searchInput, query); // Updated service method

    this.list.hookToQuery(medicationStreamCreator).subscribe(response => {
      this.medicationProducts = response;
    });
  }

  createMedication() { // Updated method name
    this.selectedMedication = {} as GetMedicationPlanProductForViewDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editMedication(id: string) { // Updated method name
    // this.medicationPlanService.get(id).subscribe(medication => { // Updated service method
    //   this.selectedMedication = medication;
    //   this.buildForm();
    //   this.isModalOpen = true;
    // });
  }

  buildForm() {
    this.form = this.fb.group({

    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    // if (this.selectedMedication.id) {
    //   this.medicationPlanService.update(this.selectedMedication.id, this.form.value).subscribe(() => { // Updated service method and property name
    //     this.isModalOpen = false;
    //     this.form.reset();
    //     this.list.get();
    //   });
    // } else {
    //   this.medicationPlanService.create(this.form.value).subscribe(() => { // Updated service method
    //     this.isModalOpen = false;
    //     this.form.reset();
    //     this.list.get();
    //   });
    // }
  }

  delete(id: string) {
    // this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
    //   if (status === Confirmation.Status.confirm) {
    //     this.medicationPlanService.delete(id).subscribe(() => this.list.get()); // Updated service method
    //   }
    // });
  }
}
