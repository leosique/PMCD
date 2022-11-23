import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroAjudanteComponent } from './cadastro-ajudante.component';

describe('CadastroAjudanteComponent', () => {
  let component: CadastroAjudanteComponent;
  let fixture: ComponentFixture<CadastroAjudanteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastroAjudanteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastroAjudanteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
