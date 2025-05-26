using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace CyberSecurityChatBot
{
    internal class Program
    {
        static string userName = "";
        static string userInterest = "";
        static Random rand = new Random();

        static void Main(string[] args)
        {
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

            StartConversation();
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

        static void StartConversation()
        {
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

               
                Console.WriteLine("\n- What's your purpose?");
                Console.WriteLine("- Tell me about password safety.");
                Console.WriteLine("- How do I spot phishing?");
                Console.WriteLine("- Safe browsing tips.");
                Console.WriteLine("- What is 2FA?");
                Console.WriteLine("- Should I trust public Wi-Fi?");
                Console.WriteLine("- How do I protect my personal data?");
                Console.WriteLine("- What is malware?");
                Console.WriteLine("- What is a firewall?");
                Console.WriteLine("- What is a VPN?");
                Console.WriteLine("- How do I secure my phone?");
                Console.WriteLine("- What is social engineering?");
                Console.WriteLine("- Why should I update my software?");
                Console.WriteLine("- What’s the dark web?");
                Console.WriteLine("- Should I click on pop-up ads?");
                Console.WriteLine("Type 'exit' to leave.\n");

                Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>()
            {
                ["purpose"] = new List<string>
    {
        $"My purpose is to give you all the informations that you need to ensure that you are safe from the internet, {userName}"
    },
                ["password"] = new List<string>
    {
        $"A strong password keeps hackers out. Make it long, complex, and unique, {userName}.",
        $"Don’t reuse passwords! Mix symbols, numbers, and upper/lowercase letters. Or better yet — use a manager, {userName}.",
        $"Avoid things like your birthday or pet’s name, {userName}. Hackers love predictable patterns."
    },
                ["phishing"] = new List<string>
    {
        $"Phishing is when cybercriminals pretend to be trusted entities to steal your personal information. Always verify the source before clicking links, {userName}.",
        $"Never give personal details over email or text unless you're sure the request is legitimate, {userName}.",
        $"Look out for suspicious signs like urgent language, unfamiliar senders, and unexpected attachments or links, {userName}."
    },
                ["browsing"] = new List<string>
    {
        $"Always use HTTPS websites when browsing. It ensures your data is encrypted, {userName}.",
        $"Avoid visiting sketchy websites. They could be designed to steal your data or infect your device, {userName}.",
        $"Consider using a privacy-focused browser or a secure search engine like DuckDuckGo, {userName}."
    },
                ["2fa"] = new List<string>
    {
        $"Two-Factor Authentication (2FA) adds an extra layer of security. Even if someone gets your password, they can't access your account without the second factor, {userName}.",
        $"Enable 2FA wherever possible, {userName}. It’s one of the best ways to protect your accounts from unauthorized access.",
        $"You can use an app like Google Authenticator or your phone’s text message to receive 2FA codes, {userName}."
    },
                ["public wifi"] = new List<string>
    {
        $"Public Wi-Fi is convenient, but it’s also risky. Avoid accessing sensitive accounts like banking when on public Wi-Fi, {userName}.",
        $"Use a VPN to encrypt your connection when connecting to public Wi-Fi, {userName}. It helps protect your data from hackers.",
        $"If you must use public Wi-Fi, avoid logging into accounts or sending sensitive information, {userName}."
    },
                ["personal data"] = new List<string>
    {
        $"Be mindful of the data you share online. The more personal information you expose, the more vulnerable you are, {userName}.",
        $"Limit what you share on social media. Even simple information like your job title can be used against you in social engineering attacks, {userName}.",
        $"Always check app permissions before granting access to your camera, contacts, or location, {userName}."
    },
                ["malware"] = new List<string>
    {
        $"Malware is malicious software that can damage or disrupt your device. Always install updates to patch vulnerabilities, {userName}.",
        $"Be cautious when downloading files from unknown sources. Malware is often disguised as legitimate software, {userName}.",
        $"Use antivirus software to protect your device from malware, and avoid clicking on suspicious links or attachments, {userName}."
    },
                ["firewall"] = new List<string>
    {
        $"A firewall helps protect your device from unauthorized access and malicious attacks by blocking unwanted traffic, {userName}.",
        $"Ensure your firewall is enabled and properly configured to protect your home network, {userName}.",
        $"Using a firewall, both on your device and router, is a key step in securing your internet connection, {userName}."
    },
                ["vpn"] = new List<string>
    {
        $"A VPN (Virtual Private Network) encrypts your internet connection, making it harder for hackers to intercept your data, {userName}.",
        $"When using public Wi-Fi or browsing anonymously, a VPN helps protect your privacy by masking your IP address, {userName}.",
        $"Choose a reputable VPN service to ensure your data is secure. Free VPNs can compromise your privacy, {userName}."
    },
                ["phone security"] = new List<string>
    {
        $"Enable a screen lock or biometric authentication to secure your phone, {userName}. It’s a simple but effective way to prevent unauthorized access.",
        $"Install updates regularly to keep your phone’s software secure, {userName}. Attackers often target known vulnerabilities.",
        $"Be cautious when downloading apps from unknown sources. Stick to trusted app stores, {userName}."
    },
                ["social engineering"] = new List<string>
    {
        $"Social engineering involves manipulating people into divulging confidential information. Always verify identities before sharing anything sensitive, {userName}.",
        $"Scammers often use tactics like urgency, authority, or fear to trick you. Stay calm and cautious, {userName}.",
        $"Be suspicious of unsolicited emails or phone calls asking for personal information or payment, {userName}."
    },
                ["software"] = new List<string>
    {
        $"Always update your software as soon as updates are available, {userName}. Updates patch vulnerabilities and improve security.",
        $"Many cyberattacks target outdated software. Regular updates help protect you from the latest threats, {userName}.",
        $"Enable automatic updates where possible to ensure your system is always up to date, {userName}."
    },
                ["dark web"] = new List<string>
    {
        $"The dark web is a part of the internet that's not indexed by search engines and often used for illegal activities. Avoid it, {userName}.",
        $"Stay safe by not visiting dark web sites. They can expose you to risks like fraud, malware, and identity theft, {userName}.",
        $"If you're curious about the dark web, remember it's a dangerous place. Protect your personal information at all costs, {userName}."
    },
                ["pop-up ads"] = new List<string>
    {
        $"Pop-up ads are often used by scammers to spread malware or trick you into revealing personal details. Always avoid clicking them, {userName}.",
        $"Use an ad blocker to prevent pop-up ads from appearing, {userName}. It can improve your browsing experience and security.",
        $"Never enter personal information in a pop-up window, especially if it looks suspicious, {userName}."
    },
                ["topic"] = new List<string>
    {
        $"You are interested in {userInterest} like you have mentioned. I remembered that."
    }


            };
            string followUpTopic = "";
            bool waitingForFollowUp = false;

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
                        Console.WriteLine($"\n{userName}, you can ask me things like:");
                        Console.WriteLine("- What's your purpose?");
                        Console.WriteLine("- Tell me about password safety.");
                        Console.WriteLine("- How do I spot phishing?");
                        Console.WriteLine("- Safe browsing tips.");
                        Console.WriteLine("- What is 2FA?");
                        Console.WriteLine("- Should I trust public Wi-Fi?");
                        Console.WriteLine("- How do I protect my personal data?");
                        Console.WriteLine("- What is malware?");
                        Console.WriteLine("- What is a firewall?");
                        Console.WriteLine("- What is a VPN?");
                        Console.WriteLine("- How do I secure my phone?");
                        Console.WriteLine("- What is social engineering?");
                        Console.WriteLine("- Why should I update my software?");
                        Console.WriteLine("- What’s the dark web?");
                        Console.WriteLine("- Should I click on pop-up ads?");
                        Console.WriteLine("Type 'exit' to leave.\n");
                    }
                    else
                    {
                        Console.WriteLine("Bot: Just let me know with 'yes' or 'no'. 🙂");
                    }
                }
                else
                {
                    bool matched = false;
                    foreach (var topic in responses.Keys)
                    {
                        if (input.Contains(topic))
                        {
                            var replies = responses[topic];
                            Console.WriteLine("Bot: " + replies[rand.Next(replies.Count)]);
                            matched = true;

                            // Generate a follow-up topic
                            Dictionary<string, string> followUpMap = new Dictionary<string, string>
                {
                    { "password", "2fa" },
                    { "phishing", "personal data" },
                    { "browsing", "vpn" },
                    { "2fa", "password" },
                    { "public wifi", "vpn" },
                    { "personal data", "social engineering" },
                    { "malware", "firewall" },
                    { "firewall", "vpn" },
                    { "vpn", "browsing" },
                    { "phone security", "software updates" },
                    { "social engineering", "phishing" },
                    { "software updates", "malware" },
                    { "dark web", "phishing" },
                    { "pop-up ads", "malware" }
                };

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
                        Console.WriteLine($" you can ask me things like:");
                        Console.WriteLine("- What's your purpose?");
                        Console.WriteLine("- Tell me about password safety.");
                        Console.WriteLine("- How do I spot phishing?");
                        Console.WriteLine("- Safe browsing tips.");
                        Console.WriteLine("- What is 2FA?");
                        Console.WriteLine("- Should I trust public Wi-Fi?");
                        Console.WriteLine("- How do I protect my personal data?");
                        Console.WriteLine("- What is malware?");
                        Console.WriteLine("- What is a firewall?");
                        Console.WriteLine("- What is a VPN?");
                        Console.WriteLine("- How do I secure my phone?");
                        Console.WriteLine("- What is social engineering?");
                        Console.WriteLine("- Why should I update my software?");
                        Console.WriteLine("- What’s the dark web?");
                        Console.WriteLine("- Should I click on pop-up ads?");
                        Console.WriteLine("Type 'exit' to leave.\n");
                    }
                }
                

                Console.ResetColor();
            }
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
                else
                {
                    // Emotional context handling
                    if (input.Contains("concerned"))
                    {
                        Console.WriteLine($"Bot: I understand that you're feeling concerned, {userName}. Let's try to ease that by exploring how you can stay protected.");
                    }
                    else if (input.Contains("worried"))
                    {
                        Console.WriteLine($"Bot: It's okay to feel worried, {userName}. Cyber threats can be scary, but you're not alone — I'm here to help.");
                    }
                    else if (input.Contains("angry"))
                    {
                        Console.WriteLine($"Bot: I hear your frustration, {userName}. Cybersecurity issues can be overwhelming, but let’s find a solution together.");
                    }
                    else if (input.Contains("stressed"))
                    {
                        Console.WriteLine($"Bot: I get that you’re feeling stressed, {userName}. Taking control of your online safety can really help you feel more in control.");
                    }

                    bool matched = false;
                    foreach (var topic in responses.Keys)
                    {
                        if (input.Contains(topic))
                        {
                            var replies = responses[topic];
                            Console.WriteLine("Bot: " + replies[rand.Next(replies.Count)]);
                            matched = true;
                            break;
                        }
                    }

                    if (!matched)
                    {
                        Console.WriteLine("Bot: I’m not sure I understand that. Could you rephrase or try another topic?");
                        Console.WriteLine($" you can ask me things like:");
                        Console.WriteLine("- What's your purpose?");
                        Console.WriteLine("- Tell me about password safety.");
                        Console.WriteLine("- How do I spot phishing?");
                        Console.WriteLine("- Safe browsing tips.");
                        Console.WriteLine("- What is 2FA?");
                        Console.WriteLine("- Should I trust public Wi-Fi?");
                        Console.WriteLine("- How do I protect my personal data?");
                        Console.WriteLine("- What is malware?");
                        Console.WriteLine("- What is a firewall?");
                        Console.WriteLine("- What is a VPN?");
                        Console.WriteLine("- How do I secure my phone?");
                        Console.WriteLine("- What is social engineering?");
                        Console.WriteLine("- Why should I update my software?");
                        Console.WriteLine("- What’s the dark web?");
                        Console.WriteLine("- Should I click on pop-up ads?");
                        Console.WriteLine("Type 'exit' to leave.\n");
                    }
                }
                }

                Console.ResetColor();
            }
        }
    }
    }
    

