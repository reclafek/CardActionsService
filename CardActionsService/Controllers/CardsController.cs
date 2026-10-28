using CardActionsService.Models;
using CardActionsService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardActionsService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardsController(CardService cardService) : ControllerBase    
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("{userId}/{cardNumber}")]
    public async Task<ActionResult<CardActions>> GetCard(
    string userId,
    string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(userId) ||
            string.IsNullOrWhiteSpace(cardNumber))
        {
            return BadRequest(new
            {
                error = "userId and cardNumber cannot be empty or whitespace."
            });
        }
        var card = await cardService.GetCardDetails(userId, cardNumber);

        if (card is null)
        {
            return NotFound(new
            {
                error = $"Card '{cardNumber}' was not found for user '{userId}'."
            });
        }

        var cardActions = cardService.GetCardActions(card);

        return Ok(cardActions);
    }
}
