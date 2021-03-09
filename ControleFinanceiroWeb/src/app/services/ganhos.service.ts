import { Ganho } from './../models/ganho.model';
import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json',
    'Authorization' : `Bearer ${localStorage.getItem('TokenUsuarioLogado')}`
  })
};


@Injectable({
  providedIn: 'root'
})
export class GanhosService {

url = 'api/Ganhos';

  constructor(private http: HttpClient) { }

  BuscarGanhosPorUsuarioId(usuarioId: string): Observable<Ganho[]>{
    const apiUrl = `${this.url}/BuscarGanhosPorUsuarioId/${usuarioId}`;
    return this.http.get<Ganho[]>(apiUrl);
  }

  BuscarGanhoPorId(ganhoId: number) : Observable<Ganho>{
    const apiUrl = `${this.url}/${ganhoId}`;
    return this.http.get<Ganho>(apiUrl);
  }

  CriarGanho(ganho: Ganho) : Observable<any>{
    return this.http.post<Ganho>(this.url, ganho, httpOptions);
  }

  AlterarGanho(ganhoId: number, ganho: Ganho) : Observable<any>{
    const apiUrl = `${this.url}/${ganhoId}`;
    return this.http.put<Ganho>(apiUrl, ganho, httpOptions);
  }

  RemoverGanho(ganhoId: number) : Observable<any>{
    const apiUrl = `${this.url}/${ganhoId}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }

  FiltrarGanhos(nomeCategoria: string): Observable<Ganho[]>{
    console.log(nomeCategoria);
    const apiUrl = `${this.url}/FiltrarGanhos/${nomeCategoria}`;
    return this.http.get<Ganho[]>(apiUrl);
  }
}