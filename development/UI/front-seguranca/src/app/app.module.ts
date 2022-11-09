import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GeneralTopBarComponent } from './general-top-bar/general-top-bar.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { LoginSegurancaComponent } from './login-seguranca/login-seguranca.component';
import { EntradasPendentesComponent } from './entradas-pendentes/entradas-pendentes.component';

@NgModule({
  declarations: [
    AppComponent,
    GeneralTopBarComponent,
    TopBarComponent,
    LoginSegurancaComponent,
    EntradasPendentesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path: '', component: LoginSegurancaComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
