using HtlPortalCore.Common.Helpers;
using HtlPortalCore.DataAccess.Entities;
using HtlPortalCore.Models;

namespace HtlPortalCore.Extensions
{
    public static class UserEntityExtensions
    {
        public static UserViewModel ToViewModel(this UserEntity entity)
        {
            return new() 
            {
                UserName = entity.UserName,
                Email = entity.Email,
                Name = entity.Name,
                PasswordHash = entity.PasswordHash,
                EmailConfirmed = entity.EmailConfirmed
            };
        }

        public static UserEntity ToEntityForCreateUser(string email, string userName, string password, string name, string phone)
        {
            var user = new UserEntity
            {            
                Id = Guid.NewGuid().ToString(),
                UserName = userName,
                Email = email,               
                PasswordHash = AuthenticationHelpers.CreateGuidString(password),
                CreatedOn = DateTime.Now,
                EmailConfirmed = false,
                PhoneNumber = phone,
                Name = name
            };           

            return user;
        }
    }
}
