using System.Text.Json.Serialization;

namespace LolEsportsSkill.Models;

public class League
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("slug")]
    public string Slug { get; set; } = null!;
}
