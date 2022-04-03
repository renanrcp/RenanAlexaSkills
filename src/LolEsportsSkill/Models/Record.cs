using System.Text.Json.Serialization;

namespace LolEsportsSkill.Models;

public class Record
{
    [JsonPropertyName("wins")]
    public int Wins { get; set; }

    [JsonPropertyName("losses")]
    public int Losses { get; set; }
}
