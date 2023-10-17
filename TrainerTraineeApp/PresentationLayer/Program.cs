using TrainerTraineeApp.Entities;

namespace TrainerTraineeApp.PresentationLayer
{
    internal class Program // UI Class - Front-End
    {
        static void Main(string[] args)
        {
            Organization theOrg = new Organization(); // object instatiation
            theOrg.OrgName = "Test";
            Console.WriteLine(theOrg.OrgName);
            //theOrg.SetName("ABC");



            //string n = theOrg.GetName();
            //Console.WriteLine(n);


        }
    }

    class Employee
    {
        //private string name;
        //private int salary;
        //private int age;
        private int _backingfield3434234234234;



        public int EmpNo { get; set; }

        public int Age // Automatic Properties
        {
            get; //{return _backingfield3434234234234; }
            set; //{_backingfield3434234234234 = value; }
        }
        public string Name
        {
            get;// { return name; }
            set;// { name = value; }
        }

        public int Salary
        {
            get;// { return salary; }
            set;// { salary = value; }
        }

    }

    class Customer
    {
        public int CustomerID { get; init; } = 111;
        public string Name { get; private set; }

        public string Email { private get; set; }

        public string Mobile { get; set; }
    }
}