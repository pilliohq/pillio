import { LIST_QUERY_DEBOUNCE_TIME, ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CareHomeDto } from '@proxy/app/organizations/dtos';
import { CareHomeService } from '@proxy/organizations';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-care-home',
  templateUrl: './care-home.component.html',
  styleUrls: ['./care-home.component.scss'],
  providers: [
    // [Required]
    ListService,

    // [Optional]
    // Provide this token if you want a different debounce time.
    // Default is 300. Cannot be 0. Any value below 100 is not recommended.
    { provide: LIST_QUERY_DEBOUNCE_TIME, useValue: 500 },
  ],
})
export class CareHomeComponent implements OnInit {
  careHome = { items: [], totalCount: 0 } as PagedResultDto<CareHomeDto>;

  isModalOpen = false;
  selectedCareHome = {} as CareHomeDto;
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    public readonly list: ListService,
    private careHomeService: CareHomeService
  ) { }

  ngOnInit() {
    const careHomeStreamCreator = query => this.careHomeService.getList(query);

    this.list.hookToQuery(careHomeStreamCreator).subscribe(response => {
      this.careHome = response;
    });
  }

  createCareHome() {
    this.selectedCareHome = {} as CareHomeDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editCareHome(id: string) {
    this.careHomeService.get(id).subscribe(careHome => {
      this.selectedCareHome = careHome;
      this.buildForm();
      this.isModalOpen = true;
    });
  }
  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedCareHome.name || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedCareHome.id) {
      this.careHomeService.update(this.selectedCareHome.id, this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    } else {
      this.careHomeService.create(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this.careHomeService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
