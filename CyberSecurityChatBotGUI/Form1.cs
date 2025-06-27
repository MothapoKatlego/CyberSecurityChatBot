namespace CyberSecurityChatBotGUI
{
    public partial class Form1 : Form
    {
        ChatBot chatbot;

        public Form1()
        {
            InitializeComponent();
            // Removed chatbot initialization here to avoid overwriting user input
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Welcome message
            txtChatLog.SelectionColor = Color.RoyalBlue;
            txtChatLog.AppendText("Bot: Hi and welcome to the Cyber Safety ChatBot!\n");
            txtChatLog.SelectionColor = txtChatLog.ForeColor; // Reset

            // Ask for user's name
            string name = Microsoft.VisualBasic.Interaction.InputBox("What is your name?", "Welcome", "User");
            if (string.IsNullOrWhiteSpace(name))
                name = "User";

            txtChatLog.SelectionColor = Color.RoyalBlue;
            txtChatLog.AppendText($"Bot: Nice to meet you, {name}! 😊\n\n");
            txtChatLog.SelectionColor = txtChatLog.ForeColor;

            // Ask for area of interest (optional)
            string interest = Microsoft.VisualBasic.Interaction.InputBox("What cybersecurity topic are you most interested in?", "Your Interest", "cybersecurity");
            if (string.IsNullOrWhiteSpace(interest))
                interest = "cybersecurity";

            // Initialize the chatbot with user input
            chatbot = new ChatBot(name, interest);

            // Show the topic suggestions
            foreach (var line in chatbot.DisplayTopicSuggestions())
            {
                txtChatLog.SelectionColor = Color.RoyalBlue;
                txtChatLog.AppendText("Bot: " + line + "\n");
            }

            txtChatLog.AppendText("\n");
            txtChatLog.SelectionColor = txtChatLog.ForeColor;
            txtChatLog.SelectionStart = txtChatLog.Text.Length;
            txtChatLog.ScrollToCaret();

        }

        private void ShowMenu()
        {
            foreach (var line in chatbot.DisplayTopicSuggestions())
            {
                txtChatLog.SelectionColor = Color.RoyalBlue;
                txtChatLog.AppendText("Bot: " + line + "\n");
            }
            txtChatLog.AppendText("\n");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input)) return;

            // Show user input in green
            txtChatLog.SelectionColor = Color.Green;
            txtChatLog.AppendText("You: " + input + "\n");

            if (input.ToLower().Contains("menu"))
            {
                // Show menu again
                ShowMenu();
            }
            else
            {
                // Get bot replies
                var replies = chatbot.ProcessInput(input);

                // Show bot replies in royal blue
                txtChatLog.SelectionColor = Color.RoyalBlue;
                foreach (var reply in replies)
                {
                    txtChatLog.AppendText("Bot: " + reply + "\n");
                }
                txtChatLog.AppendText("\n");
            }

            // Reset color & scroll
            txtChatLog.SelectionColor = txtChatLog.ForeColor;
            txtChatLog.SelectionStart = txtChatLog.Text.Length;
            txtChatLog.ScrollToCaret();

            // Clear input and focus
            txtInput.Clear();
            txtInput.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)

        {
            txtChatLog.Clear();
            txtInput.Clear();
            txtInput.Focus();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
