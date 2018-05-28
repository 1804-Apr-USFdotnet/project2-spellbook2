import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SpellService {

  constructor(private httpClient: HttpClient) { }

  getAllSpells(onSuccess) {
    const url = 'http://api.cameronwagstaff.net/api/spells';
    const req = this.httpClient.get(url);
    const promise = req.toPromise();

    promise.then(
      onSuccess,
      (reason) => console.log(reason)
    );
  }

  searchSpells(filter, onSuccess) {
    const url = 'http://api.cameronwagstaff.net/api/spells?' + filter;
    const req = this.httpClient.get(url);
    const promise = req.toPromise();

    promise.then(
      onSuccess,
      (reason) => console.log(reason)
    );
  }
}
