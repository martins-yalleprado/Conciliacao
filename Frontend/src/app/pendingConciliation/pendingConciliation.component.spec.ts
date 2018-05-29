import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PendingConciliationComponent } from './pendingConciliation.component';

describe('PendingConciliationComponent', () => {
  let component: PendingConciliationComponent;
  let fixture: ComponentFixture<PendingConciliationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PendingConciliationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PendingConciliationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
