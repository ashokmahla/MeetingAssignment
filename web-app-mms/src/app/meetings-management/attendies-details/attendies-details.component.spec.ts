import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendiesDetailsComponent } from './attendies-details.component';

describe('AttendiesDetailsComponent', () => {
  let component: AttendiesDetailsComponent;
  let fixture: ComponentFixture<AttendiesDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttendiesDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttendiesDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
