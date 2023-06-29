namespace Demo_webshop.Models.Services
{
    public interface IOrderRepository
    {

        Task CreateOrderAsync(Order order);

    }
}
