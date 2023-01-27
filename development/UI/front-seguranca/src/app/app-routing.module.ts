import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EntradasPendentesComponent } from './entradas-pendentes/entradas-pendentes.component';
import { EntradasAprovadasComponent } from './entradas-aprovadas/entradas-aprovadas.component';
import { PermissoesComponent } from './permissoes/permissoes.component';
import { CadastroVeiculoComponent } from './cadastro-veiculo/cadastro-veiculo.component';
import { CadastroMotoristaComponent } from './cadastro-motorista/cadastro-motorista.component';
import { CadastroAjudanteComponent } from './cadastro-ajudante/cadastro-ajudante.component';
import { Error404Component } from './error404/error404.component';

const routes: Routes = [
 
  {path: 'entradas-pendentes', component:EntradasPendentesComponent},
  {path: 'entradas-aprovadas', component:EntradasAprovadasComponent},
  {path: 'permissoes', component:PermissoesComponent},
  {path: 'cadastro-veiculo', component:CadastroVeiculoComponent},
  {path: 'cadastro-motorista', component:CadastroMotoristaComponent},
  {path: 'cadastro-ajudante', component:CadastroAjudanteComponent},
  {path: 'erro404', component:Error404Component},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
