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
        const int IS_FULL_TIME = 1;
        const int IS_PART_TIME = 0;
        const int IS_PRESENT = 1;
        const int IS_ABSENT = 0;
        const int RATE_PER_HOUR = 20;
        const int WORKING_DAYS_PER_MONTH = 20;

        // Attributes of the class declared here
        int totalDaysWorked;
        int monthlyWage;

        public EmployeeWage()
        {
            totalDaysWorked = 0;
            monthlyWage = 0;
        }

        private int GetAttendance()
        {
            Random random = new Random();
            int checkAttendance = random.Next(0, 2);
            if (checkAttendance == IS_PRESENT)
                return IS_PRESENT;
            else
                return IS_ABSENT;
        }

        private int GetDailyWage()
        {
            int dailyWage = 0;
            int dailyHours = 0;
            Random random = new Random();
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
            dailyWage = dailyHours * RATE_PER_HOUR;
            return dailyWage;
        }

        public void MonthlyWage()
        {
            for (int i = 0; i < WORKING_DAYS_PER_MONTH; i++)
                totalDaysWorked += GetAttendance();
            for (int j = 0; j < totalDaysWorked; j++)
            {
                monthlyWage += GetDailyWage();
            }
            Console.WriteLine("Monthly Wage: " + monthlyWage);
        }
    }
}
