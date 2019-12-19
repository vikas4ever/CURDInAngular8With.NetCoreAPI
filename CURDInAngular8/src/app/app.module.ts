import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { ToastyModule } from 'ng2-toasty';
import { AppComponent } from './app.component';
import { EmployeedetailsComponent } from './components/employeedetails/employeedetails.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeedetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    RouterModule,
    FormsModule, 
    ReactiveFormsModule,
    AppRoutingModule,
    ToastyModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
