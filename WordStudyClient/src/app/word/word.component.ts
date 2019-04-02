import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-word',
  templateUrl: './word.component.html',
  styleUrls: ['./word.component.css']
})
export class WordComponent implements OnInit {
  word: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getWords();
  }

  getWords() {
      this.http.get('http://localhost:5000/api/word').subscribe(response => {
        this.word = response;
        console.log(this.word);
      }, error => {
        console.log(error);
      });
  }

}
