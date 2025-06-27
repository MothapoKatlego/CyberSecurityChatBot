using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CyberSecurityChatBotGUI;

public class ChatBot
{
    private readonly string userName;
    private readonly string userInterest;
    private readonly Dictionary<string, List<string>> responses;
    private readonly Dictionary<string, string> followUpMap;
    private readonly Random rand;
    private bool waitingForFollowUp;
    private string followUpTopic;

    private List<CyberTask> tasks = new List<CyberTask>();
    private List<string> recentActions = new List<string>();
    private const int MaxLogSize = 10;

    private enum TaskInputState
    {
        None,
        AwaitingDescription,
        AwaitingReminderPrompt,
        AwaitingReminderTime
    }

    private TaskInputState currentTaskState = TaskInputState.None;
    private CyberTask tempTask;

    // Quiz variables
    private bool isQuizActive = false;
    private bool waitingForQuizAnswer = false;
    private int currentQuizIndex = 0;
    private int quizScore = 0;
    private List<QuizQuestion> quizQuestions = QuizData.GetQuestions(); // implement QuizData elsewhere

    public ChatBot(string userName, string userInterest)
    {
        this.userName = userName;
        this.userInterest = userInterest;
        this.rand = new Random();
        this.responses = ResponseManager.GetResponses(userName, userInterest);
        this.followUpMap = ResponseManager.GetFollowUpMap();
    }

