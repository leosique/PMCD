import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginExternoComponent } from './login-externo/login-externo.component';
import { ListaFretesComponent } from './lista-fretes/lista-fretes.component';
const routes: Routes = [
  {path:'login',component:LoginExternoComponent},
  {path:'lista-fretes',component:ListaFretesComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
