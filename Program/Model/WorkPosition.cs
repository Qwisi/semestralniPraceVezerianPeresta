namespace Program.Model
{
    public class WorkPosition : SomeTable
    {
        private string _jobTitle;
        public string JobTitle
        {
            get => _jobTitle;
            set { _jobTitle = value; }
        }

        private int _hourlyWage;
        public int HourlyWage
        {
            get => _hourlyWage;
            set { _hourlyWage = value; }
        }

        public WorkPosition(string jobTitle, int hourlyWage)
        {
            _jobTitle = jobTitle;
            _hourlyWage = hourlyWage;
        }
    }
}
