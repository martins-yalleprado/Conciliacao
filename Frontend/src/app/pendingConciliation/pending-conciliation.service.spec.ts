import { TestBed, inject } from '@angular/core/testing';

import { PendingConciliationService } from './pending-conciliation.service';

describe('PendingConciliationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PendingConciliationService]
    });
  });

  it('should be created', inject([PendingConciliationService], (service: PendingConciliationService) => {
    expect(service).toBeTruthy();
  }));
});
