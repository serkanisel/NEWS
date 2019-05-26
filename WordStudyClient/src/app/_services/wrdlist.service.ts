import { Injectable } from '@angular/core';
import { WrdList } from '../_models/WrdList';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WrdlistService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getWrdLists(): Observable<WrdList[]> {
    return this.http.get<WrdList[]>(this.baseUrl + 'WrdList');
  }
}
