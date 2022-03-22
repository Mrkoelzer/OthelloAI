namespace Othello
{
    partial class NewGameDialog
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
            this.uxLevelLabel = new System.Windows.Forms.Label();
            this.uxNumericLevel = new System.Windows.Forms.NumericUpDown();
            this.uxComputerFirstButton = new System.Windows.Forms.RadioButton();
            this.uxHumanFirstButton = new System.Windows.Forms.RadioButton();
            this.uxNoComputerButton = new System.Windows.Forms.RadioButton();
            this.uxOKButton = new System.Windows.Forms.Button();
            this.uxCancelButton = new System.Windows.Forms.Button();
            this.uxComputervscomputer = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // uxLevelLabel
            // 
            this.uxLevelLabel.AutoSize = true;
            this.uxLevelLabel.Location = new System.Drawing.Point(28, 25);
            this.uxLevelLabel.Name = "uxLevelLabel";
            this.uxLevelLabel.Size = new System.Drawing.Size(33, 13);
            this.uxLevelLabel.TabIndex = 0;
            this.uxLevelLabel.Text = "Level";
            // 
            // uxNumericLevel
            // 
            this.uxNumericLevel.Location = new System.Drawing.Point(70, 23);
            this.uxNumericLevel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uxNumericLevel.Name = "uxNumericLevel";
            this.uxNumericLevel.Size = new System.Drawing.Size(120, 20);
            this.uxNumericLevel.TabIndex = 4;
            this.uxNumericLevel.TabStop = false;
            this.uxNumericLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxComputerFirstButton
            // 
            this.uxComputerFirstButton.AutoSize = true;
            this.uxComputerFirstButton.Checked = true;
            this.uxComputerFirstButton.Location = new System.Drawing.Point(31, 64);
            this.uxComputerFirstButton.Name = "uxComputerFirstButton";
            this.uxComputerFirstButton.Size = new System.Drawing.Size(116, 17);
            this.uxComputerFirstButton.TabIndex = 5;
            this.uxComputerFirstButton.TabStop = true;
            this.uxComputerFirstButton.Text = "Computer plays first";
            this.uxComputerFirstButton.UseVisualStyleBackColor = true;
            // 
            // uxHumanFirstButton
            // 
            this.uxHumanFirstButton.AutoSize = true;
            this.uxHumanFirstButton.Location = new System.Drawing.Point(31, 87);
            this.uxHumanFirstButton.Name = "uxHumanFirstButton";
            this.uxHumanFirstButton.Size = new System.Drawing.Size(105, 17);
            this.uxHumanFirstButton.TabIndex = 6;
            this.uxHumanFirstButton.Text = "Human plays first";
            this.uxHumanFirstButton.UseVisualStyleBackColor = true;
            // 
            // uxNoComputerButton
            // 
            this.uxNoComputerButton.AutoSize = true;
            this.uxNoComputerButton.Location = new System.Drawing.Point(31, 110);
            this.uxNoComputerButton.Name = "uxNoComputerButton";
            this.uxNoComputerButton.Size = new System.Drawing.Size(117, 17);
            this.uxNoComputerButton.TabIndex = 7;
            this.uxNoComputerButton.Text = "No computer player";
            this.uxNoComputerButton.UseVisualStyleBackColor = true;
            // 
            // uxOKButton
            // 
            this.uxOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxOKButton.Location = new System.Drawing.Point(31, 153);
            this.uxOKButton.Name = "uxOKButton";
            this.uxOKButton.Size = new System.Drawing.Size(75, 23);
            this.uxOKButton.TabIndex = 8;
            this.uxOKButton.Text = "OK";
            this.uxOKButton.UseVisualStyleBackColor = true;
            // 
            // uxCancelButton
            // 
            this.uxCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxCancelButton.Location = new System.Drawing.Point(115, 153);
            this.uxCancelButton.Name = "uxCancelButton";
            this.uxCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uxCancelButton.TabIndex = 9;
            this.uxCancelButton.Text = "Cancel";
            this.uxCancelButton.UseVisualStyleBackColor = true;
            // 
            // uxComputervscomputer
            // 
            this.uxComputervscomputer.AutoSize = true;
            this.uxComputervscomputer.Location = new System.Drawing.Point(31, 130);
            this.uxComputervscomputer.Name = "uxComputervscomputer";
            this.uxComputervscomputer.Size = new System.Drawing.Size(135, 17);
            this.uxComputervscomputer.TabIndex = 10;
            this.uxComputervscomputer.Text = "Computer VS Computer";
            this.uxComputervscomputer.UseVisualStyleBackColor = true;
            // 
            // NewGameDialog
            // 
            this.AcceptButton = this.uxOKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 188);
            this.Controls.Add(this.uxComputervscomputer);
            this.Controls.Add(this.uxCancelButton);
            this.Controls.Add(this.uxOKButton);
            this.Controls.Add(this.uxNoComputerButton);
            this.Controls.Add(this.uxHumanFirstButton);
            this.Controls.Add(this.uxComputerFirstButton);
            this.Controls.Add(this.uxNumericLevel);
            this.Controls.Add(this.uxLevelLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "NewGameDialog";
            this.Text = "Setup";
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxLevelLabel;
        private System.Windows.Forms.NumericUpDown uxNumericLevel;
        private System.Windows.Forms.RadioButton uxComputerFirstButton;
        private System.Windows.Forms.RadioButton uxHumanFirstButton;
        private System.Windows.Forms.RadioButton uxNoComputerButton;
        private System.Windows.Forms.Button uxOKButton;
        private System.Windows.Forms.Button uxCancelButton;
        private System.Windows.Forms.RadioButton uxComputervscomputer;
    }
}