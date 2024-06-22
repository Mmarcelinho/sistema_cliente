import { Component, inject } from '@angular/core';
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
export class ClientesNewComponent {
  route = inject(ActivatedRoute);
  router = inject(Router);
  clienteService = inject(ClienteService);
  cliente!: Cliente;
  clienteObservable!: Observable<Cliente>;

  async ngOnInit() {
    this.clienteObservable = await of(this.clienteService.Criar())
    this.cliente = await lastValueFrom(this.clienteObservable);
  }

  async onSave(cliente: Cliente) {
    this.clienteObservable = this.clienteService.Registrar(cliente);
    const resultado = this.cliente = await lastValueFrom(this.clienteObservable);
    this.router.navigate(['/clientes/exibir/', resultado.id]);
  }

  onBack() {
    this.router.navigate(['/clientes']);
  }
}
