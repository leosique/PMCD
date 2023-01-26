import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GeneralTopBarComponent } from './general-top-bar/general-top-bar.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { EntradasPendentesComponent } from './entradas-pendentes/entradas-pendentes.component';
import { EntradasAprovadasComponent } from './entradas-aprovadas/entradas-aprovadas.component';
import { PermissoesComponent } from './permissoes/permissoes.component';
import { CadastroVeiculoComponent } from './cadastro-veiculo/cadastro-veiculo.component';
import { CadastroMotoristaComponent } from './cadastro-motorista/cadastro-motorista.component';
import { CadastroAjudanteComponent } from './cadastro-ajudante/cadastro-ajudante.component';


@NgModule({
  declarations: [
    AppComponent,
    GeneralTopBarComponent,
    TopBarComponent,
    EntradasPendentesComponent,
    EntradasAprovadasComponent,
    PermissoesComponent,
    CadastroVeiculoComponent,
    CadastroMotoristaComponent,
    CadastroAjudanteComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path: '', component: EntradasPendentesComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
