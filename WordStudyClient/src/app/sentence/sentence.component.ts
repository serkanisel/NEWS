import { Component, OnInit } from '@angular/core';
import { SentenceService } from '../_services/sentence.service';
import { AlertifyService } from '../_services/Alertify.service';
import { Sentence } from '../_models/sentence';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sentence',
  templateUrl: './sentence.component.html',
  styleUrls: ['./sentence.component.css']
})
export class SentenceComponent implements OnInit {
  sentences: Sentence[];

  constructor(private sentenceService: SentenceService, private alertifyService: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.sentences = data['sentences'];
    });
  }

}
