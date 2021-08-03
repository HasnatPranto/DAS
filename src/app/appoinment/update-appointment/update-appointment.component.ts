import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Appointment } from 'src/app/Models/appoinment';
import { Doctor } from 'src/app/Models/doctor';
import { AppoinmentService } from 'src/app/services/appoinment.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-update-appointment',
  templateUrl: './update-appointment.component.html',
  styleUrls: ['./update-appointment.component.css']
})
export class UpdateAppointmentComponent implements OnInit {

  searchForm :any={};
  updateForm:any={};
  existing_details !: Appointment;
  updated_details!:Appointment;
  doctors:any={};

  constructor(private appointmentService:AppoinmentService,private userService:UserService) { }

  ngOnInit(): void {
    this.userService.getDoctors().subscribe((doctors: Doctor[]) => {
      this.doctors = doctors;
    });
    this.searchForm =  new FormGroup({
      patient_id : new FormControl('',Validators.required),
    });
  }

  searchID(){
    this.appointmentService.getAppointment(this.searchForm.get('patient_id').value).subscribe(
      data=> {
        this.existing_details = data;
        this.initForm();
      },
      error =>(
        console.log(error)
      )
    );   
  }

  updatePage(){
    return !!this.existing_details;
  }

  initForm(){
    this.updateForm = new FormGroup(
      {
        patient_name : new FormControl(this.existing_details.patientName,Validators.required),
        doctor_name : new FormControl(this.existing_details.doctorName,Validators.required),
        date: new FormControl(this.existing_details.appoinmentDate,Validators.required),
        phone: new FormControl(this.existing_details.patientPhoneNumber,Validators.required),
        serial : new FormControl(this.existing_details.serialNumber)
      }
    );
  }

  onSubmit(){

  }
}
