using System.Security.Cryptography;
using System.Text;

namespace HtlPortalCore.Common.Helpers
{
    public static class AuthenticationHelpers
    {
        public static string CreateGuidString(string value)
        {
            using MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            return new Guid(hash).ToString();
        }
    }
}
