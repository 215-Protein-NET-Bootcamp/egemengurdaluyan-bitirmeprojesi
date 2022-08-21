using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Base
{
    public static class HashExtension
    {
        public static bool CheckingPassword(this string storagePassword, string loginPassword)
        {
            try
            {
                //Hash Password
                var hashedPassword = HashPassword(loginPassword);

                if (string.Equals(storagePassword, hashedPassword))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static string HashPassword(string password)
        {
            var salt = "patika";
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes($"{password}{salt}");

            return Convert.ToBase64String(sha.ComputeHash(asByteArray));
        }



    }
}
