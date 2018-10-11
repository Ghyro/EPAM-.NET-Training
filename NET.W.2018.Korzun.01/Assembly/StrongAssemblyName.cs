using System;
using System.Reflection;

[assembly: AssemblyKeyFile("myKey.snk")]

namespace StrongAssemblyName
{
    public class StrongApp
    {
        public static void Main()
        {
            Console.WriteLine("With strong name assembly!");
        }
    }
}