using System;
using System.Collections.Generic;
using EmployeeHierarchy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHierarchy.UnitTests
{
    [TestClass]
    public class HierarchyTests
    {
        public Employees EmployeeClass = new EmployeeHierarchy.Employees(@"Employees.csv");
        public static HierarchyTree tree = new HierarchyTree();
        [TestMethod]
        public void InsertEmployeeHierarchy_Scenario()
        {
            var employees = EmployeeClass.employees;
            foreach(var employee in employees)
                tree.InsertEmployee(employee);

            Assert.IsNotNull(tree.root);
        }

        [TestMethod]
        public void GetSalaryBudgetForManager_Scenario()
        {
            var result = tree.GetSalaryBudegetForManager(tree.root.employee);
            Assert.IsTrue(result == 43700);
        }

        [TestMethod]
        public void GetSalaryBudgetForManager_OneLevelDownScenario()
        {
            var employees = EmployeeClass.employees;
            var result = tree.GetSalaryBudegetForManager(employees[3]);
            Assert.IsTrue(result == 19100);
        }
    }
}
