using Web.Repositories.Interfaces;
using Web.Services.Interfaces;

namespace Web.Services.Implementations
{
    public class OrderService(
        IOrderRepository orderRepository,
        IProductRepository productRepository,
        IUserRepository userRepository) : IOrderService
    {
        public async Task<OrderDto> CreateAsync(CreateOrderDto dto)
        {
            var buyer = await userRepository.GetByIdAsync(dto.BuyerId);
            if (buyer == null)
                throw new KeyNotFoundException("Alıcı tapılmadı");

            var product = await productRepository.GetByIdAsync(dto.ProductId);
            if (product == null)
                throw new KeyNotFoundException("Məhsul tapılmadı");

            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Miqdar 0-dan böyük olmalıdır");

            if (product.StockQuantity < dto.Quantity)
                throw new InvalidOperationException("Stok kifayət deyil");

            product.StockQuantity -= dto.Quantity;

            var order = new Order
            {
                BuyerId = dto.BuyerId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                TotalPrice = product.Price * dto.Quantity,
                CreatedAt = DateTime.Now
            };

            await orderRepository.AddAsync(order);
            await orderRepository.SaveAsync();

            order.Buyer = buyer;
            order.Product = product;

            return MapToDto(order);
        }

        public async Task<List<OrderDto>> GetByBuyerIdAsync(int buyerId)
        {
            var buyer = await userRepository.GetByIdAsync(buyerId);
            if (buyer == null)
                throw new KeyNotFoundException("Alıcı tapılmadı");

            var orders = await orderRepository.GetByBuyerIdAsync(buyerId);
            return orders.Select(o => MapToDto(o)).ToList();
        }

        private OrderDto MapToDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                BuyerName = order.Buyer.FullName,
                ProductName = order.Product.Name,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice,
                CreatedAt = order.CreatedAt
            };
        }
    }
}