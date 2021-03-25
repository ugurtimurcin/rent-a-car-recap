using AutoMapper;
using Core.Entities;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
             CreateMap<BrandDto, Brand>().ReverseMap();
             CreateMap<CarDto, Car>().ReverseMap();
             CreateMap<CarImageDto, CarImage>().ReverseMap();
             CreateMap<ColorDto, Color>().ReverseMap();
             CreateMap<CustomerDto, Customer>().ReverseMap();
             CreateMap<RentalDto, Rental>().ReverseMap();
        }
    }
}
