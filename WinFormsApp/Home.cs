using DbAccess;

using System.Data;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Home : MetroFramework.Forms.MetroForm
    {
        private DBManager _db = new DBManager("SqlServerConnection");

        private string msgType = "";
        private string msgText = "";

        public Home()
        {
            InitializeComponent();
            //ReadData();
            //InsertDataSample();
            //UpdateDataSample();
            //ReadSingleRecord();
            //DeleteDataSample();
        }

        public void ReadData()
        {
            try
            {
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
                string strQryPerson = $@"SELECT BusinessEntityID
                                  ,PersonType
                                  ,NameStyle
                                  ,Title
                                  ,FirstName
                                  ,MiddleName
                                  ,LastName
                                  ,Suffix
                                  ,EmailPromotion
                                  ,AdditionalContactInfo
                                  ,Demographics
                                  ,rowguid
                                  ,ModifiedDate
                              FROM AdventureWorks2022.Person.Person

                            ";

                //DataTable talData = _db.GetDataTable("SELECT * from Production.Product", CommandType.Text);

                //IDbDataParameter[] param = new[]
                //{
                //    _db.CreateParameter("@PProductID",size:100, 1, DbType.Int32,ParameterDirection.Input)
                // };

                DataTable talData = _db.GetDataTable(strQryPerson, CommandType.Text);
                dataGridView.DataSource = talData;

                //_db.Insert("INSERT INTO Sales.SalesReason (Name ,ReasonType) VALUES (@PName ,@PReasonType)", CommandType.Text, out msgType, out msgText, param);

                //MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ReadSingleRecord()
        {
            try
            {
                //DataTable talData = _db.GetDataTable("SELECT * from Production.Product", CommandType.Text);
                //dataGridView.DataSource = talData;

                IDbDataParameter[] param = new[]
                {
                    _db.CreateParameter("@PSalesReasonID",size:100, 11, DbType.Int32,ParameterDirection.Input)
                };

                var dataReader = _db.GetDataReader("SELECT * from Sales.SalesReason where SalesReasonID = @PSalesReasonID ", CommandType.Text, param);
                while (dataReader.Read())
                {
                    MessageBox.Show(dataReader.GetInt32(0) + ", " + dataReader.GetString(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void InsertDataSample()
        {
            try
            {
                IDbDataParameter[] param = new[]
                {
                    _db.CreateParameter("@PName",size:100, "Microsoft PWA", DbType.String,ParameterDirection.Input),
                    _db.CreateParameter("@PReasonType",size:100, "Microsoft PWA Type", DbType.String,ParameterDirection.Input)
                 };

                _db.Insert("INSERT INTO Sales.SalesReason (Name ,ReasonType) VALUES (@PName ,@PReasonType)", CommandType.Text, out msgType, out msgText, param);

                MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateDataSample()
        {
            try
            {
                IDbDataParameter[] param = new[]
                {
                    _db.CreateParameter("@PName",size:100, "Microsoft PWA", DbType.String,ParameterDirection.Input),
                    _db.CreateParameter("@PReasonType",size:100, "Microsoft PWA Type : Updated", DbType.String,ParameterDirection.Input),
                    _db.CreateParameter("@PSalesReasonID",size:100, 11, DbType.Int32,ParameterDirection.Input)
                 };

                _db.Update("UPDATE Sales.SalesReason Set Name = @PName  ,ReasonType = @PReasonType where SalesReasonID = @PSalesReasonID ", CommandType.Text, out msgType, out msgText, param);

                MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteDataSample()
        {
            try
            {
                IDbDataParameter[] param = new[]
                 {
                    _db.CreateParameter("@PSalesReasonID",size:100, 11, DbType.Int32,ParameterDirection.Input)
                };

                _db.Delete("Delete from Sales.SalesReason where SalesReasonID = @PSalesReasonID ", CommandType.Text, out msgType, out msgText, param);

                MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                //_db.Insert("INSERT INTO Sales.SalesReason (Name ,ReasonType) VALUES (@PName ,@PReasonType)", CommandType.Text, out msgType, out msgText, param);

                //MessageBox.Show(msgText);
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