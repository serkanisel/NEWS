import { TestBed } from '@angular/core/testing';

import { AletifyService } from './Alertify.service';

describe('AletifyService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AletifyService = TestBed.get(AletifyService);
    expect(service).toBeTruthy();
  });
});
