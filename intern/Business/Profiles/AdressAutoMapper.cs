using AutoMapper;
using Business.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
     class AdressAutoMapper : Profile
    {
        public AdressAutoMapper()
        {
            CreateMap<Address, AddressGetDto>().ReverseMap();
            CreateMap<Address, AddressPostDto>().ReverseMap();
            CreateMap<Address, AddressPutDto>().ReverseMap();
        }
    }
}
