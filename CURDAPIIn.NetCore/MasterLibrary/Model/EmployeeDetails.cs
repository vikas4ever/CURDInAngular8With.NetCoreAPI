using System;
using System.Collections.Generic;
using System.Text;

namespace MasterLibrary.Model
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
