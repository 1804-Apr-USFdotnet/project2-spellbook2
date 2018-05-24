import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpellComponentComponent } from './spell-component.component';

describe('SpellComponentComponent', () => {
  let component: SpellComponentComponent;
  let fixture: ComponentFixture<SpellComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpellComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpellComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
