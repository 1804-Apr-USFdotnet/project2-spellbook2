import { TestBed, inject } from '@angular/core/testing';

import { SpellbookService } from './spellbook.service';

describe('SpellbookService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SpellbookService]
    });
  });

  it('should be created', inject([SpellbookService], (service: SpellbookService) => {
    expect(service).toBeTruthy();
  }));
});
