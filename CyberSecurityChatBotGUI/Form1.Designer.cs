namespace CyberSecurityChatBotGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtChatLog = new RichTextBox();
            txtInput = new TextBox();
            btnSend = new Button();
            lblHeading = new Label();
            btnClear = new Button();
            btnQuit = new Button();
            SuspendLayout();
            // 
            // txtChatLog
            // 
            txtChatLog.Location = new Point(55, 73);
            txtChatLog.Name = "txtChatLog";
            txtChatLog.ReadOnly = true;
            txtChatLog.Size = new Size(674, 249);
            txtChatLog.TabIndex = 0;
            txtChatLog.Text = "";
            // 
            // txtInput
            // 
            txtInput.Location = new Point(55, 351);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(553, 23);
            txtInput.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(654, 350);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI Historic", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblHeading.Location = new Point(261, 20);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(259, 30);
            lblHeading.TabIndex = 3;
            lblHeading.Text = "CyberSecurity Chatbot GUI";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(177, 406);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(134, 23);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear Chat";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnQuit
            // 
            btnQuit.Location = new Point(441, 406);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(146, 23);
            btnQuit.TabIndex = 5;
            btnQuit.Text = "Quit Program";
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnQuit);
            Controls.Add(btnClear);
            Controls.Add(lblHeading);
            Controls.Add(btnSend);
            Controls.Add(txtInput);
            Controls.Add(txtChatLog);
            Name = "Form1";
            Text = "CyberSecurity AI Chatbot";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox txtChatLog;
        private TextBox txtInput;
        private Button btnSend;
        private Label lblHeading;
        private Button btnClear;
        private Button btnQuit;
    }
}
