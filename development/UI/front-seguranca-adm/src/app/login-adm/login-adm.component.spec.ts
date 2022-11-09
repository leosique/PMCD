import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginAdmComponent } from './login-adm.component';

describe('LoginAdmComponent', () => {
  let component: LoginAdmComponent;
  let fixture: ComponentFixture<LoginAdmComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginAdmComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginAdmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
