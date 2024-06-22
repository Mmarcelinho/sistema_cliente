import { Component, inject } from '@angular/core';
import { MaterialModule } from '../../material.module';
import { AsyncPipe } from '@angular/common';
import { LoadingBarComponent } from '../../loading-bar.component';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ClienteService } from '../cliente.service';
import { Cliente } from '../cliente.dto';
import { Observable, lastValueFrom } from 'rxjs';
import { ClientesFormComponent } from '../clientes-form/clientes-form.component';

@Component({
  selector: 'app-clientes-edit',
  standalone: true,
  imports: [
    MaterialModule,
    AsyncPipe,
    LoadingBarComponent,
    RouterLink,
    ClientesFormComponent,
  ],
  templateUrl: './clientes-edit.component.html',
  styles: ``,
})
export class ClientesEditComponent {
  route = inject(ActivatedRoute);
  router = inject(Router);
  clienteService = inject(ClienteService);
  cliente!: Cliente;
  clienteObservable!: Observable<Cliente>;

  async ngOnInit() {
    const id: Number = +(this.route.snapshot.paramMap.get('id') || 0);
    this.clienteObservable = this.clienteService.RecuperarPorId(id);
    this.cliente = await lastValueFrom(this.clienteObservable);
  }

  async onSave(cliente: Cliente) {
    this.clienteObservable = this.clienteService.Registrar(cliente);
    this.cliente = await lastValueFrom(this.clienteObservable);
    this.router.navigate(['/clientes/exibir/', cliente.id]);
  }

  onBack() {
    this.router.navigate(['/clientes/exibir/', this.cliente.id]);
  }
}
