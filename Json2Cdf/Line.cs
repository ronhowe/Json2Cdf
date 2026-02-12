namespace Json2Cdf;

internal static class Line
{
    internal static string DeployLine(
        string? deploy,
        string? forfeit
    )
    {
        var safeDeploy = string.IsNullOrWhiteSpace(deploy) ? Constants.Undefined : deploy;
        var safeForfeit = (string.IsNullOrWhiteSpace(forfeit) ? Constants.Undefined : forfeit)
            .Replace("0.5", "1/2")
        ;

        var deployLabel = Format.Label(Constants.Deploy, safeDeploy);
        var forfeitLabel = Format.Label(Constants.Forfeit, safeForfeit);

        var parts = new List<string> { deployLabel };

        if (forfeit != null)
        {
            parts.Add(forfeitLabel);
        }

        return string.Join(" ", parts);
    }

    internal static string GameTextLine(
        string? gameText
    )
    {
        var safeGameText = (string.IsNullOrWhiteSpace(gameText) ? Constants.Undefined : gameText)
            .Replace("•", "*")
            .Replace("½", "1/2")
            .Replace("¼", "1/4")
            .Replace("¬", "1/4")
            .Replace("°", " degrees")
            .Trim()
        ;

        return gameText is not null
            ? Format.Label(Constants.Text, safeGameText)
            : Format.Label(Constants.Text, string.Empty);
    }

    internal static string GameTextLine(
        string? gameText,
        int? darkSideIcons,
        int? lightSideIcons
    )
    {
        var safeGameText = (string.IsNullOrWhiteSpace(gameText) ? Constants.Undefined : gameText)
            .Replace("•", "*")
            .Replace("½", "1/2")
            .Replace("¼", "1/4")
            .Replace("¬", "1/4")
            .Trim()
        ;

        return gameText is not null
            ? Format.Label(Constants.Text, safeGameText)
                .Replace(@"Dark:", $"DARK ({darkSideIcons}):", StringComparison.OrdinalIgnoreCase)
                .Replace(@"Light:", $"LIGHT ({lightSideIcons}):", StringComparison.OrdinalIgnoreCase)
            : Format.Label(Constants.Text, string.Empty);
    }

    internal static string LoreLine(
        string? lore
    )
    {
        var safeLore = string.IsNullOrWhiteSpace(lore) ? Constants.Undefined : lore;

        return Format.Label(Constants.Lore, safeLore);
    }

    internal static string IconLine(
        string? icon
    )
    {
        var safeIcon = string.IsNullOrWhiteSpace(icon) ? Constants.Undefined : icon;

        return Format.Label(Constants.Icons, safeIcon);
    }

    internal static string NewLine()
    {
        return @"\n";
    }

    internal static string PowerLine(
        string? power,
        string? ability,
        string? armor,
        string? maneuver,
        string? landspeed,
        string? hyperspeed,
        string? politics,
        string? extraText
    )
    {
        var safePower = string.IsNullOrWhiteSpace(power) ? Constants.Undefined : power;
        var safeAbility = string.IsNullOrWhiteSpace(ability) ? Constants.Undefined : ability;
        var safeArmor = string.IsNullOrWhiteSpace(armor) ? Constants.Undefined : armor;
        var safeManeuver = string.IsNullOrWhiteSpace(maneuver) ? Constants.Undefined : maneuver;
        var safeLandspeed = string.IsNullOrWhiteSpace(landspeed) ? Constants.Undefined : landspeed;
        var safeHyperspeed = string.IsNullOrWhiteSpace(hyperspeed) ? Constants.Undefined : hyperspeed;
        var safePolitics = string.IsNullOrWhiteSpace(politics) ? Constants.Undefined : politics;

        var powerLabel = Format.Label(Constants.Power, safePower);
        var abilityLabel = Format.Label(Constants.Ability, safeAbility);
        var armorLabel = Format.Label(Constants.Armor, safeArmor);
        var maneuverLabel = Format.Label(Constants.Maneuver, safeManeuver);
        var landspeedLabel = Format.Label(Constants.Landspeed, safeLandspeed);
        var hyperspeedLabel = Format.Label(Constants.Hyperspeed, safeHyperspeed);
        var politicsLabel = Format.Label(Constants.Politics, safePolitics);

        var parts = new List<string> { powerLabel };

        if (ability != null)
        {
            parts.Add(abilityLabel);
        }

        if (armor != null)
        {
            parts.Add(armorLabel);
        }

        if (maneuver != null)
        {
            parts.Add(maneuverLabel);
        }

        if (landspeed != null)
        {
            parts.Add(landspeedLabel);
        }

        if (hyperspeed != null)
        {
            parts.Add(hyperspeedLabel);
        }

        if (politics != null)
        {
            parts.Add(politicsLabel);
        }

        if (extraText != null)
        {
            parts.Add(extraText);
        }

        return string.Join(" ", parts);
    }

    internal static string SetLine(
        string? set
    )
    {
        var safeSet = string.IsNullOrWhiteSpace(set) ? Constants.Undefined : set;

        return Format.Label(Constants.Set, safeSet);
    }

    internal static string SideLine(
        string? side,
        string? type,
        string? rarity
    )
    {
        var safeSide = string.IsNullOrWhiteSpace(side) ? Constants.Undefined : side;
        var safeType = string.IsNullOrWhiteSpace(type) ? Constants.Undefined : type;
        var safeRarity = string.IsNullOrWhiteSpace(rarity) ? Constants.Undefined : rarity;

        return $"{safeSide} {safeType} [{safeRarity}]";
    }

    internal static string SideLine(
        string? side,
        string? type,
        string? subType,
        string? rarity
    )
    {
        var safeSide = string.IsNullOrWhiteSpace(side) ? Constants.Undefined : side;
        var safeType = string.IsNullOrWhiteSpace(type) ? Constants.Undefined : type;
        //var safeSubType = string.IsNullOrWhiteSpace(subType) ? Constants.Undefined : subType;
        var safeRarity = string.IsNullOrWhiteSpace(rarity) ? Constants.Undefined : rarity;

        return subType is not null
            ? $"{safeSide} {safeType} - {subType} [{safeRarity}]"
            : $"{safeSide} {safeType} [{safeRarity}]";
    }

    internal static string SectionLine(
        string? type,
        string? subType
    )
    {
        return string.IsNullOrWhiteSpace(subType) ||
            string.Equals(type, Constants.Creature, StringComparison.OrdinalIgnoreCase)
            //string.Equals(type, Constants.Mission, StringComparison.OrdinalIgnoreCase)
            ? $"[{type}]"
            : $"[{type} - {subType}]";
    }

    internal static string TitleLine(
        string? title,
        string? destiny
    )
    {
        var safeTitle = (string.IsNullOrWhiteSpace(title) ? Constants.Undefined : title);
        var safeDestiny = (string.IsNullOrWhiteSpace(destiny) ? Constants.Undefined : destiny);

        return $"{safeTitle} ({safeDestiny})";
    }
}
