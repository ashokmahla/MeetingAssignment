import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { AddUpdateComponent } from './add-update/add-update.component';
import { AuthGuard } from '../helpers/auth.guard';



const routes: Routes = [
  {path:'', component:ListComponent, canActivate: [AuthGuard] },
  {path:':id',pathMatch:'full', component:AddUpdateComponent, canActivate: [AuthGuard] },
  {path:'**', component:ListComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MeetingsManagementRoutingModule { }
