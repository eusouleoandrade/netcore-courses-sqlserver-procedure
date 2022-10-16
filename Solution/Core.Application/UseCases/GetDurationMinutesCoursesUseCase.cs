using AutoMapper;
using Core.Application.Dtos.Responses;
using Core.Application.Interfaces.Repositories;
using Core.Application.Interfaces.UseCases;
using Core.Application.Resources;
using Infra.Notification.Abstractions;
using Infra.Notification.Extensions;

namespace Core.Application.UseCases
{
    public class GetDurationMinutesCoursesUseCase : Notifiable, IGetDurationMinutesCoursesUseCase
    {
        private readonly IMapper _mapper;
        private readonly IDurationMinutesCoursesRepository _durationMinutesCoursesRepository;

        public GetDurationMinutesCoursesUseCase(IMapper mapper, IDurationMinutesCoursesRepository durationMinutesCoursesRepository)
        {
            _mapper = mapper;
            _durationMinutesCoursesRepository = durationMinutesCoursesRepository;
        }

        public async Task<GetDurationMinutesCoursesUseCaseResponse?> RunAsync(int level)
        {
            Validade(level);

            if (HasErrorNotification)
                return default;

            var durationMinutesCourses = await _durationMinutesCoursesRepository.GetAsync(level);

            if (durationMinutesCourses is null)
            {
                AddErrorNotification(Msg.DATA_OF_X0_X1_NOT_FOUND_COD, Msg.DATA_OF_X0_X1_NOT_FOUND_TXT.ToFormat("Level", level));
                return default;
            }

            var useCaseResponse = _mapper.Map<GetDurationMinutesCoursesUseCaseResponse>(durationMinutesCourses);

            return useCaseResponse;
        }

        private void Validade(int level)
        {
            if (level <= Decimal.Zero)
                AddErrorNotification(Msg.IDENTIFIER_X0_IS_INVALID_COD, Msg.IDENTIFIER_X0_IS_INVALID_TXT.ToFormat(level));
        }
    }
}