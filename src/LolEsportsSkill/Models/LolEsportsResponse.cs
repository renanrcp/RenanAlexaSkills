using System.Text.Json.Serialization;

namespace LolEsportsSkill.Models;

public class LolEsportsResponse
{
    [JsonPropertyName("data")]
    public LolEsportsData Data { get; set; } = null!;
}
