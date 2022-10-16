using AutoMapper;
using Core.Application.Dtos.Queries;
using Core.Application.Dtos.Responses;
using Core.Domain.Entities;

namespace Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<DurationMinutesCourses, GetDurationMinutesCoursesUseCaseResponse>();
            CreateMap<GetDurationMinutesCoursesUseCaseResponse, GetDurationMinutesCoursesQuery>();
        }
    }
}