
using CardActionsService.Services;

namespace CardActionsService.Tests;

public class CardServiceCreateSampleUserCardsTests
{
    [Theory]
    [InlineData("Card11")]
    [InlineData("Card121")]
    public async Task CreateSampleUserCards_CreatesFirstAndLastCard(
        string cardNumber)
    {
        // Arrange
        var service = new CardService();

        // Act
        var result = await service.GetCardDetails("User1", cardNumber);

        // Assert
        Assert.NotNull(result);
    }


    [Fact]
    public async Task CreateSampleUserCards_Creates21CardsForUser()
    {
        // Arrange
        var service = new CardService();

        // Act
        var cards = new List<string>();

        // GetCardDetails contains a 1-second delay simulating an external service call.
        // Checking all 21 cards therefore takes approximately 21 seconds.

        for (var i = 1; i <= 21; i++)
        {
            var cardNumber = $"Card1{i}";
            var card = await service.GetCardDetails("User1", cardNumber);

            if (card is not null)
            {
                cards.Add(card.CardNumber);
            }
        }

        // Assert
        Assert.Equal(21, cards.Count);
    }

    [Theory]
    [InlineData("Card00")]
    [InlineData("Card422")]
    [InlineData("Card-1-1")]
    public async Task CreateSampleUserCards_WhenCardNumberIsInvalid_ReturnsNull(
    string cardNumber)
    {
        // Arrange
        var service = new CardService();

        // Act
        var result = await service.GetCardDetails("User1", cardNumber);

        // Assert
        Assert.Null(result);
    }
}
