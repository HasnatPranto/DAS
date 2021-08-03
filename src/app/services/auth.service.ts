import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {map} from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiURL+ 'Admins/';
  logFlag = false;
  
  constructor(private http:HttpClient) { }

  login(model:any){
    
    return this.http.post(this.baseUrl+'Login',model).pipe(
      map((response : any)=>
      {
        console.log(response);
        const user = response;
        if(user){
          localStorage.setItem('token',user.token);
          this.logFlag = true;
        }
      }
      )  
    );
  }

  loggedIn(){
    const token= localStorage.getItem('token');
    //return this.logFlag;
    return !!token;
  }

  logout(){
    localStorage.removeItem('token');
   console.log('Reached');
  }
}
