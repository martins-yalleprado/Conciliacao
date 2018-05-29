import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';

import { Observable } from 'rxjs/Rx';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class PendingConciliationService {

  private url: string = 'https://jsonplaceholder.typicode.com/';

  constructor(private http: Http) { }

    getPendingConciliation(): Observable<any> {
      return this.http.get(`${this.url}/users`)
      .map((res:Response) => res.json())
      .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
    }

}
