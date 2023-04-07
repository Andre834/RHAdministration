using RHAdministrationAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolRHAdministration
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputheadMaster,
        HeadMaster
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal totalSaliries = 0;
            List<IEmployee> employees = new List<IEmployee>();
            SeeData(employees);
            //foreach (IEmployee employee in employees)
            //{
            //    totalSaliries += employee.Salary;
            //}
            //Console.WriteLine($"Total Annual Salaries (Including bonus): {totalSaliries}");
            Console.WriteLine($"Total Annual Salaries (Including bonus): {employees.Sum(e => e.Salary)}");

        }
        public static void SeeData(List<IEmployee> employees)
        {
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Sousa", 2000);
            employees.Add(teacher1);

            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Balo", "Silva", 4000);
            employees.Add(teacher2);

            IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Carlos", "Oliveira", 6000);
            employees.Add(headOfDepartment);


            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputheadMaster, 4, "Marcia", "Sousa", 8000);
            employees.Add(deputyHeadMaster);

            IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "João", "Caros", 10000);
            employees.Add(headMaster);


        }




    }

    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }

    }
    public class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }

    }
    public class DeputheadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }


    }
    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }

    }

    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
        {
            IEmployee employee = null;
            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    //employee = new Teacher { Id = id, FirstName = firstName, lastName = lastName, Salary = salary };
                    break;
                case EmployeeType.HeadOfDepartment:
                    employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    break;
                case EmployeeType.DeputheadMaster:
                    employee = FactoryPattern<IEmployee, DeputheadMaster>.GetInstance();    
                    break;
                case EmployeeType.HeadMaster:
                    employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                    break;
                default:
                    break;
            }
            if (employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstName;
                employee.lastName = lastName;
                employee.Salary = salary;
            }
            else
            {
                throw new NullReferenceException();
            }

            return employee;

        }
    }
}
