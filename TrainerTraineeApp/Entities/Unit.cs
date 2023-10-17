namespace TrainerTraineeApp.Entities
{
    public class Unit
    {
        public int Duration { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
}
