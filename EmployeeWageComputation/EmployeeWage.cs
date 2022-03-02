using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    internal class EmployeeWage
    {
        // Constant and Readonly variables declared here
        private const int IS_FULL_TIME = 1;
        private const int IS_PART_TIME = 0;
        private readonly int RATE_PER_HOUR = 20;
        private readonly int WORKING_DAYS_PER_MONTH = 20;
        private readonly int HOURS_PER_MONTH = 100;

        // Attributes of the class declared here
        private int totalDaysWorked;
        private int monthlyWage;
        private int dailyWage;
        private int totalHoursWorked;
        private readonly string company;

        // Random object declared
        private static readonly Random random = new();

        // Properties
        public string Company
        {
            get { return company; }
        }
        public int DailWage
        {
            get { return dailyWage; }
        }
        public int TotalWage
        {
            get { return monthlyWage; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeWage"/> class.
        /// </summary>
        /// <param name="company">The company name.</param>
        public EmployeeWage(string company)
        {
            totalDaysWorked = 0;
            monthlyWage = 0;
            totalHoursWorked = 0;
            this.company = company;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeWage"/> class.
        /// </summary>
        /// <param name="companyName">Name of the company.</param>
        /// <param name="ratePerHour">The rate per hour.</param>
        /// <param name="maxWorkingDays">The maximum working days.</param>
        /// <param name="maxHoursPerMonth">The maximum hours per month.</param>
        public EmployeeWage(string companyName, int ratePerHour, int maxWorkingDays, int maxHoursPerMonth)
        {
            RATE_PER_HOUR = ratePerHour;
            WORKING_DAYS_PER_MONTH = maxWorkingDays;
            HOURS_PER_MONTH = maxHoursPerMonth;
            company = companyName;
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        private void Reset()
        {
            totalDaysWorked = 0;
            monthlyWage = 0;
            totalHoursWorked = 0;
            dailyWage = 0;
        }

        /// <summary>
        /// Gets the attendance using Random.
        /// </summary>
        /// <returns>Return 0 for absent, 1 for present.</returns>
        private static int GetAttendance()
        {
            return random.Next(0, 2);
        }

        /// <summary>
        /// Gets the daily wage.
        /// </summary>
        /// <returns>The Dail wage</returns>
        private int GetDailyWage()
        {
            int empCheck = random.Next(0, 2);
            int dailyHours = empCheck switch
            {
                IS_FULL_TIME => 8,
                IS_PART_TIME => 4,
                _ => 0,
            };
            totalHoursWorked += dailyHours;
            dailyWage = dailyHours * RATE_PER_HOUR;
            return dailyWage;
        }

        /// <summary>
        /// Calculates the monthly wage.
        /// </summary>
        private void CalculateMonthlyWage()
        {
            for (int i = 0; i < WORKING_DAYS_PER_MONTH; i++)
                totalDaysWorked += GetAttendance();
            for (int j = 0; j < totalDaysWorked; j++)
                monthlyWage += GetDailyWage();
        }

        /// <summary>
        /// Meets the wage condition.
        /// Days Worked == WORKING_DAYS_PER_MONTH
        /// OR
        /// Hours Worked == HOURS_PER_MONTH
        /// </summary>
        public void MeetWageCondition()
        {
            while (totalDaysWorked != WORKING_DAYS_PER_MONTH && totalHoursWorked < HOURS_PER_MONTH)
            {
                Reset();
                CalculateMonthlyWage();
            }
        }

        /// <summary>
        /// Displays the details of the respective company's Employee wage.
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Total Hours worked: " + totalHoursWorked);
            Console.WriteLine("Total Days worked: " + totalDaysWorked);
            Console.WriteLine("Daily Wage: " + dailyWage);
            Console.WriteLine("Monthly Wage: " + monthlyWage);
        }

        /// <summary>
        /// Converts to string.
        /// Has been overridden and optimised for this class
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> with Total wage & Daily wage info.
        /// </returns>
        public override string ToString()
        {
            return $"Total Wage: {TotalWage}; Daily Wage: {DailWage}";
        }
    }
}
