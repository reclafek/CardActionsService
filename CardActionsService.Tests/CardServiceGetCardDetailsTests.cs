
using CardActionsService.Models;
using CardActionsService.Services;

namespace CardActionsService.Tests;

public class CardServiceGetCardDetailsTests
{
    [Theory]
    [InlineData("User1", "Card112")]
    [InlineData("user1", "card112")]    
    public async Task GetCardDetails_IsCaseInsensitive(
        string userId,
        string cardNumber)
    {
        // Arrange
        var service = new CardService();

        // Act
        var result = await service.GetCardDetails(userId, cardNumber);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Card112", result.CardNumber);
        Assert.Equal(CardType.Debit, result.CardType);
        Assert.Equal(CardStatus.Blocked, result.CardStatus);
        Assert.True(result.IsPinSet);        
    }

    [Fact]
    public async Task GetCardDetails_WhenUserDoesNotExist_ReturnsNull()
    {
        // Arrange
        var service = new CardService();

        // Act
        var result = await service.GetCardDetails("User99", "Card112");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetCardDetails_WhenCardDoesNotExist_ReturnsNull()
    {
        // Arrange
        var service = new CardService();

        // Act
        var result = await service.GetCardDetails("User1", "Card999");

        // Assert
        Assert.Null(result);
    }
}
