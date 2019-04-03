import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadingpartsComponent } from './readingparts.component';

describe('ReadingpartsComponent', () => {
  let component: ReadingpartsComponent;
  let fixture: ComponentFixture<ReadingpartsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReadingpartsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReadingpartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
