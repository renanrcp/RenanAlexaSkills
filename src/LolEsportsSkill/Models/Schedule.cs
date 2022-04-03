using System.Text.Json.Serialization;

namespace LolEsportsSkill.Models;

public class Schedule
{
    [JsonPropertyName("pages")]
    public Pages Pages { get; set; } = null!;

    [JsonPropertyName("events")]
    public List<Event> Events { get; set; } = new();
}
