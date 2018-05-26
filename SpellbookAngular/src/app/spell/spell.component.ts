import { Component, OnInit } from '@angular/core';
import { Spell } from '../Models/Spell';
import { SpellService } from '../Services/spell.service';

@Component({
  selector: 'app-spell',
  templateUrl: './spell.component.html',
  styleUrls: ['./spell.component.css']
})
export class SpellComponent implements OnInit {

  filter: String = "levels=1"

  spells: Spell[]

  constructor(private spellSvc: SpellService) { }

  ngOnInit() {
    this.getSpells();
  }

  getFilter(filter) {
    this.filter=filter;
  }
  
  getSpells(){
    this.spellSvc.getAllSpells((response)=> {
      this.spells= response;
    })
  }

}
