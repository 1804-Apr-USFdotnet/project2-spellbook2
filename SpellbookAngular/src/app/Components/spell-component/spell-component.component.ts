import { Component, OnInit } from '@angular/core';
import { Spell } from '../../Models/Spell';
import { SpellService } from '../../Services/spell.service';

@Component({
  selector: 'app-spell-component',
  templateUrl: './spell-component.component.html',
  styleUrls: ['./spell-component.component.css']
})
export class SpellComponentComponent implements OnInit {

  spells: Spell[]

  constructor(private spellSvc: SpellService) { }

  ngOnInit() {
  }

  getSpells(){
    this.spellSvc.getAllSpells((response)=> {
      this.spells= response;
    })
  }

}
