import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginAdmComponent } from './login-adm/login-adm.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { GeneralTopBarComponent } from './general-top-bar/general-top-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginAdmComponent,
    TopBarComponent,
    GeneralTopBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path: '', component: LoginAdmComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
