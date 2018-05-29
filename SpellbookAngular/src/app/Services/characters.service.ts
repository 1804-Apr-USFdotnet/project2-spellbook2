import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CharactersService {

  constructor(private httpClient: HttpClient) { }

  getCharacters(onSuccess) {
    const url = 'http://api.cameronwagstaff.net/api/character';
    const req = this.httpClient.get(url, {withCredentials: true});
    const promise = req.toPromise();

    promise.then(
      onSuccess,
      (reason) => console.log(reason)
    );
  }
}
