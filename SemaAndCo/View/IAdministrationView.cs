using SemaAndCo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaAndCo.View
{
    interface IAdministrationView
    {
        #region Pages
        decimal CurrentPage { set; get; }
        decimal CurrentPageMax { set; get; }
        decimal CurrentPageMin { set; get; }
        string TotalPages { set; get; }
        string ResultsAmount { set; }
        bool FirstPage { set; }
        bool LeftPage { set; }
        bool RightPage { set; }
        bool LastPage { set; }
        #endregion
        object SearchData { get; set; }
        string SearchTextBox { get; set; }
    }
}
