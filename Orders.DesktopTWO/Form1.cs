using Orders.DesktopTWO.Data;

namespace Orders.DesktopTWO
{
    public partial class Form1 : Form
    {
        private readonly DataContext dataContext;
        private readonly Form2 form2;

        public Form1(DataContext dataContext,Form2 form2)
        {
            this.dataContext = dataContext;
            this.form2 = form2;
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var data = this.dataContext.Categories.ToList();
            dataGridView1.DataSource = data;


        }
    }
}
