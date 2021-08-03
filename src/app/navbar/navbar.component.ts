import { Component, Input, OnInit } from '@angular/core';
import { AlertifyService } from '../services/alertify.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model : any = {};
  adminView = false;

  constructor(private authService: AuthService,private alert:AlertifyService) { }

  ngOnInit(): void {
  }

  login(){
   this.authService.login(this.model).subscribe(next =>{
     console.log('Logged In');
   }, error=>{
     console.log('Error fatal');
   } );
  }
  logout(){
   this.authService.logout();
    this.alert.error('Logged Out');
  }
  loggedIn(){
    return this.authService.loggedIn();
  }
}
