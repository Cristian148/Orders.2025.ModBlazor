using Orders.DesktopTWO.Controllers;
using Orders.DesktopTWO.Data;

namespace Orders.DesktopTWO
{
    public partial class Form1 : Form
    {
        private readonly DataContext dataContext;
        private readonly Form2 form2;
        private readonly FrmCategories _frmCategories;

        public Form1(DataContext dataContext, Form2 form2, FrmCategories frmCategories)
        {
            this.dataContext = dataContext;
            this.form2 = form2;
            _frmCategories = frmCategories;
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var data = this.dataContext.Categories.ToList();
            dataGridView1.DataSource = data;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            _frmCategories.ShowDialog();
        }
    }
}
