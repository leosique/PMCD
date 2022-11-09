import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginSegurancaComponent } from './login-seguranca/login-seguranca.component';

const routes: Routes = [
  {path:'login', component:LoginSegurancaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
