namespace CardActionsService.Models;

public record CardActionRule(
    HashSet<CardType> CardTypes,
    Dictionary<CardStatus, PinRule> CardStatuses
);
