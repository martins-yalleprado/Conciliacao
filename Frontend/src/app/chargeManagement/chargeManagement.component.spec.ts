import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChargeManagementComponent } from './chargeManagement.component';

describe('ChargeManagementComponent', () => {
  let component: ChargeManagementComponent;
  let fixture: ComponentFixture<ChargeManagementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChargeManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChargeManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
