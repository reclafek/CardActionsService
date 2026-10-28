
using CardActionsService.Models;
using CardActionsService.Rules;
using CardActionsService.Services;

namespace CardActionsService.Tests;

public class CardServiceGetCardActionsTests
{

    public static TheoryData<CardDetails, string[]> CardActionTestCases
    {
        get
        {
            var data = new TheoryData<CardDetails, string[]>();

            foreach (var cardType in Enum.GetValues<CardType>())
            {
                foreach (var cardStatus in Enum.GetValues<CardStatus>())
                {
                    foreach (var isPinSet in new[] { false, true })
                    {
                        var card = new CardDetails(
                            "TestCard",
                            cardType,
                            cardStatus,
                            isPinSet);

                        var expectedActions = CardActionRules.Rules
                            .Where(rule => rule.Value.CardTypes.Contains(cardType))
                            .Where(rule => rule.Value.CardStatuses.TryGetValue(
                                cardStatus, out _))
                            .Where(rule =>
                            {
                                var pinRule = rule.Value.CardStatuses[cardStatus];

                                var availability = isPinSet
                                    ? pinRule.WhenPinSet
                                    : pinRule.WhenPinNotSet;

                                return availability == ActionAvailability.Allowed;
                            })
                            .Select(rule => rule.Key)
                            .ToArray();

                        data.Add(card, expectedActions);
                    }
                }
            }

            return data;
        }
    }


    [Theory]
    [MemberData(nameof(CardActionTestCases))]
    public void GetCardActions_ReturnsExpectedActions(
        CardDetails card,
        string[] expectedActions)
    {
        // Arrange
        var service = new CardService();

        // Act
        var result = service.GetCardActions(card);

        // Assert
        Assert.Equal(expectedActions, result.Actions);
    }
}
