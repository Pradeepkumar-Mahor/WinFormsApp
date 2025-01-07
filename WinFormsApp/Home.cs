using DbAccess;

using System.Data;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Home : Form
    {
        private DBManager _db = new DBManager("SqlServerConnection");

        private string msgType = "";
        private string msgText = "";

        public Home()
        {
            InitializeComponent();
        }

        private async void btnProduct_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.Visible = false;
                pictureBox.Visible = true;
                await Task.Delay(2000);

                string strQry = $@"Select ProductID as ""Id"" ,
                                Name as ""Product Name"" ,
                                ProductNumber as ""Product Number"" ,
                                MakeFlag as ""Make Flag"" ,
                                FinishedGoodsFlag as ""Finished Goods Flag"" ,
                                Color as ""Product Color"" ,
                                SafetyStockLevel as ""Safety Stock Level"" ,
                                ReorderPoint as ""Reorder Point"" ,
                                StandardCost as ""Standard Cost"" ,
                                ListPrice as ""List Price"" ,Size as ""Product Size"" ,
                                SizeUnitMeasureCode as ""Size Unit Measure Code"" ,
                                WeightUnitMeasureCode as ""Weight Unit Measure Code"" ,Weight as ""Product Weight""
                            from Production.Product
                            ";

                DataTable talData = _db.GetDataTable(strQry, CommandType.Text);
                dataGridView.DataBindings.Clear();
                dataGridView.DataSource = talData;

                pictureBox.Visible = false;
                dataGridView.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                pictureBox.Visible = false;
                dataGridView.Visible = true;
            }
        }

        private async void btnPerson_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox.Visible = true;
                dataGridView.Visible = false;
                await Task.Delay(2000);

                string strQryPerson = $@"SELECT BusinessEntityID As 'Id'
                                      ,Title As 'Title'
                                      ,FirstName As 'First Name'
                                      ,MiddleName As 'Middle Name'
                                      ,LastName As 'Last Name'
                                      ,PersonType As 'Person Type'
                                      ,NameStyle As 'Name Style'
                                      ,Suffix As 'Suffix'
                                      ,EmailPromotion As 'Email Promotion'
                                      ,AdditionalContactInfo As 'Additional Contact Info'
                                      ,Demographics As 'Demographics'
                                      ,ModifiedDate As 'Modified Date'
                                  FROM AdventureWorks2022.Person.Person
                   ";

                DataTable talData = _db.GetDataTable(strQryPerson, CommandType.Text);
                dataGridView.DataBindings.Clear();
                dataGridView.DataSource = talData;
                pictureBox.Visible = false;
                dataGridView.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                pictureBox.Visible = false;
                dataGridView.Visible = true;
            }
        }
    }
}