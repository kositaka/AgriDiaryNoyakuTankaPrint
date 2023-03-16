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
    class ClassSystemMst
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ClassSystemMst()
        {

        }

        /// <summary>
        /// 購入先取得 strKey = "T" + 000～099 配列で返す
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="i_id"></param>
        /// <param name="i_pass"></param>
        /// <returns></returns>
        public string[] GetASystemKeyMise(ref int o_iDataCnt, string strKey, string i_id, string i_pass)
        {
            string strSQL = "";

            // DataSetを準備する
            DataSet Ds_M_SYSTEM_TBL = new DataSet();

            // "T"
            string strKeyNo = string.Empty;

            // 購入先（店）配列
            string[] MiseArray = new string[100];

            // SQL Set 先頭key　"T"のデータ
            strSQL = "SELECT AM_SYSTEM_TBL.SYSTEM_KEY, ";
            strSQL += " AM_SYSTEM_TBL.SYSTEM_DATA, ";
            strSQL += " AM_SYSTEM_TBL.SYSTEM_TYPE, ";
            strSQL += " AM_SYSTEM_TBL.SYSTEM_LENGTH, ";
            strSQL += " AM_SYSTEM_TBL.SYSTEM_EXP, ";
            strSQL += " AM_SYSTEM_TBL.INFORMATION_CD,";
            strSQL += "CONVERT(VARCHAR, TIMESTAMP_REC,  120) AS TIMESTAMP_REC ";
            strSQL += "		FROM dbo.AM_SYSTEM_TBL ";
            strSQL += "		WHERE SYSTEM_KEY  LIKE '" + strKey + "%'";
            strSQL += " ORDER BY SYSTEM_KEY";

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=SUPRE-PC\SQLEXPRESS;Initial Catalog=YUMEDB;User Id=" + i_id.Trim() + "; Password= " + i_pass.Trim() + "; ";

            // 接続します。
            conn.Open();

            // 非接続（Open=>Select=>Close）実行
            SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, conn);

            sqlda.Fill(Ds_M_SYSTEM_TBL, "M_SYSTEM_TBL");

            // 接続を解除
            conn.Close();

            // SELECT件数
            int data_cnt = 0;

            // SELECTしたROW件数を取得
            data_cnt = Ds_M_SYSTEM_TBL.Tables["M_SYSTEM_TBL"].Rows.Count;

            // Data Cntを返す
            o_iDataCnt = data_cnt;

            int i = 0;

            if (data_cnt > 0)
            {
                foreach (DataRow row_M_SYSTEM in Ds_M_SYSTEM_TBL.Tables["M_SYSTEM_TBL"].Rows)
                {
                    if (i == data_cnt) break;

                    if (row_M_SYSTEM["SYSTEM_DATA"].ToString().Trim() != "")
                    {
                        MiseArray[i] = row_M_SYSTEM["SYSTEM_DATA"].ToString().Trim();

                        i++;
                    }
                }
            }

            return MiseArray;
        }
    }
}
