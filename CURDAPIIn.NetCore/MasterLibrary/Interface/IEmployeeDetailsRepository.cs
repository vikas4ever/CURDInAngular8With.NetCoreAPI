using System;
using System.Collections.Generic;
using MasterLibrary.Model;

namespace MasterLibrary.Interface
{
    public interface IEmployeeDetailsRepository : IDisposable
    {
        Guid? InsertUpdateRecord(EmployeeDetails objEmployeeDetails);

        List<EmployeeDetails> GetAllRecord();

        EmployeeDetailsList GetRecordPage(int iPageNo, int iPageSize);

        EmployeeDetails GetRecordById(Guid iId);

        bool DeleteRecord(int iId);
    }
}
