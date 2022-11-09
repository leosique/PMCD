import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntradasPendentesComponent } from './entradas-pendentes.component';

describe('EntradasPendentesComponent', () => {
  let component: EntradasPendentesComponent;
  let fixture: ComponentFixture<EntradasPendentesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EntradasPendentesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EntradasPendentesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
