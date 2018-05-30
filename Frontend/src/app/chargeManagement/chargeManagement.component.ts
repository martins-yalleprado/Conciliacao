import { Component, OnInit, ElementRef } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { ChargeManagement } from './chargeManagement';
import { Types } from './types';
import { Router } from '@angular/router';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { FlashMessagesService } from 'angular2-flash-messages';
import { ChargeManagementService } from './charge-management.service';

declare var jQuery: any;

@Component({
  selector: 'app-chargeManagement',
  templateUrl: './chargeManagement.component.html',
  styleUrls: ['./chargeManagement.component.css']
})
export class ChargeManagementComponent implements OnInit {
  showDetails = false;
  details = {};
  chargeManagement: ChargeManagement = new ChargeManagement();
  types: Types = new Types();
  data: Observable<any>;
  type: string;
  objeto: any;

  isDesc: boolean = false;
  column: string = 'Tipo';

  constructor(private service: ChargeManagementService, private el: ElementRef, private router: Router,
     private _flashMessagesService: FlashMessagesService) {
    const currentUser = JSON.parse(localStorage.getItem('user'));
    currentUser.menu = 'Movimentos de cobrança e contábil';
    localStorage.setItem('user', JSON.stringify(currentUser));
  }

  ngOnInit() {
    const today = new Date();
    const dd = today.getDate();
    const mm = today.getMonth() + 1;
    const yyyy = today.getFullYear();
    const dataReferencia = yyyy + '-' + mm + '-' + dd;
    this.getChargeManagement(dataReferencia, 'TIT,CTB,AGN');

    jQuery(this.el.nativeElement).find('.modal').modal({
    });

    //this.sort(this.column);

  }

  getChargeManagement(dataref, tipo) {
    this.data = this.service.getChargeManagement(dataref, tipo);
  }

  searchChargeManagement(dataref, tipo) {
    if (dataref !== '') {
      const parts = dataref.split("/");
      const day = parseInt(parts[0]);
      const month = parseInt(parts[1]);
      const year = parseInt(parts[2]);

      const dateFormated = year + '-' + month + '-' + day;

      this.data = this.service.getChargeManagement(dateFormated, Object.keys(tipo));
    } else {
      this._flashMessagesService.show('Obrigatório informar uma data!', { cssClass: 'card-panel red lighten-5', timeout: 5000 });
    }
  }

  formataData(dataref): string {
    const parts = dataref.split("/");
    const day = parseInt(parts[0]);
    const month = parseInt(parts[1]);
    const year = parseInt(parts[2]);

    const dateFormated = year + '-' + month + '-' + day;
    return dateFormated;
  }

  removerVersao(id) {
    if (id !== undefined) {
      this.service.removerVersao(id);
    }
  }

  mudarVersao(objeto) {
    if (objeto !== undefined) {
      this.service.mudarVersao(objeto);
    }
  }

  alterarLoteDado(objeto) {
    this.objeto = objeto;
 
    // jQuery(this.el.nativeElement).find('.alterar').modal({
    //   show: 'true'
    // });
  }

  gerarLote(dataref, tipo) {
    if (dataref !== '') {
      const dataformatada = this.formataData(dataref);

      this.data = this.service.gerarLote(dataformatada, Object.keys(tipo));

      // Observable
      //   .forkJoin(this.service.gerarLote(dataformatada, Object.keys(tipo)))
      //   .subscribe(
      //     ([data]) => {
      //       this.data = data;
      //     }
      //   );
    } else {
      this._flashMessagesService.show('Obrigatório informar uma data!', { cssClass: 'card-panel red lighten-5', timeout: 5000 });
    }
  }
}
