using SemaAndCo.Model;
using SemaAndCo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaAndCo.Presenter
{
     class AdministrationPresenter
    {
        IAdministrationModel model;
        IAdministrationView view;

        public AdministrationPresenter(IAdministrationView view)
        {
            this.model = new AdministrationModel();
            this.view = view;
        }
        public void UsersLoad()
        {
            try
            {
                view.SearchData = model.UsersLoad();
                view.CurrentPage = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Отсутствует соединение с сервером", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SearchFilterUsers(string search)
        {
            model.SearchUsers(search);
        }

        public void Navigation(int pageSize, int currentPage)
        {
            try
            {
                var data = model.ReturnUsers();
                var count = data.Count();
                int amountPages = count / pageSize + (count % pageSize > 0 ? 1 : 0);
                var skip = pageSize * (currentPage - 1);
                var take = model.SearchUsersOrderBy(skip, pageSize);
                view.SearchData = take;
                if (amountPages < 1)
                    amountPages = 1;
                view.CurrentPageMax = amountPages;
                view.ResultsAmount = Convert.ToString(count);
                view.TotalPages = amountPages.ToString();
                LockButtons(currentPage, amountPages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LockButtons(int currentPage, int amountPages)
        {
            try
            {
                view.FirstPage = view.LeftPage = currentPage > 1;
                if (view.CurrentPageMax == 1 || currentPage >= amountPages)
                    view.LastPage = view.RightPage = false;
                else
                    view.LastPage = view.RightPage = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int AutoSize(int pageSize, int height)
        {
            view.CurrentPage = 1;
            pageSize = height - 32;
            return pageSize / 22;
        }
    }
}
