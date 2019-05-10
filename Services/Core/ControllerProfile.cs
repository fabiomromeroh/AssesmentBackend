using AutoMapper;
using Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Core
{
    public class ControllerProfile
    {
        public static IMapper Mapper { get; set; }

        public static void Configure()
        {
            var MapperConfiguration = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Client, ClientModel>().ReverseMap();
                //cfg.CreateMap<Policy, PolicyModel>().ReverseMap();


            });

            Mapper = MapperConfiguration.CreateMapper();

        }
    }
}