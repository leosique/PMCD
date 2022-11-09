import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginSegurancaComponent } from './login-seguranca.component';

describe('LoginSegurancaComponent', () => {
  let component: LoginSegurancaComponent;
  let fixture: ComponentFixture<LoginSegurancaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginSegurancaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginSegurancaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
