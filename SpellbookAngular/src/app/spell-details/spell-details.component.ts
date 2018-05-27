import { Component, OnInit, Input } from '@angular/core';
import { Spell } from '../Models/Spell';

@Component({
  selector: 'app-spell-details',
  templateUrl: './spell-details.component.html',
  styleUrls: ['./spell-details.component.css']
})
export class SpellDetailsComponent implements OnInit {

  @Input()
  spell: Spell;

  constructor() { }

  ngOnInit() {
  }

}
