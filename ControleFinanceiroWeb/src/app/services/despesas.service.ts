import { Despesa } from './../models/despesa.model';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('TokenUsuarioLogado')}`,
  }),
};

@Injectable({
  providedIn: 'root'
})
export class DespesasService {

url = 'api/Despesas';

  constructor(private http: HttpClient) { }

  BuscarDespesasPorUsuarioId(usuarioId: string): Observable<Despesa[]>{
    const apiUrl = `${this.url}/BuscarDespesasPorUsuarioId/${usuarioId}`;
    return this.http.get<Despesa[]>(apiUrl);
  }

  BuscarDespesaPorId(despesaId: number): Observable<Despesa>{
    const apiUrl = `${this.url}/${despesaId}`;
    return this.http.get<Despesa>(apiUrl);
  }

  CriarDespesa(despesa: Despesa): Observable<any>{
    return this.http.post<Despesa>(this.url, despesa, httpOptions);
  }

  AlterarDespesa(despesaId: number, despesa: Despesa): Observable<any>{
    const apiUrl = `${this.url}/${despesaId}`;
    return this.http.put<Despesa>(apiUrl, despesa, httpOptions);
  }

  RemoverDespesa(despesaId: number): Observable<any>{
    const apiUrl = `${this.url}/${despesaId}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }

  FiltrarDespesas(nomeCategoria: string): Observable<Despesa[]>{
    const apiUrl = `${this.url}/FiltrarDespesas/${nomeCategoria}`;
    return this.http.get<Despesa[]>(apiUrl);
  }
}