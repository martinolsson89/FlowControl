
namespace FlowControl
{
    internal class Program
    {
        private const int YouthPrice = 80;
        private const int PensionerPrice = 90;
        private const int StandardPrice = 120;

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
                    case "1":
                        CalculateTicketPrice();
                        break;

                    case "2":
                        LoopAndPrint();
                        break;

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
            Console.WriteLine("Skriv en siffra och tryck Enter för att välja:");
            Console.WriteLine("1) Köp biljetter");
            Console.WriteLine("2) Upprepa tio gånger");
            Console.WriteLine("0) Avsluta");
            Console.WriteLine();
        }

        private static void CalculateTicketPrice()
        {
            Console.WriteLine();
            Console.WriteLine("— Ungdom eller pensionär / Sällskap (Biljettpris) —");

            var count = ReadInt("Ange hur många biljetter: ");

            if (count < 2)
            {
                var age = ReadInt("Ange ålder: ");
                var (_, output) = GetTicketPrice(age);

                Console.WriteLine(output);
            }
            else
            {
                var totalPrice = 0;
                var age = 0;

                Console.WriteLine($"\n== Ange åldrar för de {count} personerna nedan ==");

                for (int i = 1; i <= count; i++)
                {
                    age = ReadInt($"Ange ålder för person {i}: ");
                    var (price, output) = GetTicketPrice(age);
                    totalPrice += price;
                    Console.WriteLine(output);

                }
                Console.WriteLine($"Antalet personer: {count}");
                Console.WriteLine($"Totalkostnad: {totalPrice}kr\n");
            }
        }

        private static void LoopAndPrint()
        {
            Console.WriteLine();
            Console.WriteLine("— Upprepa tio gånger —");
            var input = ReadInput("Skriv en valfri text: ");
            for (int i = 1; i <= 10; i++)
            {
                if (i == 10)
                {
                    Console.Write($"{i}.{input}\n\n");
                }
                else
                {
                    Console.Write($"{i}.{input}, ");
                }
            }

        }


        // Helper Methods

        private static string ReadInput(string prompt)
        {
            Console.Write(prompt);
            return (Console.ReadLine() ?? string.Empty).Trim();
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                var s = ReadInput(prompt);
                if (int.TryParse(s, out var value))
                {
                    if (value > -1)
                    {
                        return value;
                    }
                }

                Console.WriteLine("Ange en giltigt nummer");
            }

        }

        private static (int price, string output) GetTicketPrice(int age)
        {
            if (age < 20)
            {
                return (YouthPrice, $"Ungdomspris: {YouthPrice}kr\n");
            }
            else if (age > 64)
            {
                return (PensionerPrice, $"Pensionärspris: {PensionerPrice}kr\n");
            }
            else
            {
                return (StandardPrice, $"Standardpris: {StandardPrice}kr\n");
            }
        }
    }
}
