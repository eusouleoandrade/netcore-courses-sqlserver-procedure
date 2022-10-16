namespace Core.Application.Dtos.Responses
{
    public class GetDurationMinutesCoursesUseCaseResponse
    {
        public int Level { get; private set; }

        public int CountLevel { get; private set; }

        public int Duration { get; private set; }

        public GetDurationMinutesCoursesUseCaseResponse(int level, int countLevel, int duration)
        {
            Level = level;
            CountLevel = countLevel;
            Duration = duration;
        }
    }
}