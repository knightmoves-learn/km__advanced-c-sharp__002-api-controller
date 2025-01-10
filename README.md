# 002 API Controller

## Lecture Part 1

[![002 Api Controller(Part 1)](https://img.youtube.com/vi/eyuybKCOQ08/0.jpg)](https://www.youtube.com/watch?v=eyuybKCOQ08)

## Lecture Part 2

[![002 Api Controller(Part 2)](https://img.youtube.com/vi/0XKP_jSklGA/0.jpg)](https://www.youtube.com/watch?v=0XKP_jSklGA)

## Instructions

In this assignment you will refactor code from `StockPriceApi/Program.cs` into a seperate controller. This Refactoring should look similar to what you watched in the lecture.

The `StockPriceApi` project...

- Should contain a directory at the root of the project named "Controllers"
- Should contain a file named "StockPriceController.cs" within the "Controllers" directory

`StockPriceApi/Controllers/StockPriceController.cs`...

- Should exist in the namespace "StockPriceApi".
- Should have a `public class` named "StockPriceController" which implements the "ControllerBase" class.
- Should have attributes on the "StockPriceController" class that establish the class as an "ApiController", and establish a route of `[controller]` (or "StockPrice").
- Should contain the code from `StockPriceApi/Program.cs` which create the string array "stockTickers", and the decimal array "stockPrices" with the same initial values.
- Should contain the code from `StockPriceApi/Program.cs` which creates the public record "StockPrices".
- Should contain a `public` method which returns `IEnumerable<StockPrices>` named "Get" and takes no arguments
- The `Get()` method should have an attribute establishing it as an "HTTPGet" route.
- The `Get()` method should contain the SAME logic as the `app.MapGet("/StockPrices")` in `StockPriceApi/Program.cs`

`StockPriceApi/Program.cs`...

- Should no longer contain code creating the string array "stockTickers", and the decimal array "stockPrices.
- Should no longer contain the code creating the public record "StockPrices".
- Should no longer contain the get route for `/StockPrices` or any of thet logic existing inside of it.
- Should add and map the controllers to the project, using the available methods on `builder.Services` and `app`.

Additional Information:

- You should NOT change any code within the `TestsProj` directory

## Resources

- https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0

## Building toward CSTA Standards

- Explain how abstractions hide the underlying implementation details of computing systems embedded in everyday objects (3A-CS-01) https://www.csteachers.org/page/standards
- Demonstrate code reuse by creating programming solutions using libraries and APIs (3B-AP-16) https://www.csteachers.org/page/standards

Copyright &copy; 2024 Knight Moves. All Rights Reserved.
