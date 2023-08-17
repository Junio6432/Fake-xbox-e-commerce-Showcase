Building an Xbox Web Store using ASP.NET 6, EntityFramework, and Identity API

In this project, I embarked on the development of an Xbox web store employing a range of advanced technologies, including ASP.NET 6, EntityFramework, Identity API, JavaScript, CSS, Razor Pages, and the MVC architectural pattern. My goal was to create a seamlessly integrated platform that harmonized user interactions, server-side logic, and database functionality.

Models: The Crucial Foundation

At the heart of the application lie the models. I meticulously designed a spectrum of services, helper methods, interfaces, model classes, extension methods, and the pivotal dbContext class. These model classes, such as Genre, Order, OrderDetail, Product, and ShoppingCartItem, serve as blueprints that EntityFramework utilizes to construct tables, establish relationships, and create indexes. For instance, the Genre class seamlessly translates into SQL-compatible entities. An intriguing aspect is the navigation object, exemplified by the list of Products within Genre, which facilitates robust one-to-many relationships.

Order: Attribute Utilization and Dynamic Functionality

The Order class introduces a layer of sophistication through the deployment of attributes. These attributes, encompassing [BindNever], [Required], [Display(Name = "Email")], and [StringLength(25)], enhance client-side binding, error management, and input validation. The [BindNever] attribute safeguards specific properties from user input, while [Required] enforces mandatory fields with tailored error messages. [Display(Name = "Email")] enhances input box clarity, and [StringLength(25)] sets character limits. Significantly, these attributes dynamically govern properties like OrderPlaced, OrderTotal, and OrderId, influencing their behavior.

dbContext: The Core of EntityFramework

The dbContext class takes center stage, empowering EntityFramework to map classes, incorporate pre-defined data, and create DbSets for streamlined CRUD (Create, Read, Update, Delete) operations. These DbSets, which act as conduits for querying, mirror table types, facilitating efficient data interaction with the database. OnModelCreating facilitates manual relationship establishment, type conversions, and pre-defined data integration. Through the use of modelBuilder, we expertly orchestrate database interactions, ensuring data consistency and integrity.

APPLICATIONUSER: Extending IdentityUser for Tailored Functionality

To accommodate bespoke Identity functionality, I extended the base IdentityUser class to create the ApplicationUser class. This customization process streamlined the addition of properties like first name, last name, and ShoppingCartId. The [BindNever] attribute streamlined user registration, as the application exclusively manages ShoppingCartId.

Services: Orchestrating Controller Dynamics

Our services assume a pivotal role in directing controllers, harmonizing their behavior and interaction with the application. The interfaces, embodying the repository pattern, bolster scalability, legibility, and adherence to SOLID principles. IGenreRepository, IOrderRepository, IProductRepository, and IShoppingCart serve as the foundation for repository operations, providing a clear blueprint for repository implementations. The application of asynchronous methods ensures optimal performance.

ShoppingCartRepository: Architecting Cart Persistence

The ShoppingCartRepository assumes a central role, orchestrating a spectrum of cart operations, from additions to deletions and ShoppingCartId management. Leveraging dependency injection, we harness userManager, dbcontext, and SignInManager. The pivotal GetCart method adeptly oversees cart retrieval. By utilizing IServiceProvider, HttpContext, UserManager, and SignInManager, we adeptly handle cart persistence, catering to both authenticated and anonymous users.

ProductRepository: Mastery of Product Management

ProductRepository, meticulously constructed with dependency injection, efficiently oversees the spectrum of product management tasks. Uniquely, it leverages properties for efficient in-memory storage, enabling LINQ-based sorting. Methods such as GetAllProductsAsync, DeleteProductAsync, SearchProductsAsync, and GetProductByIdAsync propel various product management scenarios.

Helpers: Leveraging Extension Methods

Extension methods augment user management via the ApplicationUserExtension and UserManagerExtension classes. SetUserInfoAsync intelligently updates user information, while SetUserShoppingCartAsync efficiently manages ShoppingCartId. UserManagerExtension adeptly retrieves user details.

Controllers: Masterful Coordination

Controllers, underpinned by dependency injection, artfully orchestrate interactions between the backend and frontend. By adhering to consistent naming conventions, alignment between the controller and view folders is ensured, reflecting the tenets of the MVC paradigm. Methods such as DetailsAsync and DeleteProductAsync facilitate product details display and execute role-based authorization.

API: Showcasing Specialized Capability

The SearchController emerges as a testament to our proficiency in API development. Attributes such as [Route("api/[controller]")] and [ApiController] define this class as an API. Methods like GetByName exemplify our mastery in using APIs to selectively update page sections through partial views.

VIEWS: Dynamic and Adaptive Interfaces

Views, meticulously organized into folders mirroring controllers, leverage Razor Pages to introduce dynamism. Shared components like "-BackCardGame" elevate code reusability. "_LayOut" unifies design aesthetics. Razor Pages expertly harmonize C# and HTML, with ViewModels serving as conduits for data flow. Components adeptly handle product counts for the shopping cart.

JavaScript: Elevating User Engagement

JavaScript plays a pivotal role, enabling user input, dynamic content retrieval, and section updates. Via AJAX, we deftly obtain user input and employ it to query the database, significantly reducing the need for page reloads.

CSS: Pioneering Adaptability

The CSS prowess demonstrated is exemplary, harnessing flexboxes and grids to craft a fully responsive design that seamlessly adapts across an array of devices.
