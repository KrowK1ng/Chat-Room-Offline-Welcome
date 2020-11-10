namespace ClinkClinkGo
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.IPField = new System.Windows.Forms.TextBox();
            this.PortField = new System.Windows.Forms.TextBox();
            this.NameField = new System.Windows.Forms.TextBox();
            this.IPlabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.Thread1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(406, 167);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // IPField
            // 
            this.IPField.Location = new System.Drawing.Point(347, 89);
            this.IPField.Name = "IPField";
            this.IPField.Size = new System.Drawing.Size(182, 20);
            this.IPField.TabIndex = 1;
            // 
            // PortField
            // 
            this.PortField.Location = new System.Drawing.Point(347, 115);
            this.PortField.Name = "PortField";
            this.PortField.Size = new System.Drawing.Size(182, 20);
            this.PortField.TabIndex = 2;
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(347, 141);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(182, 20);
            this.NameField.TabIndex = 3;
            // 
            // IPlabel
            // 
            this.IPlabel.AutoSize = true;
            this.IPlabel.Location = new System.Drawing.Point(321, 92);
            this.IPlabel.Name = "IPlabel";
            this.IPlabel.Size = new System.Drawing.Size(20, 13);
            this.IPlabel.TabIndex = 4;
            this.IPlabel.Text = "IP:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(312, 118);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(29, 13);
            this.PortLabel.TabIndex = 5;
            this.PortLabel.Text = "Port:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(303, 144);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Name:";
            // 
            // Thread1
            // 
            this.Thread1.Enabled = true;
            this.Thread1.Tick += new System.EventHandler(this.Thread1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.IPlabel);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.PortField);
            this.Controls.Add(this.IPField);
            this.Controls.Add(this.ConnectButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox IPField;
        private System.Windows.Forms.TextBox PortField;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.Label IPlabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Timer Thread1;
    }
}

