using CardActionsService.Models;

namespace CardActionsService.Rules;

public static class CardActionRules
{
    public static readonly Dictionary<string, CardActionRule> Rules = new()
    {
        ["ACTION1"] = new(
            CardTypes: [
                CardType.Prepaid,
                CardType.Debit,
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Active] = new(ActionAvailability.Allowed, ActionAvailability.Allowed)
            }),

        ["ACTION2"] = new(
            CardTypes: [
                CardType.Prepaid,
                CardType.Debit,
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Inactive] = new(ActionAvailability.Allowed, ActionAvailability.Allowed)
            }),

        ["ACTION3"] = new(
            CardTypes: [
                CardType.Prepaid,
                CardType.Debit,
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Ordered] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Inactive] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Active] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Restricted] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Blocked] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Expired] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Closed] = new(ActionAvailability.Allowed, ActionAvailability.Allowed)
            }),

        ["ACTION4"] = new(
            CardTypes: [
                CardType.Prepaid,
                CardType.Debit,
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Ordered] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Inactive] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Active] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Restricted] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Blocked] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Expired] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Closed] = new(ActionAvailability.Allowed, ActionAvailability.Allowed)
            }),

        ["ACTION5"] = new(
            CardTypes: [
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Ordered] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Inactive] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Active] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Restricted] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Blocked] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Expired] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Closed] = new(ActionAvailability.Allowed, ActionAvailability.Allowed)
            }),

        ["ACTION6"] = new(
            CardTypes: [
                CardType.Prepaid,
                CardType.Debit,
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Ordered] = new (ActionAvailability.Allowed, ActionAvailability.Denied),
                [CardStatus.Inactive] = new(ActionAvailability.Allowed, ActionAvailability.Denied),
                [CardStatus.Active] = new(ActionAvailability.Allowed, ActionAvailability.Denied),
                [CardStatus.Blocked] = new(ActionAvailability.Allowed, ActionAvailability.Undefined)
            }),

        ["ACTION7"] = new(
            CardTypes: [
                CardType.Prepaid,
                CardType.Debit,
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Ordered] = new(ActionAvailability.Undefined, ActionAvailability.Allowed),
                [CardStatus.Inactive] = new(ActionAvailability.Undefined, ActionAvailability.Allowed),
                [CardStatus.Active] = new(ActionAvailability.Undefined, ActionAvailability.Allowed),
                [CardStatus.Blocked] = new(ActionAvailability.Allowed, ActionAvailability.Undefined)
            }),

        ["ACTION8"] = new(
            CardTypes: [
                CardType.Prepaid,
                CardType.Debit,
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Ordered] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Inactive] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Active] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Blocked] = new(ActionAvailability.Allowed, ActionAvailability.Allowed)
            }),

        ["ACTION9"] = new(
            CardTypes: [
                CardType.Prepaid,
                CardType.Debit,
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Ordered] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Inactive] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Active] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Restricted] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Blocked] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Expired] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Closed] = new(ActionAvailability.Allowed, ActionAvailability.Allowed)
            }),

        ["ACTION10"] = new(
            CardTypes: [
                CardType.Prepaid,
                CardType.Debit,
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Ordered] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Inactive] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Active] = new(ActionAvailability.Allowed, ActionAvailability.Allowed)
            }),

        ["ACTION11"] = new(
            CardTypes: [
                CardType.Prepaid,
                CardType.Debit,
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Inactive] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Active] = new(ActionAvailability.Allowed, ActionAvailability.Allowed)
            }),

        ["ACTION12"] = new(
            CardTypes: [
                CardType.Prepaid,
                CardType.Debit,
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Ordered] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Inactive] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Active] = new(ActionAvailability.Allowed, ActionAvailability.Allowed)
            }),

        ["ACTION13"] = new(
            CardTypes: [
                CardType.Prepaid,
                CardType.Debit,
                CardType.Credit
            ],
            CardStatuses: new()
            {
                [CardStatus.Ordered] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Inactive] = new(ActionAvailability.Allowed, ActionAvailability.Allowed),
                [CardStatus.Active] = new(ActionAvailability.Allowed, ActionAvailability.Allowed)
            })
    };
}