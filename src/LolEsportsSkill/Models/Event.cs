using System.Text.Json.Serialization;

namespace LolEsportsSkill.Models;

public class Event
{
    [JsonPropertyName("startTime")]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("blockName")]
    public string BlockName { get; set; } = null!;

    [JsonPropertyName("league")]
    public League League { get; set; } = null!;

    [JsonPropertyName("match")]
    public Match Match { get; set; } = null!;
}
