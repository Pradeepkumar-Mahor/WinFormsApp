using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class SampleClass
    {
        private DBManager _db = new DBManager("MyConn");

        private string msgType = "";
        private string msgText = "";

        public void ReadData()
        {
            try
            {
                DataTable talData = _db.GetDataTable("SELECT * from Production.Product", CommandType.Text);
                //dataGridView.DataSource = talData;

                //IDbDataParameter[] param = new[]
                //{
                //    _db.CreateParameter("@PName",size:100, "Microsoft PWA", DbType.String,ParameterDirection.Input),
                //    _db.CreateParameter("@PReasonType",size:100, "Microsoft PWA Type", DbType.String,ParameterDirection.Input)
                // };

                //_db.Insert("INSERT INTO Sales.SalesReason (Name ,ReasonType) VALUES (@PName ,@PReasonType)", CommandType.Text, out msgType, out msgText, param);

                //MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                throw;
                // MessageBox.Show(ex.Message);
            }
        }

        public void ReadSingleRecord()
        {
            try
            {
                IDbDataParameter[] param = new[]
                {
                    _db.CreateParameter("@PSalesReasonID",size:100, 11, DbType.Int32,ParameterDirection.Input)
                };

                var dataReader = _db.GetDataReader("SELECT * from Sales.SalesReason where SalesReasonID = @PSalesReasonID ", CommandType.Text, param);
                //while (dataReader.Read())
                //{
                //    MessageBox.Show(dataReader.GetInt32(0) + ", " + dataReader.GetString(1));
                //}
            }
            catch (Exception ex)
            {
                throw;
                // MessageBox.Show(ex.Message);
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

                //MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                throw;
                // MessageBox.Show(ex.Message);
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

                //MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                throw;
                // MessageBox.Show(ex.Message);
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

                //MessageBox.Show(msgText);
            }
            catch (Exception ex)
            {
                throw;
                // MessageBox.Show(ex.Message);
            }
        }
    }
}