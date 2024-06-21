import { Porte } from './../../enum/porte';
import { Component, Input } from '@angular/core';
import { MaterialModule } from '../../../material.module';
import { Cliente } from '../../cliente.dto';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-clientes-card',
  standalone: true,
  imports: [MaterialModule, RouterLink],
  templateUrl: './clientes-card.component.html',
  styles: ``
})
export class ClientesCardComponent {
  @Input({ required: true })
  cliente!: Cliente;

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

