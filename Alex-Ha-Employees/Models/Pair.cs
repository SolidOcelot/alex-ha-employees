namespace Alex_Ha_Employees
{
    class Pair
    {
        public int EmpLowerID { get; set; }
        public int EmpHigherID { get; set; }
        public int TimeWorkedTogether { get; set; }
        public int ProjectID { get; set; }

        public Pair(int empLowerID, int empHigherID, int projectID, int timeWorkedTogether)
        {
            this.EmpLowerID = empLowerID;
            this.EmpHigherID = empHigherID;
            this.ProjectID = projectID;
            this.TimeWorkedTogether = timeWorkedTogether;
        }
    }
}
