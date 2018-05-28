import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }

  Login(user, onSuccess) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json; charset=utf-8',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET, POST, PATCH, PUT, DELETE, OPTIONS',
        'Access-Control-Allow-Headers': 'Origin, Content-Type, X-Auth-Token'
      })
    };

    const url = 'http://api.cameronwagstaff.net/api/Account/Login';
    const req = this.httpClient.post(url, user, httpOptions );
    const promise = req.toPromise();

    promise.then(
      onSuccess,
      (reason) => console.log(reason)
    );
  }
}
