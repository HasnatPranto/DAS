import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Doctor } from 'src/app/Models/doctor';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-doctor-list',
  templateUrl: './doctor-list.component.html',
  styleUrls: ['./doctor-list.component.css']
})
export class DoctorListComponent implements OnInit {

  doctors: Doctor[] = [];

  constructor(private userService:UserService, private router:Router) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(){
    this.userService.getDoctors().subscribe((doctors:Doctor[])=>{
        this.doctors = doctors;
    });
  }
  viewDetails(id:string){
    this.router.navigate(['/view_doctor',id]);
  }
}
