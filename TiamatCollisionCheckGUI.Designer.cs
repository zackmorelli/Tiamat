namespace Tiamat
{
    partial class TiamatCollisionCheckGUI
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
            this.TCout = new System.Windows.Forms.TextBox();
            this.TCprogbar = new System.Windows.Forms.ProgressBar();
            this.CollOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TCout
            // 
            this.TCout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCout.Location = new System.Drawing.Point(12, 12);
            this.TCout.Multiline = true;
            this.TCout.Name = "TCout";
            this.TCout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TCout.Size = new System.Drawing.Size(362, 302);
            this.TCout.TabIndex = 0;
            // 
            // TCprogbar
            // 
            this.TCprogbar.Location = new System.Drawing.Point(12, 340);
            this.TCprogbar.Name = "TCprogbar";
            this.TCprogbar.Size = new System.Drawing.Size(776, 25);
            this.TCprogbar.TabIndex = 1;
            // 
            // CollOutput
            // 
            this.CollOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CollOutput.Location = new System.Drawing.Point(403, 12);
            this.CollOutput.Multiline = true;
            this.CollOutput.Name = "CollOutput";
            this.CollOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CollOutput.Size = new System.Drawing.Size(385, 302);
            this.CollOutput.TabIndex = 2;
            // 
            // TiamatCollisionCheckGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 377);
            this.Controls.Add(this.CollOutput);
            this.Controls.Add(this.TCprogbar);
            this.Controls.Add(this.TCout);
            this.Name = "TiamatCollisionCheckGUI";
            this.Text = "Tiamat - Fast Collision Check";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TCout;
        private System.Windows.Forms.ProgressBar TCprogbar;
        private System.Windows.Forms.TextBox CollOutput;
    }
}