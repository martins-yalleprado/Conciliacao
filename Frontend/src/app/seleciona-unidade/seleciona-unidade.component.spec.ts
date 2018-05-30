import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelecionaUnidadeComponent } from './seleciona-unidade.component';

describe('SelecionaUnidadeComponent', () => {
  let component: SelecionaUnidadeComponent;
  let fixture: ComponentFixture<SelecionaUnidadeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelecionaUnidadeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelecionaUnidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
