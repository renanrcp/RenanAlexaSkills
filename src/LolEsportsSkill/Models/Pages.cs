using System.Text.Json.Serialization;

namespace LolEsportsSkill.Models;

public class Pages
{
    [JsonPropertyName("older")]
    public string? Older { get; set; }

    [JsonPropertyName("newer")]
    public object? Newer { get; set; }
}
