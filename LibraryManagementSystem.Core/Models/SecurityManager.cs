using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Models
{
    public class SecurityManager : Manager
    {
        public SecurityManager(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public static byte[] GenerateSalt(int length)
        {
            var bytes = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            return bytes;
        }

        public static string GetHash(string password, byte[] salt, int iterations)
        {
            string hash = String.Empty;

            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                hash = Convert.ToBase64String(deriveBytes.GetBytes(salt.Length));
            }

            return hash;
        }
    }
}
