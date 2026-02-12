using Shouldly;
using System.Diagnostics;
using System.Text;

namespace Json2Cdf;

[TestClass]
public sealed class TemplateTest : TestBase
{
    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "RARITY", "SET", "ICON", "GAMETEXT", @"TITLE (DESTINY)\nSIDE TYPE [RARITY]\nSet: SET\nIcons: ICON\n\nText: GAMETEXT")]
    public async Task AdmiralsOrderTemplate(
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? rarity,
        string? set,
        string? icon,
        string? gameText,
        string? expected
    )
    {
        var lineBuilder = new StringBuilder();
        Template.AdmiralsOrderTemplate(
            lineBuilder,
            title,
            destiny,
            side,
            type,
            rarity,
            set,
            icon,
            gameText
        );
        var result = lineBuilder.ToString();
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "SUBTYPE", "RARITY", "SET", "ICON", "POWER", "ABILITY", "ARMOR", "MANEUVER", "POLITICS", "EXTRATEXT", "DEPLOY", "FORFEIT", "LORE", "GAMETEXT", "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE - SUBTYPE [RARITY]\nSet: SET\nPower: POWER Ability: ABILITY Armor: ARMOR Maneuver: MANEUVER Politics: POLITICS EXTRATEXT\nDeploy: DEPLOY Forfeit: FORFEIT\nIcons: ICON\n\nLore: LORE\n\nText: GAMETEXT\n\nCONCEPTBY")]
    public async Task CharacterTemplate(
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icon,
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
        string? conceptBy,
        string? expected
    )
    {
        var lineBuilder = new StringBuilder();
        Template.CharacterTemplate(
            lineBuilder,
            title,
            destiny,
            side,
            type,
            subType,
            rarity,
            set,
            icon,
            power,
            ability,
            armor,
            maneuver,
            politics,
            extraText,
            deploy,
            forfeit,
            lore,
            gameText,
            conceptBy
        );
        var result = lineBuilder.ToString();
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "SUBTYPE", "RARITY", "SET", "ICON", "POWER", "ABILITY", "ARMOR", "MANEUVER", "POLITICS", "EXTRATEXT", "DEPLOY", "FORFEIT", "LORE", "GAMETEXT", "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE - SUBTYPE [RARITY]\nSet: SET\nPower: POWER Ability: ABILITY Armor: ARMOR Maneuver: MANEUVER Politics: POLITICS EXTRATEXT\nDeploy: DEPLOY Forfeit: FORFEIT\nIcons: ICON\n\nLore: LORE\n\nText: GAMETEXT\n\nCONCEPTBY")]
    public async Task CreatureTemplate(
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icon,
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
        string? conceptBy,
        string? expected
    )
    {
        var lineBuilder = new StringBuilder();
        Template.CreatureTemplate(
            lineBuilder,
            title,
            destiny,
            side,
            type,
            subType,
            rarity,
            set,
            icon,
            power,
            ability,
            armor,
            maneuver,
            politics,
            extraText,
            deploy,
            forfeit,
            lore,
            gameText,
            conceptBy
        );
        var result = lineBuilder.ToString();
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "SUBTYPE", "RARITY", "SET", "ICON", "LORE", "GAMETEXT", "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE - SUBTYPE [RARITY]\nSet: SET\nIcons: ICON\n\nLore: LORE\n\nText: GAMETEXT\n\nCONCEPTBY")]
    public async Task DefaultTemplate(
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icon,
        string? lore,
        string? gameText,
        string? conceptBy,
        string? expected
    )
    {
        var lineBuilder = new StringBuilder();
        Template.DefaultTemplate(
            lineBuilder,
            title,
            destiny,
            side,
            type,
            subType,
            rarity,
            set,
            icon,
            lore,
            gameText,
            conceptBy
        );
        var result = lineBuilder.ToString();
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "RARITY", "SET", "ICON", "LORE", "GAMETEXT", "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE [RARITY]\nSet: SET\nIcons: ICON\n\nLore: LORE\n\nText: GAMETEXT\n\nCONCEPTBY")]
    public async Task DefensiveShieldTemplate(
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? rarity,
        string? set,
        string? icon,
        string? lore,
        string? gameText,
        string? conceptBy,
        string? expected
    )
    {
        var lineBuilder = new StringBuilder();
        Template.DefensiveShieldTemplate(
            lineBuilder,
            title,
            destiny,
            side,
            type,
            rarity,
            set,
            icon,
            lore,
            gameText,
            conceptBy
        );
        var result = lineBuilder.ToString();
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "RARITY", "SET", "ICON", "LORE", "GAMETEXT", "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE [RARITY]\nSet: SET\nIcons: ICON\n\nLore: LORE\n\nText: GAMETEXT\n\nCONCEPTBY")]
    public async Task DeviceTemplate(
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? rarity,
        string? set,
        string? icon,
        string? lore,
        string? gameText,
        string? conceptBy,
        string? expected
    )
    {
        var lineBuilder = new StringBuilder();
        Template.DeviceTemplate(
            lineBuilder,
            title,
            destiny,
            side,
            type,
            rarity,
            set,
            icon,
            lore,
            gameText,
            conceptBy
        );
        var result = lineBuilder.ToString();
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "SUBTYPE", "RARITY", "SET", "ICON", "LORE", "GAMETEXT", "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE - SUBTYPE [RARITY]\nSet: SET\nIcons: ICON\n\nLore: LORE\n\nText: GAMETEXT\n\nCONCEPTBY")]
    public async Task EffectTemplate(
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icon,
        string? lore,
        string? gameText,
        string? conceptBy,
        string? expected
    )
    {
        var lineBuilder = new StringBuilder();
        Template.EffectTemplate(
            lineBuilder,
            title,
            destiny,
            side,
            type,
            subType,
            rarity,
            set,
            icon,
            lore,
            gameText,
            conceptBy
        );
        var result = lineBuilder.ToString();
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "SUBTYPE", "RARITY", "SET", "ICON", "LORE", "GAMETEXT", "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE - SUBTYPE [RARITY]\nSet: SET\nIcons: ICON\n\nLore: LORE\n\nText: GAMETEXT\n\nCONCEPTBY")]
    public async Task InterruptTemplate(
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icon,
        string? lore,
        string? gameText,
        string? conceptBy,
        string? expected
    )
    {
        var lineBuilder = new StringBuilder();
        Template.InterruptTemplate(
            lineBuilder,
            title,
            destiny,
            side,
            type,
            subType,
            rarity,
            set,
            icon,
            lore,
            gameText,
            conceptBy
        );
        var result = lineBuilder.ToString();
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "RARITY", "SET", "ICON", null, "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE [RARITY]\nSet: SET\nIcons: ICON\n\n\n\n\n\nCONCEPTBY")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "RARITY", "SET", "ICON", "GAMETEXT", "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE [RARITY]\nSet: SET\nIcons: ICON\n\n\n\nText: GAMETEXT\n\nCONCEPTBY")]
    public async Task MissionTemplate(
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? rarity,
        string? set,
        string? icon,
        string? gameText,
        string? conceptBy,
        string? expected
    )
    {
        var lineBuilder = new StringBuilder();
        Template.MissionTemplate(
            lineBuilder,
            title,
            destiny,
            side,
            type,
            rarity,
            set,
            icon,
            gameText,
            conceptBy
        );
        var result = lineBuilder.ToString();
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "SUBTYPE", "RARITY", "SET", "ICON", "POWER", "ABILITY", "ARMOR", "MANEUVER", "LANDSPEED", "HYPERSPEED", "POLITICS", "EXTRATEXT", "DEPLOY", "FORFEIT", "LORE", "GAMETEXT", "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE - SUBTYPE [RARITY]\nSet: SET\nPower: POWER Ability: ABILITY Armor: ARMOR Maneuver: MANEUVER Landspeed: LANDSPEED Hyperspeed: HYPERSPEED Politics: POLITICS EXTRATEXT\nDeploy: DEPLOY Forfeit: FORFEIT\nIcons: ICON\n\nLore: LORE\n\nText: GAMETEXT\n\nCONCEPTBY")]
    public async Task StarshipTemplate(
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icon,
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
        string? conceptBy,
        string? expected
    )
    {
        var lineBuilder = new StringBuilder();
        Template.StarshipTemplate(
            lineBuilder,
            title,
            destiny,
            side,
            type,
            subType,
            rarity,
            set,
            icon,
            power,
            ability,
            armor,
            maneuver,
            landspeed,
            hyperspeed,
            politics,
            extraText,
            deploy,
            forfeit,
            lore,
            gameText,
            conceptBy
        );
        var result = lineBuilder.ToString();
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "SUBTYPE", "RARITY", "SET", "ICON", "POWER", "ABILITY", "ARMOR", "MANEUVER", "LANDSPEED", "POLITICS", "EXTRATEXT", "DEPLOY", "FORFEIT", "LORE", "GAMETEXT", "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE - SUBTYPE [RARITY]\nSet: SET\nPower: POWER Ability: ABILITY Armor: ARMOR Maneuver: MANEUVER Landspeed: LANDSPEED Politics: POLITICS EXTRATEXT\nDeploy: DEPLOY Forfeit: FORFEIT\nIcons: ICON\n\nLore: LORE\n\nText: GAMETEXT\n\nCONCEPTBY")]
    public async Task VehicleTemplate(
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icon,
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
        string? conceptBy,
        string? expected
    )
    {
        var lineBuilder = new StringBuilder();
        Template.VehicleTemplate(
            lineBuilder,
            title,
            destiny,
            side,
            type,
            subType,
            rarity,
            set,
            icon,
            power,
            ability,
            armor,
            maneuver,
            landspeed,
            politics,
            extraText,
            deploy,
            forfeit,
            lore,
            gameText,
            conceptBy
        );
        var result = lineBuilder.ToString();
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "SUBTYPE", "RARITY", "SET", "ICON", null, null, "LORE", "GAMETEXT", "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE - SUBTYPE [RARITY]\nSet: SET\nIcons: ICON\n\nLore: LORE\n\nText: GAMETEXT\n\nCONCEPTBY")]
    [DataRow("TITLE", "DESTINY", "SIDE", "TYPE", "SUBTYPE", "RARITY", "SET", "ICON", "DEPLOY", "FORFEIT", "LORE", "GAMETEXT", "CONCEPTBY", @"TITLE (DESTINY)\nSIDE TYPE - SUBTYPE [RARITY]\nSet: SET\nDeploy: DEPLOY Forfeit: FORFEIT\nIcons: ICON\n\nLore: LORE\n\nText: GAMETEXT\n\nCONCEPTBY")]
    public async Task WeaponTemplate(
        string? title,
        string? destiny,
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? set,
        string? icon,
        string? deploy,
        string? forfeit,
        string? lore,
        string? gameText,
        string? conceptBy,
        string? expected
    )
    {
        var lineBuilder = new StringBuilder();
        Template.WeaponTemplate(
            lineBuilder,
            title,
            destiny,
            side,
            type,
            subType,
            rarity,
            set,
            icon,
            deploy,
            forfeit,
            lore,
            gameText,
            conceptBy
        );
        var result = lineBuilder.ToString();
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }
}
