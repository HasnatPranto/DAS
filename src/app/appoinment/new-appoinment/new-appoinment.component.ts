import { isNgTemplate } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Appointment } from 'src/app/Models/appoinment';
import { Doctor } from 'src/app/Models/doctor';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AppoinmentService } from 'src/app/services/appoinment.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-new-appoinment',
  templateUrl: './new-appoinment.component.html',
  styleUrls: ['./new-appoinment.component.css']
})
export class NewAppoinmentComponent implements OnInit {

  appoinmentForm: any = {};
  doctors: any = {};
  selectedDoctor: any = {};
  appointment!: Appointment;
  presetID: any = {};
  appointmentData!:Appointment;

  constructor(private userService: UserService, private appoinmentService: AppoinmentService,
    private router: Router, private route: ActivatedRoute,private a : AlertifyService) {
  }
  ngOnInit(): void {

    this.userService.getDoctors().subscribe((doctors: Doctor[]) => {
      this.doctors = doctors;
    });

    this.presetID = this.route.snapshot.params['id'];

    if (this.presetID) {
      this.userService.getDoctor(this.presetID).subscribe((doctor: Doctor) => {
        this.selectedDoctor = doctor;
        this.appoinmentForm = new FormGroup({
          patientName: new FormControl('', Validators.required),
          doctorName: new FormControl(doctor.name, Validators.required),
          appoinmentDate: new FormControl('', Validators.required),
          patientPhoneNumber: new FormControl('', Validators.required)
        });
      });
    }

    else {
      this.appoinmentForm = new FormGroup({
        patientName: new FormControl('', Validators.required),
        doctorName: new FormControl('', Validators.required),
        appoinmentDate: new FormControl('', Validators.required),
        patientPhoneNumber: new FormControl('', Validators.required)
      });
    }
  }

  doctorSelected() {
    return !!this.presetID;
  }

  setDoc(doc: Doctor) {
    this.selectedDoctor = doc;
  }

  checkAva() {

    var selectedDay = new Date(this.appoinmentForm.get('appoinmentDate').value);
    var avaDays = this.appoinmentService.getAvailableDays(this.selectedDoctor.schedule);
    var available = avaDays[selectedDay.getDay()];

    return !!available;
  }

  onSubmit() {
    if(confirm("Confirm Appoinment? ")) {
      
    const appoinment: Appointment = {
      id: "",
      patientName: this.appoinmentForm.get('patientName').value,
      doctorName: this.appoinmentForm.get('doctorName').value,
      appoinmentDate: this.appoinmentForm.get('appoinmentDate').value,
      patientPhoneNumber: this.appoinmentForm.get('patientPhoneNumber').value,
      serialNumber: 0,
    }

    this.appoinmentService.addAppoinment(appoinment).subscribe(
      data => {
        this.appointmentData = data;
        console.log('component '+this.appointmentData.id);
        this.a.success('Appoinment Confirmed!');
      },
      error => (
        console.log(error)
      )
    );
  }
  }
  gohome(){
    this.router.navigate(['/home']);
  }
  appointmentReady() {
    return !!this.appointmentData;
  }
}
