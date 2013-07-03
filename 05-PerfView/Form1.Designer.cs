namespace Performance
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
            this.openView = new System.Windows.Forms.Button();
            this.memLeak = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openView
            // 
            this.openView.Location = new System.Drawing.Point(12, 12);
            this.openView.Name = "openView";
            this.openView.Size = new System.Drawing.Size(170, 34);
            this.openView.TabIndex = 0;
            this.openView.Text = "Neuen ItemView öffnen";
            this.openView.UseVisualStyleBackColor = true;
            this.openView.Click += new System.EventHandler(this.openView_Click);
            // 
            // memLeak
            // 
            this.memLeak.AutoSize = true;
            this.memLeak.Location = new System.Drawing.Point(12, 52);
            this.memLeak.Name = "memLeak";
            this.memLeak.Size = new System.Drawing.Size(151, 17);
            this.memLeak.TabIndex = 1;
            this.memLeak.Text = "Memory Leak aktivieren (!)";
            this.memLeak.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.memLeak);
            this.Controls.Add(this.openView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openView;
        private System.Windows.Forms.CheckBox memLeak;
    }
}

