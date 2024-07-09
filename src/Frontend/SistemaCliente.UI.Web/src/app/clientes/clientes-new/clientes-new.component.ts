import { Component, OnInit, inject } from '@angular/core';
import { MaterialModule } from '../../material.module';
import { AsyncPipe } from '@angular/common';
import { LoadingBarComponent } from '../../loading-bar.component';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ClienteService } from '../cliente.service';
import { Cliente } from '../cliente.dto';
import { Observable, lastValueFrom, of } from 'rxjs';
import { ClientesFormComponent } from '../clientes-form/clientes-form.component';

@Component({
  selector: 'app-clientes-new',
  standalone: true,
  imports: [
    MaterialModule,
    AsyncPipe,
    LoadingBarComponent,
    RouterLink,
    ClientesFormComponent,
  ],
  templateUrl: './clientes-new.component.html',
  styles: ``
})
export class ClientesNewComponent implements OnInit {
  router = inject(Router);
  clienteService = inject(ClienteService);
  clienteObservable!: Observable<Cliente>;
  cliente!: Cliente;

  async ngOnInit() {
    this.clienteObservable = await of(this.clienteService.Criar());
    this.cliente = await lastValueFrom(this.clienteObservable);
  }

  async onSave(cliente: Cliente) {
    const resultado = await lastValueFrom(this.clienteService.Registrar(cliente));
    this.router.navigate(['/clientes/exibir/', resultado.id]);
  }

  onBack() {
    this.router.navigate(['/clientes']);
  }
}
