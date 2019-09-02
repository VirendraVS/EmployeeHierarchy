using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy
{
   public class Employee
    {
        public string Id { get; set; }
        public string ManagerId { get; set; }
        public int Salary { get; set; }
    }
}
