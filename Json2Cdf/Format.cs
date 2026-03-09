namespace Json2Cdf;

internal static class Format
{
    internal static string Destiny(
        string? frontDestiny,
        string? backDestiny
    )
    {
        return !string.IsNullOrWhiteSpace(frontDestiny)
            ? string.IsNullOrWhiteSpace(backDestiny)
                ? frontDestiny
                : $"{frontDestiny}/{backDestiny}"
            : Constants.Undefined;
    }

    internal static string ImageUrl(
        string? frontImageUrl,
        string? backImageUrl,
        string? type,
        bool isLegacy
    )
    {
        const string prefix = "https://res.starwarsccg.org/cards";
        const string largeSegment = "large/";

        if (string.IsNullOrWhiteSpace(frontImageUrl))
        {
            return string.Empty;
        }

        if (!frontImageUrl.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        {
            return string.Empty;
        }

        var route = string.Equals(type, Constants.Objective, StringComparison.OrdinalIgnoreCase)
            ? $"/{Constants.TwoSided}/{Constants.StarWars}"
            : $"/{Constants.StarWars}";

        var imageBase = isLegacy
            ? string.Empty
            : route
        ;

        var imagePath = string.Concat(imageBase, frontImageUrl.AsSpan(prefix.Length));

        if (imagePath.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
        {
            imagePath = imagePath[..^4];
        }

        var idxLarge = imagePath.IndexOf(largeSegment, StringComparison.OrdinalIgnoreCase);

        if (idxLarge >= 0)
        {
            imagePath = string.Concat(imagePath.AsSpan(0, idxLarge), "t_", imagePath.AsSpan(idxLarge + largeSegment.Length));
        }

        if (string.Equals(type, Constants.Objective, StringComparison.OrdinalIgnoreCase)
            && !string.IsNullOrWhiteSpace(backImageUrl)
            && backImageUrl.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        {
            // Strip prefix
            var backRemainder = backImageUrl[prefix.Length..];

            // Remove ".gif" if present (case-insensitive)
            if (backRemainder.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
            {
                backRemainder = backRemainder[..^4];
            }

            // Extract just the filename segment
            var lastSlashIndex = backRemainder.LastIndexOf('/');
            var backFileName = lastSlashIndex >= 0
                ? backRemainder[(lastSlashIndex + 1)..]
                : backRemainder;

            imagePath = string.Concat(imagePath, "/", backFileName);
        }

        if (string.Equals(type, Constants.Objective, StringComparison.OrdinalIgnoreCase) && isLegacy)
        {
            imagePath = string.Concat("/", Constants.TwoSided, imagePath);
        }

        return imagePath;
    }

    internal static string Label(
        string? label,
        string? value
    )
    {
        var safeLabel = string.IsNullOrWhiteSpace(label) ? Constants.Undefined : label;

        return string.IsNullOrWhiteSpace(value)
            ? $"{safeLabel}:"
            : $"{safeLabel}: {value}";
    }

    internal static string Set(
        string? set
    )
    {
        var normalizedSet = (set ?? string.Empty).ToUpperInvariant();
        return normalizedSet switch
        {
            "1" => "Premiere",
            "101" => "Premiere Introductory Two Player Game",
            "102" => "Jedi Pack",
            "103" => "Rebel Leader Pack",
            "2" => "A New Hope",
            "3" => "Hoth",
            "104" => "Empire Strikes Back Introductory Two Player Game",
            "4" => "Dagobah",
            "105" => "First Anthology",
            "5" => "Cloud City",
            "6" => "Jabba's Palace",
            "106" => "Official Tournament Sealed Deck",
            "107" => "Second Anthology",
            "7" => "Special Edition",
            "108" => "Enhanced Premiere",
            "8" => "Endor",
            "109" => "Enhanced Cloud City",
            "110" => "Enhanced Jabba's Palace",
            "111" => "Third Anthology",
            "9" => "Death Star II",
            "112" => "Jabba's Palace Sealed Deck",
            "10" => "Reflections 2",
            "11" => "Tatooine",
            "12" => "Coruscant",
            "13" => "Reflections 3",
            "14" => "Theed Palace",
            "200" => "Set 0",
            "201" => "Set 1",
            "202" => "Set 2",
            "203" => "Set 3",
            "204" => "Set 4",
            "205" => "Set 5",
            "206" => "Set 6",
            "207" => "Set 7",
            "208" => "Set 8",
            "209" => "Set 9",
            "210" => "Set 10",
            "211" => "Set 11",
            "212" => "Set 12",
            "213" => "Set 13",
            "214" => "Set 14",
            "215" => "Set 15",
            "216" => "Set 16",
            "217" => "Set 17",
            "218" => "Set 18",
            "219" => "Set 19",
            "220" => "Set 20",
            "221" => "Set 21",
            "222" => "Set 22",
            "223" => "Set 23",
            "224" => "Set 24",
            "225" => "Set 25",
            "226" => "Set 26",
            "227" => "Set 27",
            "301" => "Virtual Premium Set", // aka Demo Deck
            "401" => "Dream Cards",
            "501" => "Playtesting",
            "200D" => "Virtual Defensive Shields",
            "1001" => "Virtual Block 1",
            "1002" => "Virtual Block 2",
            "1003" => "Virtual Block 3",
            "1004" => "Virtual Block 4",
            "1005" => "Virtual Block 5",
            "1006" => "Virtual Block 6",
            "1007" => "Virtual Block 7",
            "1008" => "Virtual Block 8",
            "1009" => "Virtual Block 9",
            "1000D" => "Virtual Block Shields",
            _ => Constants.Undefined,
        };
    }

    internal static string SubType(
        string? subType
    )
    {
        if (string.IsNullOrWhiteSpace(subType))
        {
            return string.Empty;
        }

        var idx = subType.IndexOf(':');

        return idx >= 0
            ? subType[..idx].Trim()
            : subType.Trim();
    }
}
