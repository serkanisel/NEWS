import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WrdlistCardComponent } from './wrdlist-card.component';

describe('WrdlistCardComponent', () => {
  let component: WrdlistCardComponent;
  let fixture: ComponentFixture<WrdlistCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WrdlistCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WrdlistCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
