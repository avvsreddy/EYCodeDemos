using TrainerTraineeApp.Entities;

namespace TrainerTraineeApp.PresentationLayer
{
    internal class Program // UI Class - Front-End
    {
        static void Main(string[] args)
        {
            Organization theOrg = new Organization(); // object instatiation
            theOrg.OrgName = "Test";

            Trainer trainer = new Trainer();

            trainer.TheOrg = theOrg;

            Training training = new Training();

            training.Trainer = trainer;

            string org = training.GetTrainingOrgName();
            //Console.WriteLine(org);

            Trainee t1 = new Trainee();
            Trainee t2 = new Trainee();
            Trainee t3 = new Trainee();

            training.Trainees.Add(t1);
            training.Trainees.Add(t2);
            //training.Trainees.Add(t3);

            int c = training.GetTraineesCount();
            //Console.WriteLine($"Trainees Count : {c}");

            Course course = new Course();
            training.Course = course;

            Module m1 = new Module();
            Module m2 = new Module();

            course.Modules.Add(m1);
            course.Modules.Add(m2);

            Unit u1 = new Unit();
            u1.Duration = 10;
            Unit u2 = new Unit();
            u2.Duration = 20;
            Unit u3 = new Unit();
            u3.Duration = 10;
            Unit u4 = new Unit();
            u4.Duration = 20;

            m1.Units.Add(u1);
            m1.Units.Add(u2);

            m2.Units.Add(u3);
            m2.Units.Add(u4);

            int duration = training.GetTrainingDuration();
            Console.WriteLine($"Training duration : {duration}");
        }
    }


}