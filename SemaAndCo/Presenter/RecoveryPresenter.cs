using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SemaAndCo.View;
using SemaAndCo.Supporting;

namespace SemaAndCo.Presenter
{
    class RecoveryPresenter
    {
        IRecoveryView view;

        public RecoveryPresenter(IRecoveryView view)
        {
            this.view = view;
        }

        public void GetLoginOrEmail(string loginOrEmail)
        {
            Properties.Settings.Default.login = loginOrEmail;
            Core.mailVariability = true;
        }
    }
}
