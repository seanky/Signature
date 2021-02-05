namespace Signature
{
    partial class learnDialog
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
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(78, 78);
            this.trackBar.Maximum = 20;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(215, 56);
            this.trackBar.TabIndex = 0;
            this.trackBar.Value = 1;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(201, 150);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(92, 43);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "Learn";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(78, 150);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(92, 43);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // textBox
            // 
            this.textBox.Enabled = false;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(78, 23);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(215, 38);
            this.textBox.TabIndex = 3;
            // 
            // learnDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(382, 205);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.trackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "learnDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mag Learn Ka";
            this.Load += new System.EventHandler(this.learnDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox textBox;
    }
}