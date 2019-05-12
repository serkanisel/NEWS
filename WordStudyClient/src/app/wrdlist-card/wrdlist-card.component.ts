import { Component, OnInit, Input } from '@angular/core';
import { WrdList } from '../_models/WrdList';

@Component({
  selector: 'app-wrdlist-card',
  templateUrl: './wrdlist-card.component.html',
  styleUrls: ['./wrdlist-card.component.css']
})
export class WrdlistCardComponent implements OnInit {
@Input() WrdList: WrdList;

  constructor() { }

  ngOnInit() {
  }

}
