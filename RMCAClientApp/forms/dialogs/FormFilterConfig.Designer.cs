namespace LCardAnalizator
{
    partial class FormFilterConfig
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
            this.labelNumberChannel = new System.Windows.Forms.Label();
            this.numericUpDownNumberChannel = new System.Windows.Forms.NumericUpDown();
            this.comboBoxFilterType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonOkFilter = new System.Windows.Forms.Button();
            this.buttonCancelFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNumberPoints = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNumberChannel
            // 
            this.labelNumberChannel.AutoSize = true;
            this.labelNumberChannel.Location = new System.Drawing.Point(13, 13);
            this.labelNumberChannel.Name = "labelNumberChannel";
            this.labelNumberChannel.Size = new System.Drawing.Size(80, 13);
            this.labelNumberChannel.TabIndex = 0;
            this.labelNumberChannel.Text = "Номер канала";
            // 
            // numericUpDownNumberChannel
            // 
            this.numericUpDownNumberChannel.Location = new System.Drawing.Point(99, 12);
            this.numericUpDownNumberChannel.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownNumberChannel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberChannel.Name = "numericUpDownNumberChannel";
            this.numericUpDownNumberChannel.Size = new System.Drawing.Size(169, 20);
            this.numericUpDownNumberChannel.TabIndex = 1;
            this.numericUpDownNumberChannel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberChannel.ValueChanged += new System.EventHandler(this.numericUpDownNumberChannel_ValueChanged);
            // 
            // comboBoxFilterType
            // 
            this.comboBoxFilterType.FormattingEnabled = true;
            this.comboBoxFilterType.Items.AddRange(new object[] {
            "Сглаживание Гаусса",
            "Сглаживание Блюр",
            "Сглаживание Блюр без масш."});
            this.comboBoxFilterType.Location = new System.Drawing.Point(16, 51);
            this.comboBoxFilterType.Name = "comboBoxFilterType";
            this.comboBoxFilterType.Size = new System.Drawing.Size(252, 21);
            this.comboBoxFilterType.TabIndex = 2;
            this.comboBoxFilterType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilterType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Тип Фильрации";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(16, 108);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonOkFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonCancelFilter);
            this.splitContainer1.Size = new System.Drawing.Size(252, 26);
            this.splitContainer1.SplitterDistance = 118;
            this.splitContainer1.TabIndex = 4;
            // 
            // buttonOkFilter
            // 
            this.buttonOkFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOkFilter.Location = new System.Drawing.Point(0, 0);
            this.buttonOkFilter.Name = "buttonOkFilter";
            this.buttonOkFilter.Size = new System.Drawing.Size(118, 26);
            this.buttonOkFilter.TabIndex = 0;
            this.buttonOkFilter.Text = "Ok";
            this.buttonOkFilter.UseVisualStyleBackColor = true;
            this.buttonOkFilter.Click += new System.EventHandler(this.buttonOkFilter_Click);
            // 
            // buttonCancelFilter
            // 
            this.buttonCancelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancelFilter.Location = new System.Drawing.Point(0, 0);
            this.buttonCancelFilter.Name = "buttonCancelFilter";
            this.buttonCancelFilter.Size = new System.Drawing.Size(130, 26);
            this.buttonCancelFilter.TabIndex = 0;
            this.buttonCancelFilter.Text = "Отмена";
            this.buttonCancelFilter.UseVisualStyleBackColor = true;
            this.buttonCancelFilter.Click += new System.EventHandler(this.buttonCancelFilter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Количетво точек(нечетное)";
            // 
            // textBoxNumberPoints
            // 
            this.textBoxNumberPoints.Location = new System.Drawing.Point(165, 79);
            this.textBoxNumberPoints.Name = "textBoxNumberPoints";
            this.textBoxNumberPoints.Size = new System.Drawing.Size(103, 20);
            this.textBoxNumberPoints.TabIndex = 6;
            this.textBoxNumberPoints.Text = "125";
            // 
            // FormFilterConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 143);
            this.Controls.Add(this.textBoxNumberPoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxFilterType);
            this.Controls.Add(this.numericUpDownNumberChannel);
            this.Controls.Add(this.labelNumberChannel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFilterConfig";
            this.Text = "Настройка фильрации";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberChannel)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumberChannel;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberChannel;
        private System.Windows.Forms.ComboBox comboBoxFilterType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonOkFilter;
        private System.Windows.Forms.Button buttonCancelFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNumberPoints;
    }
}