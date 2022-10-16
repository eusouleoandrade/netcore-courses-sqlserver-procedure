using AutoMapper;
using Core.Application.Dtos.Queries;
using Core.Application.Dtos.Wrappers;
using Core.Application.Interfaces.UseCases;
using Infra.Notification.Contexts;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Controllers.Common;

namespace Presentation.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class LevelController : BaseApiController
    {
        private readonly IGetDurationMinutesCoursesUseCase _getDurationMinutesCoursesUseCase;
        private readonly NotificationContext _notificationContext;
        private readonly IMapper _mapper;

        public LevelController(IGetDurationMinutesCoursesUseCase getDurationMinutesCoursesUseCase, NotificationContext notificationContext, IMapper mapper)
        {
            _getDurationMinutesCoursesUseCase = getDurationMinutesCoursesUseCase;
            _notificationContext = notificationContext;
            _mapper = mapper;
        }

        [HttpGet("{level}/duration-courses")]
        public async Task<ActionResult<Response<GetDurationMinutesCoursesQuery>>> Get([FromRoute] int level)
        {
            var useCaseResponse = await _getDurationMinutesCoursesUseCase.RunAsync(level);

            if (_getDurationMinutesCoursesUseCase.HasErrorNotification)
            {
                _notificationContext.AddErrorNotifications(_getDurationMinutesCoursesUseCase);
                return BadRequest();
            }

            var response = _mapper.Map<GetDurationMinutesCoursesQuery>(useCaseResponse);

            return Ok(new Response<GetDurationMinutesCoursesQuery>(succeeded: true, data: response));
        }
    }
}