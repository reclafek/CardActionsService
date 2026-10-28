using CardActionsService.Controllers;
using CardActionsService.Models;
using CardActionsService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardActionsService.Tests;

public class CardsControllerTests
{
    private readonly CardsController _controller =
        new(new CardService());

    [Fact]
    public async Task GetCard_WhenCardExists_ReturnsOk()
    {
        // Act
        var result = await _controller.GetCard("User1", "Card112");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var cardActions = Assert.IsType<CardActions>(okResult.Value);

        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.NotNull(cardActions.Actions);
    }

    [Theory]
    [InlineData("", "Card112")]
    [InlineData("User1", "")]
    [InlineData(" ", "Card112")]
    [InlineData("User1", " ")]
    public async Task GetCard_WhenParametersAreEmptyOrWhitespace_ReturnsBadRequest(
    string userId,
    string cardNumber)
    {
        // Act
        var result = await _controller.GetCard(userId, cardNumber);

        // Assert
        var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);

        Assert.Equal(StatusCodes.Status400BadRequest, badRequest.StatusCode);
    }

    [Theory]
    [InlineData("User1", "Card999")]
    [InlineData("User99", "Card112")]
    public async Task GetCard_WhenUserOrCardDoesNotExist_ReturnsNotFound(
    string userId,
    string cardNumber)
    {
        // Act
        var result = await _controller.GetCard(userId, cardNumber);

        // Assert
        var notFound = Assert.IsType<NotFoundObjectResult>(result.Result);

        Assert.Equal(StatusCodes.Status404NotFound, notFound.StatusCode);
    }
}