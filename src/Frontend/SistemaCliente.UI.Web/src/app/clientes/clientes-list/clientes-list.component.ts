import { Component, OnInit, inject } from '@angular/core';
import { Cliente } from '../cliente.dto';
import { EMPTY, Observable, catchError } from 'rxjs';
import { ClienteService } from '../cliente.service';
import { MaterialModule } from '../../material.module';
import { LoadingBarComponent } from '../../loading-bar.component';
import { AsyncPipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ClientesCardComponent } from './clientes-card/clientes-card.component';

@Component({
  selector: 'app-clientes-list',
  standalone: true,
  imports: [MaterialModule, LoadingBarComponent, AsyncPipe, RouterLink, ClientesCardComponent],
  templateUrl: './clientes-list.component.html',
  styles: ``,
})
export class ClientesListComponent implements OnInit {
  clientes$!: Observable<Cliente[]>;
  error!: string;
  private clienteService = inject(ClienteService);


  async ngOnInit() {
    this.clientes$ = this.clienteService.RecuperarTodos().pipe(
      catchError(error => {
        this.error = error.message
        return EMPTY
      })
    )
  }
}
