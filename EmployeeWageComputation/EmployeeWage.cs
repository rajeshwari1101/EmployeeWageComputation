using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    internal class EmployeeWage
    {
        // Constant variables declared here
        private const int IS_FULL_TIME = 1;
        private const int IS_PART_TIME = 0;
        private const int IS_PRESENT = 1;
        private const int IS_ABSENT = 0;
        private readonly int RATE_PER_HOUR = 20;
        private readonly int WORKING_DAYS_PER_MONTH = 20;
        private readonly int HOURS_PER_MONTH = 100;

        // Attributes of the class declared here
        private int totalDaysWorked;
        private int monthlyWage;
        private int totalHoursWorked;

        // Random object declared
        private static Random random = new Random();

        // Default Constructor
        public EmployeeWage()
        {
            totalDaysWorked = 0;
            monthlyWage = 0;
            totalHoursWorked = 0;
        }

        // Parametrised Constructor
        public EmployeeWage(int ratePerHour, int maxWorkingDays, int maxHoursPerMonth)
        {
            RATE_PER_HOUR = ratePerHour;
            WORKING_DAYS_PER_MONTH = maxWorkingDays;
            HOURS_PER_MONTH = maxHoursPerMonth;
        }

        // Resets class attributes to default values given in constructor
        private void Reset()
        {
            totalDaysWorked = 0;
            monthlyWage = 0;
            totalHoursWorked = 0;
        }

        // Gets attendance of employee using Random
        private int GetAttendance()
        {
            int checkAttendance = random.Next(0, 2);
            if (checkAttendance == IS_PRESENT)
                return IS_PRESENT;
            else
                return IS_ABSENT;
        }

        // Calculates Daily Wage
        private int GetDailyWage()
        {
            int dailyWage = 0;
            int dailyHours = 0;
            int empCheck = random.Next(0, 2);
            switch (empCheck)
            {
                case IS_FULL_TIME:
                    dailyHours = 8;
                    break;
                case IS_PART_TIME:
                    dailyHours = 4;
                    break;
                default:
                    dailyHours = 0;
                    break;
            }
            totalHoursWorked += dailyHours;
            dailyWage = dailyHours * RATE_PER_HOUR;
            return dailyWage;
        }

        // Gets monthly wage after checkking attendance for the working days
        private void CalculateMonthlyWage()
        {
            for (int i = 0; i < WORKING_DAYS_PER_MONTH; i++)
                totalDaysWorked += GetAttendance();
            for (int j = 0; j < totalDaysWorked; j++)
                monthlyWage += GetDailyWage();
        }

        // Until total hours reaches 100 or total days = 20
        public void MeetWageCondition()
        {
            while (totalDaysWorked != WORKING_DAYS_PER_MONTH && totalHoursWorked < HOURS_PER_MONTH)
            {
                Reset();
                CalculateMonthlyWage();
            }
        }

        // Displays the values of the class atributes at the time this method is called
        public void Display()
        {
            Console.WriteLine("Total Hours worked: " + totalHoursWorked);
            Console.WriteLine("Total Days worked: " + totalDaysWorked);
            Console.WriteLine("Monthly Wage: " + monthlyWage);
        }

        // Overriding the ToString method of Object class
        public override string ToString()
        {
            return "Total Hours: " + totalHoursWorked + "; Total Days: " + totalDaysWorked + "; Total Wage: " + monthlyWage;
        }
    }
}
