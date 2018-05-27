import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-spell-filter',
  templateUrl: './spell-filter.component.html',
  styleUrls: ['./spell-filter.component.css']
})
export class SpellFilterComponent implements OnInit {

  levels = {
    filter: "changed",
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

  @Input()
  filter:string;

  @Output()
  selectFilter = new EventEmitter<string>();

  onSelectFilter(filter: string) {
    this.selectFilter.emit(filter);
  }

  constructor() { }

  ngOnInit() {
  }


}
