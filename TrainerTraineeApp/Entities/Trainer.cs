namespace TrainerTraineeApp.Entities
{
    public class Trainer
    {
        public string Name { get; set; }
        public Organization TheOrg { get; set; }

        // Static Array
        //public Trainee[] Trainees { get; set; } = new Trainee[10];
        // Dynamic Array / collection
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();

        public List<Training> Trainings { get; set; } = new List<Training>();
    }
}
