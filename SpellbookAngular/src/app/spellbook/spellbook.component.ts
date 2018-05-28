import { Component, OnInit, Input } from '@angular/core';
import { Spellbook } from '../Models/Spellbook';
import { SpellbookService } from '../services/spellbook.service';


@Component({
  selector: 'app-spellbook',
  templateUrl: './spellbook.component.html',
  styleUrls: ['./spellbook.component.css']
})
export class SpellbookComponent implements OnInit {
  id: Number;
  spellBook: Spellbook;

  constructor(private service: SpellbookService) { }

  ngOnInit() {
    this.id = 1;
    this.getSpellBook();
  }

  getId(id) {
    this.id = id;
    this.getSpellBook();
  }

  getSpellBook() {
    this.service.getSpellBook(this.id, (response) => {
      this.spellBook = response;
    });
  }
}
