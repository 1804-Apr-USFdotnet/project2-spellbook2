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

  levelsArr: String[] = [];

  @Input()
  filter:string;

  @Output()
  selectFilter = new EventEmitter<string>();

  createFilter(){
    this.levelsArr.sort();
    this.selectFilter.emit("levels="+this.levelsArr.toString());
  }

  activateFilter(event, id){
    console.log(event);
    if(event.target.checked)
    {
      this.levelsArr = [...this.levelsArr, id];
    }
    else {
      this.levelsArr = this.levelsArr.filter(i => i !== id)
    }
  }

  constructor() { }

  ngOnInit() {
  }


}
