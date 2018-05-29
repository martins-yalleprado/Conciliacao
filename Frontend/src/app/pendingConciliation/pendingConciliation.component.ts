import { Component, OnInit, ElementRef } from '@angular/core';
import { Observable } from 'rxjs/Rx';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { PendingConciliationService } from './pending-conciliation.service';

declare var jQuery: any;

@Component({
    selector: 'app-pendingConciliation',
    templateUrl: './pendingConciliation.component.html',
    styleUrls: ['./pendingConciliation.component.css']
})
export class PendingConciliationComponent implements OnInit {

  showDetails = false;
  details = {};

  data: Observable<any>;

  constructor(private service: PendingConciliationService, private el:ElementRef) {}

  ngOnInit() {
    this.getPendingConciliation();

  }

  getPendingConciliation() {
      this.data = this.service.getPendingConciliation();
  }


}
