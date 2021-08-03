import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Doctor } from 'src/app/Models/doctor';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-doclist',
  templateUrl: './doclist.component.html',
  styleUrls: ['./doclist.component.css']
})
export class DoclistComponent implements OnInit {

  doctors: Doctor[] = [];

  constructor(private userService:UserService,private router:Router) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(){
    this.userService.getDoctors().subscribe((doctors:Doctor[])=>{
        this.doctors = doctors;
    });
  }

  deleteDoctor(id: string) {
    console.log('ID '+id);
    this.userService.deleteDoctor(id)
      .subscribe(
        data => {
          console.log(data);
          this.loadUsers();
        },
        error => console.log(error));
  }

  gotoUpdate(id:string){
    this.router.navigate(['updateDocInfo', id]);
  }
}
