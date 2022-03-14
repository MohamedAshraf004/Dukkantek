using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailRequest>()
                .ReverseMap();
          
        }
    }
}
