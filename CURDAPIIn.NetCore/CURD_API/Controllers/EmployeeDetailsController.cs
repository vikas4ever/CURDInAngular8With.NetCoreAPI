using System;
using MasterLibrary.BAL;
using MasterLibrary.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CURD_API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeDetailsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<EmployeeDetails> Get()
        {
            List<EmployeeDetails> objReturn = new List<EmployeeDetails>();
            using (EmployeeDetails_BAL objBAL = new EmployeeDetails_BAL())
            {
                objReturn = objBAL.GetAllRecord();
            }
            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public EmployeeDetails Get(Guid id)
        {
            EmployeeDetails objReturn = new EmployeeDetails();
            using (EmployeeDetails_BAL objBAL = new EmployeeDetails_BAL())
            {
                objReturn = objBAL.GetRecordById(id);
            }
            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody]EmployeeDetails value)
        {
            DefaultResult objReturn = new DefaultResult();
            if (value.Id == 0)
            {
                value.EmployeeId = Guid.NewGuid();
            }
            value.IsDeleted = false;
            using (EmployeeDetails_BAL objBAL = new EmployeeDetails_BAL())
            {
                objReturn.Data = objBAL.InsertUpdateRecord(value).ToString();
            }
            return objReturn;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
