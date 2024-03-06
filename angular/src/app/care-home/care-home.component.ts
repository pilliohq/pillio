import { LIST_QUERY_DEBOUNCE_TIME, ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { CareHomeDto } from '@proxy/app/organizations/dtos';
import { CareHomeService } from '@proxy/organizations';

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

  constructor(public readonly list: ListService, private careHomeService: CareHomeService) {}

  ngOnInit() {
    const careHomeStreamCreator = query => this.careHomeService.getList(query);

    this.list.hookToQuery(careHomeStreamCreator).subscribe(response => {
      this.careHome = response;
    });
  }

  createCareHome() {
    this.isModalOpen = true;
  }
}
