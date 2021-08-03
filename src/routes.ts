import { Component } from "@angular/core";
import { Routes } from "@angular/router";
import { AdminListComponent } from "./app/admin-panel/admin-list/admin-list.component";
import { NewAdminComponent } from "./app/admin-panel/new-admin/new-admin.component";
import { NewAppoinmentComponent } from "./app/appoinment/new-appoinment/new-appoinment.component";
import { DocAddComponent } from "./app/doctor/doctor-management/doc-add/doc-add.component";
import { DocUpdateComponent } from "./app/doctor/doctor-management/doc-update/doc-update.component";
import { DoclistComponent } from "./app/doctor/doctor-management/doclist/doclist.component";
import { DocViewComponent } from "./app/doctor/patientView/doc-view/doc-view.component";
import { DoctorListComponent } from "./app/doctor/patientView/doctor-list/doctor-list.component";
import { HomeComponent } from "./app/home/home.component";
import { LogInComponent } from "./app/log-in/log-in.component";

export const appRoutes:  Routes = [
    {path: 'login', component: LogInComponent },
    {path: 'home', component: HomeComponent },
    {path: 'doclist-mg', component: DoclistComponent},
    {path:'updateDocInfo/:id', component:DocUpdateComponent},
    {path:'createDoctor',component:DocAddComponent},
    {path:'admin_list',component:AdminListComponent},
    {path:'create_an_admin',component:NewAdminComponent},
    {path:'our_doctors',component:DoctorListComponent},
    {path:'view_doctor/:id',component:DocViewComponent},
    {path:'get_appointment',component:NewAppoinmentComponent},
    {path:'get_appointment/:id',component:NewAppoinmentComponent},
    {path: '**', redirectTo:'home', pathMatch:'full'}    
]