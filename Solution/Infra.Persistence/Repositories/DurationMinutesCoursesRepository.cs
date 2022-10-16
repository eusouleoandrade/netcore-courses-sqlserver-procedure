using Core.Application.Exceptions;
using Core.Application.Interfaces.Repositories;
using Core.Application.Resources;
using Core.Domain.Entities;
using Dapper;
using Infra.Persistence.Configs;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infra.Persistence.Repositories
{
    public class DurationMinutesCoursesRepository : ConnectionConfig, IDurationMinutesCoursesRepository
    {
        public DurationMinutesCoursesRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<DurationMinutesCourses?> GetAsync(int level)
        {
            try
            {
                string procedure = "[sp_sumDurationInMinutes]";

                var pars = new DynamicParameters();

                pars.Add("@LEVEL", value: level);
                pars.Add("@COUNT_LEVEL", dbType: DbType.Int32, direction: ParameterDirection.Output);
                pars.Add("@DURATION", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await _connection.QueryAsync(procedure, pars, commandType: CommandType.StoredProcedure);

                var countLevel = pars.Get<int>("@COUNT_LEVEL");
                var duration = pars.Get<int>("@DURATION");

                return new DurationMinutesCourses(level, countLevel, duration);
            }
            catch (Exception ex)
            {
                throw new AppException(Msg.DATA_BASE_SERVER_ERROR_TXT, ex);
            }
        }
    }
}