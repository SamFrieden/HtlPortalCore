using HtlPortalCore.Common.Helpers;
using HtlPortalCore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HtlPortalCore.DataAccess.Seeds
{
    public static class SeedData
    {
        public static void AddAdminUsers(ModelBuilder builder)
        {
            builder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Admin",
                    Email = "admin@abc.at",
                    PhoneNumber = "12345",
                    Name = "Administrator",
                    EmailConfirmed = true,
                    PasswordHash = AuthenticationHelpers.CreateGuidString("AdminPassword"),
                    CreatedOn = DateTime.Now
                });
        }        
    }
}
