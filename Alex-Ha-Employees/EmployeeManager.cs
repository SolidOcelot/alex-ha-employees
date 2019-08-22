using System;
using System.Collections.Generic;
using System.Linq;

namespace Alex_Ha_Employees
{
    class EmployeeManager
    {
        private List<Row> employeeList;
        private List<Pair> employeePairs = new List<Pair>();

        public EmployeeManager(List<Row> employees)
        {
            employeeList = employees;

            this.PopulateEmployeePairs();
        }

        private void PopulateEmployeePairs()
        {
            int daysTogether = 0;

            for (int i = 0; i < employeeList.Count - 1; i++)
            {
                Row emp1 = employeeList[i];

                for (int j = i + 1; j < employeeList.Count; j++)
                {
                    Row emp2 = employeeList[j];

                    if (emp1.ProjectID == emp2.ProjectID)
                    {
                        daysTogether = GetTimeWorkedTogether(emp1, emp2);

                        if (daysTogether > 0) CreatePair(emp1, emp2, daysTogether);
                    }
                }
            }
        }

        private int GetTimeWorkedTogether(Row emp1, Row emp2)
        {
            DateTime startDate, endDate;

            if (emp1.DateFrom < emp2.DateFrom) startDate = emp2.DateFrom;
            else startDate = emp1.DateFrom;

            if (emp1.DateTo < emp2.DateTo) endDate = emp1.DateTo;
            else endDate = emp2.DateTo;

            return (endDate - startDate).Days;
        }

        private void CreatePair(Row emp1, Row emp2, int daysTogether)
        {
            int lowerID, higherID;

            if (emp1.EmpID < emp2.EmpID)
            {
                lowerID = emp1.EmpID;
                higherID = emp2.EmpID;
            }
            else
            {
                lowerID = emp2.EmpID;
                higherID = emp1.EmpID;
            }

            Pair searchedPair = employeePairs.Find(e => e.EmpLowerID == lowerID
                                    && e.EmpHigherID == higherID);

            if(searchedPair == null)
            {
                employeePairs.Add(new Pair(lowerID, higherID, emp1.ProjectID, daysTogether));
            }
            else
            {
                searchedPair.TimeWorkedTogether += daysTogether;
            }
        }

        public List<Pair> GetLongestTimeTogetherPairList()
        {
            Pair longestTimePair = 
                      employeePairs.OrderByDescending(p => p.TimeWorkedTogether).First();

            List<Pair> longestTimePairAllProjects = employeePairs.Where(
                                    e => e.EmpLowerID == longestTimePair.EmpLowerID
                                    && e.EmpHigherID == longestTimePair.EmpHigherID).ToList();
            
            return longestTimePairAllProjects;
        }
    }
}
