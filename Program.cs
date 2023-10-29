namespace BankSistem
{
    internal class Program
    {
        static List<BankCardAndAproove> bankCards = new List<BankCardAndAproove>();
        static string databaseFile = "bankcards.txt";//sukurtas naujas tekstinis sarasas kaip 

        internal static void LoadData() // suranda visa informacija faile, bei tikrina ar yra toks failas
        {
            if (File.Exists(databaseFile))
            {
                string[] lines = File.ReadAllLines(databaseFile);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');// kiekvinas atskiras useris turi savo eilute, tam tikra info atskitras kableliu kad lengviau atskirti info ir atpavinta pagal index
                    if (parts.Length == 3)
                    {

                        string cardNumber = parts[0];
                        string password = parts[1];
                        double balance = double.Parse(parts[2]);


                        BankCardAndAproove card = new BankCardAndAproove(cardNumber, password, balance);
                        bankCards.Add(card);
                    }
                }
            }
        }

        static void SaveData()// issaugo info
        {
            using (StreamWriter writer = new StreamWriter(databaseFile))
            {
                foreach (BankCardAndAproove card in bankCards)
                {
                    writer.WriteLine($"{card.CardNumber},{card.Password},{card.Balance},{card.History}");
                }
            }
        }
        internal static void ShowBalance(BankCardAndAproove card)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Balansas: {card.Balance:C}");
            Console.WriteLine("\nSpauskite Enter, kad griztumrte  meniu.");
            Console.ReadLine();
        }
        internal static void BalanceHistory(BankCardAndAproove card)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            if (history.Count == 0)
            {
                Console.WriteLine("Nėra paskutinių tranzakcijų.");
            }
        }

        internal static void MenueOfChoice(BankCardAndAproove card)
        {
            Console.Clear();
            Console.WriteLine("Malonu kad sugrizote");
            Thread.Sleep(3000);
            bool choosing = true;
            do
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Prasome pasirinkti viena is operaciju. Aciu.");
                Console.WriteLine("1. Jusu esamas balansas");
                Console.WriteLine("2. Paskutines 5 tranzakcijos");
                Console.WriteLine("3. Pinigų išsiėmimas");
                Console.WriteLine("4. Iseiti is sistemos");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowBalance(card);
                        break;
                    case "2":

                    case "3":

                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Aciu, kad psirinkote mus ir Geros Jums Dienos");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas. Pasirinkite dar kartą.");
                        break;
                }
            }
            while (choosing);
        }

        internal static string FindCard(string input)
        {
            bool cardFound = false;

            foreach (var card in bankCards)
            {
                if (input == card.CardNumber)
                {
                    Aproove(card);
                    cardFound = true;
                    Thread.Sleep(3000);
                    return "Sveiki, Malonu ir jus matyti!";
                }
            }
            Thread.Sleep(3000);
            return $"Tokia kortele neegzistoja";

        }
        internal static void Aproove(BankCardAndAproove card)
        {
            int maxTries = 3;
            int numberOfTries = 0;


            while (numberOfTries < maxTries)
            {
                Console.WriteLine("Įveskite PIN kodą:");
                string enteredPin = Console.ReadLine(); // pin kodo ivestis cia nes kitaip luzta progma ir ne duoda ivesti pakartotinai pin kodo ir uzsidaro

                if (enteredPin == card.Password) // teisingai ivedus pin koda pamatom trumpam balansa ir ieinam i menu
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"PIN kodas teisingas.\n Balansas: {card.Balance:C}");
                    Thread.Sleep(3000);
                    MenueOfChoice(card);

                }
                else
                {
                    numberOfTries++;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Neteisingas PIN kodas.\n Liko bandymų: {maxTries - numberOfTries}"); // pin kodo ivesties bandymu likutis
                }
            }

            if (numberOfTries >= maxTries)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pasibaigė bandymai. Kortelė užblokuota.");
                Thread.Sleep(3000);

            }
        }


        static void Main(string[] args)
        {
            LoadData();
            Console.WriteLine("Laba diena Sveiki Atvyke i musu BANKA");
            Console.WriteLine("Prasom ivesti Jusu korteles numeri");
            string input = FindCard(Console.ReadLine());


        }
    }
}
