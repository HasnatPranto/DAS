import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Admin } from '../Models/admin';
import { Doctor } from '../Models/doctor';

var auth_token = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('token'));

const httpOptions = {
  headers: auth_token
};


@Injectable({
  providedIn: 'root'
})

export class UserService {

  baseUrl = environment.apiURL;
  
  constructor(private http:HttpClient) { }

  getDoctor(name:string): Observable<Doctor>{
    return this.http.get<Doctor>(this.baseUrl+'Doctors/GetDoctor/'+name);
  }
  getDoc(name:string): Observable<Doctor>{
    return this.http.get<Doctor>(this.baseUrl+'Doctors/GetDoctor_name/'+name);
  }
  getDoctors(): Observable<Doctor[]>{
    return this.http.get<Doctor[]>(this.baseUrl+'Doctors/GetDoctors');
  }
  getAdmin(name:string): Observable<Admin>{
    return this.http.get<Admin>(this.baseUrl+'Admins/GetAdmin/'+name,httpOptions);
  }
  getAdmins(): Observable<Admin[]>{
    return this.http.get<Admin[]>(this.baseUrl+'Admins/GetAdmins',httpOptions);
  }
  updateDoctor(doc:Doctor){
    return this.http.put<Doctor>(this.baseUrl+'Doctors/PutDoctor/'+doc.id, doc,httpOptions);
  }
  addDoctor(doctor: any) {
    return this.http.post(this.baseUrl+'Doctors/PostDoctor',doctor,httpOptions);
  }
  addAdmin(admin: any) {
    return this.http.post(this.baseUrl+'Admins/Register',admin,httpOptions);
  }
  deleteDoctor(id: string): Observable<any> {
    return this.http.delete(this.baseUrl+'Doctors/DeleteDoctor/'+id,httpOptions);
  }
  deleteAdmin(id: string): Observable<any> {
    return this.http.delete(this.baseUrl+'Admins/DeleteAdmin/'+id,httpOptions);
  }
}
