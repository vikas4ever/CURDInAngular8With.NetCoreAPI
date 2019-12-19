export class employeedetails {
    Id: number;
    employeeDetailsId: string;
    name: string;
    emailId: string;
    mobileNo: string;
    position: string;
    department: string;
    salary: string;
    isActive: boolean;
    isDeleted: boolean;
}
export class employeedetailsListDetails {
    employeedetailslist: Array<employeedetails>;
    tatalRecords: number;
}