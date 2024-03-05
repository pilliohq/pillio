import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CareHomeComponent } from './care-home.component';

describe('CareHomeComponent', () => {
  let component: CareHomeComponent;
  let fixture: ComponentFixture<CareHomeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CareHomeComponent]
    });
    fixture = TestBed.createComponent(CareHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
