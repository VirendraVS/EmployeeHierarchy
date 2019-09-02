using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy
{
    public class HierarchyTree
    {
        public class Node
        {
            public Employee employee;
            public Node left, right;
            public Node(Employee employee)
            {
                this.employee = employee;
                left = right = null;
            }
        }

        public Node root = null;
        public void Add (Node root,Employee employee)
        {
            Node newNode = new Node(employee);
            if (root == null)
            {
                root = newNode;
                return;
            }

            if(string.Compare(employee.ManagerId,root.left.employee.ManagerId) > 0)
            {

            }
        }

        private int SalaryBudget(Node root)
        {
            SalaryBudget(root.left);
            SalaryBudget(root.right);

            var salary = +root.employee.Salary;

            return salary;
        }
    }
}
