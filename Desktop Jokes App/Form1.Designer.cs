namespace Desktop_Jokes_App
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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeJokeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.changeJokeNow = new System.Windows.Forms.Timer(this.components);
            this.changeIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalTime = new System.Windows.Forms.ToolStripTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeJokeToolStripMenuItem,
            this.changeIntervalToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 92);
            // 
            // changeJokeToolStripMenuItem
            // 
            this.changeJokeToolStripMenuItem.Name = "changeJokeToolStripMenuItem";
            this.changeJokeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.changeJokeToolStripMenuItem.Text = "Change joke...";
            this.changeJokeToolStripMenuItem.Click += new System.EventHandler(this.changeJokeToolStripMenuItem_Click_1);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // changeJokeNow
            // 
            this.changeJokeNow.Interval = 600000;
            this.changeJokeNow.Tick += new System.EventHandler(this.changeJokeNow_Tick);
            // 
            // changeIntervalToolStripMenuItem
            // 
            this.changeIntervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intervalTime});
            this.changeIntervalToolStripMenuItem.Name = "changeIntervalToolStripMenuItem";
            this.changeIntervalToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.changeIntervalToolStripMenuItem.Text = "Change interval...";
            // 
            // intervalTime
            // 
            this.intervalTime.Name = "intervalTime";
            this.intervalTime.Size = new System.Drawing.Size(100, 23);
            this.intervalTime.Text = "600000";
            this.intervalTime.TextChanged += new System.EventHandler(this.intervalTime_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 148);
            this.Name = "Form1";
            this.Text = "Desktop Jokes v1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changeJokeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer changeJokeNow;
        private System.Windows.Forms.ToolStripMenuItem changeIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox intervalTime;
    }
}

