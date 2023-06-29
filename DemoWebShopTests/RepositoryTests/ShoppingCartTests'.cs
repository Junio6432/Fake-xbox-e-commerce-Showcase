using Demo_webshop.Models;
using Demo_webshop.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Text;

namespace DemoWebShopTests.RepositoryTests
{
    public class ShoppingCartTests
    {

        private readonly ShoppingCartRepository _shoppingCart;

        public ShoppingCartTests()
        {
        }

        public void Dispose()
        {

        }

        [Fact]
        public void GetCart_SetCart_SetStringForNewCart()
        {

            // Arrange
            var services = new ServiceCollection();
            services.AddHttpContextAccessor();

            var session = new TestSession();
            var accessor = new HttpContextAccessor { HttpContext = new DefaultHttpContext { Session = session}};

            services.AddDbContext<DemoWebShopDBContext>(options =>
            options.UseSqlServer(Configuration.("WebShopContextSQLConnection")));


            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<DemoWebShopDBContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();

            // Registrar UserManager
            services.AddScoped<UserManager<ApplicationUser>>();

            // Registrar SignInManager
            services.AddScoped<SignInManager<ApplicationUser>>();

            services.AddSingleton<DemoWebShopDBContext>();
            services.AddSingleton<IHttpContextAccessor>(accessor);
            var serviceProviderWithAccessor = services.BuildServiceProvider();

            // Act
            ShoppingCartRepository.GetCart(serviceProviderWithAccessor);

            // Assert
            Assert.NotNull(session.GetString("CartId"));


        }

        [Fact]
        public void GetCart_ReturningShoppingCartRepositoryObject_ShoppingCartRepositoryIsReturned()
        {

            //Arrange
            var services = new ServiceCollection();

            var session = new TestSession();
            var accesor = new HttpContextAccessor() { HttpContext = new DefaultHttpContext { Session = session } };

            services.AddSingleton<DemoWebShopDBContext>();
            services.AddSingleton<IHttpContextAccessor>(accesor);
            var serviceProviderWithAccesor = services.BuildServiceProvider();

            //Act

            var shoppingCart = ShoppingCartRepository.GetCart(serviceProviderWithAccesor);

            //Assert
            Assert.IsType<ShoppingCartRepository>(shoppingCart);

        }



    }
}
