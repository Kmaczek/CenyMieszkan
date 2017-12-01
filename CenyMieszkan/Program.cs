using System;

namespace CenyMieszkan
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var runner = new Runner();
                runner.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
    }
}
