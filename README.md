# Sneaker Inventory Manager

A C# console application for managing a sneaker inventory, built to demonstrate advanced C# concepts and professional software design patterns.

## Tech Stack
- C# / .NET 8
- xUnit (unit testing)

## Concepts Demonstrated
- Object-Oriented Programming — inheritance, polymorphism, abstract classes, interfaces
- Design Patterns — Repository pattern, Factory pattern
- Dependency Injection
- LINQ
- Async/Await
- Custom Exceptions
- Delegates & Events
- Middleware Pipeline
- JSON serialization with System.Text.Json
- Unit Testing with xUnit

## Project Structure
- **SneakerInventory** — main console application
- **SneakerTests** — unit tests for the application

## Features
- Add casual and running shoes with full input validation
- Display all sneakers
- Search by brand, price, or ID
- Sort by price
- Save and load inventory to/from JSON file
- Auto-generated unique IDs (SNK001, SNK002 etc)

## Running the Project
1. Clone the repo
2. Navigate to the `SneakerInventory` folder
3. Run `dotnet run`

## Running the Tests
1. Navigate to the `SneakerTests` folder
2. Run `dotnet test`