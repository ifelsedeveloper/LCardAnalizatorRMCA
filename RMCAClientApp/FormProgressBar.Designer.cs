namespace WindowsFormsGraphickOpenGL
{
    partial class FormProgressBar
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
            this.progressBarStateAcivity = new System.Windows.Forms.ProgressBar();
            this.labelState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarStateAcivity
            // 
            this.progressBarStateAcivity.Location = new System.Drawing.Point(12, 12);
            this.progressBarStateAcivity.Name = "progressBarStateAcivity";
            this.progressBarStateAcivity.Size = new System.Drawing.Size(310, 23);
            this.progressBarStateAcivity.TabIndex = 0;
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(12, 51);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(72, 13);
            this.labelState.TabIndex = 1;
            this.labelState.Text = "Ввод данных";
            // 
            // FormProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 82);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.progressBarStateAcivity);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Состояние";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormProgressBar_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarStateAcivity;
        private System.Windows.Forms.Label labelState;
    }
}