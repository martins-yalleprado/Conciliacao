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
    return  this.http.delete(AppConstants.API_ROOT+'/api/GestaoCarga', id).catch
    ((error:any) => Observable.throw(error.json().error || 'Server error'));
    }

    mudarVersao(objeto) {
      this.http.put('https://jsonplaceholder.typicode.com/api/GestaoCarga/change', objeto);
    }

    gerarLote(dataref) : Promise<any> {
        return this.http
          .post(AppConstants.API_ROOT+'/api/GestaoCarga?'+dataref,{ headers: this.headers })
          .toPromise()
          .then(res => res);
    }

    // Não utilizaremos este método, favor ignorar
    // this.http.post('http://jsonplaceholder.typicode.com/posts', objeto)
    //       .subscribe(
    //         res => {
    //           console.log(res);
    //         },
    //         err => {
    //           console.log("Error occured");
    //         }
    //       );
    //
    // getChargeManagementById(id): Observable<any> {
    //     return this.http.get('https://jsonplaceholder.typicode.com/users/' + id);
    // }

}
