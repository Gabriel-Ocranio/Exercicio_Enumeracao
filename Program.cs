using System;
using Enumeracao.Entities.Enums;
using Enumeracao.Entities;
using System.Globalization;

namespace Enumeracao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            System.Console.WriteLine("Enter Worker data: ");
            System.Console.Write("Name: ");
            string name = Console.ReadLine();
            System.Console.Write("Level (Junior,MidLevel,Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            System.Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            System.Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            Department dept = new Department(deptName);
            Worker worker = new Worker(name,level, salary, dept);
            Console.Clear();

            for(int i = 1; i<= n; i++){
                System.Console.WriteLine($"Enter #{i} contract data: ");
                System.Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                System.Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                System.Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, value, hours);
                worker.AddContract(contract);
            }
            Console.Clear();
            System.Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0,2));
            int year = int.Parse(monthAndYear.Substring(3));
            System.Console.WriteLine();
            System.Console.WriteLine("Name: " + worker.Name);
            System.Console.WriteLine("Department: " + worker.Department.Name);
            System.Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month));
            
        }
    }
}
