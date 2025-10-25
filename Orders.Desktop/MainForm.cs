using Microsoft.EntityFrameworkCore;
using Orders.Desktop.Data;

namespace Orders.Desktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Example in a WinForms form or service
            using (var context = new DataContext(new DbContextOptions<DataContext>(), Program.Program.Configuration))
            {
                // Perform database operations
                var entities = context.Countries.ToList();
                dataGridView1.DataSource = entities;
            }

        }
    }


}
