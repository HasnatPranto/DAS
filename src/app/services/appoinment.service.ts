import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Appointment } from '../Models/appoinment';

@Injectable({
  providedIn: 'root'
})
export class AppoinmentService {

  baseUrl = environment.apiURL;
  docSchedule:string[]=[];
  appointment!:Appointment;  

  constructor(private http: HttpClient) { }

  getFullSchedule(dirtySchedule:string): string[]{
    this.docSchedule = dirtySchedule.split(",");
    return this.docSchedule;
  }

  getAvailableDays(dirtySchedule:string): string[]{
    
    var days: string[];
    var day:string[];
    
    this.docSchedule = dirtySchedule.split(",");
    days=[];
    for(var dirtyDay of this.docSchedule){
      
      day=dirtyDay.split(" ", 1);
      days.push(day[0]);
    }
    return days;
  }
  
  addAppoinment(appoinment: any) {
    return this.http.post(this.baseUrl+'Appoinments/PostAppoinment',appoinment).pipe(
      map((response : any)=>
      {
        console.log(response);
        const appo = response;
        if(appo){
          this.appointment = appo;
          console.log('service '+this.appointment.appoinmentDate);
          return appo;
        }
      }
    ));
  }

  getAppointment(id:string): Observable<Appointment>{
    return this.http.get<Appointment>(this.baseUrl+'Appoinments/GetAppoinment/'+id);
    
  }
}
