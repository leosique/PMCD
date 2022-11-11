import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginExternoComponent } from './login-externo/login-externo.component';
import { ListaFretesComponent } from './lista-fretes/lista-fretes.component';
import { CadastroComponent } from './cadastro/cadastro.component';
const routes: Routes = [
  {path:'login',component:LoginExternoComponent},
  {path:'lista-fretes',component:ListaFretesComponent},
  {path:'cadastro', component:CadastroComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
