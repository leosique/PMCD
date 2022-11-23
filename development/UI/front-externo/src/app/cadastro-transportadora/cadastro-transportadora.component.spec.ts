import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroTransportadoraComponent } from './cadastro-transportadora.component';

describe('CadastroTransportadoraComponent', () => {
  let component: CadastroTransportadoraComponent;
  let fixture: ComponentFixture<CadastroTransportadoraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastroTransportadoraComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastroTransportadoraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
