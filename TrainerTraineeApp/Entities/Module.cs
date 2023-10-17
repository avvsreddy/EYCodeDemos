namespace TrainerTraineeApp.Entities
{
    public class Module
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
    }

    public class Course
    {
        public List<Training> Trainings { get; set; } = new List<Training>();
        public List<Module> Modules { get; set; } = new List<Module>();
    }
    public class Unit
    {
        public int Duration { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
    public class Topic
    {
        public string Name { get; set; }
    }
}
