using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY_MANAGEMENT
{
    internal class passwordgenerator
    {
        public static string GeneratePassword(int passLength)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%&+=";
            var random= new Random();
            var result = new string(Enumerable.Repeat(chars, passLength).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }
    }
}
