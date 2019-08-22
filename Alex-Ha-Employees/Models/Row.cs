using System;

namespace Alex_Ha_Employees
{
    class Row
    {
        public int EmpID { get; set; }
        public int ProjectID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public Row(int empID, int projectID, DateTime dateFrom, DateTime dateTo)
        {
            this.EmpID = empID;
            this.ProjectID = projectID;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
        }
    }
}
