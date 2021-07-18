using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace EmployeeService.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Employees.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            // when id is not found return response 404

            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                var entity =  entities.Employees.FirstOrDefault(e => e.ID == id);

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id = " + id.ToString() + " not found");
                }
            }


        }

        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    entities.Employees.Add(employee);
                    entities.SaveChanges();

                    // Sending reponse code along with URL attach with ID
                    var message = Request.CreateResponse(HttpStatusCode.Created, employee); //201 Item Created
                    message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString()); //Passing location ie.URI + ID
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Implementing Delete method
        // With void return type it will get us HTTPstatus code - 204 No Content
        public void Delete(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                entities.Employees.Remove(entities.Employees.FirstOrDefault( e => e.ID == id));
                entities.SaveChanges();

            }
        }

    }
}
