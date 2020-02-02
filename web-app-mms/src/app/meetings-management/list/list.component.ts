import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { Meeting } from '../../Models/meeting.model';
import { MeetingService } from 'src/app/services/meeting.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.sass']
})
export class ListComponent implements OnInit {
  displayedColumns: string[] = ['Subject', 'Attendees', 'Agenda','Date', 'Action'];
  dataSource: Meeting[];
  constructor(private router: Router, private activated: ActivatedRoute, private meetingService: MeetingService) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };

    this.router.events.subscribe((evt) => {
      if (evt instanceof NavigationEnd) {
        this.router.navigated = false;
        this.initlizeData();
      }
    });
  }

  ngOnInit() {

  }

//Getting the list of all meetings
  initlizeData() {
    this.meetingService.getAll()
      .subscribe(
        data => {
          this.dataSource = data;
        },
        error => {
          console.log(error)
        });

  }

//Navigte to update meeting details page for seeing and upating the single meeting.
  update(id) {
    let path = this.router.url + '/' + id;
    this.router.navigate([path])
  }

  //Add a new meeting
  addMeeting() {
    let id = 0;
    let path = this.router.url + '/' + id;
    this.router.navigate([path])

  }
}
