using System.Text.Json;
using System.Text.Json.Serialization;

namespace Json2Cdf;

public class Face
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("subType")]
    public string? SubType { get; set; }

    [JsonPropertyName("destiny")]
    public string? Destiny { get; set; }

    [JsonPropertyName("deploy")]
    public string? Deploy { get; set; }

    [JsonPropertyName("forfeit")]
    public string? Forfeit { get; set; }

    [JsonPropertyName("power")]
    public string? Power { get; set; }

    [JsonPropertyName("ability")]
    public string? Ability { get; set; }

    [JsonPropertyName("politics")]
    public string? Politics { get; set; }

    [JsonPropertyName("armor")]
    public string? Armor { get; set; }

    [JsonPropertyName("landspeed")]
    public string? Landspeed { get; set; }

    [JsonPropertyName("maneuver")]
    public string? Maneuver { get; set; }

    [JsonPropertyName("hyperspeed")]
    public string? Hyperspeed { get; set; }

    [JsonPropertyName("icons")]
    public List<string>? Icons { get; set; }

    [JsonPropertyName("extraText")]
    public List<string>? ExtraText { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("lore")]
    public string? Lore { get; set; }

    [JsonPropertyName("gametext")]
    public string? GameText { get; set; }

    [JsonPropertyName("uniqueness")]
    public string? Uniqueness { get; set; }

    [JsonPropertyName("parsec")]
    public string? Parsec { get; set; }

    [JsonPropertyName("darkSideIcons")]
    public int? DarkSideIcons { get; set; }

    [JsonPropertyName("lightSideIcons")]
    public int? LightSideIcons { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; set; }
}
