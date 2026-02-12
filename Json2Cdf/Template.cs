using System.Text;

namespace Json2Cdf;

internal static class Template
{
    internal static void AdmiralsOrderTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? rarity,
        string? set,
        string? icons,
        string? gameText
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SideLine(side, type, rarity));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.IconLine(icons));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.GameTextLine(gameText));
    }

    internal static void CharacterTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icons,
        string? power,
        string? ability,
        string? armor,
        string? maneuver,
        string? politics,
        string? extraText,
        string? deploy,
        string? forfeit,
        string? lore,
        string? gameText,
        string? conceptBy
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SideLine(side, type, subType, rarity));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.PowerLine(power, ability, armor, maneuver, null, null, politics, extraText));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.DeployLine(deploy, forfeit));
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(icons))
        {
            lineBuilder.Append(Line.IconLine(icons));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        else
        {
            lineBuilder.Append(Line.NewLine());
        }
        if (!string.IsNullOrWhiteSpace(lore))
        {
            lineBuilder.Append(Line.LoreLine(lore));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        else
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.GameTextLine(gameText));
        if (conceptBy is not null)
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(conceptBy);
        }
    }

    internal static void CreatureTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icons,
        string? power,
        string? ability,
        string? armor,
        string? maneuver,
        string? politics,
        string? extraText,
        string? deploy,
        string? forfeit,
        string? lore,
        string? gameText,
        string? conceptBy
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SideLine(side, type, subType, rarity));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.PowerLine(power, ability, armor, maneuver, null, null, politics, extraText));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.DeployLine(deploy, forfeit));
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(icons))
        {
            lineBuilder.Append(Line.IconLine(icons));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        else
        {
            lineBuilder.Append(Line.NewLine());
        }
        if (!string.IsNullOrWhiteSpace(lore))
        {
            lineBuilder.Append(Line.LoreLine(lore));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        else
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.GameTextLine(gameText));
        if (conceptBy is not null)
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(conceptBy);
        }
    }

    internal static void DefaultTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icons,
        string? lore,
        string? gameText,
        string? conceptBy
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SideLine(side, type, subType, rarity));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(icons))
        {
            lineBuilder.Append(Line.IconLine(icons));
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(lore))
        {
            lineBuilder.Append(Line.LoreLine(lore));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.GameTextLine(gameText));
        if (conceptBy is not null)
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(conceptBy);
        }
    }

    internal static void DefensiveShieldTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? rarity,
        string? set,
        string? icons,
        string? lore,
        string? gameText,
        string? conceptBy
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SideLine(side, type, rarity));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(icons))
        {
            lineBuilder.Append(Line.IconLine(icons));
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(lore))
        {
            lineBuilder.Append(Line.LoreLine(lore));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.GameTextLine(gameText));
        if (conceptBy is not null)
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(conceptBy);
        }
    }

    internal static void DeviceTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? rarity,
        string? set,
        string? icons,
        string? lore,
        string? gameText,
        string? conceptBy
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SideLine(side, type, rarity));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(icons))
        {
            lineBuilder.Append(Line.IconLine(icons));
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(lore))
        {
            lineBuilder.Append(Line.LoreLine(lore));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.GameTextLine(gameText));
        if (conceptBy is not null)
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(conceptBy);
        }
    }

    internal static void EffectTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icons,
        string? lore,
        string? gameText,
        string? conceptBy
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SideLine(side, type, subType, rarity));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(icons))
        {
            lineBuilder.Append(Line.IconLine(icons));
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(lore))
        {
            lineBuilder.Append(Line.LoreLine(lore));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.GameTextLine(gameText));
        if (conceptBy is not null)
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(conceptBy);
        }
    }

    internal static void InterruptTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icons,
        string? lore,
        string? gameText,
        string? conceptBy
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SideLine(side, type, subType, rarity));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(icons))
        {
            lineBuilder.Append(Line.IconLine(icons));
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(lore))
        {
            lineBuilder.Append(Line.LoreLine(lore));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.GameTextLine(gameText));
        if (conceptBy is not null)
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(conceptBy);
        }
    }
    internal static void LocationTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icons,
        string? parsec,
        int? darkSideIcons,
        int? lightSideIcons,
        string? gameText,
        string? conceptBy
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SideLine(side, type, subType, rarity));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(icons))
        {
            lineBuilder.Append(Line.IconLine(icons));
            lineBuilder.Append(Line.NewLine());
        }
        if (!string.IsNullOrWhiteSpace(parsec))
        {
            lineBuilder.Append($"Parsec: {parsec}");
            lineBuilder.Append(Line.NewLine());
        }
        else if (string.IsNullOrWhiteSpace(parsec) && string.Equals(subType, Constants.System, StringComparison.OrdinalIgnoreCase))
        {
            lineBuilder.Append("Parsec: X");
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.GameTextLine(gameText, darkSideIcons, lightSideIcons));
        if (conceptBy is not null)
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(conceptBy);
        }
    }

    internal static void MissionTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? rarity,
        string? set,
        string? icons,
        string? gameText,
        string? conceptBy
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SideLine(side, type, null, rarity));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(icons))
        {
            lineBuilder.Append(Line.IconLine(icons));
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.NewLine());
        // TODO - Remove extra lines.
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.NewLine());
        if (gameText is not null)
        {
            lineBuilder.Append(Line.GameTextLine(gameText));
        }
        if (conceptBy is not null)
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(conceptBy);
        }
    }

    internal static void StarshipTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icons,
        string? power,
        string? ability,
        string? armor,
        string? maneuver,
        string? landspeed,
        string? hyperspeed,
        string? politics,
        string? extraText,
        string? deploy,
        string? forfeit,
        string? lore,
        string? gameText,
        string? conceptBy
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SideLine(side, type, subType, rarity));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.PowerLine(power, ability, armor, maneuver, landspeed, hyperspeed, politics, extraText));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.DeployLine(deploy, forfeit));
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(icons))
        {
            lineBuilder.Append(Line.IconLine(icons));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        else
        {
            lineBuilder.Append(Line.NewLine());
        }
        if (!string.IsNullOrWhiteSpace(lore))
        {
            lineBuilder.Append(Line.LoreLine(lore));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        else
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.GameTextLine(gameText));
        if (conceptBy is not null)
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(conceptBy);
        }
    }

    internal static void VehicleTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icons,
        string? power,
        string? ability,
        string? armor,
        string? maneuver,
        string? landspeed,
        string? politics,
        string? extraText,
        string? deploy,
        string? forfeit,
        string? lore,
        string? gameText,
        string? conceptBy
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SideLine(side, type, subType, rarity));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.PowerLine(power, ability, armor, maneuver, landspeed, null, politics, extraText));
        lineBuilder.Append(Line.NewLine());
        lineBuilder.Append(Line.DeployLine(deploy, forfeit));
        lineBuilder.Append(Line.NewLine());
        if (!string.IsNullOrWhiteSpace(icons))
        {
            lineBuilder.Append(Line.IconLine(icons));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        else
        {
            lineBuilder.Append(Line.NewLine());
        }
        if (!string.IsNullOrWhiteSpace(lore))
        {
            lineBuilder.Append(Line.LoreLine(lore));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        else
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        lineBuilder.Append(Line.GameTextLine(gameText));
        if (conceptBy is not null)
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(conceptBy);
        }
    }

    internal static void WeaponTemplate(
        StringBuilder lineBuilder,
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icons,
        string? deploy,
        string? forfeit,
        string? lore,
        string? gameText,
        string? conceptBy
    )
    {
        lineBuilder.Append(Line.TitleLine(title, destiny));
        lineBuilder.Append(Line.NewLine());

        lineBuilder.Append(Line.SideLine(side, type, subType, rarity));
        lineBuilder.Append(Line.NewLine());

        lineBuilder.Append(Line.SetLine(set));
        lineBuilder.Append(Line.NewLine());

        if (!string.IsNullOrWhiteSpace(deploy))
        {
            lineBuilder.Append(Line.DeployLine(deploy, forfeit));
            lineBuilder.Append(Line.NewLine());
        }

        if (!string.IsNullOrWhiteSpace(icons))
        {
            lineBuilder.Append(Line.IconLine(icons));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        else
        {
            lineBuilder.Append(Line.NewLine());
        }

        if (!string.IsNullOrWhiteSpace(lore))
        {
            lineBuilder.Append(Line.LoreLine(lore));
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }
        else
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
        }

        lineBuilder.Append(Line.GameTextLine(gameText));

        if (conceptBy is not null)
        {
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(Line.NewLine());
            lineBuilder.Append(conceptBy);
        }
    }
}