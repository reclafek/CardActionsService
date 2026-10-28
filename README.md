# CardActionsService

ASP.NET Core Web API that determines which actions are available for a payment card based on its type, status, and PIN configuration.

## Technologies

- C#
- ASP.NET Core Web API (.NET 8)
- xUnit
- REST API
- In-memory sample data

## Features

- Retrieves card details by user ID and card number.
- Determines available card actions using configurable business rules.
- Supports case-insensitive user ID and card number lookup.
- Handles HTTP responses for successful requests, invalid input, and missing cards.
- Includes unit tests for business rules, service logic, and controller behavior.

## API Endpoint

`GET /api/cards/{userId}/{cardNumber}`

### Responses

- `200 OK` — card found; returns the available actions.
- `400 Bad Request` — user ID or card number is empty or whitespace.
- `404 Not Found` — user or card does not exist.
- `500 Internal Server Error` — unexpected server error.

## Testing

The solution includes an xUnit test project covering card action rules, card lookup, and HTTP response handling.

## Data

The application currently uses in-memory sample data to demonstrate the business logic. The data source can be replaced with a database or an external service.

## Purpose

This project demonstrates REST API design, separation of responsibilities, business rule implementation, error handling, and unit testing in .NET.

## Example Request

GET /api/cards/User3/Card36

## Example Response

```json
{
  "actions": [
    "ACTION3",
    "ACTION4",
    "ACTION9"
  ]
}
