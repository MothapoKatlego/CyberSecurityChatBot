using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;

public class ResponseManager
{
    public static Dictionary<string, List<string>> GetResponses(string userName, string userInterest)
    {
        return new Dictionary<string, List<string>>()
        {
            ["purpose"] = new List<string> { $"My purpose is to help you stay safe online, {userName}." },
            ["password"] = new List<string>
                {
                    $"Use long, complex passwords. Avoid birthdays and common words, {userName}.",
                    $"Use a password manager to keep track securely, {userName}.",
                    $"Don't reuse passwords across sites, {userName}."
                },
            ["phishing"] = new List<string>
                {
                    $"Phishing tricks you into giving personal info. Always verify senders, {userName}.",
                    $"Avoid clicking on links from unknown sources, {userName}.",
                    $"Watch out for urgent language and fake logos, {userName}."
                },
            ["vpn"] = new List<string>
                {
                    $"A VPN hides your IP and encrypts your data, {userName}.",
                    $"Use a VPN on public Wi-Fi for safety, {userName}.",
                    $"Choose a reliable paid VPN for best protection, {userName}."
                },
            ["browsing"] = new List<string>
                {
                    $"Always use HTTPS websites, {userName}.",
                    $"Avoid suspicious downloads or pop-ups, {userName}.",
                    $"Consider a private browser like Brave or DuckDuckGo, {userName}."
                },
            ["2fa"] = new List<string>
                {
                    $"2FA adds another step after password login. Use it, {userName}.",
                    $"Apps like Google Authenticator make 2FA easy, {userName}.",
                    $"It protects your account even if your password is leaked, {userName}."
                },
            ["malware"] = new List<string>
                {
                    $"Malware harms your system or steals data. Avoid unknown downloads, {userName}.",
                    $"Use antivirus software and keep it updated, {userName}.",
                    $"Patch vulnerabilities by updating your software often, {userName}."
                },
            ["firewall"] = new List<string>
                {
                    $"A firewall blocks dangerous network traffic, {userName}.",
                    $"Use it to protect both your PC and network router, {userName}."
                },
            ["public wifi"] = new List<string>
                {
                    $"Avoid logging into banking apps on public Wi-Fi, {userName}.",
                    $"Use a VPN when connected to public hotspots, {userName}."
                },
            ["phone security"] = new List<string>
                {
                    $"Use biometrics or a PIN to lock your phone, {userName}.",
                    $"Avoid downloading apps from outside the official app store, {userName}."
                },
            ["social engineering"] = new List<string>
                {
                    $"It's when people trick you into giving info. Always verify before sharing, {userName}.",
                    $"If something feels urgent or off — pause and think, {userName}."
                },
            ["software"] = new List<string>
                {
                    $"Keep your apps updated to fix security holes, {userName}.",
                    $"Enable auto-updates to stay protected, {userName}."
                },
            ["dark web"] = new List<string>
                {
                    $"The dark web isn't safe. Avoid it, {userName}.",
                    $"It’s full of illegal activity and malware, {userName}."
                },
            ["pop-up ads"] = new List<string>
                {
                    $"Never click on pop-ups. Use an ad blocker, {userName}.",
                    $"Most pop-ups are phishing or malware traps, {userName}."
                },
            ["topic"] = new List<string>
                {
                    $"You mentioned you're interested in {userInterest}, {userName}. Feel free to ask more!"
                }
        };
    }

    public static Dictionary<string, string> GetFollowUpMap()
    {
        return new Dictionary<string, string>
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
    }
}

