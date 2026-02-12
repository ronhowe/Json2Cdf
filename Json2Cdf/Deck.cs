using System.Text.Json;
using System.Text.Json.Serialization;

namespace Json2Cdf;

public class Deck
{
    [JsonPropertyName("cards")]
    public List<Card> Cards { get; set; } = [];

    [JsonIgnore]
    public JsonElement? Raw { get; set; }
}
