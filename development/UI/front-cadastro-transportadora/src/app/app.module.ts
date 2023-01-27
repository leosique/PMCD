import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { SucessoComponent } from './sucesso/sucesso.component';

@NgModule({
  declarations: [
    AppComponent,
    CadastroComponent,
    TopBarComponent,
    SucessoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path: '', component: CadastroComponent},
     
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
