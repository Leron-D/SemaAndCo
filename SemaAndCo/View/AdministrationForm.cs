using SemaAndCo.Model;
using SemaAndCo.Presenter;
using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaAndCo.View
{
    public partial class AdministrationForm : TemplateForm, IAdministrationView
    {
        int pageSize = 1;
        int currentPage = 1;
        AdministrationPresenter presenter;

        public AdministrationForm()
        {
            InitializeComponent();
            usersGridView.AutoGenerateColumns = false;
            presenter = new AdministrationPresenter(this);
            pageSize = presenter.AutoSize(pageSize, usersGridView.Size.Height);
            presenter.UsersLoad();
            presenter.Navigation(pageSize, currentPage);
        }

        #region Pages
        public decimal CurrentPage
        {
            set
            {
                try
                {
                    currentPageNumeric.Value = value;
                }
                catch (ArgumentOutOfRangeException) { }
            }
            get
            {
                return currentPageNumeric.Value;
            }
        }
        public decimal CurrentPageMax
        {
            set
            {
                currentPageNumeric.Maximum = value;
            }
            get
            {
                return currentPageNumeric.Maximum;
            }
        }
        public decimal CurrentPageMin
        {
            set
            {
                currentPageNumeric.Minimum = value;
            }
            get
            {
                return currentPageNumeric.Minimum;
            }
        }
        public string TotalPages
        {
            set
            {
                totalPagesLabel.Text = value;
            }
            get
            {
                return totalPagesLabel.Text;
            }
        }
        public string ResultsAmount
        {
            set
            {
                resultsAmountLabel.Text = value;
            }
        }
        public bool FirstPage
        {
            set
            {
                firstPageButton.Enabled = value;
            }
        }
        public bool LeftPage
        {
            set
            {
                leftPageButton.Enabled = value;
            }
        }
        public bool RightPage
        {
            set
            {
                rightPageButton.Enabled = value;
            }
        }
        public bool LastPage
        {
            set
            {
                lastPageButton.Enabled = value;
            }
        }
        #endregion

        public string SearchTextBox
        {
            set
            {
                searchTextBox.Text = value;
            }
            get 
            {
                return searchTextBox.Text; 
            }
        }
        public object SearchData
        {
            set
            {
                usersGridView.DataSource = value;
            }
            get
            {
                object[][] result = new object[usersGridView.ColumnCount][];
                for (int i = 0; i < usersGridView.ColumnCount; i++)
                {
                    result[i] = new object[usersGridView.RowCount];
                    for (int j = 0; j < usersGridView.RowCount; j++)
                    {
                        result[i][j] = usersGridView[i, j].Value;
                    }
                }
                return result;
            }
        }

        private void FirstPageButton_Click(object sender, EventArgs e)
        {
            currentPageNumeric.Value = 1;
        }

        private void LeftPageButton_Click(object sender, EventArgs e)
        {
            if (currentPageNumeric.Value > currentPageNumeric.Minimum)
                currentPageNumeric.Value--;
        }

        private void RightPageButton_Click(object sender, EventArgs e)
        {
            if (currentPageNumeric.Value < currentPageNumeric.Maximum)
                currentPageNumeric.Value++;
        }

        private void LastPageButton_Click(object sender, EventArgs e)
        {
            currentPageNumeric.Value = currentPageNumeric.Maximum;
        }

        private void CurrentPageNumeric_ValueChanged(object sender, EventArgs e)
        {
            currentPage = (int)currentPageNumeric.Value;
            presenter.Navigation(pageSize, currentPage);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchMethod();
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchMethod();
            }
        }

        private void SearchMethod()
        {
            presenter.SearchFilterUsers(searchTextBox.Text);
            presenter.Navigation(pageSize, 1);
            currentPageNumeric.Value = currentPageNumeric.Minimum = 1;
        }

        private void AdministrationForm_SizeChanged(object sender, EventArgs e)
        {
            pageSize = presenter.AutoSize(pageSize, usersGridView.Size.Height);
            presenter.SearchFilterUsers(searchTextBox.Text);
            presenter.Navigation(pageSize, 1);
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            addButton.Enabled = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Core.addingUserVariability = true;
            RegistrationForm form = new RegistrationForm();
            form.FormClosed += Form_FormClosed;
            form.Show();
            addButton.Enabled = false;
        }
    }
}