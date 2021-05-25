using AutoMapper;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMS.DAL;
using UsersMS.Mapper;
using UsersMS.Models.DTO.Logs;
using UsersMS.Models.DTO.Users;
using UsersMS.Models.Entities;


namespace UsersMS.Services
{
    public class LogsService
    {
       // private static IMapper mapper = AutoMapperConfig.Configure().CreateMapper();

       // public static void AddLog(DateTime regTime,User user )
       // {
       //     LogRecord log = new LogRecord();
       //     log.AddedAt = regTime;
       //     UserDTO userDTO = mapper.Map<UserDTO>(user);
       //     JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
       //     log.Details = javaScriptSerializer.Serialize(userDTO);
       //  //   DAL_Prod.Logs.Add(log);            
       // }

       // public static List<LogRecordDTO> All()
       // {
       // //    List<LogRecord> logRecords = DAL_Prod.Logs.All();
       ////     return mapper.Map<List<LogRecordDTO>>(logRecords);
       // }
       // public static List<LogRecordDTO> ByID(int logID)
       // {
       //  //   List<LogRecord> logRecords = DAL_Prod.Logs.ByID(logID);
       //  //   return mapper.Map<List<LogRecordDTO>>(logRecords);
       // }




    }
}



/*
  public class LogsService
    {
        private static IMapper mapper = AutoMapperConfig.Configure().CreateMapper();

        public static void AddLog(DateTime regTime,UserDTO userDTO )
        {
            LogRecord log = new LogRecord();
            log.AddedAt = regTime;     
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            log.Details = javaScriptSerializer.Serialize(userDTO);
            _DAL.Logs.Add(log);            
        }

        public static List<LogRecordDTO> All()
        {
            List<LogRecord> logRecords = _DAL.Logs.All();
            return mapper.Map<List<LogRecordDTO>>(logRecords);
        }
        public static List<LogRecordDTO> ByID(int logID)
        {
            List<LogRecord> logRecords = _DAL.Logs.ByID(logID);
            return mapper.Map<List<LogRecordDTO>>(logRecords);
        }




    }
 
 */