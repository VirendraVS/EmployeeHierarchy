using System;
using System.Collections.Generic;
using EmployeeHierarchy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHierarchy.UnitTests
{
    [TestClass]
    public class EmployeesTests
    {
        public Employees EmployeeClass = new EmployeeHierarchy.Employees(@"Employees.csv");

        [TestMethod]
        public void Employees_Scenario()
        {
            var result = EmployeeClass.ValidateOneCEO();
            Assert.IsTrue(result);

            var result1 = EmployeeClass.ValidateManagerNotEmployee();
            Assert.IsFalse(result1);
        }
    }
}
