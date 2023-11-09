using HtlPortalCore.Common.Enums;
using HtlPortalCore.DataAccess;
using HtlPortalCore.DataAccess.Entities;
using HtlPortalCore.Extensions;
using HtlPortalCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HtlPortalCore.Services
{
    public interface IUserService
    {
        Task RegisterPhoneSendEmailVerificationAsync(UserRegisterViewModel user);
    }

    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly AppDbContext _appDbContext;

        public UserService(ILogger<UserService> logger, AppDbContext appDbContex)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _appDbContext = appDbContex ?? throw new ArgumentNullException(nameof(appDbContex));
        }

        public async Task RegisterPhoneSendEmailVerificationAsync(UserRegisterViewModel user)
        {
            // Validate Email

            // Check user already registered, if not save to database
            var userEntity = await _appDbContext.Users.SingleOrDefaultAsync(u => user.Email == u.Email);

            if (userEntity == null)
            {
                try
                {
                    userEntity = UserEntityExtensions.ToEntityForCreateUser(user.Email, user.UserName, user.Password, user.Name, user.PhoneNumber);
                    await _appDbContext.Users.AddAsync(userEntity);
                     await _appDbContext.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    int x = 10;
                }
               
            };
            

            // Create Email verification token

            // send email to user with token 
        }



        public async Task<UserViewModel?> GetAsync(EAuthenticationMethod authenticationMethod, string value)
        {
            UserEntity? userEntity = null;

            if (EAuthenticationMethod.Email == authenticationMethod)
            {
                userEntity = await _appDbContext.Users.SingleOrDefaultAsync(u => string.Compare(u.Email, value, StringComparison.OrdinalIgnoreCase) == 0);
            }
            else if (EAuthenticationMethod.Phone == authenticationMethod)
            {
                userEntity = await _appDbContext.Users.SingleOrDefaultAsync(u => string.Compare(u.PhoneNumber, value, StringComparison.OrdinalIgnoreCase) == 0);
            }

            return userEntity?.ToViewModel();
        }

     
    }
}
