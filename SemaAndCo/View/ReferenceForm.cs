using SemaAndCo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaAndCo.View
{
    public partial class ReferenceForm : Form
    {
        public ReferenceForm()
        {
            InitializeComponent();
            referenceWebBrowser.Navigate(Directory.GetCurrentDirectory() + @"\Руководство пользователя.html");
        }
    }
}
