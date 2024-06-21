import { Component } from '@angular/core';
import { MaterialModule } from '../material.module';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-clientes',
  standalone: true,
  imports: [MaterialModule, RouterOutlet],
  templateUrl: './clientes.component.html',
  styles: ``
})
export class ClientesComponent {

}
