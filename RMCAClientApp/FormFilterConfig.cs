using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LCardAnalizator
{
    public partial class FormFilterConfig : Form
    {
        public FormFilterConfig()
        {
            InitializeComponent();
            comboBoxFilterType.SelectedIndex = 0;
            numericUpDownNumberChannel.Maximum = maxChannels;
        }

        int _maxChannels = 1;
        public int maxChannels
        {
            get { return _maxChannels; }
            set {
                _maxChannels = value;
                numericUpDownNumberChannel.Maximum = _maxChannels;
            }
        }


        public int typeFilter
        {
            get {
                return comboBoxFilterType.SelectedIndex;
            }
        }

        public int numberChannel
        {
            get {
                return Convert.ToInt32(numericUpDownNumberChannel.Value);
            }
        }

        private void numericUpDownNumberChannel_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonOkFilter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancelFilter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
