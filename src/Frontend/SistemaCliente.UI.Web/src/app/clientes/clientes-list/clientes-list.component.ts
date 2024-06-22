import { Component, OnInit } from '@angular/core';
import { Cliente } from '../cliente.dto';
import { Observable, lastValueFrom } from 'rxjs';
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
  clientes!: Cliente[];
  clienteObservable!: Observable<Cliente[]>;

  constructor(private clienteService: ClienteService) {}

  async ngOnInit() {
    this.clienteObservable = this.clienteService.RecuperarTodos();
    this.clientes = await lastValueFrom(this.clienteObservable);
  }
}
