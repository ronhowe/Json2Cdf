using Shouldly;
using System.Diagnostics;

namespace Json2Cdf;

[TestClass]
public sealed class LineTest : TestBase
{
    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("DEPLOY", null, "Deploy: DEPLOY")]
    [DataRow("DEPLOY", "FORFEIT", "Deploy: DEPLOY Forfeit: FORFEIT")]
    public async Task DeployLine(
        string? deploy,
        string? forfeit,
        string? expected
    )
    {
        var result = Line.DeployLine(
            deploy,
            forfeit
        );
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("GAMETEXT", "Text: GAMETEXT")]
    [DataRow(null, "Text:")]

    public async Task GameTextLine(
        string? gameText,
        string? expected
    )
    {
        var result = Line.GameTextLine(gameText);

        Debug.WriteLine(expected);
        Debug.WriteLine(result);
        for (int i = 0; i < 100; i++) { Debug.WriteLine(""); }

        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow(@"Light: Obi-Wan is deploy -3 here. Dark: If you control, Force drain +1 here.", 0, 2, @"Text: LIGHT (2): Obi-Wan is deploy -3 here. DARK (0): If you control, Force drain +1 here.")]
    [DataRow(@"Dark: Once per game, you may take Emperor's Power into hand from Reserve Deck; reshuffle. Light: Immune to Revolution.", 2, 0, @"Text: DARK (2): Once per game, you may take Emperor's Power into hand from Reserve Deck; reshuffle. LIGHT (0): Immune to Revolution.")]

    public async Task GameTextLine(
        string? gameText,
        int? darkSideIcons,
        int? lightSideIcons,
        string? expected
    )
    {
        var result = Line.GameTextLine(gameText, darkSideIcons, lightSideIcons);

        Debug.WriteLine(gameText);
        Debug.WriteLine("");
        Debug.WriteLine(expected);
        Debug.WriteLine("");
        Debug.WriteLine(result);
        for (int i = 0; i < 100; i++) { Debug.WriteLine(""); }

        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("LORE", "Lore: LORE")]
    public async Task LoreLine(
        string? lore,
        string? expected
    )
    {
        var result = Line.LoreLine(lore);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("POWER", "ABILITY", "ARMOR", "MANEUVER", "LANDSPEED", "HYPERSPEED", "POLITICS", "EXTRATEXT", "Power: POWER Ability: ABILITY Armor: ARMOR Maneuver: MANEUVER Landspeed: LANDSPEED Hyperspeed: HYPERSPEED Politics: POLITICS EXTRATEXT")]
    public async Task PowerLine(
        string? power,
        string? ability,
        string? armor,
        string? maneuver,
        string? landspeed,
        string? hyperspeed,
        string? politics,
        string? extraText,
        string? expected
    )
    {
        var result = Line.PowerLine(
            power,
            ability,
            armor,
            maneuver,
            landspeed,
            hyperspeed,
            politics,
            extraText
        );
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("ICON", "Icons: ICON")]
    public async Task IconLine(
        string? icon,
        string? expected
    )
    {
        var result = Line.IconLine(icon);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow(@"\n")]
    public async Task NewLine(
        string? expected
    )
    {
        var result = Line.NewLine();
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TYPE", null, "[TYPE]")]
    [DataRow("TYPE", "SUBTYPE", "[TYPE - SUBTYPE]")]
    [DataRow("Creature", "SUBTYPE", "[Creature]")]
    public async Task SectionLine(
        string? type,
        string? subType,
        string? expected
    )
    {
        var result = Line.SectionLine(type, subType);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("SET", "Set: SET")]

    public async Task SetLine(
        string? set,
        string? expected
    )
    {
        var result = Line.SetLine(set);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("SIDE", "TYPE", "RARITY", "SIDE TYPE [RARITY]")]

    public async Task SideLine(
        string? side,
        string? type,
        string? rarity,
        string? expected
    )
    {
        var result = Line.SideLine(side, type, rarity);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("SIDE", "TYPE", "SUBTYPE", "RARITY", "SIDE TYPE - SUBTYPE [RARITY]")]

    public async Task SideLine(
        string? side,
        string? type,
        string? subType,
        string? rarity,
        string? expected
    )
    {
        var result = Line.SideLine(side, type, subType, rarity);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("TITLE", "DESTINY", "TITLE (DESTINY)")]
    public async Task TitleLine(
        string? title,
        string? destiny,
        string? expected
    )
    {
        var result = Line.TitleLine(title, destiny);
        result.ShouldBe(expected);
    }
}
