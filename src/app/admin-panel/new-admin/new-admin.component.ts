import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-new-admin',
  templateUrl: './new-admin.component.html',
  styleUrls: ['./new-admin.component.css']
})
export class NewAdminComponent implements OnInit {

  admin: any={};

  constructor(private userService:UserService,private router:Router, private a:AlertifyService) { }

  ngOnInit(): void {
  }

  onSubmit(){
   
    this.userService.addAdmin(this.admin).subscribe(
      data=> {
        this.a.success('New Admin Created!');
        this.refresh();
      },
      error =>(
        console.log(error)
      )
    );
  }
  refresh(){
    this.router.navigate(['/admin_list']);
  }
}
