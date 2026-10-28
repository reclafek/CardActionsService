namespace CardActionsService.Models;

public record PinRule(
    ActionAvailability WhenPinSet,
    ActionAvailability WhenPinNotSet
);