import { Routes } from '@angular/router';
import { ClientesComponent } from './clientes/clientes.component';
import { ClientesListComponent } from './clientes/clientes-list/clientes-list.component';

export const routes: Routes = [
  {
    path: 'clientes',
    component: ClientesComponent,
    children: [
      {
        path: '',
        component: ClientesListComponent,
      },
    ],
  },
];
