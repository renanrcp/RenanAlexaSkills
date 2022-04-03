using System.Text.Json.Serialization;

namespace LolEsportsSkill.Models;

public class Strategy
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("count")]
    public int Count { get; set; }
}
