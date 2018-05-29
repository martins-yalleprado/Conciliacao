import { TestBed, inject } from '@angular/core/testing';

import { ChargeManagementService } from './charge-management.service';

describe('ChargeManagementService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ChargeManagementService]
    });
  });

  it('should be created', inject([ChargeManagementService], (service: ChargeManagementService) => {
    expect(service).toBeTruthy();
  }));
});
