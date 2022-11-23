using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaAndCo.View
{
    public partial class IntroForm : Form
    {
        public IntroForm(int interval)
        {
            InitializeComponent();
            timer.Interval = interval;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
