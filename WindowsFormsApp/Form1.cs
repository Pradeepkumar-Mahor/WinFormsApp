using System.Data;
using System.Windows.Forms;
using System;
using AdODotNetFramework;

namespace WindowsFormsApp
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private DBManager _db = new DBManager("SqlServerConnection");
        private DataTable talData = null;
        private string msgType = "";
        private string msgText = "";

        public Form1()
        {
            InitializeComponent();
            ReadData();
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

                talData = _db.GetDataTable(strQry, CommandType.Text);

                advancedDataGridView.DataSource = talData;

                //_db.Insert("INSERT INTO Sales.SalesReason (Name ,ReasonType) VALUES (@PName ,@PReasonType)", CommandType.Text, out msgType, out msgText, param);

                //MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void advancedDataGridView_SortStringChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource source = new BindingSource();
                source.DataSource = advancedDataGridView.DataSource;

                advancedDataGridView.DataSource = source;
                source.Sort = advancedDataGridView.SortString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void advancedDataGridView_FilterStringChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource source = new BindingSource();
                source.DataSource = advancedDataGridView.DataSource;

                advancedDataGridView.DataSource = source;
                source.Filter = advancedDataGridView.FilterString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}