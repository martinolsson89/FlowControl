
namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            while (true)
            {
                PrintMenu();
                var choice = ReadInput("Välj ett alternativ: ");

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Avslutar...");
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val.\n");
                        break;
                }

            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("==== Huvudmeny ====");
            Console.WriteLine("0) Avsluta");
            Console.WriteLine();
        }

        // Helper Method

        private static string ReadInput(string prompt)
        {
            Console.Write(prompt);
            return (Console.ReadLine() ?? string.Empty).Trim();
        }
    }
}
