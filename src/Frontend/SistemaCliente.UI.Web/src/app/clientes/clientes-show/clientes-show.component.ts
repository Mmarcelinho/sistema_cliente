import { Component, inject } from '@angular/core';
import { MaterialModule } from '../../material.module';
import { AsyncPipe } from '@angular/common';
import { LoadingBarComponent } from '../../loading-bar.component';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ClienteService } from '../cliente.service';
import { Cliente } from '../cliente.dto';
import { Observable, lastValueFrom } from 'rxjs';
import { Porte } from '../enum/porte';

@Component({
  selector: 'app-clientes-show',
  standalone: true,
  imports: [MaterialModule, AsyncPipe, LoadingBarComponent, RouterLink],
  templateUrl: './clientes-show.component.html',
  styles: ``,
})
export class ClientesShowComponent {
  route = inject(ActivatedRoute);
  clienteService = inject(ClienteService);
  cliente!: Cliente;
  clienteObservable!: Observable<Cliente>;

  async ngOnInit() {
    const id: Number = +(this.route.snapshot.paramMap.get('id') || 0);
    this.clienteObservable = this.clienteService.RecuperarPorId(id);
    this.cliente = await lastValueFrom(this.clienteObservable);
  }

  getPorteString(porte: Porte): string {
    switch (porte) {
      case Porte.PEQUENA:
        return 'Pequena';
      case Porte.MEDIA:
        return 'Média';
      case Porte.GRANDE:
        return 'Grande';
      default:
        return 'Desconhecido';
    }
  }
}
