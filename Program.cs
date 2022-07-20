namespace MumuseAvecCSharp
{
    internal class Program
    {

        private static List<string> _list = new();
        static void Main(string[] args)
        {
            if (NewDirectory.CreateFolder(@"C:\", "Test516"))
                Console.WriteLine("Directory Created");
            else
                Console.WriteLine("Directory Already exist");
            
        }
    }
}