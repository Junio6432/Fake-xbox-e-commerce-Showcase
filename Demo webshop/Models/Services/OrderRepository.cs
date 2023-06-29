namespace Demo_webshop.Models.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DemoWebShopDBContext _webDBContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(DemoWebShopDBContext wbeShopDbContext, IShoppingCart shoppingCart)
        {
            _webDBContext = wbeShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public async Task CreateOrderAsync(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = await _shoppingCart.GetShoppingCartTotalAsync();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.product.ProductId,
                    Price = shoppingCartItem.product.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            await _webDBContext.Orders.AddAsync(order);

            await _webDBContext.SaveChangesAsync();
        }

    }
}
