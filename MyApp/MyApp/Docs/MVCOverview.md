# MVC Pattern in the Inventory App

The application follows the Model-View-Controller (MVC) architectural pattern to separate responsibilities and keep the codebase maintainable.

## Model
- **`Models/Producto.cs`** defines the `Producto` entity that represents inventory items. It contains validation rules and default values to ensure data quality before the entity reaches the database.

## Data Access
- **`Data/AppDbContext.cs`** implements the Entity Framework Core `DbContext`. It exposes the `Productos` set so the application can query and persist `Producto` records through EF Core.

## Controller
- **`Controllers/ProductosController.cs`** coordinates HTTP requests for product management. It retrieves and stores data through `AppDbContext`, applies validation with model state, and decides which views should render responses for listing, creating, editing, or deleting products.

## Views
- **`Views/Productos/Index.cshtml`**, **`Create.cshtml`**, **`Edit.cshtml`**, and **`Delete.cshtml`** compose the user interface. They render Tailwind CSS-styled pages that display products and provide forms for user interactions while relying on Razor syntax to bind to the `Producto` model.

## Application Composition
- **`Program.cs`** wires services together. It registers `AppDbContext`, applies the connection string from `appsettings.json`, and seeds sample products at startup. This bootstrap file ensures that the controller receives an initialized data context when handling requests.

Together, these components implement the MVC pattern: models encapsulate data, views deliver presentation, the controller orchestrates requests, and the program bootstrap configures dependencies.
