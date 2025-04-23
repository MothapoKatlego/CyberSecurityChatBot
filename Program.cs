namespace CyberSecurityChatBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] asciiArt = new string[]
{
    @"  ____        _               _                                _            _           ",
    @" / ___|  ___| |__   ___  ___| |_   _ __ ___  ___  ___  _ __ (_) ___  _ __ | | ___ _ __ ",
    @" \___ \ / __| '_ \ / _ \/ __| __| | '__/ _ \/ __|/ _ \| '_ \| |/ _ \| '_ \| |/ _ \ '__|",
    @"  ___) | (__| | | |  __/ (__| |_  | | |  __/\__ \ (_) | | | | | (_) | | | | |  __/ |   ",
    @" |____/ \___|_| |_|\___|\___|\__| |_|  \___||___/\___/|_| |_|_|\___/|_| |_|_|\___|_|   ",
    @"                                                                                      ",
    @"                    >>> South African Cybersecurity Awareness Bot <<<                 ",
    @"--------------------------------------------------------------------------------------"
};

            foreach (string line in asciiArt)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(line);
            }
            Console.ResetColor();


            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome, {name}! I'm your Cybersecurity Awareness Bot.");

            System.Threading.Thread.Sleep(500);

            void StartConversation(string name)
            {
                Console.WriteLine($"\n{name}, you can ask me things like:");
                Console.WriteLine("- What's your purpose?");
                Console.WriteLine("- Tell me about password safety.");
                Console.WriteLine("- How do I spot phishing?");
                Console.WriteLine("- Safe browsing tips.\n");

                while (true)
                {
                    Console.Write("You: ");
                    string input = Console.ReadLine().ToLower();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Bot: I didn't catch that. Try typing something?");
                    }
                    else if (input.Contains("purpose"))
                    {
                        Console.WriteLine("Bot: My purpose is to help you stay safe online by teaching cybersecurity tips.");
                    }
                    else if (input.Contains("password"))
                    {
                        Console.WriteLine("Bot: Use strong, unique passwords for each account. Consider using a password manager.");
                    }
                    else if (input.Contains("phishing"))
                    {
                        Console.WriteLine("Bot: Be cautious of unexpected emails or links. Check sender addresses and avoid clicking suspicious URLs.");
                    }
                    else if (input.Contains("browsing"))
                    {
                        Console.WriteLine("Bot: Always ensure you're using HTTPS websites and keep your browser updated.");
                    }
                    else if (input.Contains("exit"))
                    {
                        Console.WriteLine("Bot: Goodbye! Stay safe out there.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bot: Hmm, I didn't quite understand that. Could you rephrase?");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Welcome to CyberBot ===");
            Console.ResetColor();

            void TypeEffect(string message, int delay = 30)
            {
                foreach (char c in message)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(delay);
                }
                Console.WriteLine();
            }

        }
    }
}
