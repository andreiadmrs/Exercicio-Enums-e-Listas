using System;
using System.Globalization;
using Enum1.Entities;
using Enum1.Entities.Enums;

namespace Enum1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter department's name");
            string depName = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Level: (Junior/MidLevel/Senior):");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.WriteLine("Base Salary:");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(depName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine("How many contracts to this worker?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data");
                Console.WriteLine("Date (DD/MM/YYYY):");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Value per hour:");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Duration (Hours):");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.WriteLine("Enter month and year to calculate income (MM/YYYY):");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));           

            Console.WriteLine("Name "+ worker.Name);
            Console.WriteLine("Department "+ worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
            
        }

    }
}