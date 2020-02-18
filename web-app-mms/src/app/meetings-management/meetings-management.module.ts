import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AddUpdateComponent } from './add-update/add-update.component';
import { ListComponent } from './list/list.component';
import { MeetingsManagementRoutingModule } from './meetings-management-routing.module';
import { MaterialModule } from '../material.module';
import { LogoutComponent } from '../logout/logout.component';
import { MatDatetimepickerModule,MatNativeDatetimeModule } from '@mat-datetimepicker/core';
import { DatePipe } from '@angular/common';
import { AttendiesDetailsComponent } from './attendies-details/attendies-details.component';

@NgModule({
  declarations: [AddUpdateComponent, ListComponent, LogoutComponent,AttendiesDetailsComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    MeetingsManagementRoutingModule,
    MatDatetimepickerModule,
    MatNativeDatetimeModule
  ],
  providers: [DatePipe],
  schemas:[CUSTOM_ELEMENTS_SCHEMA],
})
export class MeetingsManagementModule { }
