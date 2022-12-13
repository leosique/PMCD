import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroAdicionaisComponent } from './cadastro-adicionais.component';

describe('CadastroAdicionaisComponent', () => {
  let component: CadastroAdicionaisComponent;
  let fixture: ComponentFixture<CadastroAdicionaisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastroAdicionaisComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastroAdicionaisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
