using System.Text.Json.Serialization;

namespace LolEsportsSkill.Models;

public class LolEsportsData
{
    [JsonPropertyName("schedule")]
    public Schedule Schedule { get; set; } = null!;
}
