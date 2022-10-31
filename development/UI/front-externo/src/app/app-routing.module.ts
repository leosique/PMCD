import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginExternoComponent } from './login-externo/login-externo.component';

const routes: Routes = [
  {path:'login',component:LoginExternoComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
