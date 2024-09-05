namespace Tiamat
{
    partial class InitialTiamatGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialTiamatGUI));
            this.LateralityBox = new System.Windows.Forms.ListBox();
            this.LateralityLabel = new System.Windows.Forms.Label();
            this.TreatSiteLabel = new System.Windows.Forms.Label();
            this.TreatSiteBox = new System.Windows.Forms.ListBox();
            this.TreatTechLabel = new System.Windows.Forms.Label();
            this.TreatTechBox = new System.Windows.Forms.ListBox();
            this.RapidCBox = new System.Windows.Forms.CheckBox();
            this.OptimizeCBox = new System.Windows.Forms.CheckBox();
            this.TradeOffCBox = new System.Windows.Forms.CheckBox();
            this.ExBut = new System.Windows.Forms.Button();
            this.LinacLabel = new System.Windows.Forms.Label();
            this.LinacBox = new System.Windows.Forms.ListBox();
            this.DoseCalcCBox = new System.Windows.Forms.CheckBox();
            this.AlgoCBox = new System.Windows.Forms.CheckBox();
            this.SetupBeamsCBox = new System.Windows.Forms.CheckBox();
            this.BootPanel = new System.Windows.Forms.Panel();
            this.OptObjLabel = new System.Windows.Forms.Label();
            this.OptObjBox = new System.Windows.Forms.ListBox();
            this.RunningPanel = new System.Windows.Forms.Panel();
            this.ProgBar = new System.Windows.Forms.ProgressBar();
            this.OutBox = new System.Windows.Forms.TextBox();
            this.ProgRun = new System.Windows.Forms.Label();
            this.BootPanel.SuspendLayout();
            this.RunningPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LateralityBox
            // 
            this.LateralityBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LateralityBox.FormattingEnabled = true;
            this.LateralityBox.ItemHeight = 20;
            this.LateralityBox.Items.AddRange(new object[] {
            "NA"});
            this.LateralityBox.Location = new System.Drawing.Point(275, 183);
            this.LateralityBox.Name = "LateralityBox";
            this.LateralityBox.Size = new System.Drawing.Size(93, 64);
            this.LateralityBox.TabIndex = 0;
            // 
            // LateralityLabel
            // 
            this.LateralityLabel.AutoSize = true;
            this.LateralityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LateralityLabel.Location = new System.Drawing.Point(271, 156);
            this.LateralityLabel.Name = "LateralityLabel";
            this.LateralityLabel.Size = new System.Drawing.Size(82, 24);
            this.LateralityLabel.TabIndex = 1;
            this.LateralityLabel.Text = "Laterality";
            // 
            // TreatSiteLabel
            // 
            this.TreatSiteLabel.AutoSize = true;
            this.TreatSiteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreatSiteLabel.Location = new System.Drawing.Point(10, 7);
            this.TreatSiteLabel.Name = "TreatSiteLabel";
            this.TreatSiteLabel.Size = new System.Drawing.Size(131, 24);
            this.TreatSiteLabel.TabIndex = 2;
            this.TreatSiteLabel.Text = "Treatment Site";
            // 
            // TreatSiteBox
            // 
            this.TreatSiteBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreatSiteBox.FormattingEnabled = true;
            this.TreatSiteBox.ItemHeight = 20;
            this.TreatSiteBox.Items.AddRange(new object[] {
            "NA",
            "Abdomen",
            "Head & Neck",
            "Lung"
            });
            this.TreatSiteBox.Location = new System.Drawing.Point(10, 34);
            this.TreatSiteBox.Name = "TreatSiteBox";
            this.TreatSiteBox.Size = new System.Drawing.Size(242, 324);
            this.TreatSiteBox.TabIndex = 3;
            this.TreatSiteBox.SelectedValueChanged += new System.EventHandler(this.TreatSiteSelect);
            // 
            // TreatTechLabel
            // 
            this.TreatTechLabel.AutoSize = true;
            this.TreatTechLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreatTechLabel.Location = new System.Drawing.Point(271, 7);
            this.TreatTechLabel.Name = "TreatTechLabel";
            this.TreatTechLabel.Size = new System.Drawing.Size(192, 24);
            this.TreatTechLabel.TabIndex = 4;
            this.TreatTechLabel.Text = "Treatment Technique";
            // 
            // TreatTechBox
            // 
            this.TreatTechBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreatTechBox.FormattingEnabled = true;
            this.TreatTechBox.ItemHeight = 20;
            this.TreatTechBox.Items.AddRange(new object[] {
            "NA"});
            this.TreatTechBox.Location = new System.Drawing.Point(275, 36);
            this.TreatTechBox.Name = "TreatTechBox";
            this.TreatTechBox.Size = new System.Drawing.Size(188, 84);
            this.TreatTechBox.TabIndex = 5;
            // 
            // RapidCBox
            // 
            this.RapidCBox.AutoSize = true;
            this.RapidCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RapidCBox.Location = new System.Drawing.Point(645, 217);
            this.RapidCBox.Name = "RapidCBox";
            this.RapidCBox.Size = new System.Drawing.Size(116, 24);
            this.RapidCBox.TabIndex = 7;
            this.RapidCBox.Text = "Rapidplan ?";
            this.RapidCBox.UseVisualStyleBackColor = true;
            this.RapidCBox.Visible = false;
            // 
            // OptimizeCBox
            // 
            this.OptimizeCBox.AutoSize = true;
            this.OptimizeCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptimizeCBox.Location = new System.Drawing.Point(618, 183);
            this.OptimizeCBox.Name = "OptimizeCBox";
            this.OptimizeCBox.Size = new System.Drawing.Size(118, 28);
            this.OptimizeCBox.TabIndex = 8;
            this.OptimizeCBox.Text = "Optimize ?";
            this.OptimizeCBox.UseVisualStyleBackColor = true;
            this.OptimizeCBox.CheckedChanged += new System.EventHandler(this.OptimizeCheckChange);
            // 
            // TradeOffCBox
            // 
            this.TradeOffCBox.AutoSize = true;
            this.TradeOffCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TradeOffCBox.Location = new System.Drawing.Point(543, 294);
            this.TradeOffCBox.Name = "TradeOffCBox";
            this.TradeOffCBox.Size = new System.Drawing.Size(218, 28);
            this.TradeOffCBox.TabIndex = 10;
            this.TradeOffCBox.Text = "Trade-Off Exploration?";
            this.TradeOffCBox.UseVisualStyleBackColor = true;
            // 
            // ExBut
            // 
            this.ExBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExBut.Location = new System.Drawing.Point(42, 395);
            this.ExBut.Name = "ExBut";
            this.ExBut.Size = new System.Drawing.Size(126, 61);
            this.ExBut.TabIndex = 13;
            this.ExBut.Text = "Execute";
            this.ExBut.UseVisualStyleBackColor = true;
            // 
            // LinacLabel
            // 
            this.LinacLabel.AutoSize = true;
            this.LinacLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinacLabel.Location = new System.Drawing.Point(271, 267);
            this.LinacLabel.Name = "LinacLabel";
            this.LinacLabel.Size = new System.Drawing.Size(55, 24);
            this.LinacLabel.TabIndex = 14;
            this.LinacLabel.Text = "Linac";
            // 
            // LinacBox
            // 
            this.LinacBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinacBox.FormattingEnabled = true;
            this.LinacBox.ItemHeight = 20;
            this.LinacBox.Items.AddRange(new object[] {
            "Varian 21EX",
            "Novalis_TX",
            "Truebeam1",
            "Silhouette"});
            this.LinacBox.Location = new System.Drawing.Point(275, 294);
            this.LinacBox.Name = "LinacBox";
            this.LinacBox.Size = new System.Drawing.Size(104, 84);
            this.LinacBox.TabIndex = 15;
            // 
            // DoseCalcCBox
            // 
            this.DoseCalcCBox.AutoSize = true;
            this.DoseCalcCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoseCalcCBox.Location = new System.Drawing.Point(611, 92);
            this.DoseCalcCBox.Name = "DoseCalcCBox";
            this.DoseCalcCBox.Size = new System.Drawing.Size(125, 28);
            this.DoseCalcCBox.TabIndex = 16;
            this.DoseCalcCBox.Text = "Dose Calc?";
            this.DoseCalcCBox.UseVisualStyleBackColor = true;
            this.DoseCalcCBox.CheckedChanged += new System.EventHandler(this.DoseCheckChange);
            // 
            // AlgoCBox
            // 
            this.AlgoCBox.AutoSize = true;
            this.AlgoCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgoCBox.Location = new System.Drawing.Point(641, 126);
            this.AlgoCBox.Name = "AlgoCBox";
            this.AlgoCBox.Size = new System.Drawing.Size(90, 24);
            this.AlgoCBox.TabIndex = 17;
            this.AlgoCBox.Text = "Acuros?";
            this.AlgoCBox.UseVisualStyleBackColor = true;
            this.AlgoCBox.Visible = false;
            // 
            // SetupBeamsCBox
            // 
            this.SetupBeamsCBox.AutoSize = true;
            this.SetupBeamsCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetupBeamsCBox.Location = new System.Drawing.Point(538, 36);
            this.SetupBeamsCBox.Name = "SetupBeamsCBox";
            this.SetupBeamsCBox.Size = new System.Drawing.Size(223, 28);
            this.SetupBeamsCBox.TabIndex = 18;
            this.SetupBeamsCBox.Text = "Imaging Setup Beams?";
            this.SetupBeamsCBox.UseVisualStyleBackColor = true;
            // 
            // BootPanel
            // 
            this.BootPanel.BackColor = System.Drawing.SystemColors.Control;
            this.BootPanel.Controls.Add(this.OptObjLabel);
            this.BootPanel.Controls.Add(this.OptObjBox);
            this.BootPanel.Controls.Add(this.TreatSiteBox);
            this.BootPanel.Controls.Add(this.TradeOffCBox);
            this.BootPanel.Controls.Add(this.AlgoCBox);
            this.BootPanel.Controls.Add(this.SetupBeamsCBox);
            this.BootPanel.Controls.Add(this.DoseCalcCBox);
            this.BootPanel.Controls.Add(this.TreatSiteLabel);
            this.BootPanel.Controls.Add(this.RapidCBox);
            this.BootPanel.Controls.Add(this.OptimizeCBox);
            this.BootPanel.Controls.Add(this.ExBut);
            this.BootPanel.Controls.Add(this.TreatTechBox);
            this.BootPanel.Controls.Add(this.LinacLabel);
            this.BootPanel.Controls.Add(this.LinacBox);
            this.BootPanel.Controls.Add(this.TreatTechLabel);
            this.BootPanel.Controls.Add(this.LateralityBox);
            this.BootPanel.Controls.Add(this.LateralityLabel);
            this.BootPanel.Location = new System.Drawing.Point(22, 22);
            this.BootPanel.Name = "BootPanel";
            this.BootPanel.Size = new System.Drawing.Size(775, 471);
            this.BootPanel.TabIndex = 19;
            // 
            // OptObjLabel
            // 
            this.OptObjLabel.AutoSize = true;
            this.OptObjLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptObjLabel.Location = new System.Drawing.Point(396, 156);
            this.OptObjLabel.Name = "OptObjLabel";
            this.OptObjLabel.Size = new System.Drawing.Size(211, 24);
            this.OptObjLabel.TabIndex = 20;
            this.OptObjLabel.Text = "Optimization Objectives ";
            this.OptObjLabel.Visible = false;
            // 
            // OptObjBox
            // 
            this.OptObjBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptObjBox.FormattingEnabled = true;
            this.OptObjBox.ItemHeight = 20;
            this.OptObjBox.Location = new System.Drawing.Point(400, 183);
            this.OptObjBox.Name = "OptObjBox";
            this.OptObjBox.Size = new System.Drawing.Size(162, 84);
            this.OptObjBox.TabIndex = 19;
            this.OptObjBox.Visible = false;
            // 
            // RunningPanel
            // 
            this.RunningPanel.BackColor = System.Drawing.SystemColors.Control;
            this.RunningPanel.Controls.Add(this.ProgBar);
            this.RunningPanel.Controls.Add(this.OutBox);
            this.RunningPanel.Controls.Add(this.ProgRun);
            this.RunningPanel.Location = new System.Drawing.Point(4, 3);
            this.RunningPanel.Name = "RunningPanel";
            this.RunningPanel.Size = new System.Drawing.Size(793, 505);
            this.RunningPanel.TabIndex = 20;
            this.RunningPanel.Visible = false;
            // 
            // ProgBar
            // 
            this.ProgBar.Location = new System.Drawing.Point(7, 462);
            this.ProgBar.Name = "ProgBar";
            this.ProgBar.Size = new System.Drawing.Size(764, 28);
            this.ProgBar.TabIndex = 16;
            this.ProgBar.Visible = false;
            // 
            // OutBox
            // 
            this.OutBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutBox.Location = new System.Drawing.Point(7, 34);
            this.OutBox.Multiline = true;
            this.OutBox.Name = "OutBox";
            this.OutBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutBox.Size = new System.Drawing.Size(549, 406);
            this.OutBox.TabIndex = 15;
            // 
            // ProgRun
            // 
            this.ProgRun.AutoSize = true;
            this.ProgRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgRun.Location = new System.Drawing.Point(3, 7);
            this.ProgRun.Name = "ProgRun";
            this.ProgRun.Size = new System.Drawing.Size(174, 24);
            this.ProgRun.TabIndex = 2;
            this.ProgRun.Text = "Program Running...";
            // 
            // InitialTiamatGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 518);
            this.Controls.Add(this.RunningPanel);
            this.Controls.Add(this.BootPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InitialTiamatGUI";
            this.Text = "Tiamat - External Beam Radiation Treatment Autoplanner";
            this.BootPanel.ResumeLayout(false);
            this.BootPanel.PerformLayout();
            this.RunningPanel.ResumeLayout(false);
            this.RunningPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LateralityBox;
        private System.Windows.Forms.Label LateralityLabel;
        private System.Windows.Forms.Label TreatSiteLabel;
        private System.Windows.Forms.ListBox TreatSiteBox;
        private System.Windows.Forms.Label TreatTechLabel;
        private System.Windows.Forms.ListBox TreatTechBox;
        private System.Windows.Forms.CheckBox RapidCBox;
        private System.Windows.Forms.CheckBox OptimizeCBox;
        private System.Windows.Forms.CheckBox TradeOffCBox;
        private System.Windows.Forms.Button ExBut;
        private System.Windows.Forms.Label LinacLabel;
        private System.Windows.Forms.ListBox LinacBox;
        private System.Windows.Forms.CheckBox DoseCalcCBox;
        private System.Windows.Forms.CheckBox AlgoCBox;
        private System.Windows.Forms.CheckBox SetupBeamsCBox;
        private System.Windows.Forms.Panel BootPanel;
        private System.Windows.Forms.Panel RunningPanel;
        private System.Windows.Forms.ProgressBar ProgBar;
        private System.Windows.Forms.TextBox OutBox;
        private System.Windows.Forms.Label ProgRun;
        private System.Windows.Forms.Label OptObjLabel;
        private System.Windows.Forms.ListBox OptObjBox;
    }
}