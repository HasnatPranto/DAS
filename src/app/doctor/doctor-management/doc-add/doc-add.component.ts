import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Doctor } from 'src/app/Models/doctor';
import { AlertifyService } from 'src/app/services/alertify.service';
import { UserService } from 'src/app/services/user.service';
import { DoctorListComponent } from '../../patientView/doctor-list/doctor-list.component';

@Component({
  selector: 'app-doc-add',
  templateUrl: './doc-add.component.html',
  styleUrls: ['./doc-add.component.css']
})
export class DocAddComponent implements OnInit {

  doctor: any= {};
 
  constructor(private userService:UserService,private router:Router, private a:AlertifyService) { }

  ngOnInit(): void {
  }

  onSubmit(){
   
    this.userService.addDoctor(this.doctor).subscribe(
      data=> {
        this.a.success('Doctor added successfully!')
        this.refresh();
      },
      error =>(
        console.log(error)
      )
    );
  }

  refresh(){
    this.router.navigate(['/doclist-mg']);
  }
}
