using System.Text.Json.Serialization;

namespace LolEsportsSkill.Models;

public class Result
{
    [JsonPropertyName("outcome")]
    public string Outcome { get; set; } = null!;

    [JsonPropertyName("gameWins")]
    public int GameWins { get; set; }
}
