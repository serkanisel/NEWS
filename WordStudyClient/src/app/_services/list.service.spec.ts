import { TestBed } from '@angular/core/testing';

import { WrdlistService } from './list.service';

describe('WrdlistService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WrdlistService = TestBed.get(WrdlistService);
    expect(service).toBeTruthy();
  });
});
