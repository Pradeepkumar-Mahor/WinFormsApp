using DbAccess;
using System.Data;

namespace WinFormsApp
{
    public partial class FrmGetDataFromSqLite : MetroFramework.Forms.MetroForm
    {
        private readonly DBManager _db = new("SqLiteConnection");

        private string msgType = "";
        private string msgText = "";

        public FrmGetDataFromSqLite()
        {
            InitializeComponent();
            //DeleteDataSample();
            ReadData();
            //InsertDataSample();
            //UpdateDataSample();
            //ReadSingleRecord();
            //DeleteDataSample();
        }

        public void ReadData()
        {
            try
            {
                string strQry = $@"Select
                            Manufacturer ,
                            Part_Number as ""Part Number"",
                            Part_Description as ""Part Description"",
                            Input_Voltage as ""Input Voltage"",
                            Input_Voltage_Type as ""Input Voltage Type"",
                            Input_Current as ""Input Current"",
                            Inrush_Current as ""Inrush Current"",
                            Recommended_Protection_Device_Rating_MCB_C_curve as ""Recommended Protection Device Rating MCB C curve"",
                            IP_wire_size_AWG as ""IP wire size AWG"",
                            IP_wire_size_Sq_mm as ""IP wire size Sq mm"",
                            Output_Voltage as ""Output Voltage"",
                            Output_Current as ""Output Current"",
                            Output_Rating as ""Output Rating"",
                            Power_factor as ""Power factor"",
                            Output_Protection_Device_Rating as ""Output Protection Device Rating"",
                            OP_Wire_size_AWG as ""OP Wire size AWG"",
                            OP_wire_size_Sq_mm as ""OP wire size Sq mm"",
                            Power_Loss_watt as ""Power Loss watt"",
                            Efficiency as ""Efficiency"",
                            Dimension_W_x_H_x_D as ""Dimension W x H x D"",
                            Certifications as ""Certifications"",
                            Temp as ""Temp"",
                            Hazardous_Location as ""Hazardous Location""
                        from Power_Supply
                            where Manufacturer = ifnull(@Pmanufacturer,Manufacturer)";
                IDbDataParameter[] param = new[]
                {
                          _db.CreateParameter("@Pmanufacturer","Phoenix Contact", DbType.String)
                          //_db.CreateParameter("@Pmanufacturer",null, DbType.String)
                        };
                DataTable talData = _db.GetDataTable(strQry, CommandType.Text, param);
                dataGridView.DataSource = talData;

                //_db.Insert("INSERT INTO Sales.SalesReason (Name ,ReasonType) VALUES (@PName ,@PReasonType)", CommandType.Text, out msgType, out msgText, param);

                //MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
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

                IDataReader dataReader = _db.GetDataReader("SELECT * from Sales.SalesReason where SalesReasonID = @PSalesReasonID ", CommandType.Text, param);
                while (dataReader.Read())
                {
                    _ = MessageBox.Show(dataReader.GetInt32(0) + ", " + dataReader.GetString(1));
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
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

                _ = MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
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

                _ = MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }

        public void DeleteDataSample()
        {
            try
            {
                //IDbDataParameter[] param = new[]
                // {
                //    _db.CreateParameter("@PSalesReasonID",size:100, 11, DbType.Int32,ParameterDirection.Input)
                //};
                IDbDataParameter[] param = new[]
              {
                      _db.CreateParameter("@Pmanufacturer","Phoenix Contact", DbType.String)
                };
                _db.Delete("Delete from Power_Supply where Power_Supply.Manufacturer = @Pmanufacturer ", CommandType.Text, out msgType, out msgText, param);

                _ = MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }
    }
}