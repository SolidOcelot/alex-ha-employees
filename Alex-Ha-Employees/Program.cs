using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Alex_Ha_Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "";
            List<Row> employees = new List<Row>();

            Console.WriteLine("Enter the path to the text file: ");

            try
            {
                string path = Console.ReadLine();
                StreamReader reader = new StreamReader(path);

                using (reader)
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        
                        DateTime dateFrom = DateTime.ParseExact(data[2].Trim(' '), "yyyy-MM-dd", null);

                        DateTime dateTo = CheckForNull(data[3]);

                        employees.Add(
                            new Row(Int32.Parse(data[0]), Int32.Parse(data[1]),
                                            dateFrom,
                                            dateTo));
                    }
                }
                
                EmployeeManager empManager = new EmployeeManager(employees);
                List<Pair> result = empManager.GetLongestTimeTogetherPairList();

                foreach(Pair pair in result)
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine("Result:");
                    Console.WriteLine($"Longest working pair ids: {pair.EmpLowerID} and {pair.EmpHigherID}.");
                    Console.WriteLine($"On project id: {pair.ProjectID}.");
                    Console.WriteLine($"For the duration of: {pair.TimeWorkedTogether} days.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong. Please try again.");
                Console.WriteLine("----------------");
                Main(args);
            } 
        }

        static DateTime CheckForNull(string date)
        {
            date = date.Trim(' ');

            if(date == "NULL")
            {
                return DateTime.Today;
            }
            else
            {
                return DateTime.ParseExact(date, "yyyy-MM-dd", null);
            }
        }
    }
}
