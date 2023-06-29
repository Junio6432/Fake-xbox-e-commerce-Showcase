using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Demo_webshop.Models.Services.Helpers.ExtensionMethods;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Dapper.Contrib;
using Dapper;
using Demo_webshop.Models.Services.Helpers;
using Microsoft.Data.Sqlite;

namespace Demo_webshop.Models.Services
{
    public class ShoppingCartRepository : IShoppingCart
    {

        private readonly DemoWebShopDBContext _webDBContext = default!;

        private  readonly SignInManager<ApplicationUser> _signInManager = default!;

        private  readonly UserManager<ApplicationUser> _userManager = default!;

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public string? ShoppingCartId { get; set; }

        private ShoppingCartRepository(DemoWebShopDBContext webShopDbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {

            _userManager = userManager;

            _webDBContext = webShopDbContext;

            _signInManager = signInManager;

        }


        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {

            long tiempo;

            var cronometro = new Stopwatch();

            cronometro.Start();

            DemoWebShopDBContext context = services.GetService<DemoWebShopDBContext>() ?? throw new Exception("Error initializing");

            var httpContext = services.GetRequiredService<IHttpContextAccessor>().HttpContext;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            var signInManager = services.GetRequiredService<SignInManager<ApplicationUser>>();

            ShoppingCartRepository repository = new(context, userManager, signInManager);

            if (repository.isSignedIn(httpContext) == true)
            {

                var shoppingCartId = repository.getShoppingCartFromSql(httpContext);

                return new ShoppingCartRepository(context, userManager, signInManager){ ShoppingCartId = shoppingCartId };

            }
            else
            {

                string shoppingCartId = getShoppingCartId(httpContext);

                if (shoppingCartId == "")
                {

                    shoppingCartId = Guid.NewGuid().ToString();

                    httpContext?.Response.Cookies.Append("cartId", shoppingCartId);

                }

                return new ShoppingCartRepository(context, userManager, signInManager) { ShoppingCartId = shoppingCartId };

            }

        }


        private static string getShoppingCartId(HttpContext httpContext)
        {

            var shoppingCartId = httpContext?.Request.Cookies["cartId"];

            if (shoppingCartId != null)
            {

                return shoppingCartId;

            }
            else
            {

                return "";
            }


        }

        private bool isSignedIn(HttpContext httpContext)
        {
            if (_signInManager.IsSignedIn(httpContext?.User) == true)
            {

                return true;

            }
            else
            {
                return false;
            }
        }

        private string getShoppingCartFromSql(HttpContext httpContext)
        {

                var userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var applicationUser = _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();

                var sqlShoppingCartId = _userManager.GetUserShoppingCart(applicationUser);

                if (sqlShoppingCartId == null || sqlShoppingCartId == "")
                {

                    var shoppingCartId = Guid.NewGuid().ToString();

                     _userManager.SetUserShoppingCartAsync(applicationUser, shoppingCartId);

                    return shoppingCartId;

                }
                else
                {

                    return sqlShoppingCartId;

                }

        }


        public async Task AddToCartAsync(Product product)
        {

            var shoppingCartItem =
                    await _webDBContext.ShoppingCartItems.AsNoTracking().SingleOrDefaultAsync(
                        s => s.product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    product = product,
                    Amount = 1
                };

                await _webDBContext.ShoppingCartItems.AddAsync(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
                _webDBContext.Update(shoppingCartItem);
            }

            await _webDBContext.SaveChangesAsync();
        }

        public async Task ClearCartAsync()
        {

            var cartItems = await _webDBContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId).ToListAsync();

            _webDBContext.ShoppingCartItems.RemoveRange(cartItems);

            await _webDBContext.SaveChangesAsync();
        }

        public async Task<List<ShoppingCartItem>> GetShoppingCartItemsAsync()
        {

            return ShoppingCartItems ??= 
                       await _webDBContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.product).ToListAsync();
        }

        public async Task<double> GetShoppingCartTotalAsync()
        {

            var total = await _webDBContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => (double)c.product.Price * c.Amount).SumAsync();
            return total;
        }

        public async Task RemoveFromCartAsync(Product product)
        {

            var shoppingCartItem =
                    await _webDBContext.ShoppingCartItems.SingleOrDefaultAsync(
                        s => s.product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _webDBContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

             await _webDBContext.SaveChangesAsync();

        }

        public async Task<double> GetShoppingCartTotalProductsAsync()
        {

            var total = await _webDBContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => (double)c.Amount).SumAsync();
            return total;
        }

    }
}
