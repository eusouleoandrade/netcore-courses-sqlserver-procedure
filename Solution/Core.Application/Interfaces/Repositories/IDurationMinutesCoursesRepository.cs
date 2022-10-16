using Core.Domain.Entities;

namespace Core.Application.Interfaces.Repositories
{
    public interface IDurationMinutesCoursesRepository
    {
        Task<DurationMinutesCourses?> GetAsync(int level);
    }
}
