import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginAdmComponent } from './login-adm/login-adm.component';
import { PermissionsComponent } from './permissions/permissions.component';

const routes: Routes = [
  {path: 'login', component:LoginAdmComponent},
  {path: 'permissions', component:PermissionsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
