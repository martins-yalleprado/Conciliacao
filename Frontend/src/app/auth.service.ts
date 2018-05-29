import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import * as jwt_decode from 'jwt-decode';
import { AppConstants } from './app.constants';

export const TOKEN_NAME: string = 'jwt_token';

import { Observable } from 'rxjs/Rx';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class AuthService {


  private headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
  
  constructor(private http: Http) { }

  getToken(): string {
    return localStorage.getItem(TOKEN_NAME);
  }

  setToken(token: string): void {
    const usuarioObj = {
      firstName: 'Usuario teste',
      menu: '',
      quantidade_avisos: '4'};

    localStorage.setItem(TOKEN_NAME, token);
    localStorage.setItem('user', JSON.stringify(usuarioObj));
  }

  removeToken(): void {
    localStorage.removeItem(TOKEN_NAME);
    localStorage.removeItem('user');
  }

  getTokenExpirationDate(token: string): Date {
    const decoded = jwt_decode(token);
    if (decoded.exp === undefined) {
      return null;
    }

    const date = new Date(0);
    date.setUTCSeconds(decoded.exp);
    return date;
  }

  isTokenExpired(token?: string): boolean {
    if (!token) {
      token = this.getToken();
    }

    if (!token) {
      return true;
    }

    const date = this.getTokenExpirationDate(token);

    if (date === undefined) {
      return false;
    }
    return !(date.valueOf() > new Date().valueOf());
  }

  login(user): Promise<any> {
    return this.http
      .post(AppConstants.API_ROOT + '/oauth2/token', user, { headers: this.headers })
      .toPromise()
      .then(res => res);
  }

}
