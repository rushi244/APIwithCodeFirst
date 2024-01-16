using APIwithCodeFirst.Data;
using APIwithCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Http;
using System.Web.Http.Results;

namespace APIwithCodeFirst.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                List<Employee> lstEmployee = new List<Employee>();
                lstEmployee = dbContext.Employees.ToList();
                if (lstEmployee.Count != 0)
                {
                    return Ok(new {data=lstEmployee});
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpGet]
        public IHttpActionResult GetEmployees(int id)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
               var lstEmployee = dbContext.Employees.FirstOrDefault(e=>e.Id==id);
                if (lstEmployee != null)
                {
                    return Ok(lstEmployee);
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpPost]
        public HttpResponseMessage PostEmployee(Employee employee)
        {
            using (ApplicationDbContext dbContext=new ApplicationDbContext())
            {
                if (employee != null)
                {
                    dbContext.Employees.Add(employee);
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created,employee);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError); 
                }
            }
        }
        [HttpPut]
        public IHttpActionResult PutEmployee(int id,Employee employee)
        {
            using (ApplicationDbContext dbContext=new ApplicationDbContext())
            {
                var employeeFound = dbContext.Employees.FirstOrDefault(x => x.Id == id);
                if (employeeFound != null)
                {
                   employeeFound.FirstName= employee.FirstName;
                    employeeFound.LastName= employee.LastName;
                    employeeFound.Gender= employee.Gender;
                    employeeFound.City= employee.City;
                    dbContext.SaveChanges();
                    return Ok(employee);
                }
                else
                {
                    return NotFound();
                }
            }
        }


        [HttpPatch]
        public IHttpActionResult PatchEmployee(int id, [FromBody]Employee employee)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var employeeFound = dbContext.Employees.FirstOrDefault(x => x.Id == id);
                if (employeeFound != null)
                {
                    employeeFound.FirstName = employee.FirstName;
                    dbContext.SaveChanges();
                    var emp=dbContext.Employees.FirstOrDefault(x => x.Id == id);
                    return Ok(emp);
                }
                else
                {
                    return NotFound();
                }
            }
        }


        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            using (ApplicationDbContext dbContex = new ApplicationDbContext())
            {
                var foundEmployee =dbContex.Employees.FirstOrDefault(x => x.Id == id);
                if (foundEmployee != null)
                {
                    dbContex.Employees.Remove(foundEmployee);
                    dbContex.SaveChanges();
                    return Ok("Employee deleted Success..");
                }
                else
                {
                    return BadRequest();
                }
            } 
        }
    }
}
