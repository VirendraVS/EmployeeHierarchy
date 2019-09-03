using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeHierarchy
{
    public class Employees
    {
       
        public Employees(string filename)
        {
            var employees = (from row in File.ReadLines(filename).Where(t => !string.IsNullOrWhiteSpace(t)).AsEnumerable()
                            let columns = row.Split(',')
                            select new Employee
                            {
                                Id = columns[0],
                                ManagerId = columns[1],
                                Salary = ValidateSalary(columns[2]) ? Convert.ToInt32(columns[2]) : 0
                            }).OrderBy(x => x.ManagerId).ToList();

            if (ValidateManager(employees)) throw new Exception("Employee with more than  one manager found");
            if(!ValidateOneCEO(employees)) throw new Exception("More than CEO found");
            if (ValidateManagerNotEmployee(employees)) throw new Exception("Some Managers are not employees");
        }

        public bool ValidateSalary(string salary)
        {
            int result;
            return int.TryParse(salary, out result);
        }

        public bool ValidateManager(List<Employee> employees)
        {
            return employees.Select(t => new {t.Id, t.ManagerId }).GroupBy(c => c.Id, x => x.ManagerId).Count() > 1;
        }

        public bool ValidateOneCEO(List<Employee> employees)
        {
            return employees.Where(c => c.ManagerId == null).Count() == 1;
        }


        //NB: To be implemented later
        public bool ValidateEmployeeCircularReference(List<Employee> employees)
        {
            return false;
        }

        public bool ValidateManagerNotEmployee(List<Employee> employees)
        {
            var employeeIds = new HashSet<string>(employees.Where(x => x.ManagerId != null).Select(x => x.Id));
            return employees.Where(e => !employeeIds.Contains(e.ManagerId)).Count() > 0;
        }
    }
}
