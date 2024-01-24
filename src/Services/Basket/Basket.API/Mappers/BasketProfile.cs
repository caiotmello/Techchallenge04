using AutoMapper;
using Basket.API.Entities;
using EventBus.Messages;

namespace Basket.API.Mappers
{
    public class BasketProfile: Profile
    {
        public BasketProfile() 
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
