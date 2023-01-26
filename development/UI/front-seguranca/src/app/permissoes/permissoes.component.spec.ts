import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PermissoesComponent } from './permissoes.component';

describe('PermissoesComponent', () => {
  let component: PermissoesComponent;
  let fixture: ComponentFixture<PermissoesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PermissoesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PermissoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
