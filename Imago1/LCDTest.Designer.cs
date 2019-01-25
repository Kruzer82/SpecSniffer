namespace Sniffer
{
    partial class LCDTest
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
            this.label_fadeTxt1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label_fadeTxt1
            // 
            this.label_fadeTxt1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_fadeTxt1.AutoSize = true;
            this.label_fadeTxt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_fadeTxt1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_fadeTxt1.Location = new System.Drawing.Point(110, 188);
            this.label_fadeTxt1.Name = "label_fadeTxt1";
            this.label_fadeTxt1.Size = new System.Drawing.Size(580, 74);
            this.label_fadeTxt1.TabIndex = 5;
            this.label_fadeTxt1.Text = "Press \"Esc\" or \"1\" to close.\r\n\"Space\" to change background color.";
            this.label_fadeTxt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 18;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LCDTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.label_fadeTxt1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LCDTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LCDTest_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_fadeTxt1;
        private System.Windows.Forms.Timer timer1;
    }
}