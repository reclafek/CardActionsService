using CardActionsService.Models;
using CardActionsService.Rules;

namespace CardActionsService.Services;

public class CardService
{
    private readonly Dictionary<string, Dictionary<string, CardDetails>> _userCards = CreateSampleUserCards();    

    public async Task<CardDetails?> GetCardDetails(string userId, string cardNumber)
    {
        // At this point, we would typically make an HTTP call to an external service
        // to fetch the data. For this example we use generated sample data.
        await Task.Delay(1000);
        if (!_userCards.TryGetValue(userId, out var cards)
        || !cards.TryGetValue(cardNumber, out var cardDetails))
        {
            return null;
        }
        return cardDetails;
    }
    private static Dictionary<string, Dictionary<string, CardDetails>> CreateSampleUserCards()
    {
        var userCards = new Dictionary<string, Dictionary<string, CardDetails>>(StringComparer.OrdinalIgnoreCase);
        for (var i = 1; i <= 3; i++)
        {
            var cards = new Dictionary<string, CardDetails>(StringComparer.OrdinalIgnoreCase);
            var cardIndex = 1;
            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    var cardNumber = $"Card{i}{cardIndex}";
                    cards.Add(cardNumber,
                    new CardDetails(
                    CardNumber: cardNumber,
                    CardType: cardType,
                    CardStatus: cardStatus,
                    IsPinSet: cardIndex % 2 == 0));
                    cardIndex++;
                }
            }
            var userId = $"User{i}";
            userCards.Add(userId, cards);
        }
        return userCards;
    }
    public CardActions GetCardActions(CardDetails card)
    {        
        var actions = new List<string>();

        foreach (var (actionName, rule) in CardActionRules.Rules)
        {
            if (!rule.CardTypes.Contains(card.CardType))
            {
                continue;
            }

            if (!rule.CardStatuses.TryGetValue(card.CardStatus, out var pinRule))
            {
                continue;
            }

            var availability = card.IsPinSet
                ? pinRule.WhenPinSet
                : pinRule.WhenPinNotSet;

            //komentarz do konsulacji z analitykiem tylko na potrzeby testu
            //Zadanie nie mówi co w przypadku warunku:
            //"TAK - jeżeli pin nadany" gdy pin nie jest nadany
            //"TAK - jeżeli brak pin" a pin jest nadany
            //bo mamy przecież warunek precyzyjny: "TAK - ale jak nie ma pin to NIE"
            //stąd dałbym exception i obsługę wyjątku w middleware i zwrot 500
            //{
            //    "error": "Availability of ACTION6 is undefined for card status 'Blocked' when PIN is not set."
            //}
            //natomiast Przykład 2 jasno każe zwrócić akcje bez ACTION6 i ACTION7 więc komentuję throw
            /*
            if (availability == ActionAvailability.Undefined)
            {
                throw new InvalidOperationException(
                    $"Availability of {actionName} is undefined for card status " +
                    $"'{card.CardStatus}' when PIN is {(card.IsPinSet ? "set" : "not set")}.");
            }
            */
            if (availability == ActionAvailability.Allowed)
            {
                actions.Add(actionName);
            }
        }

        return new CardActions(actions);
    }
}