import { Cartao } from './../models/cartao.model';
import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    Authorization: `Bearer ${localStorage.getItem('TokenUsuarioLogado')}`,
  }),
};

@Injectable({
  providedIn: 'root',
})
export class CartoesService {
  url = 'api/Cartoes';

  constructor(private http: HttpClient) {}

  BuscarCartaoPorId(cartaoId: number): Observable<Cartao> {
    const apiUrl = `${this.url}/${cartaoId}`;
    return this.http.get<Cartao>(apiUrl);
  }

  BuscarCartoesPorUsuarioId(usuarioId: string): Observable<Cartao[]> {
    const apiUrl = `${this.url}/BuscarCartoesPorUsuarioId/${usuarioId}`;
    return this.http.get<Cartao[]>(apiUrl);
  }

  CriarCartao(cartao: Cartao): Observable<any> {
    return this.http.post<Cartao>(this.url, cartao, httpOptions);
  }

  AlterarCartao(cartaoId: number, cartao: Cartao): Observable<any> {
    const apiUrl = `${this.url}/${cartaoId}`;
    return this.http.put<Cartao>(apiUrl, cartao, httpOptions);
  }

  RemoverCartao(cartaoId: number): Observable<any> {
    const apiUrl = `${this.url}/${cartaoId}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }

  FiltrarCartoes(numeroCartao: string): Observable<Cartao[]>{
    const apiUrl = `${this.url}/FiltrarCartoes/${numeroCartao}`;
    return this.http.get<Cartao[]>(apiUrl);
  }
}