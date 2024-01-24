using AutoMapper;
using Ordering.Application.Commands.CheckoutOrder;
using Ordering.Application.Commands.UpdateOrder;
using Ordering.Application.Queries.GetOrdersByUser;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, GetOrdersByUserQueryResponse>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
