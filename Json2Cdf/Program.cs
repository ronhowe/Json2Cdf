using Shouldly;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Json2Cdf;

[TestClass]
public sealed partial class Program : TestBase
{
    [TestMethod]
    [TestCategory("Integration")]
    [DataRow(@"Dark.json", @"DarkLegacy.json", @"darkside.cdf", "imp.gif")]
    [DataRow(@"Light.json", @"LightLegacy.json", @"lightside.cdf", "reb.gif")]
    public async Task Main(
        string liveJson,
        string legacyJson,
        string cdfPath,
        string back
    )
    {
        #region Read
        var liveDeck = Read.LoadFromFile(liveJson);
        var legacyDeck = Read.LoadFromFile(legacyJson);

        var allCards = new List<Card>();

        if (liveDeck?.Cards != null)
        {
            allCards.AddRange(liveDeck.Cards);
        }

        if (legacyDeck?.Cards != null)
        {
            allCards.AddRange(legacyDeck.Cards);
        }
        #endregion Read

        #region Filter
        var filteredCards = allCards
            .Where(card =>
                string.Equals(card.Front?.Type, "Admiral's Order", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Character", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Creature", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Defensive Shield", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Device", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Effect", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Epic Event", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Game Aid", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Interrupt", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Jedi Test #1", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Jedi Test #2", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Jedi Test #3", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Jedi Test #4", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Jedi Test #5", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Jedi Test #6", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Location", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Mission", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Objective", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Podracer", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Starship", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Vehicle", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(card.Front?.Type, "Weapon", StringComparison.OrdinalIgnoreCase) ||
                true == false
            )
            .ToList();
        #endregion Filter

        #region Group
        var sections = filteredCards
            .Select(c =>
                Line.SectionLine(
                    c.Front?.Type ?? c.Back?.Type ?? string.Empty,
                    Format.SubType(c.Front?.SubType ?? c.Back?.SubType ?? string.Empty)))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(s => s, StringComparer.InvariantCultureIgnoreCase)
            .ToList();
        #endregion Group

        #region Build
        StringBuilder lineBuilder = new();

        lineBuilder.AppendLine($"version {DateTime.Now:yyyyMMdd}");
        lineBuilder.AppendLine($"back {back}");
        lineBuilder.AppendLine();

        foreach (var section in sections)
        {
            lineBuilder.AppendLine(section);
            lineBuilder.AppendLine();

            #region Sort
            var sortedCards = filteredCards
                .Where(card =>
                    string.Equals(
                        Line.SectionLine(
                            card.Front?.Type ?? card.Back?.Type ?? string.Empty,
                            Format.SubType(card.Front?.SubType ?? card.Back?.SubType ?? string.Empty)),
                        section,
                        StringComparison.OrdinalIgnoreCase))
                //.OrderBy(
                //    t => NameFilterRegEx().Replace(t.Front?.Title ?? string.Empty, string.Empty),
                //    StringComparer.OrdinalIgnoreCase)
                .OrderBy(
                    t => TitleSortRegEx().Replace(t.Front?.Title ?? string.Empty, string.Empty),
                    StringComparer.InvariantCultureIgnoreCase)
                .ThenByDescending(t => t.Legacy)
                .ThenBy(t => t.Front?.ImageUrl)
                .ToList();
            #endregion Sort

            foreach (var card in sortedCards)
            {
                var id = card.Id;
                var ability = card.Front?.Ability;
                var armor = card.Front?.Armor;
                var conceptBy = card.ConceptBy;
                var darkSideIcons = card.Front?.DarkSideIcons;
                var deploy = card.Front?.Deploy;
                var destiny = Format.Destiny(card.Front?.Destiny, card.Back?.Destiny);
                var extraText = card.Front?.ExtraText != null
                    ? string.Join(", ", card.Front.ExtraText)
                    : null;
                var forfeit = card.Front?.Forfeit;
                var gameText = card.Front?.GameText;
                var hyperspeed = card.Front?.Hyperspeed;
                var icons = card.Front?.Icons != null
                    ? string.Join(", ", card.Front.Icons.Where(i =>
                        !string.Equals(i, "Defensive Shield", StringComparison.OrdinalIgnoreCase) &&
                        // TODO - Support Maintenance icons.
                        !string.Equals(i, "Maintenance", StringComparison.OrdinalIgnoreCase)
                    ))
                    : null;
                var imagePath = Format.ImageUrl(
                    card.Front?.ImageUrl,
                    card.Back?.ImageUrl,
                    card.Front?.Type,
                    card.Legacy == true
                );
                var landspeed = card.Front?.Landspeed;
                var lightSideIcons = card.Front?.LightSideIcons;
                var lore = card.Front?.Lore;
                var maneuver = card.Front?.Maneuver;
                var parsec = card.Front?.Parsec;
                var politics = card.Front?.Politics;
                var power = card.Front?.Power;
                var rarity = card.Rarity;
                var set = Format.Set(card.Set);
                var side = card.Side;
                var subType = card.Front?.SubType;
                var title = card.Front?.Title;
                var type = card.Front?.Type;

                // Special cases for two-sided cards with unique formatting.
                switch (id)
                {
                    case 6435: // Jabba's Prize (Dark Side)
                        lineBuilder.Append(@"card ""/TWOSIDED/starwars/ReflectionsII-Dark/t_jabbasprizefront/jabbasprizeback"" ""*Jabba's Prize/*Jabba's Prize (0/0)\nDark Character - Rebel [PM]\nSet: Reflections 2\nPower: 0 Ability: 0 Carbon-Frozen\nDeploy: 0 Forfeit: 0\n\nLore: Han Solo was frozen in carbonite to test the process Vader planned to use on Luke. When Boba Fett delivered Han to Jabba, the vile gangster called him his 'favorite decoration.'\n\n*Jabba's Prize:\n\nText: {Deploys only at start of game if Carbon Chamber Testing is on table to Security Tower, frozen and imprisoned, (instead of a Rebel from opponent's Reserve Deck). If You Can Either Profit By This... is on table, opponent does not deploy Han at start of game (relocate Jabba's Prize to Audience Chamber, flip Carbon Chamber Testing, and you may not move or transfer Jabba's Prize)}.\n\nMay not be placed in Reserve Deck. Jabba's Prize is a persona of Han only while on table. If Jabba's Prize leaves table, place it out of play. May not be targeted by We're The Bait or Someone Who Loves You. While Jabba's Prize is at Audience Chamber, Jabba is power +3, defense value +3, and adds 3 to his immunity to attrition. If Jabba's Prize was just released, opponent may replace it with any Han from hand, Used Pile, or Reserve Deck; reshuffle (if not replaced, place Jabba's Prize out of play).\n\n*Jabba's Prize:\n\n<none>");
                        break;
                    case 5620: // Jabba's Prize (Light Side) - LEGACY
                        lineBuilder.Append(@"card ""/TWOSIDED/legacy/VirtualBlock6-Light/t_jabbasprizefront/jabbasprizeback"" ""*Jabba's Prize/*Jabba's Prize (0/0)\nLight Character - Rebel [PM]\nSet: Set 0\nPower: 0 Ability: 0 Carbon-Frozen\nDeploy: 0 Forfeit: 0\n\nLore: Blank.\n\n*Jabba's Prize:\nText: Jabba's Prize is a Light Side card and does not count toward your deck limit (but subtracts one from the number of cards you may start under your Starting Effect). Reveal to opponent when deploying your Starting Effect. For remainder of game, you may not deploy [Maintenance] Falcon.\n\n{Deploys only at start of game if Jabba's Prize is at Security Tower (replaces opponent's Jabba's Prize imprisoned in Security Tower); otherwise place out of play.}\n\nMay not be placed in Reserve Deck. Jabba's Prize is a persona of Corran Horn only while on table. If Jabba's Prize was just released or leaves table, place it out of play. For remainder of game, you may not deploy [Maintenance] Falcon. While Jabba's Prize at Audience Chamber, opponent's battle destiny draws there are +1.\n\n*Jabba's Prize:\nText:\n<none>");
                        break;
                    case 6501: // Luke Skywalker, The Emperor's Prize
                        lineBuilder.Append(@"card ""/TWOSIDED/starwars/Virtual5-Dark/t_lukeskywalkertheemperorsprizefront/lukeskywalkertheemperorsprizeback"" ""*Luke Skywalker, The Emperor's Prize/*Luke Skywalker, The Emperor's Prize (0/7)\nDark Character - Rebel [R]\nSet: Set 5\nPower: 0 Ability: 0 Carbon-Frozen\nDeploy: 0 Forfeit: 0\n\n*Luke Skywalker, The Emperor's Prize:\n\nText: This is a Dark Side card and does not count toward your deck limit. Reveal to opponent when deploying your Starting Effect. Deploys to Death Star II: Throne Room only at start of game as a frozen captive if Bring Him Before Me on table and Your Destiny is suspended; otherwise place out of play. For remainder of game, may not be placed in Reserve Deck. This is a persona of Luke only while on table. While this side up, Bring Him Before Me may not flip. May not be escorted. Flip this card if Vader present and not escorting a captive. Place out of play if released or about to leave table.\n\n*Luke Skywalker, The Emperor's Prize:\n\nPower: 6 Ability: 6 Jedi Knight\nImmediately 'thaw' Luke (Luke is a non-frozen captive escorted by Vader). While this side up, subtracts 3 from attempts to cross Luke over (even while a captive). Place out of play if released or about to leave table.");
                        break;
                    case 5959: // The Falcon, Junkyard Garbage (Light Side)
                        lineBuilder.Append(@"card ""/TWOSIDED/starwars/Virtual4-Light/t_thefalconjunkyardgarbagefront/thefalconjunkyardgarbageback"" ""*The Falcon, Junkyard Garbage/*The Falcon, Junkyard Garbage (0/7)\nLight Starship - Starfighter: Heavily-Modified Light Freighter [C]\nSet: Set 4\nPower: 3 Maneuver: 4 Hyperspeed: 6\nDeploy: 0 Forfeit: 7\nIcons: Nav Computer, Resistance, Scomp Link, Episode VII\n\n*The Falcon, Junkyard Garbage:\nLore: The Millennium Falcon's well-known reputation is favorable not only for its captain and first mate, but for the Alliance as well.\n\nText: May not be placed in Reserve Deck. If Falcon about to leave table, place it out of play. May add 2 pilots and 2 passengers. Has ship-docking capability. While [Episode VII] Han or Rey piloting, maneuver +2 and immune to attrition < 4 (< 6 if both). Once during your move phase, if at a site, may flip this card (even if unpiloted).\n\n*The Falcon, Junkyard Garbage:\nLight Combat Vehicle - Heavily-Modified Light Freighter\nPower: 3 Maneuver: 5 Landspeed: 2\nDeploy: 0 Forfeit: 7\nIcons: Resistance, Scomp Link, Episode VII\n\nLore: Enclosed.\n\nText: May not be placed in Reserve Deck. If Falcon about to leave table, place it out of play. May add 2 pilots and 2 passengers. Immune to Trample and Unsalvageable, even if unpiloted. While Finn or Rey aboard, immune to attrition < 4 (< 6 if both). Once during your move phase, if piloted, may flip this card.");
                        break;
                    case 7146: // The Falcon, Junkyard Garbage (AI) (Light Side)
                        lineBuilder.Append(@"card ""/TWOSIDED/starwars/VirtualAlternateImage-Light/t_thefalconjunkyardgarbagefront_ai/thefalconjunkyardgarbageback_ai"" ""*The Falcon, Junkyard Garbage [AI]/*The Falcon, Junkyard Garbage [AI] (0/7)\nLight Starship - Starfighter: Heavily-Modified Light Freighter [C]\nSet: Set 4\nPower: 3 Maneuver: 4 Hyperspeed: 6\nDeploy: 0 Forfeit: 7\nIcons: Nav Computer, Resistance, Scomp Link, Episode VII\n\n*The Falcon, Junkyard Garbage [AI]:\nLore: The Millennium Falcon's well-known reputation is favorable not only for its captain and first mate, but for the Alliance as well.\n\nText: May not be placed in Reserve Deck. If Falcon about to leave table, place it out of play. May add 2 pilots and 2 passengers. Has ship-docking capability. While [Episode VII] Han or Rey piloting, maneuver +2 and immune to attrition < 4 (< 6 if both). Once during your move phase, if at a site, may flip this card (even if unpiloted).\n\n*The Falcon, Junkyard Garbage [AI]:\nLight Combat Vehicle - Heavily-Modified Light Freighter\nPower: 3 Maneuver: 5 Landspeed: 2\nDeploy: 0 Forfeit: 7\nIcons: Resistance, Scomp Link, Episode VII\n\nLore: Enclosed.\n\nText: May not be placed in Reserve Deck. If Falcon about to leave table, place it out of play. May add 2 pilots and 2 passengers. Immune to Trample and Unsalvageable, even if unpiloted. While Finn or Rey aboard, immune to attrition < 4 (< 6 if both). Once during your move phase, if piloted, may flip this card.");
                        break;
                    case 5621: // The Mythrol (Light Side)
                        lineBuilder.Append(@"card ""/TWOSIDED/starwars/Virtual0-Light/t_themythrolfront/themythrolback"" ""*The Mythrol/*The Mythrol (0/7)\nLight Character - Alien [U]\nSet: Set 0\n*The Mythrol:\nPower: 0 Ability: 0 Carbon-Frozen\nDeploy: 0 Forfeit: 0\n\nThe Mythrol's game text may not be canceled. If about to leave table, place out of play.\n\n{Plays only during start of game by revealing from outside your deck to replace a just-deployed Jabba's Prize imprisoned in Security Tower. If not revealed, place this card under your Starting Effect.}\n\n[Set 1] Despair targets The Mythrol instead of Jabba's Prize. Cancels Stunning Leader here. If just released, either flip this card or place it out of play.\n*The Mythrol:\nPower: 2 Ability: 1\nDeploy: 0 Forfeit: 2\n\nLore: Mythrol accountant.\n\nIf either player just deployed a card with ability here, you may use 1 Force to place The Mythrol out of play; if card was Din Djarin or a bounty hunter, you may activate 2 Force. If about to leave table, place out of play.");
                        break;
                    default:
                        lineBuilder.Append($"{Constants.Card} \"{imagePath}\" \"");

                        var normalizedType = (type ?? string.Empty).ToUpperInvariant();
                        switch (normalizedType)
                        {
                            case "ADMIRAL'S ORDER":
                                Template.AdmiralsOrderTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    rarity,
                                    set,
                                    icons,
                                    gameText
                                );
                                break;
                            case "CHARACTER":
                                Template.CharacterTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    subType,
                                    rarity,
                                    set,
                                    icons,
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
                                break;
                            case "CREATURE":
                                // TODO - Support Ferocity.
                                Template.CreatureTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    subType,
                                    rarity,
                                    set,
                                    icons,
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
                                break;
                            case "DEFENSIVE SHIELD":
                                Template.DefensiveShieldTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    rarity,
                                    set,
                                    icons,
                                    lore,
                                    gameText,
                                    conceptBy
                                );
                                break;
                            case "DEVICE":
                                Template.DeviceTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    rarity,
                                    set,
                                    icons,
                                    lore,
                                    gameText,
                                    conceptBy
                                );
                                break;
                            case "EFFECT":
                                Template.EffectTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    subType,
                                    rarity,
                                    set,
                                    icons,
                                    lore,
                                    gameText,
                                    conceptBy
                                );
                                break;
                            case "EPIC EVENT":
                                Template.DefaultTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    subType,
                                    rarity,
                                    set,
                                    icons,
                                    lore,
                                    gameText,
                                    conceptBy
                                );
                                break;
                            case "GAME AID":
                                Template.DefaultTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    subType,
                                    rarity,
                                    set,
                                    icons,
                                    lore,
                                    gameText,
                                    conceptBy
                                );
                                break;
                            case "INTERUPT":
                                Template.InterruptTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    subType,
                                    rarity,
                                    set,
                                    icons,
                                    lore,
                                    gameText,
                                    conceptBy
                                );
                                break;
                            case "LOCATION":
                                Template.LocationTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    subType,
                                    rarity,
                                    set,
                                    icons,
                                    parsec,
                                    darkSideIcons,
                                    lightSideIcons,
                                    gameText,
                                    conceptBy
                                );
                                break;
                            case "MISSION":
                                Template.MissionTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    rarity,
                                    set,
                                    icons,
                                    gameText,
                                    conceptBy
                                );
                                break;
                            case "PODRACER":
                                Template.DefaultTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    subType,
                                    rarity,
                                    set,
                                    icons,
                                    lore,
                                    gameText,
                                    conceptBy
                                );
                                break;
                            case "STARSHIP":
                                Template.StarshipTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    subType,
                                    rarity,
                                    set,
                                    icons,
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
                                break;
                            case "VEHICLE":
                                Template.VehicleTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    subType,
                                    rarity,
                                    set,
                                    icons,
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
                                break;
                            case "WEAPON":
                                Template.WeaponTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    subType,
                                    rarity,
                                    set,
                                    icons,
                                    deploy,
                                    forfeit,
                                    lore,
                                    gameText,
                                    conceptBy
                                );
                                break;
                            default:
                                Template.DefaultTemplate(
                                    lineBuilder,
                                    title,
                                    destiny,
                                    side,
                                    type,
                                    subType,
                                    rarity,
                                    set,
                                    icons,
                                    lore,
                                    gameText,
                                    conceptBy
                                );
                                break;
                        }
                        break;
                }

                lineBuilder.Append('"');

                lineBuilder.AppendLine();
            }

            lineBuilder.AppendLine();
        }
        #endregion Build

        #region Scrub
        // order matters
        lineBuilder.Replace("•", "*");
        lineBuilder.Replace('ä', 'a');
        lineBuilder.Replace("4½", "4.5");
        lineBuilder.Replace("½ or 5½", "5.5");
        lineBuilder.Replace("½", "0.5");
        lineBuilder.Replace("π or 2π", "Pi or 2Pi");
        lineBuilder.Replace("π", "Pi");
        #endregion Scrub

        #region Write
        await Write.WriteAsync(cdfPath, lineBuilder.ToString(), TestContext.CancellationToken);
        Debug.WriteLine(lineBuilder.ToString());
        #endregion Write

        #region Assert
        true.ShouldBeTrue();
        #endregion Assert
    }

    public TestContext TestContext { get; set; }

    [GeneratedRegex("[•<>]", RegexOptions.None)]
    private static partial Regex TitleSortRegEx();
}
