import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SucessoComponent } from './sucesso/sucesso.component';

const routes: Routes = [
  {path:'sucesso', component:SucessoComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
