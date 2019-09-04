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
            var nodeManager = GetManagerNode(employee);
            AddNode(nodeManager, employee);
        }
        public void AddNode(Node nodeManager, Employee employee)
        {
            Node newNode = new Node(employee);
            if (nodeManager == null)
            {
                root = newNode;
                nodeManager = newNode;
                return;
            }

            if (nodeManager.children == null)
                nodeManager.children = new List<Node>() { newNode };
            else
                nodeManager.children.Add(newNode);
        }

        private Node GetManagerNode(Employee employee)
        {   if (root == null)
                return null;

            if (root.employee.Id == employee.ManagerId || root.employee.ManagerId == string.Empty)
                return root;

            foreach (var child in root.children)
                if (child.employee.Id == employee.ManagerId)
                    return child;

            return null;
        }

        public int GetSalaryBudegetForManager(Employee employee)
        {
            var nodeManager = GetManagerNode(employee);
            var result = SalaryBudget(nodeManager);

            return result;
        }

        private int SalaryBudget(Node head)
        {
            int salary = head.employee.Salary;
            //O(h) where h is the height of the tree
            foreach (var child in head.children)
                salary = salary  + child.employee.Salary;

            return salary;
        }
    }
}
