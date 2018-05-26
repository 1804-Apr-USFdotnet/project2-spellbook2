import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-spell-filter',
  templateUrl: './spell-filter.component.html',
  styleUrls: ['./spell-filter.component.css']
})
export class SpellFilterComponent implements OnInit {

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
