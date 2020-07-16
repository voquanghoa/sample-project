using System;
using AutoMapper;
using BusinessLogic.Models;
using DataModels.Entities;

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
            x.CreateMap<UserLogin, User>();
        });

        private static readonly IMapper mapper = mapperConfiguration.CreateMapper();

        public static T ConvertTo<T>(this object t)
        {
            if (t == null)
            {
                throw new Exception("Nullpoint exception occurs!");
            }
            
            return mapper.Map<T>(t);
        }
    }
}