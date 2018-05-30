import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { AppConstants } from '../app.constants';
import { AuthService } from '../auth.service';

import { Observable } from 'rxjs/Rx';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class ChargeManagementService {

  constructor(private http: Http) { }

  private headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });

    getChargeManagement(dataref, tipo): Observable<any> {
      return this.http.get(AppConstants.API_ROOT + '/api/GestaoCarga?dataref=' + dataref + '&tipo=' + tipo)
      .map((res: Response) => res.json())
      .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }

    removerVersao(id) {
    return  this.http.delete(AppConstants.API_ROOT + '/api/GestaoCarga', id).catch
    ((error: any) => Observable.throw(error.json().error || 'Server error'));
    }

    mudarVersao(objeto) {
      this.http.put('https://jsonplaceholder.typicode.com/api/GestaoCarga/change', objeto);
    }

    gerarLote(dataref, tipo): Observable<any> {
      return this.http.post(AppConstants.API_ROOT + '/api/GestaoCarga?' + 'dataref=' + dataref + '&tipo=' + tipo + '&codUnidade=0',
        { 'dataref': dataref, 'tipo': tipo.toString(), 'codUnidade': 0} )
        .map((res: Response) => res.json())
        .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }

}
