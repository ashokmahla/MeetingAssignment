import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, AbstractControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Attendees } from '../../Models/attendees.model';
import { AttendeesService } from 'src/app/services/attendees.service';
import { MeetingService } from 'src/app/services/meeting.service';
import { Meeting } from 'src/app/Models/meeting.model';

@Component({
  selector: 'app-add-update',
  templateUrl: './add-update.component.html',
  styleUrls: ['./add-update.component.sass']
})
export class AddUpdateComponent implements OnInit {

  //Class level variables.
  attendees: Attendees[]; 
  attendiesIds : string[];
  meetingObject:Meeting = new Meeting();
  meetingForm: FormGroup;
  currentId:number = 0;
  errorMessage;
  savedDateTime;
  tomorrowDate;
  isDisabled : boolean;
  constructor(private fb: FormBuilder,private router:Router, private activated: ActivatedRoute,private attendeesService:AttendeesService,private meetingService:MeetingService) 
  {
    this.tomorrowDate = new Date(); 
    this.tomorrowDate.setDate(this.tomorrowDate.getDate() + 1);
    this.currentId = +this.activated.snapshot.paramMap.get('id');
    //Creating the dynamic form for meetings detail page.
    this.meetingForm = this.fb.group({
      subject: ['',[Validators.required,Validators.maxLength(50)]],
      attendee: ['', Validators.required],
      agends: ['',Validators.required],
      meetingdate: ['',Validators.required]
    })
  }

  ngOnInit() {
    //Get list of all attendies from the server.
    this.attendeesService.getAll()
    .subscribe(
        data => {
          this.attendees = data;
          if(this.currentId != 0){
          this.getMeeting(); 
          }
        },
        error => {
            console.log(error);
            this.errorMessage = error;
        });
    }

  //Getting the meeting details from server in case of update
  getMeeting(){
      this.meetingService.get(this.currentId)
      .subscribe(
          data => {
            this.meetingObject = data;
            var ids  = this.meetingObject.attendeesId.split(",").map(Number);
            this.meetingForm.get('subject').setValue(this.meetingObject.subject);
            this.meetingForm.get('attendee').setValue(ids);
            this.meetingForm.get('agends').setValue(this.meetingObject.agenda);
            this.meetingForm.get('meetingdate').setValue(new Date(this.meetingObject.meetingTime));
            this.savedDateTime = new Date(this.meetingObject.meetingTime);
          },
          error => {
              console.log(error);
              this.errorMessage = error;
        });

  }

  changed() {
    if (this.meetingForm.get('attendee').value.length > 9) {
      alert('Selecting more than 10 attendees not allowed. ');
      this.isDisabled = true;
      return;
    }
    
   }
  
//Saving or updating the Meeetings details
  submit() {
   
    if(this.meetingForm.invalid){
      return;
    }
    this.meetingObject = new Meeting();
    this.meetingObject.id = this.currentId;
    this.meetingObject.subject =  this.meetingForm.value.subject;
    this.meetingObject.attendeesId =  this.meetingForm.value.attendee.join(',');
    this.meetingObject.agenda =  this.meetingForm.value.agends;
    this.meetingObject.meetingTime =  this.meetingForm.value.meetingdate;
    if(this.currentId == 0){
       //This for creating the meetings
      this.meetingService.add(this.meetingObject)
      .subscribe(
        data => {
        },
        error => {
            console.log(error);
            this.errorMessage = error;
        });
    } else{
      //This for updating the meetings
      this.meetingService.update(this.meetingObject)
      .subscribe(
        data => {
        },
        error => {
          console.log(error);
          this.errorMessage = error;
        });
    }
    this.router.navigate(['meetings']);
  }

  //Navigate to the meeting list
  goBack() {
    this.router.navigate(['meetings']);
  }

  //Reset the form values.
  clearForm(){
    this.isDisabled = false;
    this.meetingForm.reset();
  }

}
 