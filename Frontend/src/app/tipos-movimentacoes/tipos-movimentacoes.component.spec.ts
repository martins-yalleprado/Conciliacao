import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TiposMovimentacoesComponent } from './tipos-movimentacoes.component';

describe('TiposMovimentacoesComponent', () => {
  let component: TiposMovimentacoesComponent;
  let fixture: ComponentFixture<TiposMovimentacoesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TiposMovimentacoesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TiposMovimentacoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
