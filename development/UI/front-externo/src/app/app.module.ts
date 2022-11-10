import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginExternoComponent } from './login-externo/login-externo.component';
import { GeneralTopBarComponent } from './general-top-bar/general-top-bar.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { ListaFretesComponent } from './lista-fretes/lista-fretes.component';
import { CadastroComponent } from './cadastro/cadastro.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginExternoComponent,
    GeneralTopBarComponent,
    TopBarComponent,
    ListaFretesComponent,
    CadastroComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path: '', component: LoginExternoComponent},
      {path: '', component: CadastroComponent},
    ])
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
