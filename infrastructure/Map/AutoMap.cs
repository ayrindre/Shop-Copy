using System;
using AutoMapper;
using core.Domain;
using infrastructure.Data.Entities;

namespace infrastructure.Map
{
    public class AutoMap:Profile
    {
        public AutoMap()
        {
            CreateMap<MCategory,Category>().ReverseMap();
        }
    }
}