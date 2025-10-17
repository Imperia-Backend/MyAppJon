# Project Guidelines

## Architecture Requirements
- Use Clean Architecture with the following layers: Domain, Application, Infrastructure, and API.
- Employ Entity Framework Core for data access.
- Store configuration values in `appsettings.json`.
- Implement RESTful controllers with validation and DTOs.
- Configure dependency injection in `Program.cs`.
- Use structured logging via Serilog.
- Provide unit tests built with xUnit and FluentAssertions.
- Publish Swagger/OpenAPI documentation.
- Generate and commit Entity Framework Core migrations whenever entity classes change, and ensure the database is updated.

## Code Style
- Write code and comments in English.
- Use explicit type declarations; the `var` keyword is not allowed.
- Use good, descriptive variable names.
- Apply camelCase to local variables, PascalCase to methods and class members, and UPPER_SNAKE_CASE to TA properties.
- Endpoints cannot return TA elements.
- LINQ and Entity Framework transformations are allowed with simple, reasonable use.
- Use 4 spaces instead of tabs for indentation.
- Use CRLF for new lines.
- Place braces (`{}`) on new lines.
- Insert a blank line between methods.
- Use whitespace thoughtfully inside methods; keep related code together.
- Place spaces before and after any operator (except for `++`).
- Only use the `++` operator after the variable, never before.
- Prefer `double` over `float`.
- Prefer `List<T>` over arrays.
- Avoid `out` and optional parameters.
