namespace OOConceptsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee e1 = new Employee(111, "Ravi");
            Employee e1 = new Employee();
            e1.ID = 111;
            e1.Name = "Ravi";
            e1.Salary = 60000;

            // Object Initialization Syntax

            Employee e11 = new Employee
            {
                ID = 111,
                Name = "Ravi",
                Salary = 75000
            };

            Employee e2 = new Employee { ID = 111 };
            Employee e3 = new Employee { ID = 111, Name = "Ravi", Salary = 60000 };
            Employee e4 = new Employee();

            // Anonymous object/types

            var p = new { Pid = 111, PName = "IPhone", Rate = 125000 };

            Console.WriteLine(p.PName);
            //p.Rate = 0;
        }
    }

    class _andsfsdfsd3434234
    {

    }

    class Employee
    {

        //private int id;
        //private string name;
        //private int salary;

        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        //public Employee()
        //{
        //    this.id = 0;
        //    this.name = string.Empty;
        //    this.salary = 0;
        //}
        //public Employee(int eid, string name) : this(eid)
        //{
        //    //this.id = eid;
        //    this.name = name;
        //}
        //public Employee(int eid)
        //{
        //    this.id = eid;
        //}
        //public Employee(int eid, string name, int sal) : this(eid, name)
        //{
        //    //this.id = eid;
        //    //this.name = name;
        //    this.salary = sal;
        //}
    }



}