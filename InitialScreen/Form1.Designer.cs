namespace InitialScreen
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
            this.consoleBtn = new System.Windows.Forms.Button();
            this.guiBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // consoleBtn
            // 
            this.consoleBtn.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleBtn.Location = new System.Drawing.Point(-2, -4);
            this.consoleBtn.Name = "consoleBtn";
            this.consoleBtn.Size = new System.Drawing.Size(140, 266);
            this.consoleBtn.TabIndex = 0;
            this.consoleBtn.Text = "console";
            this.consoleBtn.UseVisualStyleBackColor = true;
            this.consoleBtn.Click += new System.EventHandler(this.consoleBtn_Click);
            // 
            // guiBtn
            // 
            this.guiBtn.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiBtn.Location = new System.Drawing.Point(135, 1);
            this.guiBtn.Name = "guiBtn";
            this.guiBtn.Size = new System.Drawing.Size(153, 261);
            this.guiBtn.TabIndex = 1;
            this.guiBtn.Text = "GUI";
            this.guiBtn.UseVisualStyleBackColor = true;
            this.guiBtn.Click += new System.EventHandler(this.guiBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 260);
            this.Controls.Add(this.guiBtn);
            this.Controls.Add(this.consoleBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button consoleBtn;
        private System.Windows.Forms.Button guiBtn;
    }
}

