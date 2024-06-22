import { Component, OnInit, inject } from '@angular/core';
import { MaterialModule } from '../../material.module';
import { AsyncPipe } from '@angular/common';
import { LoadingBarComponent } from '../../loading-bar.component';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ClientesFormComponent } from '../clientes-form/clientes-form.component';
import { Cliente } from '../cliente.dto';
import { ClienteService } from '../cliente.service';
import { Observable, lastValueFrom } from 'rxjs';
@Component({
  selector: 'app-clientes-delete',
  standalone: true,
  imports: [
    MaterialModule,
    AsyncPipe,
    LoadingBarComponent,
    RouterLink,
    ClientesFormComponent,
  ],
  templateUrl: './clientes-delete.component.html',
  styles: ``,
})
export class ClientesDeleteComponent implements OnInit {
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

  async confirmDelete() {
    this.clienteObservable = this.clienteService.Deletar(this.cliente.id);
    this.cliente = await lastValueFrom(this.clienteObservable);
    this.router.navigate(['/clientes']);
  }
}
