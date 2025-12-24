using Basic_WebAPI_ConventionalRouting.Models;
    
    
namespace Basic_WebAPI_ConventionalRouting.Services
{
    
    public class EmployeeService
    {
        public EmployeeService() {}
        static List<Employee> employees = new List<Employee>();
       static int Id = 1;

        //create
        public Employee CreateEmployee(Employee employee)
        {
            
            employee.Id = Id++;                  // Auto-increment ID
            employees.Add(employee);             // Add to list
            return employee;                     // Return created object
        }

        //read
        public List<Employee> GetEmployees() 
        { 
            return employees;
        }

        //readbyid
        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        //readbydepartment
        public List<Employee> GetEmployeeByDept(string department)
        {
            return employees.Where(s => s.Department == department).ToList();
        }

        //update
        public Employee UpdateEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        //delete
        public void DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }

        
    }
}
