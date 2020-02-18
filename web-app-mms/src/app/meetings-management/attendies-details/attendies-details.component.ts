import { Component, OnInit } from '@angular/core';
import { AttendeesService } from 'src/app/services/attendees.service';
import { MappedAttendees } from 'src/app/Models/attendees.model';
import { Router } from '@angular/router';
 

@Component({
  selector: 'app-attendies-details',
  templateUrl: './attendies-details.component.html',
  styleUrls: ['./attendies-details.component.sass']
})
export class AttendiesDetailsComponent implements OnInit {

  constructor(private attendeesService:AttendeesService,private router:Router) { }
  dataSource: MappedAttendees[];
  displayedColumns: string[] = ['Name', 'MeetingCount'];
  ngOnInit() {
     //Get list of all attendies from the server.
     this.attendeesService.getMappedAttendies()
     .subscribe(
         data => {
           this.dataSource = data;
         },
         error => {
             console.log(error);
             
         });
     }

  //Navigate to the meeting list
  goBack() {
    this.router.navigate(['meetings']);
  }

  }

 
