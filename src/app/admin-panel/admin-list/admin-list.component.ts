import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Admin } from 'src/app/Models/admin';
import { AlertifyService } from 'src/app/services/alertify.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-admin-list',
  templateUrl: './admin-list.component.html',
  styleUrls: ['./admin-list.component.css']
})
export class AdminListComponent implements OnInit {

  admins: Admin[]=[];

  constructor(private userService:UserService,private router:Router,private a: AlertifyService) { }

  ngOnInit(): void {
    this.getAdmins();
  }

  getAdmins(){
    this.userService.getAdmins().subscribe(
    
      (admins:Admin[])=>{
        this.admins = admins;
        console.log(admins);
      }
    );
  }
  deleteAdmin(id: string) {
    console.log('ID '+id);
    this.userService.deleteAdmin(id)
      .subscribe(
        data => {
          this.a.error('Admin Deleted!');
          this.getAdmins();
        },
        error => console.log(error));
  }
}
