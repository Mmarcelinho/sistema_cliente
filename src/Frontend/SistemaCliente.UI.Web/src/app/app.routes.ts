import { Routes } from '@angular/router';
import { ClientesComponent } from './clientes/clientes.component';
import { ClientesListComponent } from './clientes/clientes-list/clientes-list.component';
import { ClientesShowComponent } from './clientes/clientes-show/clientes-show.component';
import { ClientesEditComponent } from './clientes/clientes-edit/clientes-edit.component';
import { ClientesDeleteComponent } from './clientes/clientes-delete/clientes-delete.component';
import { ClientesNewComponent } from './clientes/clientes-new/clientes-new.component';

export const routes: Routes = [
  {
    path: 'clientes',
    loadComponent: () =>
      import('./clientes/clientes.component').then((c) => c.ClientesComponent),
    children: [
      {
        path: '',
        loadComponent: () =>
          import('./clientes/clientes-list/clientes-list.component').then((c) => c.ClientesListComponent)
      },
      {
        path: 'exibir/:id',
        loadComponent: () =>
          import('./clientes/clientes-show/clientes-show.component').then((c) => c.ClientesShowComponent)
      },
      {
        path: 'editar/:id',
        loadComponent: () =>
          import('./clientes/clientes-edit/clientes-edit.component').then((c) => c.ClientesEditComponent)
      },
      {
        path: 'deletar/:id',
        loadComponent: () =>
          import('./clientes/clientes-delete/clientes-delete.component').then((c) => c.ClientesDeleteComponent)
      },
      {
        path: 'registrar',
        loadComponent: () =>
          import('./clientes/clientes-new/clientes-new.component').then((c) => c.ClientesNewComponent)
      }
    ],
  },
];
