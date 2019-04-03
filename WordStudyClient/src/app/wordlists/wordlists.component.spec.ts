import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WordlistsComponent } from './wordlists.component';

describe('WordlistsComponent', () => {
  let component: WordlistsComponent;
  let fixture: ComponentFixture<WordlistsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WordlistsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WordlistsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
