using System.Text.Json.Serialization;

namespace LolEsportsSkill.Models;

public class Team
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("code")]
    public string Code { get; set; } = null!;

    [JsonPropertyName("image")]
    public string Image { get; set; } = null!;

    [JsonPropertyName("result")]
    public Result? Result { get; set; }

    [JsonPropertyName("record")]
    public Record? Record { get; set; }
}
