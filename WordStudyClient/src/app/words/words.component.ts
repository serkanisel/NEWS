import { Component, OnInit } from '@angular/core';
import { WordService } from '../_services/word.service';
import { Word } from '../_models/word';
import { AlertifyService } from '../_services/Alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-words',
  templateUrl: './words.component.html',
  styleUrls: ['./words.component.css']
})
export class WordsComponent implements OnInit {
  words: Word[];

  constructor(private wordService: WordService, private alertifyService: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.words = data['words'];
    });
  }

}
