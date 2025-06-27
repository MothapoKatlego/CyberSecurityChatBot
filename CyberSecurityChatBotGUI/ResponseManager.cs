using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Generic;

public static class ResponseManager
{
    public static Dictionary<string, List<string>> GetResponses(string userName, string userInterest)
    {
        return new Dictionary<string, List<string>>
        {
            { "dark web", new List<string>
                {
                    $"The dark web is a hidden part of the internet not indexed by search engines. Be cautious if you explore it, {userName}.",
                    $"Accessing the dark web requires special software like Tor, {userName}. It’s often used for privacy but can also be dangerous.",
                    $"Stay away from illegal marketplaces on the dark web, {userName}. They pose serious risks, including malware and scams."
                }
            },
            { "vpn", new List<string>
                {
                    $"A VPN (Virtual Private Network) encrypts your internet connection, making your online activity more private, {userName}.",
                    $"When you're using public Wi-Fi, a VPN helps protect your data from being intercepted, {userName}.",
                    $"Always choose a trusted VPN provider, {userName}. Free VPNs might sell your data."
                }
            },
            { "phishing", new List<string>
                {
                    $"Phishing is a tactic where attackers trick you into revealing personal info through fake messages, {userName}.",
                    $"If an email seems urgent or suspicious, double-check the sender before clicking anything, {userName}.",
                    $"Avoid clicking links or downloading files from unknown sources, especially in unexpected emails, {userName}."
                }
            },
            { "password", new List<string>
                {
                    $"Use strong passwords with numbers, symbols, and upper/lowercase letters, {userName}.",
                    $"Avoid using the same password across different accounts, {userName}. Use a password manager instead.",
                    $"Never include personal info like your birthday in your passwords, {userName}."
                }
            },
            { "2fa", new List<string>
                {
                    $"Two-Factor Authentication (2FA) adds another layer of security, {userName}.",
                    $"Even if someone gets your password, 2FA can keep them out of your account, {userName}.",
                    $"You can set up 2FA using authenticator apps or text codes — it's easy and effective, {userName}."
                }
            },
            { "safe browsing", new List<string>
                {
                    $"Always look for HTTPS in the URL bar before entering any information, {userName}.",
                    $"Avoid downloading files from unfamiliar sites — they could be infected, {userName}.",
                    $"Use browsers that offer privacy features like tracking protection, {userName}."
                }
            },
            { "firewall", new List<string>
                {
                    $"A firewall acts like a gatekeeper between your device and the internet, {userName}.",
                    $"It helps block unauthorized access and malware, {userName}.",
                    $"Make sure your firewall is turned on in your system settings, {userName}."
                }
            },
            { "malware", new List<string>
                {
                    $"Malware is harmful software designed to steal data or damage your system, {userName}.",
                    $"To protect yourself, always keep your software updated and use antivirus tools, {userName}.",
                    $"Avoid clicking pop-ups or downloading unverified apps, {userName}."
                }
            },
            { "public wifi", new List<string>
                {
                    $"Public Wi-Fi is often unsecured. Avoid logging into sensitive accounts on it, {userName}.",
                    $"If you must use public Wi-Fi, always enable your VPN first, {userName}.",
                    $"Consider using your mobile hotspot instead of open public networks, {userName}."
                }
            },
            { "personal data", new List<string>
                {
                    $"Be cautious about what you share online — it can be used against you, {userName}.",
                    $"Check app permissions before giving access to your camera or contacts, {userName}.",
                    $"Use privacy settings on social media to limit who sees your info, {userName}."
                }
            },
            { "social engineering", new List<string>
                {
                    $"Social engineering is when people manipulate you into giving up information, {userName}.",
                    $"Always verify identities before handing over sensitive details, {userName}.",
                    $"Don't trust unsolicited phone calls or emails asking for credentials, {userName}."
                }
            },
            { "phone security", new List<string>
                {
                    $"Lock your phone with biometrics or a strong passcode, {userName}.",
                    $"Don’t install apps from unknown sources. Stick to trusted stores, {userName}.",
                    $"Enable auto-lock and disable unnecessary permissions for apps, {userName}."
                }
            },
            { "software updates", new List<string>
                {
                    $"Software updates fix bugs and vulnerabilities that hackers might exploit, {userName}.",
                    $"Always keep your operating system and apps up to date, {userName}.",
                    $"Enable auto-updates where possible so you don't forget, {userName}."
                }
            },
            { "pop-up ads", new List<string>
                {
                    $"Pop-ups may contain malware or trick you into fake offers, {userName}.",
                    $"Never click on pop-ups that look suspicious or too good to be true, {userName}.",
                    $"Use an ad blocker to avoid unsafe or annoying pop-ups, {userName}."
                }
            },
            { "purpose", new List<string>
                {
                    $"My purpose is to help you understand how to stay safe online and make smart cybersecurity choices, {userName}.",
                    $"I'm here to protect your digital journey and answer your safety questions, {userName}.",
                    $"Think of me as your friendly guide to surviving the online world, {userName}!"
                }
            },
            { "interest", new List<string>
                {
                    $"You're interested in {userInterest}, {userName}. That’s an important topic!",
                    $"You mentioned you're into {userInterest}, {userName}. Let’s dive into that!",
                    $"Great to see your interest in {userInterest}, {userName}. Ask me more about it anytime!"
                }
            }
        };
    }

    public static Dictionary<string, string> GetFollowUpMap()
    {
        return new Dictionary<string, string>
        {
            { "password", "2fa" },
            { "phishing", "personal data" },
            { "safe browsing", "vpn" },
            { "vpn", "public wifi" },
            { "public wifi", "vpn" },
            { "personal data", "social engineering" },
            { "malware", "firewall" },
            { "firewall", "vpn" },
            { "dark web", "phishing" },
            { "pop-up ads", "malware" },
            { "software updates", "malware" },
            { "phone security", "software updates" }
        };
    }
}
