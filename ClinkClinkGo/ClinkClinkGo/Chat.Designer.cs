namespace ClinkClinkGo
{
    partial class Chat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MessageTB = new System.Windows.Forms.TextBox();
            this.ChatTB = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MessageTB
            // 
            this.MessageTB.Location = new System.Drawing.Point(12, 418);
            this.MessageTB.Name = "MessageTB";
            this.MessageTB.Size = new System.Drawing.Size(699, 20);
            this.MessageTB.TabIndex = 0;
            this.MessageTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MessageTB_KeyPress);
            // 
            // ChatTB
            // 
            this.ChatTB.Location = new System.Drawing.Point(12, 12);
            this.ChatTB.Multiline = true;
            this.ChatTB.Name = "ChatTB";
            this.ChatTB.ReadOnly = true;
            this.ChatTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatTB.Size = new System.Drawing.Size(776, 400);
            this.ChatTB.TabIndex = 1;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(717, 415);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(71, 23);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SendButton_MouseClick);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ChatTB);
            this.Controls.Add(this.MessageTB);
            this.Name = "Chat";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_FormClosing);
            this.Load += new System.EventHandler(this.Chat_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Chat_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageTB;
        private System.Windows.Forms.TextBox ChatTB;
        private System.Windows.Forms.Button SendButton;
    }
}