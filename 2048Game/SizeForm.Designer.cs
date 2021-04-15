namespace _2048Game
{
    partial class SizeForm
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
            this.sizeTextLabel = new System.Windows.Forms.Label();
            this.sizeFourButton = new System.Windows.Forms.Button();
            this.sizeFiveButton = new System.Windows.Forms.Button();
            this.sizeSixButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sizeTextLabel
            // 
            this.sizeTextLabel.AutoSize = true;
            this.sizeTextLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sizeTextLabel.Location = new System.Drawing.Point(48, 29);
            this.sizeTextLabel.Name = "sizeTextLabel";
            this.sizeTextLabel.Size = new System.Drawing.Size(162, 19);
            this.sizeTextLabel.TabIndex = 0;
            this.sizeTextLabel.Text = "Выберите размер поля";
            // 
            // sizeFourButton
            // 
            this.sizeFourButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sizeFourButton.Location = new System.Drawing.Point(63, 64);
            this.sizeFourButton.Name = "sizeFourButton";
            this.sizeFourButton.Size = new System.Drawing.Size(121, 54);
            this.sizeFourButton.TabIndex = 1;
            this.sizeFourButton.Text = "4 x 4";
            this.sizeFourButton.UseVisualStyleBackColor = true;
            this.sizeFourButton.Click += new System.EventHandler(this.sizeFourButton_Click_1);
            // 
            // sizeFiveButton
            // 
            this.sizeFiveButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sizeFiveButton.Location = new System.Drawing.Point(63, 124);
            this.sizeFiveButton.Name = "sizeFiveButton";
            this.sizeFiveButton.Size = new System.Drawing.Size(121, 54);
            this.sizeFiveButton.TabIndex = 2;
            this.sizeFiveButton.Text = "5 x 5";
            this.sizeFiveButton.UseVisualStyleBackColor = true;
            this.sizeFiveButton.Click += new System.EventHandler(this.sizeFiveButton_Click_1);
            // 
            // sizeSixButton
            // 
            this.sizeSixButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sizeSixButton.Location = new System.Drawing.Point(63, 184);
            this.sizeSixButton.Name = "sizeSixButton";
            this.sizeSixButton.Size = new System.Drawing.Size(121, 54);
            this.sizeSixButton.TabIndex = 3;
            this.sizeSixButton.Text = "6 x 6";
            this.sizeSixButton.UseVisualStyleBackColor = true;
            this.sizeSixButton.Click += new System.EventHandler(this.sizeSixButton_Click_1);
            // 
            // SizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 278);
            this.Controls.Add(this.sizeSixButton);
            this.Controls.Add(this.sizeFiveButton);
            this.Controls.Add(this.sizeFourButton);
            this.Controls.Add(this.sizeTextLabel);
            this.Name = "SizeForm";
            this.Text = "SizeForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SizeForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sizeTextLabel;
        private System.Windows.Forms.Button sizeFourButton;
        private System.Windows.Forms.Button sizeFiveButton;
        private System.Windows.Forms.Button sizeSixButton;
    }
}