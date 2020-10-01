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
            Cat cat1 = new Cat("Vaska", 3);
            Cat cat2 = new Cat("Murzik", 3);
            Cat cat3 = cat2;
            Cat cat4 = new Cat("Vaska", 3);
            String s1 = new String(new char[]{'w', 'o', 'r', 'l', 'd' });
            String s2 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });
            StringBuilder sb1 = new StringBuilder("world");
            StringBuilder sb2 = new StringBuilder("world");

            Console.WriteLine(IIG.BinaryFlag.MultipleBinaryFlag.Equals(s1, s2));
            Console.WriteLine(IIG.BinaryFlag.MultipleBinaryFlag.ReferenceEquals(s1, s2));
           

            Console.ReadKey();
                    }
    }

    public class Cat
    {
        String name;
        int age;

        public Cat(String name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
