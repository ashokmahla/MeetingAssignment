import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './helpers/auth.guard';


const routes: Routes = [
  {path:'login', component:LoginComponent},
  { path: 'meetings', 
  loadChildren: () => import('./meetings-management/meetings-management.module').then(m =>     
  m.MeetingsManagementModule) , canActivate: [AuthGuard] 
},
  {path:'**', component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
