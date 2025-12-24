using Basic_WebAPI_ConventionalRouting.Models;
using Basic_WebAPI_ConventionalRouting.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Basic_WebAPI_ConventionalRouting.Controllers
{
  
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;
        public EmployeeController(EmployeeService service) { _service = service; }
       //create
       public IActionResult Create([FromBody] Employee employee)
        {
            var _employee = _service.CreateEmployee(employee);
            return CreatedAtAction(nameof(GetById), new {id = _employee.Id},_employee);
        }
        //read
        public IActionResult Get()
        {
            var employees = _service.GetEmployees();
            if (employees == null || !employees.Any())
            {
                return NotFound("No employees found");
            }
            return Ok(employees);
        }

        //readbyid
        public IActionResult GetById(int id)
        {
            var emp = _service.GetEmployee(id);
            if(emp == null)
            {
                return NotFound("Employee not found");
            }
            else
            {
                return Ok(emp);
            }
        }

       //readbydept
       public IActionResult GetByDept(string department)
        {
            var emp = _service.GetEmployeeByDept(department);
            if (emp == null || emp.Count==0)
            {
                return NotFound("No employees found in this department");
            }
            else
            {
                return Ok(emp);
            }
        }

       //update
       public IActionResult Update([FromBody]Employee employee)
        {
            var emp = _service.UpdateEmployee(employee.Id);
            if (emp == null)
            {
                return NotFound("Employee not found");
            }
            emp.Name = employee.Name;
            emp.Department = employee.Department;
            emp.Salary = employee.Salary;
            return Ok(emp);
        }

        //delete
        public IActionResult Delete(int id)
        {
            var employee = _service.GetEmployee(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            _service.DeleteEmployee(id);
            return NoContent(); 
        }

    }
}
