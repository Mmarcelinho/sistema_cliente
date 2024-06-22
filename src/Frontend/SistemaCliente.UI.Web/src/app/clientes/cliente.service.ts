import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from './cliente.dto';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ClienteService {
  constructor(private http: HttpClient) {}

  public RecuperarTodos(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(environment.api + 'cliente');
  }

  public RecuperarPorId(id: Number): Observable<Cliente> {
    return this.http.get<Cliente>(environment.api + 'cliente/' + id);
  }

  public Registrar(cliente: Cliente): Observable<Cliente> {
    if (cliente.id)
      return this.http.put<Cliente>(
        environment.api + 'cliente/' + cliente.id,
        cliente
      );

    return this.http.post<Cliente>(environment.api + 'cliente', cliente);
  }

  public Deletar(id?: number): Observable<Cliente> {
    return this.http.delete<Cliente>(environment.api + 'cliente/' + id);
  }

  public Criar(): Cliente {
    return {
      id: 0,
      nomeEmpresa: '',
      porte: 0
    }
  }
}
