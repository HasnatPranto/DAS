import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppoinmentService } from 'src/app/services/appoinment.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-doc-view',
  templateUrl: './doc-view.component.html',
  styleUrls: ['./doc-view.component.css']
})
export class DocViewComponent implements OnInit {

  id:string="";
  doctor:any={};
  days: string[]=[];

  constructor(private userService:UserService, 
    private route: ActivatedRoute, private router: Router, private appoService:AppoinmentService) { }

  ngOnInit(): void {
    
    this.id = this.route.snapshot.params['id'];
    this.userService.getDoctor(this.id).subscribe(data => {
      console.log(data)
      this.doctor = data;
    }, error => console.log(error));
  }
  
  getThisAppoinment(id:string){
    this.router.navigate(['/get_appointment',id]);
  }
  getFullSchedule(schedule:string){
    this.days = this.appoService.getFullSchedule(schedule);
  }
}
