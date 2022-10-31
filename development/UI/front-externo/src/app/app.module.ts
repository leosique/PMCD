import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginExternoComponent } from './login-externo/login-externo.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginExternoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path: '', component: LoginExternoComponent},
    ])
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
