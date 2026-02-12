using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Json2Cdf;

internal static class Read
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public static Deck LoadFromFile(
        string path
    ) =>
        ReadAsync(path).GetAwaiter().GetResult();

    public static async Task<Deck> ReadAsync(
        string path
    )
    {
        ArgumentNullException.ThrowIfNull(path);

        Debug.WriteLine($"Reading {Path.GetFullPath(path)}");
        var bytes = await File.ReadAllBytesAsync(path).ConfigureAwait(false);

        Deck deck;
        using (var ms = new MemoryStream(bytes, writable: false))
        {
            var deserialized = await JsonSerializer.DeserializeAsync<Deck>(ms, Options).ConfigureAwait(false);
            deck = deserialized ?? new Deck();
        }

        try
        {
            using var doc = JsonDocument.Parse(bytes, new JsonDocumentOptions { AllowTrailingCommas = true });
            deck.Raw = doc.RootElement.Clone();
        }
        catch
        {
            deck.Raw = null;
        }

        return deck;
    }
}
