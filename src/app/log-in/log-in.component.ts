import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from '../services/alertify.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
  
  model:any={};
  
  constructor(private authService: AuthService,private router:Router, private alertify:AlertifyService) { }

  ngOnInit(): void {
  }

  login(){
    this.authService.login(this.model).subscribe(next =>{
     this.alertify.success('Logged In');
     this.router.navigate(['/doclist-mg']);
    }, 
    error=>{
      this.alertify.error('Invalid username or password!');
    } );
   }
   loggedIn(){
     return this.authService.loggedIn();
   }
}
