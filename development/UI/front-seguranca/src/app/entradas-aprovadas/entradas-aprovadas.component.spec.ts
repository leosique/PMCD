import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntradasAprovadasComponent } from './entradas-aprovadas.component';

describe('EntradasAprovadasComponent', () => {
  let component: EntradasAprovadasComponent;
  let fixture: ComponentFixture<EntradasAprovadasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EntradasAprovadasComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EntradasAprovadasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
