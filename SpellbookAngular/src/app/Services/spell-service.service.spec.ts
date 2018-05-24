import { TestBed, inject } from '@angular/core/testing';

import { SpellServiceService } from './spell-service.service';

describe('SpellServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SpellServiceService]
    });
  });

  it('should be created', inject([SpellServiceService], (service: SpellServiceService) => {
    expect(service).toBeTruthy();
  }));
});
