using System;
using EmployeeHierarchy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHierarchy.UnitTests
{
    [TestClass]
    public class HierarchyTests
    {
        public Employees EmployeeClass = new EmployeeHierarchy.Employees(@"Employees.csv");
        public HierarchyTree tree = new HierarchyTree();

        [TestMethod]
        public void EmployeeHierarchy_Scenario()
        {
            var employees = EmployeeClass.employees;
            foreach(var employee in employees)
                tree.InsertEmployee(employee);

            Assert.IsNotNull(tree.root);

            var result = tree.GetSalaryBudegetForManager(tree.root.employee);

            Assert.IsTrue(result == 43700);
        }
    }
}
