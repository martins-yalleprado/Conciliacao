import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgingPeriodComponent } from './agingPeriod.component';

describe('AgingPeriodComponent', () => {
  let component: AgingPeriodComponent;
  let fixture: ComponentFixture<AgingPeriodComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgingPeriodComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgingPeriodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
