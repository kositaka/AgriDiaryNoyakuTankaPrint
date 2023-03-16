using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgriDiaryNoyakuTankaPrint
{
    class ClassHanbaihinMst
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ClassHanbaihinMst()
        {

        }

        public bool SM_HANBAIHIN_DataSet(ref DataSet o_DataSet_Hanbaihin, string i_id, string i_pass)
        {
            // DataSetを準備する
            DataSet Ds_SM_HANBAIHIN_TBL = new DataSet();

            string strSQL = "SELECT ";
            strSQL += " SM_HANBAIHIN_CD, ";
            strSQL += " SM_HANBAIHIN_NAME ";
            strSQL += "     FROM dbo.SM_HANBAIHIN_TBL ";
            strSQL += " ORDER BY SM_HANBAIHIN_CD ";

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=SUPRE-PC\SQLEXPRESS;Initial Catalog=YUMEDB;User Id=" + i_id.Trim() + "; Password= " + i_pass.Trim() + "; ";

            // 接続します。
            conn.Open();

            // 非接続（Open=>Select=>Close）実行
            SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, conn);

            sqlda.Fill(Ds_SM_HANBAIHIN_TBL, "SM_HANBAIHIN_TBL");

            // 接続を解除
            conn.Close();

            o_DataSet_Hanbaihin = Ds_SM_HANBAIHIN_TBL;

            return true;
        }
    }
}
