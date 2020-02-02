import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Attendees } from '../Models/attendees.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AttendeesService {

  constructor(private http: HttpClient) { }
  getAll() {
    return this.http.get<Attendees[]>(`${environment.apiUrl}/attendees`);
}

}
