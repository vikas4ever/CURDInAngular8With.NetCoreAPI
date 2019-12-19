import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EmployeedetailsComponent } from './components/employeedetails/employeedetails.component';

const routes: Routes = [
  { path: '', redirectTo:'login', pathMatch: 'full'},
  { path: 'employeeDetails', component:EmployeedetailsComponent },
  { path: '**', redirectTo: 'employeeDetails' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
