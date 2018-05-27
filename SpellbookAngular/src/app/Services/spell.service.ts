import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SpellService {

  constructor(private httpClient: HttpClient) { }

  getAllSpells(onSuccess) {
    var url = "http://api.cameronwagstaff.net/api/spells";
    var req = this.httpClient.get(url);
    var promise = req.toPromise();

    promise.then(
      onSuccess,
      (reason) => console.log(reason)
    );
  }

  searchSpells(filter, onSuccess) {
    var url = "http://api.cameronwagstaff.net/api/spells?" + filter;
    var req = this.httpClient.get(url);
    var promise = req.toPromise();

    promise.then(
      onSuccess,
      (reason) => console.log(reason)
    )
  }
}
