namespace PLANCHECK
{
    partial class simpleGUI
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
            this.progbar = new System.Windows.Forms.ProgressBar();
            this.textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // progbar
            // 
            this.progbar.Location = new System.Drawing.Point(12, 103);
            this.progbar.Name = "progbar";
            this.progbar.Size = new System.Drawing.Size(460, 36);
            this.progbar.TabIndex = 0;
            this.progbar.Visible = true;
            // 
            // textbox
            // 
            this.textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox.Location = new System.Drawing.Point(12, 12);
            this.textbox.Multiline = true;
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(460, 68);
            this.textbox.TabIndex = 1;
            this.textbox.Text = "A plan check is currently running. A PDF report with the results of the performed" +
    " tests will appear in about 30 seconds.";
            // 
            // simpleGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 154);
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.progbar);
            this.Name = "simpleGUI";
            this.Text = "Plan Check";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progbar;
        private System.Windows.Forms.TextBox textbox;

    }
}