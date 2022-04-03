using LolEsportsSkill.Models;

namespace LolEsportsSkill;

public interface ILolEsportsService : IDisposable
{
    Task<Schedule> GetScheduleAsync(string? pageToken = null);
}
