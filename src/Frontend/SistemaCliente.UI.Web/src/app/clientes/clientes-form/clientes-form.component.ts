import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  inject,
} from '@angular/core';
import { MaterialModule } from '../../material.module';
import { Cliente } from '../cliente.dto';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Porte } from '../enum/porte';

@Component({
  selector: 'app-clientes-form',
  standalone: true,
  imports: [MaterialModule],
  templateUrl: './clientes-form.component.html',
  styles: ``,
})
export class ClientesFormComponent implements OnInit {
  @Input({ required: true })
  cliente!: Cliente;
  @Output() salvar = new EventEmitter<Cliente>();
  @Output() voltar = new EventEmitter();
  clienteForm!: FormGroup;
  private fb = inject(FormBuilder);

  porteOptions = [
    { value: Porte.PEQUENA, label: 'Pequena' },
    { value: Porte.MEDIA, label: 'Média' },
    { value: Porte.GRANDE, label: 'Grande' },
  ];

  ngOnInit(): void {
    this.clienteForm = this.fb.group({
      id: [this.cliente.id],
      nomeEmpresa: [
        this.cliente.nomeEmpresa,
        [Validators.required, Validators.minLength(3)],
      ],
      porte: [this.cliente.porte, [Validators.required]],
    });
  }

  onSubmit() {
    this.salvar.emit(this.clienteForm.value as Cliente);
  }

  onBack(event: Event) {
    event.preventDefault();
    this.voltar.emit();
  }
}
