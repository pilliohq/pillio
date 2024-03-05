import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { CareHomeDto } from '@proxy/app/organizations/dtos';
import { CareHomeService } from '@proxy/organizations';

@Component({
  selector: 'app-care-home',
  templateUrl: './care-home.component.html',
  styleUrls: ['./care-home.component.scss'],
})
export class CareHomeComponent implements OnInit {
  careHome = { items: [], totalCount: 0 } as PagedResultDto<CareHomeDto>;

  constructor(public readonly list: ListService, private careHomeService: CareHomeService) {}

  ngOnInit() {
    const careHomeStreamCreator = query => this.careHomeService.getList(query);

    this.list.hookToQuery(careHomeStreamCreator).subscribe(response => {
      this.careHome = response;
    });
  }
}
