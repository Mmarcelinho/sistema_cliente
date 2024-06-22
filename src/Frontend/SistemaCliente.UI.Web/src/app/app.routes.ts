import { Routes } from '@angular/router';
import { ClientesComponent } from './clientes/clientes.component';
import { ClientesListComponent } from './clientes/clientes-list/clientes-list.component';
import { ClientesShowComponent } from './clientes/clientes-show/clientes-show.component';
import { ClientesEditComponent } from './clientes/clientes-edit/clientes-edit.component';
import { ClientesDeleteComponent } from './clientes/clientes-delete/clientes-delete.component';

export const routes: Routes = [
  {
    path: 'clientes',
    component: ClientesComponent,
    children: [
      {
        path: '',
        component: ClientesListComponent
      },
      {
        path: 'exibir/:id',
        component: ClientesShowComponent
      },
      {
        path: 'editar/:id',
        component: ClientesEditComponent
      },
      {
        path: 'deletar/:id',
        component: ClientesDeleteComponent
      }
    ],
  },
];
