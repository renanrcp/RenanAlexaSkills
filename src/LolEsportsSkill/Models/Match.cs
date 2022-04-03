using System.Text.Json.Serialization;

namespace LolEsportsSkill.Models;

public class Match
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("flags")]
    public List<string> Flags { get; set; } = new();

    [JsonPropertyName("teams")]
    public List<Team> Teams { get; set; } = new();

    [JsonPropertyName("strategy")]
    public Strategy Strategy { get; set; } = null!;
}
