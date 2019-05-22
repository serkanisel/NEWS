import { Injectable } from '@angular/core';
import { List } from '../_models/List';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ListService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getLists(): Observable<List[]> {
    return this.http.get<List[]>(this.baseUrl + 'Lists');
  }
}