    public List<string> ProcessInput(string input)
    {
        List<string> botReplies = new List<string>();
        input = input.Trim();

        // Cybersecurity Quiz Flow
        if (isQuizActive)
        {
            if (waitingForQuizAnswer)
            {
                string userAnswer = input.ToUpper();
                var question = quizQuestions[currentQuizIndex];

                if (userAnswer == question.Answer)
                {
                    quizScore++;
                    botReplies.Add("Correct.");
                }
                else
                {
                    botReplies.Add("Incorrect.");
                }

                botReplies.Add(question.Explanation);
                currentQuizIndex++;
                waitingForQuizAnswer = false;
            }

            if (currentQuizIndex < quizQuestions.Count)
            {
                var q = quizQuestions[currentQuizIndex];
                botReplies.Add($"Q{currentQuizIndex + 1}: {q.Question}");
                foreach (var option in q.Options)
                    botReplies.Add(option);

                botReplies.Add("Your answer (A, B... True, False):");
                waitingForQuizAnswer = true;
            }
            else
            {
                botReplies.Add($"Quiz complete. Your score: {quizScore}/{quizQuestions.Count}");
                if (quizScore >= 8)
                    botReplies.Add("Great job! You're a cybersecurity pro!");
                else if (quizScore >= 5)
                    botReplies.Add("Good effort! Keep learning to stay safer online.");
                else
                    botReplies.Add("You’ve got potential — let’s study more and stay protected!");

                SaveRecentAction($"Completed quiz with score {quizScore}/{quizQuestions.Count}");
                isQuizActive = false;
                quizScore = 0;
                currentQuizIndex = 0;
                waitingForQuizAnswer = false;
                botReplies.Add("What else would you like to do?");
            }

            return botReplies;
        }

        // NLP-style Commands
        if (input.ToLower() == "nlp" || input.ToLower() == "help nlp")
        {
            botReplies.Add("Natural Language Help:");
            botReplies.Add("Try saying things like:");
            botReplies.Add("- 'Remind me to update my password tomorrow'");
            botReplies.Add("- 'Add a task to enable two-factor authentication'");
            botReplies.Add("- 'Remind me to check my privacy settings in 3 days'");
            botReplies.Add("- 'Create task for checking phishing emails'");
            return botReplies;
        }

        if (Regex.IsMatch(input, @"remind me to (.+?) (in \d+ days|tomorrow)?", RegexOptions.IgnoreCase))
        {
            Match match = Regex.Match(input, @"remind me to (.+?) (in \d+ days|tomorrow)?", RegexOptions.IgnoreCase);
            string action = match.Groups[1].Value;
            string when = match.Groups[2].Value;

            DateTime? reminderDate = ParseReminder(when);
            var task = new CyberTask(action, "Auto-added reminder");

            if (reminderDate.HasValue)
                task.ReminderDate = reminderDate.Value;

            tasks.Add(task);
            SaveRecentAction($"Reminder set for '{action}' on {task.ReminderDate?.ToShortDateString() ?? "unspecified date"}.");
            botReplies.Add($"Reminder set for '{action}' on {task.ReminderDate?.ToShortDateString() ?? "unspecified date"}.");
            return botReplies;
        }

        if (Regex.IsMatch(input, @"add a task to (.+)", RegexOptions.IgnoreCase))
        {
            Match match = Regex.Match(input, @"add a task to (.+)", RegexOptions.IgnoreCase);
            string title = match.Groups[1].Value;
            var task = new CyberTask(title, "Auto-added task");

            tasks.Add(task);
            tempTask = task;
            currentTaskState = TaskInputState.AwaitingReminderPrompt;

            SaveRecentAction($"Task added: '{title}' (no reminder set)");
            botReplies.Add($"Task added: '{title}'. Would you like to set a reminder for this task?");
            return botReplies;
        }

        if (input.ToLower().Contains("start quiz") || input.ToLower().Contains("quiz me"))
        {
            botReplies.Add("Let's test your cybersecurity knowledge!");
            isQuizActive = true;
            currentQuizIndex = 0;
            quizScore = 0;
            waitingForQuizAnswer = false;
            SaveRecentAction("Quiz started.");
            return ProcessInput(""); // recursive to show first question
        }

        if (input.ToLower().Contains("what have you done for me") || input.ToLower().Contains("recent actions"))
        {
            if (recentActions.Count == 0)
            {
                botReplies.Add("I haven’t done anything for you yet.");
            }
            else
            {
                botReplies.Add("Here's a summary of recent actions:");
                for (int i = 0; i < Math.Min(10, recentActions.Count); i++)
                {
                    botReplies.Add($"{i + 1}. {recentActions[i]}");
                }
            }
            return botReplies;
        }

        // Task Input State Handling
        if (currentTaskState == TaskInputState.AwaitingDescription)
        {
            tempTask.Description = input;
            currentTaskState = TaskInputState.AwaitingReminderPrompt;
            botReplies.Add($"Task added with description: {tempTask.Description}");
            botReplies.Add("Would you like a reminder? (yes/no)");
            return botReplies;
        }

        if (currentTaskState == TaskInputState.AwaitingReminderPrompt)
        {
            if (input.Contains("yes"))
            {
                currentTaskState = TaskInputState.AwaitingReminderTime;
                botReplies.Add("When should I remind you? ('tomorrow', 'in 3 days')");
                return botReplies;
            }
            else if (input.Contains("no"))
            {
                tasks.Add(tempTask);
                SaveRecentAction($"Task saved: '{tempTask.Title}' (no reminder)");
                ResetTaskState();
                botReplies.Add("Task saved without a reminder.");
                return botReplies;
            }
            else
            {
                botReplies.Add("Please respond with 'yes' or 'no'.");
                return botReplies;
            }
        }

        if (currentTaskState == TaskInputState.AwaitingReminderTime)
        {
            DateTime? reminderDate = ParseReminder(input);
            if (reminderDate.HasValue)
            {
                tempTask.ReminderDate = reminderDate.Value;
                tasks.Add(tempTask);
                SaveRecentAction($"Task saved: '{tempTask.Title}' with reminder on {reminderDate.Value.ToShortDateString()}");
                ResetTaskState();
                botReplies.Add($"Reminder set for {reminderDate.Value.ToShortDateString()}.");
                return botReplies;
            }
            else
            {
                botReplies.Add("I couldn't understand the reminder time. Try again?");
                return botReplies;
            }
        }

        // Task Commands
        if (input.StartsWith("add task") || input.StartsWith("create task"))
        {
            string title = input.Replace("add task", "").Replace("create task", "").Trim();
            if (string.IsNullOrEmpty(title))
            {
                botReplies.Add("What's your task title? Try: add task finish homework");
                return botReplies;
            }

            tempTask = new CyberTask(title, "");
            currentTaskState = TaskInputState.AwaitingDescription;
            botReplies.Add($"Task title is '{title}'. Please enter a description.");
            return botReplies;
        }

        if (input.StartsWith("view tasks"))
        {
            if (tasks.Count == 0)
            {
                botReplies.Add("No tasks found.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    var task = tasks[i];
                    string status = task.IsCompleted ? "Done" : "Pending";
                    string reminder = task.ReminderDate.HasValue ? $" (Reminder: {task.ReminderDate.Value.ToShortDateString()})" : "";
                    botReplies.Add($"{i + 1}. {task.Title} - {status}{reminder}");
                    botReplies.Add($"   Description: {task.Description}");
                }
            }
            return botReplies;
        }

        if (input.StartsWith("mark task"))
        {
            int index = ExtractTaskNumber(input);
            if (IsValidTaskIndex(index))
            {
                tasks[index - 1].IsCompleted = true;
                SaveRecentAction($"Marked task {index} as completed.");
                botReplies.Add($"Marked task {index} as complete.");
            }
            else
            {
                botReplies.Add("Invalid task number.");
            }
            return botReplies;
        }

        if (input.StartsWith("delete task"))
        {
            int index = ExtractTaskNumber(input);
            if (IsValidTaskIndex(index))
            {
                string removed = tasks[index - 1].Title;
                tasks.RemoveAt(index - 1);
                SaveRecentAction($"Deleted task: {removed}");
                botReplies.Add($"Task {index} deleted.");
            }
            else
            {
                botReplies.Add("Invalid task number.");
            }
            return botReplies;
        }

        // Menu
        if (input == "menu")
        {
            botReplies.AddRange(DisplayTopicSuggestions());
            return botReplies;
        }

        // General & Emotion responses
        if (string.IsNullOrWhiteSpace(input))
        {
            botReplies.Add("You didn’t say anything. Try again?");
            return botReplies;
        }

        if (input.Contains("exit"))
        {
            botReplies.Add($"Goodbye, {userName}. Stay cyber safe!");
            return botReplies;
        }

        if (waitingForFollowUp)
        {
            if (input.Contains("yes"))
            {
                if (responses.ContainsKey(followUpTopic))
                    botReplies.Add(responses[followUpTopic][rand.Next(responses[followUpTopic].Count)]);
                else
                    botReplies.Add("I couldn't find more info, but let’s continue.");

                waitingForFollowUp = false;
                followUpTopic = "";
                botReplies.Add("What else would you like to know?");
                return botReplies;
            }

            if (input.Contains("no"))
            {
                waitingForFollowUp = false;
                followUpTopic = "";
                botReplies.Add("Okay! What else would you like to know?");
                return botReplies;
            }
        }

        if (input.Contains("stressed"))
            botReplies.Add("Feeling stressed is normal. Let's improve your cybersecurity confidence.");
        else if (input.Contains("angry"))
            botReplies.Add("Frustration is okay. I’m here to help.");
        else if (input.Contains("worried"))
            botReplies.Add("Don't worry, I’ve got your back.");
        else if (input.Contains("concerned"))
            botReplies.Add("Let’s clear up your concerns together.");

        // 📚 Topic Matching
        bool matched = false;
        foreach (var topic in responses.Keys)
        {
            if (input.ToLower().Contains(topic.ToLower()))
            {
                botReplies.Add(responses[topic][rand.Next(responses[topic].Count)]);
                matched = true;

                if (followUpMap.ContainsKey(topic))
                {
                    followUpTopic = followUpMap[topic];
                    waitingForFollowUp = true;
                    botReplies.Add($"Would you like to learn more about {followUpTopic.Replace("_", " ")}?");
                }

                break;
            }
        }

        if (!matched && botReplies.Count == 0)
        {
            botReplies.Add("I’m not sure I understand. Try rephrasing?");
        }

        return botReplies;
    }

