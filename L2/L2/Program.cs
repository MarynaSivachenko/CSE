using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n = 2;

            //IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(n, false);
            //Console.WriteLine(mbf1.GetFlag());
            //Console.WriteLine();

            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(99, false);
            IIG.BinaryFlag.MultipleBinaryFlag mbf2 = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);
            Console.WriteLine(mbf1.GetHashCode());
            mbf2.Dispose();
            Console.WriteLine(mbf2 == null);
            //mbf1.SetFlag(1);
            Console.WriteLine(mbf2.GetFlag());

            //mbf1.SetFlag(0);
            //mbf1.SetFlag(1);
            //Console.WriteLine(mbf1.GetFlag());
            // mbf1.Dispose();
            //Console.WriteLine(mbf1.GetFlag());
            
            //Console.WriteLine(IIG.BinaryFlag.MultipleBinaryFlag.ReferenceEquals(s1, s2));


            Console.ReadKey();
        }
    }
}
