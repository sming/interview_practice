using System;
namespace org.psk.playground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Permer("lab");
            var perms = p.GetPermutations();
            string output = string.Join(", ", perms);
            Console.WriteLine($"The permutations of 'lab' are {output}.");
        }
    }
}