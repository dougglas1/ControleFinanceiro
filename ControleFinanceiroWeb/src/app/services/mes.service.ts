import { Mes } from './../models/mes.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MesService {

  url = 'api/Meses';

  constructor(private http: HttpClient) { }

  BuscarTodos(): Observable<Mes[]>{
    return this.http.get<Mes[]>(this.url);
  }
}