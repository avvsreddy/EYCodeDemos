namespace TrainerTraineeApp.Entities
{
    public class Trainee
    {
        public Trainer TheTrainer { get; set; }
        public List<Training> Trainings { get; set; } = new List<Training>();
    }
}
