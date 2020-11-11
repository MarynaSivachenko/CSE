using System;

public class Class1
{
    static void Main(string[] args)
    {
        int a = 5;
        IIG.PasswordHashingUtils.PasswordHasher.Init("m", 1);
        Console.WriteLine(IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234", null, 0));
        Console.ReadKey();
    }
}
