using Core.Application.Dtos.Responses;
using Infra.Notification.Interfaces;

namespace Core.Application.Interfaces.UseCases
{
    public interface IGetDurationMinutesCoursesUseCase : INotifiable, IUseCase<int, GetDurationMinutesCoursesUseCaseResponse>
    {
    }
}
