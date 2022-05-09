using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string pasword, out byte[] paswordHash, out byte[] paswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                paswordSalt = hmac.Key;
                paswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pasword));
            }
            
        }
    }
}
