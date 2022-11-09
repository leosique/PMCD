import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralTopBarComponent } from './general-top-bar.component';

describe('GeneralTopBarComponent', () => {
  let component: GeneralTopBarComponent;
  let fixture: ComponentFixture<GeneralTopBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GeneralTopBarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GeneralTopBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
