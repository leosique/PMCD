import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginExternoComponent } from './login-externo/login-externo.component';
import { ListaFretesComponent } from './lista-fretes/lista-fretes.component';
import { CadastroVeiculoComponent } from './cadastro-veiculo/cadastro-veiculo.component';
import { CadastroAjudanteComponent } from './cadastro-ajudante/cadastro-ajudante.component';
import { CadastroMotoristaComponent } from './cadastro-motorista/cadastro-motorista.component';
import { CadastroTransportadoraComponent } from './cadastro-transportadora/cadastro-transportadora.component';

const routes: Routes = [
  {path:'login',component:LoginExternoComponent},
  {path:'lista-fretes',component:ListaFretesComponent},
  {path:'cadastro-veiculo', component:CadastroVeiculoComponent},
  {path:'cadastro-motorista', component:CadastroMotoristaComponent},
  {path:'cadastro-ajudante', component:CadastroAjudanteComponent},
  {path:'cadastro-transportadora', component:CadastroTransportadoraComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
