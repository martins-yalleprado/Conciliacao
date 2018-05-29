import { TestBed, inject } from '@angular/core/testing';

import { AgingPeriodService } from './aging-period.service';

describe('AgingPeriodService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AgingPeriodService]
    });
  });

  it('should be created', inject([AgingPeriodService], (service: AgingPeriodService) => {
    expect(service).toBeTruthy();
  }));
});
