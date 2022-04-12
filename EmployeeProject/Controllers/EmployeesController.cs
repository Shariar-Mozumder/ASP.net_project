using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeAccess;

namespace EmployeeProject.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            using(EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Employees.ToList();
            }
        }

        public Employee GetonlyEmployee(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Employees.FirstOrDefault(x => x.ID == id);
            }
               
        }

        public void AddEmployee(Employee employee)
        {
            using(EmployeeDBEntities entity = new EmployeeDBEntities())
            {
                entity.Employees.Add(employee);
                entity.SaveChanges();
            }
        }

        public void UpDateEmployee(int id,Employee employee)
        {
            using( EmployeeDBEntities entity = new EmployeeDBEntities())
            {
                //if there is ID
                 var emp=entity.Employees.FirstOrDefault(x => x.ID == id);

                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Designation= employee.Designation;
                emp.Salary= employee.Salary;


                // entity.Employees.Attach(employee);
                entity.SaveChanges();



            }
        }

        public void DeleteEmployee(int id)
        {
            using(EmployeeDBEntities entities=new EmployeeDBEntities())
            {
                var emp=entities.Employees.FirstOrDefault(x => x.ID == id);
                entities.Employees.Remove(emp);
                entities.SaveChanges();
            }
        }
    }
}
