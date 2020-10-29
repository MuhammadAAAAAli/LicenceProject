namespace UserInterface
{
    partial class ChooseLevelGui
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
            this.singleModeRD = new System.Windows.Forms.RadioButton();
            this.easyModeRB = new System.Windows.Forms.RadioButton();
            this.mediumModeRB = new System.Windows.Forms.RadioButton();
            this.hardModeRB = new System.Windows.Forms.RadioButton();
            this.expertModeRB = new System.Windows.Forms.RadioButton();
            this.allRadioButtons = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.playBtn = new System.Windows.Forms.Button();
            this.allWhoStartsFirstButtons = new System.Windows.Forms.GroupBox();
            this.computerStartsFirst = new System.Windows.Forms.RadioButton();
            this.iStartFirst = new System.Windows.Forms.RadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.allRadioButtons.SuspendLayout();
            this.allWhoStartsFirstButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // singleModeRD
            // 
            this.singleModeRD.AutoSize = true;
            this.singleModeRD.Location = new System.Drawing.Point(63, 71);
            this.singleModeRD.Name = "singleModeRD";
            this.singleModeRD.Size = new System.Drawing.Size(86, 27);
            this.singleModeRD.TabIndex = 0;
            this.singleModeRD.TabStop = true;
            this.singleModeRD.Text = "go go go";
            this.singleModeRD.UseVisualStyleBackColor = true;
            this.singleModeRD.CheckedChanged += new System.EventHandler(this.singleModeRD_CheckedChanged);
            // 
            // easyModeRB
            // 
            this.easyModeRB.AutoSize = true;
            this.easyModeRB.Location = new System.Drawing.Point(63, 178);
            this.easyModeRB.Name = "easyModeRB";
            this.easyModeRB.Size = new System.Drawing.Size(60, 27);
            this.easyModeRB.TabIndex = 1;
            this.easyModeRB.Text = "easy";
            this.easyModeRB.UseVisualStyleBackColor = true;
            this.easyModeRB.CheckedChanged += new System.EventHandler(this.easyModeRB_CheckedChanged);
            // 
            // mediumModeRB
            // 
            this.mediumModeRB.AutoSize = true;
            this.mediumModeRB.Location = new System.Drawing.Point(63, 226);
            this.mediumModeRB.Name = "mediumModeRB";
            this.mediumModeRB.Size = new System.Drawing.Size(80, 27);
            this.mediumModeRB.TabIndex = 2;
            this.mediumModeRB.TabStop = true;
            this.mediumModeRB.Text = "medium";
            this.mediumModeRB.UseVisualStyleBackColor = true;
            this.mediumModeRB.CheckedChanged += new System.EventHandler(this.mediumModeRB_CheckedChanged);
            // 
            // hardModeRB
            // 
            this.hardModeRB.AutoSize = true;
            this.hardModeRB.Location = new System.Drawing.Point(63, 275);
            this.hardModeRB.Name = "hardModeRB";
            this.hardModeRB.Size = new System.Drawing.Size(61, 27);
            this.hardModeRB.TabIndex = 3;
            this.hardModeRB.TabStop = true;
            this.hardModeRB.Text = "hard";
            this.hardModeRB.UseVisualStyleBackColor = true;
            this.hardModeRB.CheckedChanged += new System.EventHandler(this.hardModeRB_CheckedChanged);
            // 
            // expertModeRB
            // 
            this.expertModeRB.AutoSize = true;
            this.expertModeRB.Location = new System.Drawing.Point(63, 322);
            this.expertModeRB.Name = "expertModeRB";
            this.expertModeRB.Size = new System.Drawing.Size(77, 27);
            this.expertModeRB.TabIndex = 4;
            this.expertModeRB.TabStop = true;
            this.expertModeRB.Text = "expert";
            this.expertModeRB.UseVisualStyleBackColor = true;
            this.expertModeRB.CheckedChanged += new System.EventHandler(this.expertModeRB_CheckedChanged);
            // 
            // allRadioButtons
            // 
            this.allRadioButtons.Controls.Add(this.label2);
            this.allRadioButtons.Controls.Add(this.label1);
            this.allRadioButtons.Controls.Add(this.hardModeRB);
            this.allRadioButtons.Controls.Add(this.expertModeRB);
            this.allRadioButtons.Controls.Add(this.singleModeRD);
            this.allRadioButtons.Controls.Add(this.easyModeRB);
            this.allRadioButtons.Controls.Add(this.mediumModeRB);
            this.allRadioButtons.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allRadioButtons.ForeColor = System.Drawing.Color.Maroon;
            this.allRadioButtons.Location = new System.Drawing.Point(69, 25);
            this.allRadioButtons.Name = "allRadioButtons";
            this.allRadioButtons.Size = new System.Drawing.Size(277, 368);
            this.allRadioButtons.TabIndex = 5;
            this.allRadioButtons.TabStop = false;
            this.allRadioButtons.Text = "Choose game mode !";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Single player mode :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Two player mode :";
            // 
            // playBtn
            // 
            this.playBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.playBtn.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Location = new System.Drawing.Point(109, 586);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(200, 27);
            this.playBtn.TabIndex = 6;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = false;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // allWhoStartsFirstButtons
            // 
            this.allWhoStartsFirstButtons.Controls.Add(this.computerStartsFirst);
            this.allWhoStartsFirstButtons.Controls.Add(this.iStartFirst);
            this.allWhoStartsFirstButtons.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allWhoStartsFirstButtons.ForeColor = System.Drawing.Color.DarkMagenta;
            this.allWhoStartsFirstButtons.ImeMode = System.Windows.Forms.ImeMode.On;
            this.allWhoStartsFirstButtons.Location = new System.Drawing.Point(109, 444);
            this.allWhoStartsFirstButtons.Name = "allWhoStartsFirstButtons";
            this.allWhoStartsFirstButtons.Size = new System.Drawing.Size(200, 100);
            this.allWhoStartsFirstButtons.TabIndex = 7;
            this.allWhoStartsFirstButtons.TabStop = false;
            this.allWhoStartsFirstButtons.Text = "Who starts first :";
            this.allWhoStartsFirstButtons.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // computerStartsFirst
            // 
            this.computerStartsFirst.AutoSize = true;
            this.computerStartsFirst.Location = new System.Drawing.Point(39, 62);
            this.computerStartsFirst.Name = "computerStartsFirst";
            this.computerStartsFirst.Size = new System.Drawing.Size(95, 27);
            this.computerStartsFirst.TabIndex = 1;
            this.computerStartsFirst.TabStop = true;
            this.computerStartsFirst.Text = "computer";
            this.computerStartsFirst.UseVisualStyleBackColor = true;
            // 
            // iStartFirst
            // 
            this.iStartFirst.AutoSize = true;
            this.iStartFirst.Location = new System.Drawing.Point(39, 29);
            this.iStartFirst.Name = "iStartFirst";
            this.iStartFirst.Size = new System.Drawing.Size(47, 27);
            this.iStartFirst.TabIndex = 0;
            this.iStartFirst.TabStop = true;
            this.iStartFirst.Text = "me";
            this.iStartFirst.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ChooseLevelGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 693);
            this.Controls.Add(this.allWhoStartsFirstButtons);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.allRadioButtons);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ChooseLevelGui";
            this.Text = "Choose level";
            this.TransparencyKey = System.Drawing.Color.LightPink;
            this.Load += new System.EventHandler(this.ChooseLevelGui_Load);
            this.allRadioButtons.ResumeLayout(false);
            this.allRadioButtons.PerformLayout();
            this.allWhoStartsFirstButtons.ResumeLayout(false);
            this.allWhoStartsFirstButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton singleModeRD;
        private System.Windows.Forms.RadioButton easyModeRB;
        private System.Windows.Forms.RadioButton mediumModeRB;
        private System.Windows.Forms.RadioButton hardModeRB;
        private System.Windows.Forms.RadioButton expertModeRB;
        private System.Windows.Forms.GroupBox allRadioButtons;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.RadioButton computerStartsFirst;
        private System.Windows.Forms.RadioButton iStartFirst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox allWhoStartsFirstButtons;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

