using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMS.Models.Entities;

namespace UsersMS.DAL
{
    public interface IDAL
    {
        Task<List<User>> All();
        Task<User> Add(User user);
        Task<User> ByID(int userID);
        List<User> BySearchFunc(Func<User, bool> predicate);
        Task<bool> DeleteById(int userID);
        Task<User> Edit(User user);
    }
}
