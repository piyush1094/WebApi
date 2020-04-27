using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication10.Controllers.Resource;
using WebApplication10.Models;

namespace WebApplication10.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Campground, CampgroundResource>();
            Mapper.CreateMap<CampgroundResource, Campground>();
        }
    }
}