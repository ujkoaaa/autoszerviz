namespace autoszerviz
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
            this.névText = new System.Windows.Forms.TextBox();
            this.jelszóText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.regisztrálB = new System.Windows.Forms.Button();
            this.belépB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // névText
            // 
            this.névText.Location = new System.Drawing.Point(329, 134);
            this.névText.Name = "névText";
            this.névText.Size = new System.Drawing.Size(100, 20);
            this.névText.TabIndex = 0;
            // 
            // jelszóText
            // 
            this.jelszóText.Location = new System.Drawing.Point(329, 160);
            this.jelszóText.Name = "jelszóText";
            this.jelszóText.Size = new System.Drawing.Size(100, 20);
            this.jelszóText.TabIndex = 1;
            this.jelszóText.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "név";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jelszó";
            // 
            // regisztrálB
            // 
            this.regisztrálB.Location = new System.Drawing.Point(255, 214);
            this.regisztrálB.Name = "regisztrálB";
            this.regisztrálB.Size = new System.Drawing.Size(75, 23);
            this.regisztrálB.TabIndex = 4;
            this.regisztrálB.Text = "regisztrál";
            this.regisztrálB.UseVisualStyleBackColor = true;
            this.regisztrálB.Click += new System.EventHandler(this.regisztrálB_Click);
            // 
            // belépB
            // 
            this.belépB.Location = new System.Drawing.Point(363, 214);
            this.belépB.Name = "belépB";
            this.belépB.Size = new System.Drawing.Size(75, 23);
            this.belépB.TabIndex = 5;
            this.belépB.Text = "belép";
            this.belépB.UseVisualStyleBackColor = true;
            this.belépB.Click += new System.EventHandler(this.belépB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.belépB);
            this.Controls.Add(this.regisztrálB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jelszóText);
            this.Controls.Add(this.névText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox névText;
        private System.Windows.Forms.TextBox jelszóText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button regisztrálB;
        private System.Windows.Forms.Button belépB;
    }
}

