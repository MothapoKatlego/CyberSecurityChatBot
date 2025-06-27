using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityChatBotGUI
{
    public class CyberTask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }

        public CyberTask(string title, string description)
        {
            Title = title;
            Description = description;
            ReminderDate = null;
            IsCompleted = false;
        }
    }
}

