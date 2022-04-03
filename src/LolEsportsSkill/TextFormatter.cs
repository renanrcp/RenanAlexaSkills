namespace LolEsportsSkill;

public static class TextFormatter
{
    public static string FormatGameDay(string team1, string team2, DateTime gameDate)
    {
        return $"Hoje tem jogo entre {team1} e {team2} às {TimeOnly.FromDateTime(gameDate).Hour} horas";
    }
}
