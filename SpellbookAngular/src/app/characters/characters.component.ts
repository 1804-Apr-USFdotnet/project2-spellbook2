import { Component, OnInit } from '@angular/core';
import { Character } from '../Models/Characters';
import { CharactersService } from '../Services/characters.service';

@Component({
  selector: 'app-characters',
  templateUrl: './characters.component.html',
  styleUrls: ['./characters.component.css']
})
export class CharactersComponent implements OnInit {
  characters: Character[];

  constructor(private characterSvc: CharactersService) { }

  ngOnInit() {
    this.getCharacters();
  }

  getCharacters() {
    this.characterSvc.getCharacters( (response) => {
      this.characters = response;
    });
  }

}
