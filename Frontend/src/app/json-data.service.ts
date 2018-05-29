import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers, ResponseContentType, BaseRequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';


@Injectable()
export class JsonDataService {

  constructor(private http: Http) {}

  // getUser(): Observable<any> {
  //   return this.http.get('https://jsonplaceholder.typicode.com/users')
  //   .map((res:Response) => res.json())
  //   .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
  // }

  getChargeManagementById(id): Observable<any> {
      return this.http.get('https://jsonplaceholder.typicode.com/users/' + id);
  }

// http://192.168.0.240:1741/

  // getChargeManagement(): Observable<Array<any>> {
  getChargeManagement(): Observable<any> {
    let headers = new Headers({ 'X-Authorization': 'Bearer eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJhZG1pbiIsInNjb3BlcyI6WyJBRE1JTklTVFJBRE9SIl0sImlzcyI6Ind3dy5reXJvcy5jb20uYnIiLCJpYXQiOjE1MjU3MjUwNzMsImV4cCI6NjE1MjU3MjUwNzN9.VztqfEdFa9UifIMeYdMRbX0SK_VmiVC962pyFQlWHXXZwRtUZaP-uLk8DV2awptHIu4eWw9v04v3tqagvbuQtw' });
    let options = new RequestOptions ({ headers: headers });
    return this.http.get('https://jsonplaceholder.typicode.com/users', options)
    .map(response => response.json());
  }


}
