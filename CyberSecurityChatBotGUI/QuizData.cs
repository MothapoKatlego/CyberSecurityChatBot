using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

public static class QuizData
{
    public static List<QuizQuestion> GetQuestions()
    {
        return new List<QuizQuestion>
        {
            new QuizQuestion
            {
                Question = "What does 2FA stand for?",
                Options = new List<string> { "A. Two-Factor Authentication", "B. Two-Face Attack", "C. Fast Access", "D. Free Account" },
                Answer = "A",
                Explanation = "2FA stands for Two-Factor Authentication. It provides an extra layer of security by requiring two forms of verification."
            },
            new QuizQuestion
            {
                Question = "Which of these is a common sign of phishing?",
                Options = new List<string> { "A. Spelling errors in emails", "B. Emails from known contacts", "C. A secure website", "D. Antivirus warnings" },
                Answer = "A",
                Explanation = "Phishing emails often contain spelling or grammar mistakes and try to trick users into revealing personal information."
            },
            new QuizQuestion
            {
                Question = "Which password is strongest?",
                Options = new List<string> { "A. Password123", "B. Qwerty!", "C. Xy!8#Dk@29", "D. abcde" },
                Answer = "C",
                Explanation = "A strong password contains a mix of upper and lowercase letters, numbers, and special characters."
            },
            new QuizQuestion
            {
                Question = "What should you do when using public Wi-Fi?",
                Options = new List<string> { "A. Log into your bank account", "B. Use a VPN", "C. Share your hotspot", "D. Turn off your firewall" },
                Answer = "B",
                Explanation = "When using public Wi-Fi, using a VPN (Virtual Private Network) helps encrypt your connection and protects your data."
            },
            new QuizQuestion
            {
                Question = "What is malware?",
                Options = new List<string> { "A. A computer accessory", "B. A software license", "C. Malicious software", "D. Antivirus software" },
                Answer = "C",
                Explanation = "Malware stands for malicious software, which includes viruses, worms, trojans, and spyware."
            }
        };
    }
}
