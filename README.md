Fake Xbox Webshop: An ASP.NET 6 Showcase
Overview
This is a demonstration of a webshop built using ASP.NET 6, Entity Framework, Identity API, JavaScript, CSS, Razor Pages, and MVC. The project employs the Model-View-Controller (MVC) architectural pattern to effectively organize various components, including the frontend, backend, and repositories.

Models
In the "Models" section, various components are introduced, including services, helper methods, interfaces, model classes, extension methods, extension classes, and the DbContext.

Model Classes
The application features essential model classes that serve as the foundation for Entity Framework's table creation, relations, indexes, and foreign keys. Notably, these classes include:

Genre
Order
OrderDetail
Product
ShoppingCartItem
For instance, let's delve into the Genre model class:

public class Genre
{
    public int GenreId { get; set; }
    public string GenreName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<Product>? Products { get; set; }
}
The class's properties are automatically translated by Entity Framework into SQL-compatible fields. The List<Product>? Products property establishes a one-to-many relationship with the "Product" table, enhancing data organization.

Order Class Attributes
Exploring the Order class, we encounter the effective use of attributes to enhance data binding and validation:

[BindNever]: Excludes a property from data binding, preserving data integrity.
[Required]: Specifies that a field is mandatory, with customizable error messages.
[Display(Name = "Email")]: Provides a reference string for input boxes.
[StringLength(25)]: Sets the maximum length for input data.
Noteworthy attributes, such as [BindNever], ensure certain properties, like OrderPlaced, OrderTotal, and OrderId, are properly managed by the application, minimizing user input.

DbContext
A pivotal component of the project, the DbContext class, enables Entity Framework to map classes, create pre-built data, and generate DbSets. These DbSets facilitate CRUD operations and queries.

The class encompasses DbSet properties, defining types for the classes used as tables. Furthermore, the OnModelCreating method plays a crucial role by manually establishing relationships, data defaults, and pre-built data. For example:


ApplicationUser Extension
The ApplicationUser class extends the IdentityUser class provided by Identity API. This extension accommodates additional properties, such as FirstName, LastName, and ShoppingCartId. The ShoppingCartId property, adorned with the [BindNever] attribute, ensures seamless registration without user interference, as the application handles this data.

Services
The "Services" section introduces essential services that power the controllers. Following the Repository Pattern, interfaces guide repositories, promoting SOLID principles and efficient dependency injection. Interfaces include:

IGenreRepository
IOrderRepository
IProductRepository
IShoppingCart
An essential repository, ShoppingCartRepository, implements the IShoppingCart interface. It handles shopping cart functionality, including item addition, deletion, and ShoppingCartId management.

Notably, the static GetCart method efficiently retrieves the shopping cart for users, leveraging dependency injection and HttpContext. This method caters to both signed-in and anonymous users, ensuring seamless shopping cart management across devices.
