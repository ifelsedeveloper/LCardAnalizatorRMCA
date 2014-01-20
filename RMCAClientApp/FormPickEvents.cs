using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace LCardAnalizator
{
    public partial class FormPickEvents : Form
    {
        public FormPickEvents()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            try
            {
                if (textBoxStep.Text.Length > 0 && textBoxStartPoint.Text.Length > 0)
                {
                    step = Convert.ToInt32(textBoxStep.Text);
                    startPoint = Convert.ToInt32(textBoxStartPoint.Text);
                    diff = Convert.ToInt32(textBoxDiff.Text);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        bool allowSpace = false;

        public int Step
        {
            get { return step; }
        }

        public int StartPoint
        {
            get { return startPoint; }
        }

        public int DiffPoints
        {
            get { return diff; }
        }

        private int step;
        private int startPoint;
        private int diff;
        // Restricts the entry of characters to digits (including hex), the negative sign, 
        // the decimal point, and editing keystrokes (backspace). 
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            string groupSeparator = numberFormatInfo.NumberGroupSeparator;
            string negativeSign = numberFormatInfo.NegativeSign;

            // Workaround for groupSeparator equal to non-breaking space 
            if (groupSeparator == ((char)160).ToString())
            {
                groupSeparator = " ";
            }

            string keyInput = e.KeyChar.ToString();

            if (Char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
             keyInput.Equals(negativeSign))
            {
                // Decimal separator is OK
            }
            else if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }
            //    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0) 
            //    { 
            //     // Let the edit control handle control and alt key combinations 
            //    } 
            else if (this.allowSpace && e.KeyChar == ' ')
            {

            }
            else
            {
                // Consume this invalid key and beep
                e.Handled = true;
                //    MessageBeep();
            }
        }

        private void textBoxStartPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }
    }
}
