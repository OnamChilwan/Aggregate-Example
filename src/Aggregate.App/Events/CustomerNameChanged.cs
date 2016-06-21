namespace Aggregate.App.Events
{
    public class CustomerNameChanged
    {
        public CustomerNameChanged(string forename, string surname)
        {
            Forename = forename;
            Surname = surname;
        }

        public string Forename { get; private set; }

        public string Surname { get; private set; }
    }
}