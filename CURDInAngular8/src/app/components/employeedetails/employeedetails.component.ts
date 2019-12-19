import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastyService, ToastyConfig } from 'ng2-toasty';
import { employeedetails } from "./Models/employeedetails.model";
import { EmployeeDetailsServices } from './Services/employeedetails.service';

@Component({
  selector: 'app-employeedetails',
  templateUrl: './employeedetails.component.html',
  styleUrls: ['./employeedetails.component.css'],
  providers: [EmployeeDetailsServices]
})
export class EmployeedetailsComponent implements OnInit {
  p: number;
  ID: string;
  public loading = false;
  Viewname: string;
  EmpDetails: employeedetails = new employeedetails();

  constructor(private _employeeDetailsServices: EmployeeDetailsServices, private _ToastyService: ToastyService, private _ToastyConfig: ToastyConfig, private _routeParams: ActivatedRoute) {
    this._ToastyConfig.theme = 'bootstrap';
    this._ToastyConfig.position = 'bottom-center';
  }

  onSubmit() {
    this.loading = true;
    this._employeeDetailsServices.AddEmployeeDetails(this.EmpDetails).subscribe
      (
        data => {
          this.loading = false;
          if (this.Viewname !== 'edit') {
            this.resetFormdata();
            this._ToastyService.success('Data Added Sucessfuly');
          } else {
            this._ToastyService.success('Records Updated Sucessfuly');
          }
        }, err => {
          if (err) {
            this._ToastyService.warning('An Error has occured please try again after some time !' + err);
            this.loading = false;
          }
        });
  }
  resetFormdata() {
    this.EmpDetails.name = '';
    this.EmpDetails.emailId = '';
    this.EmpDetails.mobileNo = '';
    this.EmpDetails.position = '';
    this.EmpDetails.department = '';
    this.EmpDetails.salary = null;
    this.EmpDetails.isActive = null;
  }

  EditProductDetail(Id) {
    this.loading = true;
    try {
      this._employeeDetailsServices.EditEmployeeDetails(Id).subscribe(
        data => {
          this.loading = false;
          this.EmpDetails = data;
        }, error => {
          if (error) {
            this._ToastyService.warning('An Error has occured please try again after some time !' + error);
            this.loading = false;
          }
        }
      )
    } catch{ this.loading = false; }
  }

  ngOnInit() {
    //this.GetEmployeeDetails(1);
    this.p = 1;
    this.ID = this._routeParams.snapshot.params['ID'];
    this.Viewname = this._routeParams.snapshot.params['Viewname'];
    if (this.ID != null) {
      this.loading = true;
      this._employeeDetailsServices.EditEmployeeDetails(this.ID).
        subscribe
        (
          data => {
            this.EmpDetails = data;
            if (this.EmpDetails.employeeDetailsId !== '' && this.EmpDetails.employeeDetailsId !== null) {
              //this.GetEmployeeDetails(1);
            }
          },
          err => {
            if (err) {
              this._ToastyService.warning('An Error has occured please try again after some time !' + err);
            }
          },

        );
    }
  }
}
