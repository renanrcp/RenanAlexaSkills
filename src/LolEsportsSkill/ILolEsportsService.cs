using LolEsportsSkill.Models;

namespace LolEsportsSkill;

public interface ILolEsportsService
{
    Task<Schedule> GetScheduleAsync(string? pageToken);
}
