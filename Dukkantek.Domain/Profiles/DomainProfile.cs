using System.Linq;
using AutoMapper;
using Dukkantek.Domain.Contracts.Requests;
using Dukkantek.Domain.Models;

namespace Dukkantek.Domain.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Product, CreateProductRequest>()
                .ReverseMap();

            CreateMap<Order, CreateOrderRequest>()
                .ReverseMap()
                .ForMember(dest => dest.Total, 
                    op => 
                        op.MapFrom(src => src.OrderDetails.Sum(s => s.Price)));
            CreateMap<OrderDetail, CreateOrderDetailRequest>()
                .ReverseMap();

        }
    }
}
