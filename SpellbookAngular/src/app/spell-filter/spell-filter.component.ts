import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-spell-filter',
  templateUrl: './spell-filter.component.html',
  styleUrls: ['./spell-filter.component.css']
})
export class SpellFilterComponent implements OnInit {

  levels = {
    zero: false,
    one: false,
    two: false,
    three: false,
    four: false,
    five: false,
    six: false,
    seven: false,
    eight: false,
    nine: false
  };

  classes = {
    Bard: false,
    Cleric: false,
    Druid: false,
    Paladin: false,
    Ranger: false,
    Sorcerer: false,
    Warlock: false,
    Wizard: false
  };

  levelsArr: String[] = [];
  schoolsArr: String[] = [];
  classesArr: String[] = [];

  @Input()
  filter:string;

  @Output()
  selectFilter = new EventEmitter<string>();

  createFilter(){
    this.levelsArr.sort();
    this.classesArr.sort();

    let lev = "levels="+this.levelsArr.toString();
    let classes = "classes="+this.classesArr.toString();

    this.selectFilter.emit(lev+"&"+classes);
  }

  levelsFilter(event, id){
    console.log(event);
    if(event.target.checked)
    {
      this.levelsArr = [...this.levelsArr, id];
    }
    else {
      this.levelsArr = this.levelsArr.filter(i => i !== id)
    }
  }

  schoolsFilter(event, id){
    console.log(event);
    if(event.target.checked)
    {
      this.schoolsArr = [...this.schoolsArr, id];
    }
    else {
      this.schoolsArr = this.schoolsArr.filter(i => i !== id)
    }
  }

  classesFilter(event, id){
    console.log(event);
    if(event.target.checked)
    {
      this.classesArr = [...this.classesArr, id];
      console.log(this.classesArr);
    }
    else {
      this.classesArr = this.classesArr.filter(i => i !== id);
      console.log(this.classesArr);
    }
  }

  constructor() { }

  ngOnInit() {
  }


}
