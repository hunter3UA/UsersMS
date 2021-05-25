using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMS.Models.DTO.Logs;
using UsersMS.Models.DTO.Users;
using UsersMS.Models.Entities;

namespace UsersMS.Mapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<UserCreateDTO, User>();
                    cfg.CreateMap<UserUpdateDTO, User>();
                    cfg.CreateMap<User, UserDTO>();
                    cfg.CreateMap<LogRecord, LogRecordDTO>();
                    cfg.CreateMap<LogRecordDTO, LogRecord>();

                });
            return config;
        }
    }
}
