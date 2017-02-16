namespace CrazyMouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown2 = new System.Windows.Forms.DomainUpDown();
            this.labelX = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelY = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(4, 7);
            this.listBox1.MaximumSize = new System.Drawing.Size(58, 173);
            this.listBox1.MinimumSize = new System.Drawing.Size(58, 173);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(58, 173);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(68, 7);
            this.listBox2.MaximumSize = new System.Drawing.Size(58, 173);
            this.listBox2.MinimumSize = new System.Drawing.Size(58, 173);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(58, 173);
            this.listBox2.TabIndex = 1;
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Location = new System.Drawing.Point(132, 7);
            this.domainUpDown1.MaximumSize = new System.Drawing.Size(50, 0);
            this.domainUpDown1.MinimumSize = new System.Drawing.Size(50, 0);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(50, 20);
            this.domainUpDown1.TabIndex = 2;
            this.domainUpDown1.Text = "domainUpDown1";
            // 
            // domainUpDown2
            // 
            this.domainUpDown2.Location = new System.Drawing.Point(189, 7);
            this.domainUpDown2.MaximumSize = new System.Drawing.Size(62, 0);
            this.domainUpDown2.MinimumSize = new System.Drawing.Size(62, 0);
            this.domainUpDown2.Name = "domainUpDown2";
            this.domainUpDown2.Size = new System.Drawing.Size(62, 20);
            this.domainUpDown2.TabIndex = 3;
            this.domainUpDown2.Text = "domainUpDown2";
            // 
            // label1
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(133, 103);
            this.labelX.Name = "label1";
            this.labelX.Size = new System.Drawing.Size(35, 13);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(175, 103);
            this.labelY.Name = "label2";
            this.labelY.Size = new System.Drawing.Size(35, 13);
            this.labelY.TabIndex = 6;
            this.labelY.Text = "label2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 184);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.domainUpDown2);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(271, 223);
            this.MinimumSize = new System.Drawing.Size(271, 223);
            this.Name = "Form1";
            this.Text = "Crazy Mouse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.DomainUpDown domainUpDown2;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Timer timer1;
    }
}

