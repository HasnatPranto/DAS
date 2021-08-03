import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AuthService } from './services/auth.service';
import { HomeComponent } from './home/home.component';
import { LogInComponent } from './log-in/log-in.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from 'src/routes';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { UserService } from './services/user.service';
import { DoctorListComponent } from './doctor/patientView/doctor-list/doctor-list.component';
import { DoclistComponent } from './doctor/doctor-management/doclist/doclist.component';
import { DocUpdateComponent } from './doctor/doctor-management/doc-update/doc-update.component';
import { DocAddComponent } from './doctor/doctor-management/doc-add/doc-add.component';
import { NewAdminComponent } from './admin-panel/new-admin/new-admin.component';
import { AdminListComponent } from './admin-panel/admin-list/admin-list.component';
import { AppoinmentService } from './services/appoinment.service';
import { DocViewComponent } from './doctor/patientView/doc-view/doc-view.component';
import { NewAppoinmentComponent } from './appoinment/new-appoinment/new-appoinment.component';
import { AlertifyService } from './services/alertify.service';
import { UpdateAppointmentComponent } from './appoinment/update-appointment/update-appointment.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    LogInComponent,
    AdminPanelComponent,
    DoctorListComponent,
    DoclistComponent,
    DocUpdateComponent,
    DocAddComponent,
    NewAdminComponent,
    AdminListComponent,
    DocViewComponent,
    NewAppoinmentComponent,
    UpdateAppointmentComponent,    
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [
    AuthService,
    UserService,
    AppoinmentService,
    AlertifyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
