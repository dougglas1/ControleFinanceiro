import { Funcao } from './../models/funcao.model';
import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('TokenUsuarioLogado')}`
  }),
};

@Injectable({
  providedIn: 'root',
})
export class FuncoesService {
url = 'api/Funcoes';

  constructor(private http: HttpClient) {}

  BuscarTodos(): Observable<Funcao[]>{
    return this.http.get<Funcao[]>(this.url);
  }

  BuscarPorId(funcaoId: string): Observable<Funcao>{
    const apiUrl = `${this.url}/${funcaoId}`;
    return this.http.get<Funcao>(apiUrl);
  }

  CriarFuncao(funcao: Funcao): Observable<any>{
    console.log(funcao);
    return this.http.post<Funcao>(this.url, funcao, httpOptions);
  }

  AlterarFuncao(funcaoId: string, funcao: Funcao): Observable<any>{
    const apiUrl = `${this.url}/${funcaoId}`;
    return this.http.put<Funcao>(apiUrl, funcao, httpOptions);
  }

  RemoverFuncao(funcaoId: string): Observable<any>{
    const apiUrl = `${this.url}/${funcaoId}`;
    return this.http.delete<string>(apiUrl, httpOptions);
  }

  FiltrarFuncoes(nomeFuncao: string): Observable<Funcao[]>{
    const apiUrl = `${this.url}/FiltrarFuncoes/${nomeFuncao}`;
    return this.http.get<Funcao[]>(apiUrl);
  }
}