    private void SaveRecentAction(string action)
    {
        string timestamp = DateTime.Now.ToString("g"); // e.g. 6/27/2025 10:25 PM
        recentActions.Insert(0, $"{timestamp}: {action}");

        if (recentActions.Count > MaxLogSize)
            recentActions.RemoveAt(recentActions.Count - 1);
    }


    private void ResetTaskState()
    {
        currentTaskState = TaskInputState.None;
        tempTask = null;
    }

    private DateTime? ParseReminder(string input)
    {
        if (input.ToLower().Contains("tomorrow"))
            return DateTime.Now.AddDays(1);

        Match match = Regex.Match(input, @"in (\d+) days", RegexOptions.IgnoreCase);
        if (match.Success && int.TryParse(match.Groups[1].Value, out int days))
            return DateTime.Now.AddDays(days);

        return null;
    }

    private int ExtractTaskNumber(string input)
    {
        var parts = input.Split(' ');
        foreach (var part in parts)
        {
            if (int.TryParse(part, out int num))
                return num;
        }
        return -1;
    }

    private bool IsValidTaskIndex(int num) => num > 0 && num <= tasks.Count;

    public List<string> DisplayTopicSuggestions()
    {
        return new List<string>
        {
            "You can ask me about cybersecurity topics like:",
            "- Password safety",
            "- Phishing",
            "- Safe browsing",
            "- 2FA",
            "- Public Wi-Fi",
            "- Dark web",
            "- Malware",
            "- VPN",
            "- Firewalls",
            "- Add user task",
            "- View user tasks",
            "- Start the Cyber Quiz",
            "- NLP"
        };
    }
}
