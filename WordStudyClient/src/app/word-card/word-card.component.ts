import { Component, OnInit, Input } from '@angular/core';
import { Word } from '../_models/word';

@Component({
  selector: 'app-word-card',
  templateUrl: './word-card.component.html',
  styleUrls: ['./word-card.component.css']
})
export class WordCardComponent implements OnInit {
  @Input() word: Word;
  constructor() { }

  ngOnInit() {
  }

}
