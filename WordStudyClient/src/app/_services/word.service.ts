import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Word } from '../_models/word';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WordService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getWords(): Observable<Word[]> {
    return this.http.get<Word[]>(this.baseUrl  + 'word');
  }

  getWord(id): Observable<Word> {
    return this.http.get<Word>(this.baseUrl + 'word/' + id);
  }

}
