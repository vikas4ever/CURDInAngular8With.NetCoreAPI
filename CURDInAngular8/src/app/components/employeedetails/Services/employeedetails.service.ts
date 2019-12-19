import { Router } from '@angular/router';
import { Injectable } from '@angular/core'
import { map, catchError } from 'rxjs/operators';
import { Http, Headers, Response, RequestOptions } from '@angular/http';

import { AppConfig } from '../../_config/app.config';
import { employeedetails } from "../Models/employeedetails.model";

@Injectable()
export class EmployeeDetailsServices {
    public apiUrl: string;
    constructor(private _http: Http, private _router: Router) {
        this.apiUrl = new AppConfig().apiUrl;
    }

    public AddEmployeeDetails(EmployeeDetails: employeedetails) {
        const headers = new Headers({ 'Content-Type': 'application/json' });
        const options = new RequestOptions({ headers: headers });
        return this._http.post(this.apiUrl + 'EmployeeDetails', EmployeeDetails, options)
            .pipe(map((res: Response) => res.json()),
                catchError(response => {
                    if (response.EmployeeDetails === 401) {
                        this._router.navigate(['Login']);
                    }
                    return response;
                })
            )
    }

    public GetAllEmployeeDetails(PageNo: number, PageSize: string) {
        const headers = new Headers({ 'Content-Type': 'application/json' });
        const options = new RequestOptions({ headers: headers });
        return this._http.get(this.apiUrl + 'ProductPage/' + PageNo + '/' + PageSize, options)
            .pipe(map((response: Response) => <any>response.json()),
                catchError(response => {
                    if (response.EmployeeDetails === 401) {
                        this._router.navigate(['Login']);
                    }
                    return response;
                }));
    }

    public EditEmployeeDetails(Id: string) {
        const headers = new Headers({ 'Content-Type': 'application/json' });
        const options = new RequestOptions({ headers: headers });
        return this._http.get(this.apiUrl + 'EmployeeDetails/' + Id, options)
            .pipe(map((response: Response) => <any>response.json()),
                catchError(response => {
                    if (response.EmployeeDetails === 401) {
                        this._router.navigate(['login']);
                    }
                    return response;
                })
            );
    }

    public DeleteEmployeeDetails(Id: number) {
        const headers = new Headers({ 'Content-Type': 'application/json' });
        const options = new RequestOptions({ headers: headers });
        return this._http.delete(this.apiUrl + 'EmployeeDetails/' + Id, options)
            .pipe(map((response: Response) => <any>response.json()),
                catchError(response => {
                    if (response.EmployeeDetails === 401) {
                        this._router.navigate(['Login']);
                    }
                    return response;
                }));
    }
}
