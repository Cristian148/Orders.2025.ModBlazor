using Orders.DesktopTWO.UnitsOfWork.Implementations;
using Orders.DesktopTWO.UnitsOfWork.Interfaces;
using Orders.Shared.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orders.DesktopTWO.Controllers
{
    public partial class FrmCategories : Form
    {
        private readonly ICategoriesUnitOfWork _categoriesUnitOfWork;
        private readonly Form3 _form3;

        // private readonly IGenericUnitOfWork<Category> _unitOfWork;
        //private readonly CategoriesUnitOfWork _categoriesUnitOfWork;
        public FrmCategories(ICategoriesUnitOfWork categoriesUnitOfWork,Form3 form3)
        {

            _categoriesUnitOfWork = categoriesUnitOfWork;
            _form3 = form3;
            InitializeComponent();
        }
        //public FrmCategories( CategoriesUnitOfWork categoriesUnitOfWork)
        //{

        //   // _unitOfWork = unitOfWork;
        //    _categoriesUnitOfWork = categoriesUnitOfWork;
        //    InitializeComponent();

        //}

        private async void FrmCategories_Load(object sender, EventArgs e)
        {
            try
            {
                var resul = await _categoriesUnitOfWork.GetAsync();
                 dataGridView1.DataSource = resul.Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _form3.ShowDialog();
                //var resul = await _categoriesUnitOfWork.GetAsync();
                //dataGridView1.DataSource = resul.Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
