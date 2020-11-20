using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PharmaWarehouse.Api.Entities;
using PharmaWarehouse.Api.Modules.Extensions;

namespace PharmaWarehouse.Api.Dtos
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            this.UserDtoMappings();
        }

        private void UserDtoMappings()
        {
            this.CreateMap<User, UserDto>()
                .ForMember(userDto => userDto.RoleName, options => options.MapFrom(user => "Admin"))
                .ForMember(userDto => userDto.BirthDate, options => options.MapFrom(user => user.BirthDate.ToUnixDate()));

            this.CreateMap<UserDto, User>()
                .ForMember(user => user.BirthDate, options => options.MapFrom(userDto => userDto.BirthDate.FromUnixDate()));

            this.CreateMap<UserUpsertDto, User>()
                .ForMember(user => user.BirthDate, options => options.MapFrom(userDto => userDto.BirthDate.FromUnixDate()));
        }
    }
}
