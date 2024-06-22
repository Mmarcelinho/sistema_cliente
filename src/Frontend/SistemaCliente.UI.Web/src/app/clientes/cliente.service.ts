import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from './cliente.dto';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient) { }

  public RecuperarTodos(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(environment.api + 'cliente');
  }

  public RecuperarPorId(id: Number): Observable<Cliente> {
    return this.http.get<Cliente>(environment.api + 'cliente/' + id);
  }
}
