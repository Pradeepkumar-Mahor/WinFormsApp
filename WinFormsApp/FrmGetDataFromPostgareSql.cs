using DbAccess;
using System.Data;

namespace WinFormsApp
{
    public partial class FrmGetDataFromPostgareSql : Form
    {
        private readonly DBManager _db = new("PostgareSqlConnection");

        private string msgType = "";
        private string msgText = "";

        public FrmGetDataFromPostgareSql()
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
                string strQry = $@"SELECT item_id, item_name, serial_number,
                            bottom_md, bottom_md_uom, top_md, top_md_uom, bottom_tvd, bottom_tvd_uom, top_tvd, top_tvd_uom, id, id_uom,
                            weight_per_len, weight_per_len_uom, od, od_uom, joints, set_depth, set_depth_uom, id_drift_dia,
                            id_drift_dia_uom, id_min_dia, id_min_dia_uom, length, length_uom, make_up_length, make_up_length_uom,
                            od_coupling, od_coupling_uom, od_max, od_max_uom, wall_thickness, wall_thickness_uom, weight,
                            weight_uom, radial_offset, radial_offset_uom, comments, condition, condition_text, top_conn_config,
                            top_conn_config_text, top_conn_size, top_conn_size_uom, top_conn_type, top_conn_type_text, top_conn_weight,
                            top_conn_weight_uom, bot_conn_config, bot_conn_config_text, bot_conn_size, bot_conn_size_uom, bot_conn_type,
                            bot_conn_type_text, bot_conn_weight, bot_conn_weight_uom, legacy_id, material_req, material_req_text,
                            material_wetted, material_wetted_text, grade, grade_text, manufacturer, manufacturer_text, model_series,
                            model, max_pressure, max_pressure_uom, pressure_rating, pressure_rating_text, max_temperature,
                            max_temperature_uom, min_temperature, min_temperature_uom, ext_work_press, ext_work_press_uom,
                            int_work_press, int_work_press_uom, work_press_temp, work_press_temp_uom, hyd_test_press, hyd_test_press_uom,
                            hyd_test_temp, hyd_test_temp_uom, max_makeup_tor, max_makeup_tor_uom, min_makeup_tor, min_makeup_tor_uom,
                            op_torque, op_torque_uom, nace_sour, burst_press, burst_press_uom, burst_temp, burst_temp_uom, collapse_press,
                            collapse_press_uom, collapse_temp, collapse_temp_uom, compression, compression_uom, tension, tension_uom,
                            tensile_stress, tensile_stress_uom, yield_stress, yield_stress_uom, elastic_modulus, hardness_brinel,
                            poissons_ratio, category, hidden, config_id, shape, stencil, z_index, data_status, data_status_text, latitude, longitude, send_to_avalon,
                            external_id, active, x, y, spheroid, spheroid_text, north, zone, area_polygon, surface_line, time_zone, prosource_id, prosource_type,
                            color, catalog_id
	                            FROM public.vi_catalog_wbs_en_us;";

                DataTable talData = _db.GetDataTable(strQry, CommandType.Text);
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