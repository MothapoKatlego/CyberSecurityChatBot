using System;
using System.Collections.Generic;

public class ChatBot
{
    private readonly string userName;
    private readonly string userInterest;
    private readonly Dictionary<string, List<string>> responses;
    private readonly Dictionary<string, string> followUpMap;
    private readonly Random rand;
    private bool waitingForFollowUp;
    private string followUpTopic;

    public ChatBot(string userName, string userInterest)
    {
        this.userName = userName;
        this.userInterest = userInterest;
        this.rand = new Random();
        this.responses = ResponseManager.GetResponses(userName, userInterest);
        
    }

    public void StartConversation()
    {
        DisplayTopicSuggestions();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("You: ");
            string input = Console.ReadLine().ToLower();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Bot: Hmm, it seems like you didn’t say anything. Try again?");
            }
            else if (input.Contains("exit"))
            {
                Console.WriteLine($"Bot: It was great chatting with you, {userName}! Stay alert and cyber safe.");
                Console.ResetColor();
                break;
            }
            else if (waitingForFollowUp)
            {
                HandleFollowUp(input);
            }
            else
            {
                // Integrated emotional + topic handling
                bool emotionalResponseGiven = false;

                if (input.Contains("concerned"))
                {
                    Console.WriteLine($"Bot: I understand that you're feeling concerned, {userName}. Let's try to ease that by exploring how you can stay protected.");
                    emotionalResponseGiven = true;
                }
                else if (input.Contains("worried"))
                {
                    Console.WriteLine($"Bot: It's okay to feel worried, {userName}. Cyber threats can be scary, but you're not alone — I'm here to help.");
                    emotionalResponseGiven = true;
                }
                else if (input.Contains("angry"))
                {
                    Console.WriteLine($"Bot: I hear your frustration, {userName}. Cybersecurity issues can be overwhelming, but let’s find a solution together.");
                    emotionalResponseGiven = true;
                }
                else if (input.Contains("stressed"))
                {
                    Console.WriteLine($"Bot: I get that you’re feeling stressed, {userName}. Taking control of your online safety can really help you feel more in control.");
                    emotionalResponseGiven = true;
                }

                // Check if the input matches any topic keywords
                bool matched = false;
                foreach (var topic in responses.Keys)
                {
                    if (input.Contains(topic))
                    {
                        var replies = responses[topic];
                        Console.WriteLine("Bot: " + replies[rand.Next(replies.Count)]);
                        matched = true;

                        // Optionally ask follow-up question if applicable
                        if (followUpMap.ContainsKey(topic))
                        {
                            followUpTopic = followUpMap[topic];
                            Console.WriteLine($"Bot: Good topic! Would you like to learn more about {followUpTopic.Replace('_', ' ')}?");
                            waitingForFollowUp = true;
                        }
                        break;
                    }
                }

                // If no emotion or topic matched, fallback prompt
                if (!emotionalResponseGiven && !matched)
                {
                    Console.WriteLine("Bot: I’m not sure I understand that. Could you rephrase or try another topic?");
                    DisplayTopicSuggestions();
                }
            }

            Console.ResetColor();
        }
    }

    private void DisplayTopicSuggestions()
    {
        Console.WriteLine($"\n{userName}, you can ask me things like:");

        if (userInterest.ToLower().Contains("password"))
        {
            Console.WriteLine($"Since you're interested in {userInterest}, you might want to explore topics like 'password safety' or '2FA'.");
        }
        else if (userInterest.ToLower().Contains("phishing"))
        {
            Console.WriteLine($"Since you're interested in {userInterest}, you might want to learn how to spot phishing emails or avoid social engineering scams.");
        }
        else if (userInterest.ToLower().Contains("vpn") || userInterest.ToLower().Contains("privacy"))
        {
            Console.WriteLine($"Since you're interested in {userInterest}, topics like 'VPN', 'safe browsing tips', and 'public Wi-Fi safety' might interest you.");
        }
        else if (userInterest.ToLower().Contains("malware") || userInterest.ToLower().Contains("security"))
        {
            Console.WriteLine($"Since you're interested in {userInterest}, try asking about 'malware', 'software updates', or 'firewalls'.");
        }
        else
        {
            Console.WriteLine($"Since you're interested in {userInterest}, feel free to ask any related questions to learn more.");
        }

        Console.WriteLine(@"
- What's your purpose?
- Tell me about password safety.
- How do I spot phishing?
- Safe browsing tips.
- What is 2FA?
- Should I trust public Wi-Fi?
- How do I protect my personal data?
- What is malware?
- What is a firewall?
- What is a VPN?
- How do I secure my phone?
- What is social engineering?
- Why should I update my software?
- What’s the dark web?
- Should I click on pop-up ads?
Type 'exit' to leave.
");
    }

    private void HandleFollowUp(string input)
    {
        if (input.Contains("yes"))
        {
            if (responses.ContainsKey(followUpTopic))
            {
                var replies = responses[followUpTopic];
                Console.WriteLine("Bot: " + replies[rand.Next(replies.Count)]);
            }
            else
            {
                Console.WriteLine("Bot: Hmm, I couldn’t find info on that. Let's go back to the main topics.");
            }

            waitingForFollowUp = false;
            followUpTopic = "";
        }
        else if (input.Contains("no"))
        {
            waitingForFollowUp = false;
            followUpTopic = "";
            DisplayTopicSuggestions();
        }
        else
        {
            Console.WriteLine("Bot: Just let me know with 'yes' or 'no'. 🙂");
        }
    }

    private void HandleMainInput(string input)
    {
        bool matched = false;

        foreach (var topic in responses.Keys)
        {
            if (input.Contains(topic))
            {
                var replies = responses[topic];
                Console.WriteLine("Bot: " + replies[rand.Next(replies.Count)]);
                matched = true;

                if (followUpMap.ContainsKey(topic))
                {
                    followUpTopic = followUpMap[topic];
                    Console.WriteLine($"Bot: Good topic! Would you like to learn more about {followUpTopic.Replace('_', ' ')}?");
                    waitingForFollowUp = true;
                }

                break;
            }
        }

        if (!matched)
        {
            Console.WriteLine("Bot: I’m not sure I understand that. Could you rephrase or try another topic?");
            DisplayTopicSuggestions();
        }
    }
}
