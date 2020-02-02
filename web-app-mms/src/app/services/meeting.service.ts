import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Meeting } from '../Models/meeting.model';

@Injectable({
  providedIn: 'root'
})
export class MeetingService {

  constructor(private http: HttpClient) { }
  getAll() {
    return this.http.get<Meeting[]>(`${environment.apiUrl}/meetings`);
  }

  get(meetingId:number) {
    return this.http.get<Meeting>(`${environment.apiUrl}/meetings/`+meetingId);
  }

  add(meeting: Meeting) {
    return this.http.post(`${environment.apiUrl}/meetings`, meeting);
  }

  update(meeting: Meeting) {
    return this.http.post(`${environment.apiUrl}/meetings`, meeting);
  }

}
