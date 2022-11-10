import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginSegurancaComponent } from './login-seguranca/login-seguranca.component';
import { EntradasPendentesComponent } from './entradas-pendentes/entradas-pendentes.component';

const routes: Routes = [
  {path:'login', component:LoginSegurancaComponent},
  {path: 'entradas-pendentes', component:EntradasPendentesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
