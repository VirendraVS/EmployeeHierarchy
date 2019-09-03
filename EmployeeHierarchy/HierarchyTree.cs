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
            public List<Node> children;
            public Node(Employee employee)
            {
                this.employee = employee;
                children = null;
            }
        }

        public Node root = null;

        public void InsertEmployee(Employee employee)
        {
            var root = GetManagerNode(employee);
            AddNode(root, employee);
        }
        public void AddNode(Node head, Employee employee)
        {
            Node newNode = new Node(employee);
            if (head == null)
            {
                head = newNode;
                return;
            }

            if (head.children == null)
                head.children = new List<Node>() { newNode };
            else
                head.children.Add(newNode);
        }

        private Node GetManagerNode(Employee employee)
        {
            if (root.employee.Id == employee.ManagerId)
                return root;

            foreach (var child in root.children)
                if (child.employee.Id == employee.ManagerId)
                    return child;

            return null;
        }

        private int SalaryBudget(Node head)
        {
            int salary = head.employee.Salary;
            foreach (var child in head.children)
                salary = +child.employee.Salary;

            return salary;
        }
    }
}
