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
        public void ValidateCEO_Scenario()
        {
            var result = EmployeeClass.ValidateOneCEO();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateManagerNotEmployee_Scenario()
        {
            var result = EmployeeClass.ValidateManagerNotEmployee();
            Assert.IsFalse(result);
        }
    }
}
