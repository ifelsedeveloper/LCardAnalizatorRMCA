using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsGraphickOpenGL
{
    public partial class FormProgressBar : Form
    {
        BackgroundWorker worker;
        public FormProgressBar(ref BackgroundWorker state)
        {
            worker = state;
            InitializeComponent();
        }

        public void setProgress(int value,string description)
        {
            //lock (progressBarStateAcivity)
            //{
                progressBarStateAcivity.Value = value;
            //}
            //lock (labelState.Text)
            //{
                labelState.Text = description;
            //}
                labelState.Invalidate();
                progressBarStateAcivity.Invalidate();
        }

        private void FormProgressBar_FormClosed(object sender, FormClosedEventArgs e)
        {
            worker.ReportProgress(100);
            worker.CancelAsync();
        }
    }
}
