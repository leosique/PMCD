import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaFretesComponent } from './lista-fretes.component';

describe('ListaFretesComponent', () => {
  let component: ListaFretesComponent;
  let fixture: ComponentFixture<ListaFretesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaFretesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListaFretesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
