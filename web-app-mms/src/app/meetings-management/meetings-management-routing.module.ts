import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { AddUpdateComponent } from './add-update/add-update.component';
import { AuthGuard } from '../helpers/auth.guard';
import { AttendiesDetailsComponent } from './attendies-details/attendies-details.component';



const routes: Routes = [
  {path:'', component:ListComponent, canActivate: [AuthGuard] },
  {path:'attendies-details',pathMatch:'full', component:AttendiesDetailsComponent, canActivate: [AuthGuard] },
  {path:':id',pathMatch:'full', component:AddUpdateComponent, canActivate: [AuthGuard] },
  {path:'**', component:ListComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MeetingsManagementRoutingModule { }
