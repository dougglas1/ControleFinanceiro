import { Tipo } from './../models/tipo.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TiposService {
  url: string = 'api/Tipos';

  constructor(private http: HttpClient) {}

  BuscarTodos(): Observable<Tipo[]> {
    return this.http.get<Tipo[]>(this.url);
  }
}