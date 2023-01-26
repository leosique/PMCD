import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EntradasPendentesComponent } from './entradas-pendentes/entradas-pendentes.component';
import { EntradasAprovadasComponent } from './entradas-aprovadas/entradas-aprovadas.component';
import { PermissoesComponent } from './permissoes/permissoes.component';

const routes: Routes = [
  {path: 'entradas-pendentes', component:EntradasPendentesComponent},
  {path: 'entradas-aprovadas', component:EntradasAprovadasComponent},
  {path: 'permissoes', component:PermissoesComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
