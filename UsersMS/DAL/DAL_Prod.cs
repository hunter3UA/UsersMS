using System;
using System.Collections.Generic;
using System.Linq;
using UsersMS.Models.Entities;
using UsersMS.DB;
using UsersMS.Models.DTO.Logs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace UsersMS.DAL
{
    public class DAL_Prod:IDAL
    {
        public  async Task<List<User>> All()
            {
                using (var db = new UsersMsDbContext())
                {                 
                    return await db.User.ToListAsync();
                }
            }
        public  async Task<User> Add(User user)
            {
                using (var db = new UsersMsDbContext())
                {
                    await db.User.AddAsync(user);
                    await db.SaveChangesAsync();
                    return user;
                }
            }
        public  async Task<User> ByID(int userID)
            {
                using (var db = new UsersMsDbContext())
                {
                    return await db.User.Where(u => u.UserID == userID).FirstOrDefaultAsync();
                }
            }       
        public  List<User> BySearchFunc(Func<User, bool> predicate)
            {
                using(var db=new UsersMsDbContext())
                {
                    return db.User.Where(predicate).ToList();
                }
            }       
        public  async Task<bool> DeleteById(int userID)
            {
                using(var db=new UsersMsDbContext())
                {
                    User userToDelete =await db.User.Where(u => u.UserID == userID).FirstOrDefaultAsync();
                    if (userToDelete == null)
                    {
                        return false;
                    }
                    else
                    {
                        db.User.Remove(userToDelete);
                        await db.SaveChangesAsync();
                        return true;
                    }
                }
            }
        public  async Task<User> Edit(User user)
            {
                using(var db=new UsersMsDbContext())
                {
                    User userToEdit =await  db.User.Where(u => u.UserID == user.UserID).FirstOrDefaultAsync();
                    if (userToEdit == null)
                    {
                        return user;
                    }
                    else
                    {
                        userToEdit.UserName = user.UserName;
                        userToEdit.BirthDate = user.BirthDate;
                        userToEdit.PasswordHash = user.PasswordHash;
                        await db.SaveChangesAsync();
                        return userToEdit;
                    }
                }
            }

        

    }
}
        //public static class Logs
        //{
        //    public static List<LogRecord> All()
        //    {
        //        using(var db=new UsersMsDbContext())
        //        {
        //            return db.LogRecord.ToList();
        //        }
        //    }

        //    public static List<LogRecord> ByID(int logID)
        //    {
        //        using(var db=new UsersMsDbContext())
        //        {
        //            var firstLog = db.LogRecord.Where(l => l.LogRecordID == logID).First();
        //            return db.LogRecord.Where(l => l.AddedAt >= firstLog.AddedAt).ToList();
        //        }
        //    }
        //    public static LogRecord Add(LogRecord logRecord)
        //    {
        //        using (var db = new UsersMsDbContext())
        //        {
        //             db.LogRecord.Add(logRecord);
        //             db.SaveChanges();
        //             return logRecord;
        //        }
        //    }
            

        //}