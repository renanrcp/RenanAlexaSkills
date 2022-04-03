using System.Globalization;

namespace LolEsportsSkill;

public static class TextFormatter
{
    public static string FormatGameDay(string team1, string team2, DateTime gameDate)
    {
        return $"Hoje tem jogo entre {team1} e {team2} às {TimeOnly.FromDateTime(gameDate).Hour} horas";
    }

    public static string TodayHasNoGame(string team1, string team2, DateTime gameDate)
    {
        var time = TimeOnly.FromDateTime(gameDate);
        var date = DateOnly.FromDateTime(gameDate);
        var monthName = new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(date.Month);

        return $"Hoje não tem jogo, o próximo jogo é entre {team1} e {team2} dia {date.Day} de {monthName} às {time.Hour} horas";
    }

    public static string NoGamesScheduled()
    {
        return "Não há nenhum jogo agendado";
    }
}
