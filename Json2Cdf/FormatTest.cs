using Shouldly;
using System.Diagnostics;

namespace Json2Cdf;

[TestClass]
public sealed class FormatTest : TestBase
{
    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("", "7", "UNDEFINED")]
    [DataRow("1", "", "1")]
    [DataRow("1", "7", "1/7")]
    [DataRow("1", null, "1")]
    [DataRow(null, "7", "UNDEFINED")]
    public async Task Destiny(
        string? frontDestiny,
        string? backDestiny,
        string? expected
    )
    {
        var result = Format.Destiny(frontDestiny, backDestiny);
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("https://res.starwarsccg.org/cards/SET/large/FRONT.gif", null, null, false, "/starwars/SET/t_FRONT")]
    [DataRow("https://res.starwarsccg.org/cards/legacy/SET/large/FRONT.gif", null, null, true, "/legacy/SET/t_FRONT")]
    [DataRow("https://res.starwarsccg.org/cards/SET/large/FRONT.gif", "https://res.starwarsccg.org/cards/SET/large/BACK.gif", Constants.Objective, false, "/TWOSIDED/starwars/SET/t_FRONT/BACK")]
    public async Task ImageUrl(
        string? frontImgUrl,
        string? backImgUrl,
        string? type,
        bool isLegacy,
        string? expected
    )
    {
        var result = Format.ImageUrl(frontImgUrl, backImgUrl, type, isLegacy);

        Debug.WriteLine(expected);
        Debug.WriteLine(result);
        for (int i = 0; i < 100; i++) { Debug.WriteLine(""); }

        result.ShouldBe(expected);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [DataRow("LABEL", "VALUE", "LABEL: VALUE")]
    [DataRow("LABEL", null, "LABEL:")]
    public async Task Label(
        string? label,
        string? value,
        string? expected
    )
    {
        var result = Format.Label(label, value);
        Debug.WriteLine(result);
        result.ShouldBe(expected);
    }
}
