namespace Web.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> CreateAsync(CreateOrderDto dto);
        Task<List<OrderDto>> GetByBuyerIdAsync(int buyerId);
    }
}