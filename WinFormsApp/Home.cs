using DbAccess;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Home : MetroFramework.Forms.MetroForm
    {
        private DBManager _db = new DBManager("MyConn");

        public Home()
        {
            InitializeComponent();
            ReadData();
        }

        public void ReadData()
        {
            try
            {
                DataTable talData = _db.GetDataTable("SELECT * from Production.Product", CommandType.Text);
                dataGridView.DataSource = talData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}