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

        private string msgType = "";
        private string msgText = "";

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

                IDbDataParameter[] param = new[]
                {
                    _db.CreateParameter("@PName",size:100, "PVal", DbType.String,ParameterDirection.Input),
                    _db.CreateParameter("@PId",size:5, 101, DbType.Int32,ParameterDirection.Input)
                };

                _db.Insert("Insert Cmd", CommandType.Text, out msgType, out msgText, param);

                MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}