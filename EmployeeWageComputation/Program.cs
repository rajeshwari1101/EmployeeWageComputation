using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Wage Computation");
            // Creating an object of CompanyList
            CompanyList companyList = new();

            // Adding company with default values for wage, number of working days and working hours per month
            companyList.AddCompany("Reliance");
            companyList.AddCompany("Tata");

            // Adding company with parameters for wage, number of working days and working hours per month
            companyList.AddCompany("Facebook", 50, 22, 120);

            // Display all companies
            companyList.Display();

            Console.ReadLine();
        }
    }
}