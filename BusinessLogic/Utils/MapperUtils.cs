using System;
using AutoMapper;
using BusinessLogic.Models;
using DataModels.Entities;
using Void = BusinessLogic.Models.Void;

namespace BusinessLogic.Utils
{
    public static class MapperUtils
    {
        private static void CreateMaps<TA, TB>(this IProfileExpression profileExpression)
        {
            profileExpression.CreateMap<TA, TB>().ReverseMap();
        }
        
        private static readonly MapperConfiguration mapperConfiguration =  new MapperConfiguration(x =>
        {
            x.CreateMaps<UserLogin, User>();
            x.CreateMaps<UserCreate, User>();
            x.CreateMaps<Void, User>();
        });

        private static readonly IMapper mapper = mapperConfiguration.CreateMapper();

        public static T ConvertTo<T>(this object t)
        {
            if (t == null)
            {
                throw new Exception("Nullpoint exception occurs!");
            }

            if (t is T objT)
            {
                return objT;
            }
            
            return mapper.Map<T>(t);
        }
    }
}