namespace Core.Application.Dtos.Queries
{
    public class GetDurationMinutesCoursesQuery
    {
        public int Level { get; private set; }

        public int CountLevel { get; private set; }

        public int Duration { get; private set; }

        public GetDurationMinutesCoursesQuery(int level, int countLevel, int duration)
        {
            Level = level;
            CountLevel = countLevel;
            Duration = duration;
        }
    }
}
