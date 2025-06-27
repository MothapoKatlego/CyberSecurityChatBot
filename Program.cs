using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;
using System;
using System.Media; // Required for SoundPlayer

class Program
{
    static void Main(string[] args)
    {
        string userName = "";
        string userInterest = "";

        try
        {
            SoundPlayer player = new SoundPlayer("p_44007391_519.wav");
            player.PlaySync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Audio load error: " + ex.Message);
        }

        DisplayBanner();

        Console.Write("Please enter your name: ");
        Console.ForegroundColor = ConsoleColor.Green;
        userName = Console.ReadLine();
        Console.ResetColor();

        Console.WriteLine($"\nWelcome, {userName}! I'm your Cybersecurity Awareness Bot.");
        Console.WriteLine("Before we begin, what topic in cybersecurity interests you most?");
        Console.ForegroundColor = ConsoleColor.Green;
        userInterest = Console.ReadLine();
        Console.ResetColor();

        Console.WriteLine($"Thanks, {userName}. I'll remember that you're interested in {userInterest}.\n");
        ChatBot bot = new ChatBot(userName, userInterest);
        bot.StartConversation();
    }

    static void DisplayBanner()
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

        Console.ForegroundColor = ConsoleColor.Cyan;
        foreach (string line in asciiArt)
        {
            Console.WriteLine(line);
        }
        Console.ResetColor();
    }
}
