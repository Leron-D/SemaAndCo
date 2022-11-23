using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaAndCo.View
{
    interface ILoginView
    {
        void Hide();
        void Close();
        void Show();

        string Login { set; get; }
        string Password { set; get; }
        bool SaveOptions { set; get; }
    }
}
