namespace Program.Model
{
    public class Storage : SomeTable
    {
        private string _office_Hours_Start;
        public string Office_Hours_Start
        {
            get => _office_Hours_Start;
            set { _office_Hours_Start = value; }
        }

        private string _office_Hours_End;
        public string Office_Hours_End
        {
            get => _office_Hours_End;
            set { _office_Hours_End = value; }
        }

        public Storage(string office_Hours_Start, string office_Hours_End)
        {
            _office_Hours_Start = office_Hours_Start;
            _office_Hours_End = office_Hours_End;
        }
    }
}
