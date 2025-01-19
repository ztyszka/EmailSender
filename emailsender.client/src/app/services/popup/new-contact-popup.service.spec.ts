import { TestBed } from '@angular/core/testing';

import { NewContactPopupService } from './new-contact-popup.service';

describe('NewContactPopupService', () => {
  let service: NewContactPopupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NewContactPopupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
