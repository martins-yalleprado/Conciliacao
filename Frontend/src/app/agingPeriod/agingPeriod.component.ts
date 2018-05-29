import { Component, OnInit, ElementRef } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { AgingPeriod } from './agingPeriod'
import { AgingPeriodInterval } from './agingPeriodInterval'


import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { AgingPeriodService } from './aging-period.service';

declare var jQuery: any;

@Component({
  selector: 'app-agingPeriod',
  templateUrl: './agingPeriod.component.html',
  styleUrls: ['./agingPeriod.component.css']
})
export class AgingPeriodComponent implements OnInit {
  showDetails = false;
  details = {};
  agingPeriod: AgingPeriod = new AgingPeriod();
  agingPeriodInterval: AgingPeriodInterval = new AgingPeriodInterval();
  data: Observable<any>;
  dataIntervalo: Observable<any>;
  show_element: boolean = false;
  constructor(private service: AgingPeriodService, private el:ElementRef) {}

  ngOnInit() {
    //this.getAging();
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth()+1;
    var yyyy = today.getFullYear();
    let dataReferencia = yyyy +'-'+ mm +'-'+ dd;
    this.getBuscaPeriodos(dataReferencia, '');
    jQuery(this.el.nativeElement).find('.modal').modal({
    });
  }

  getBuscaPeriodos(periodo, ativo) {
    this.data = this.service.buscaPeriodos();
    //this.data = this.service.getBuscaPeriodos(periodo, ativo);
  }
  buscaIntervalos(idPeriodo)
  {
    debugger;
    this.dataIntervalo = this.service.buscaIntervalo(idPeriodo);
  }

  buscaPeriodos() {
    this.data = this.service.buscaPeriodos();
  }

  removerPeriodo(id) {
    this.service.removerPeriodo(id);
  }

  atualizarPeriodo (obj) {
    this.service.atualizarPeriodo(obj)
  }

  salvarNovoPeriodo () {
    debugger;
    var teste = this.agingPeriod.nome;
    this.service.salvarNovoPeriodo(this.agingPeriod)
  }
setClickedRow(index){
    this.agingPeriod = index;
    this.buscaIntervalos(index.codPeriodo)  
    this.show_element = true;
  }
}
