import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfiguracaoEmpresaComponent } from './configuracao-empresa.component';

describe('ConfiguracaoEmpresaComponent', () => {
  let component: ConfiguracaoEmpresaComponent;
  let fixture: ComponentFixture<ConfiguracaoEmpresaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfiguracaoEmpresaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfiguracaoEmpresaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
