import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SpellbookService {

  constructor(private client: HttpClient) { }

  getSpellBook(
    spellBookId: Number,
    onSuccess,
    onFail = (reason) => console.log(reason)) {
      const url = 'http://api.cameronwagstaff.net/api/SpellBooks/';

      const req = this.client.get(url + spellBookId + '?populate', {withCredentials: true});

      var promise = req.toPromise();

      promise.then(
        onSuccess,
        onFail
      );
  }
}
