using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersMS.Services
{
    public interface IPasswordService
    {
        string CreateSHA256Hash(string stringToHash);
    }
}
