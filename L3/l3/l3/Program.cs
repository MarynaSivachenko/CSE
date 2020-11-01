using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace l3
{
    class Program
    {
        static void Main(string[] args)
        {
          
            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 0);
            IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
                        Console.ReadKey();

        }

        

    }
}
