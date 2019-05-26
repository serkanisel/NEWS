import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sentence } from '../_models/sentence';

@Injectable({
  providedIn: 'root'
})
export class SentenceService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getSentences(): Observable<Sentence[]> {
    return this.http.get<Sentence[]>(this.baseUrl  + 'sentences');
  }

  getSentence(id): Observable<Sentence> {
    return this.http.get<Sentence>(this.baseUrl + 'sentences/' + id);
  }

}
