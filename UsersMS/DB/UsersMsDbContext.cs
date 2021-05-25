using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UsersMS.Models.Entities;


namespace UsersMS.DB
{
    public class UsersMsDbContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<LogRecord> LogRecord { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            IConfiguration appConfig =
                new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true).Build();
            string dbConnnString = appConfig.GetConnectionString("UserMsDb");
            optionsBuilder.UseSqlServer(dbConnnString);


        }
    }
}
