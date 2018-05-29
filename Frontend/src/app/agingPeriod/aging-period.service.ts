import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { AppConstants } from '../app.constants';
import { AuthService } from '../auth.service';

import { Observable } from 'rxjs/Rx';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class AgingPeriodService {

  constructor(private http: Http) { }

    getBuscaPeriodos(periodo, ativo): Observable<any> {
      return this.http.get(AppConstants.API_ROOT+'/api/Periodo?nome='+periodo+'&ativo='+ativo)
      .map((res:Response) => res.json())
      .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
    }
    
    buscaPeriodos(): Observable<any> {
      return this.http.get(AppConstants.API_ROOT+'/api/Periodo?nome=')
      .map((res:Response) => res.json())
      .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
    }

    removerPeriodo(id) {
      return this.http.delete(AppConstants.API_ROOT +'/api/Periodo' , id)
      .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
    }

    salvarNovoPeriodo(objeto) {
      debugger;
     return this.http.post(AppConstants.API_ROOT +'/api/Periodo', objeto)
     .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
    }

    atualizarPeriodo(objeto) {
      return this.http.put(AppConstants.API_ROOT +'/api/Periodo', objeto)
      .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
    }

    buscaIntervalo(periodo): Observable<any> {
      return this.http.get(AppConstants.API_ROOT+'/api/Intervalo?periodo='+periodo)
      .map((res:Response) => res.json())
      .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
    }
}
