using System.Text.Json;
using System.Text.Json.Serialization;

namespace Json2Cdf;

public class Card
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("gempId")]
    public string? GempId { get; set; }

    [JsonPropertyName("side")]
    public string? Side { get; set; }

    [JsonPropertyName("set")]
    public string? Set { get; set; }

    [JsonPropertyName("rarity")]
    public string? Rarity { get; set; }

    [JsonPropertyName("legacy")]
    public bool? Legacy { get; set; }

    [JsonPropertyName("conceptBy")]
    public string? ConceptBy { get; set; }

    [JsonPropertyName("front")]
    public Face? Front { get; set; }

    [JsonPropertyName("back")]
    public Face? Back { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; set; }
}
