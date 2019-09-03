using System;
using System.Collections.Generic;
using EmployeeHierarchy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHierarchy.UnitTests
{
    [TestClass]
    public class EmployeesTests
    {
        public List<Employee> employees;
        [TestMethod]
        public void ValidateOneCEO_Scenario()
        {
            employees = new List<Employee>() {
                new Employee { Id = "E1", ManagerId = null, Salary = 10000 },
                new Employee { Id = "E2", ManagerId = "E1", Salary = 8500 },
                new Employee { Id = "E3", ManagerId = "E2", Salary = 6500 },
                };
            var employeeObject = new EmployeeHierarchy.Employees();

            var result = employeeObject.ValidateOneCEO(employees);

                Assert.IsTrue(result);
        }
    }
}
