import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Doctor } from 'src/app/Models/doctor';
import { AlertifyService } from 'src/app/services/alertify.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-doc-update',
  templateUrl: './doc-update.component.html',
  styleUrls: ['./doc-update.component.css']
})
export class DocUpdateComponent implements OnInit {
 
  id:string="";
  doctor:any={};

  constructor(private userService:UserService, 
    private route: ActivatedRoute, private router: Router, private alertifyService:AlertifyService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.userService.getDoctor(this.id).subscribe(data => {
      this.doctor = data;
    }, error => console.log(error));
  }

  onSubmit(){
    this.userService.updateDoctor(this.doctor).subscribe(
      next =>{
        this.alertifyService.success('Doctor info Updated')
        this.router.navigate(['/doclist-mg']);
      },
      error =>
        this.alertifyService.error('Something Went Wrong!') 
    );  
  }
  goback(){
    this.router.navigate(['/doclist-mg']);
  }
}
