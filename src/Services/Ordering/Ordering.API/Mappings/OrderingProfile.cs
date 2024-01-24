using AutoMapper;
using EventBus.Messages;
using Ordering.Application.Commands.CheckoutOrder;

namespace Ordering.API.Mappings
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile() 
        {
            CreateMap<CheckoutOrderCommand,BasketCheckoutEvent>().ReverseMap();
        }
    }
}
