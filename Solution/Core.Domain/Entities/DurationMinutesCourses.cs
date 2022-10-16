namespace Core.Domain.Entities
{
    public class DurationMinutesCourses
    {
        public int Level { get; private set; }

        public int CountLevel { get; private set; }

        public int Duration { get; private set; }

        public DurationMinutesCourses(int level, int countLevel, int duration)
        {
            Level = level;
            CountLevel = countLevel;
            Duration = duration;
        }
    }
}