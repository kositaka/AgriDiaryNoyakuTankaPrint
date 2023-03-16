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
    class ClassNoyaku
    {
        public ClassNoyaku()
        {

        }

        public bool SM_NOYAKU_Count(ref string o_strCount, string i_NoyakuCd, string i_HanbaihinCd, string i_NotiCd, string i_Nendo, string i_id, string i_pass)
        {
            // DataSetを準備する
            DataSet Ds_SD_SAGYO_TBL = new DataSet();

            // SQLをセットする
            string strSQL_Noyaku = "SELECT ";
            strSQL_Noyaku += " COUNT(SEL_DATA.SD_SAGYO_NOYAKU_CD) AS CNT  ";
            strSQL_Noyaku += " FROM ( SELECT ";
            strSQL_Noyaku += " SD_SAGYO_TBL.SD_SAGYO_NOYAKU_CD1 AS SD_SAGYO_NOYAKU_CD";
            strSQL_Noyaku += " FROM dbo.SD_SAGYO_TBL ";
            strSQL_Noyaku += " WHERE SD_SAGYO_YMD >= CONVERT(DateTime,'" + i_Nendo + "/01/01',120)";
            strSQL_Noyaku += " AND   SD_SAGYO_YMD <= CONVERT(DateTime,'" + i_Nendo + "/12/31',120)";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_RIRE1 = '0' ";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_RIRE2 = '0' ";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_RIRE3 = '0' ";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_CD1 IS NOT NULL ";
            strSQL_Noyaku += " AND SD_SAGYO_HANBAIHIN_CD IS NOT NULL ";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_CD1 = '" + i_NoyakuCd + "'";
            strSQL_Noyaku += " AND SD_SAGYO_HANBAIHIN_CD = '" + i_HanbaihinCd + "'";
            strSQL_Noyaku += " AND SD_SAGYO_NOTI_CD = '" + i_NotiCd + "'";
            strSQL_Noyaku += " UNION ALL ";
            strSQL_Noyaku += " SELECT ";
            strSQL_Noyaku += " SD_SAGYO_TBL.SD_SAGYO_NOYAKU_CD2 AS SD_SAGYO_NOYAKU_CD";
            strSQL_Noyaku += " FROM dbo.SD_SAGYO_TBL  ";
            strSQL_Noyaku += " WHERE SD_SAGYO_YMD >= CONVERT(DateTime,'" + i_Nendo + "/01/01',120)";
            strSQL_Noyaku += " AND   SD_SAGYO_YMD <= CONVERT(DateTime,'" + i_Nendo + "/12/31',120)";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_RIRE1 = '0' ";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_RIRE2 = '0' ";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_RIRE3 = '0' ";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_CD2 IS NOT NULL ";
            strSQL_Noyaku += " AND SD_SAGYO_HANBAIHIN_CD IS NOT NULL ";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_CD2 = '" + i_NoyakuCd + "'";
            strSQL_Noyaku += " AND SD_SAGYO_HANBAIHIN_CD = '" + i_HanbaihinCd + "'";
            strSQL_Noyaku += " AND SD_SAGYO_NOTI_CD = '" + i_NotiCd + "'";
            strSQL_Noyaku += " UNION ALL ";
            strSQL_Noyaku += " SELECT ";
            strSQL_Noyaku += " SD_SAGYO_TBL.SD_SAGYO_NOYAKU_CD3 AS SD_SAGYO_NOYAKU_CD";
            strSQL_Noyaku += " FROM dbo.SD_SAGYO_TBL  ";
            strSQL_Noyaku += " WHERE SD_SAGYO_YMD >= CONVERT(DateTime,'" + i_Nendo + "/01/01',120)";
            strSQL_Noyaku += " AND   SD_SAGYO_YMD <= CONVERT(DateTime,'" + i_Nendo + "/12/31',120)";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_RIRE1 = '0' ";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_RIRE2 = '0' ";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_RIRE3 = '0' ";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_CD3 IS NOT NULL ";
            strSQL_Noyaku += " AND SD_SAGYO_HANBAIHIN_CD IS NOT NULL ";
            strSQL_Noyaku += " AND SD_SAGYO_NOYAKU_CD3 = '" + i_NoyakuCd + "'";
            strSQL_Noyaku += " AND SD_SAGYO_NOTI_CD = '" + i_NotiCd + "'";
            strSQL_Noyaku += " AND SD_SAGYO_HANBAIHIN_CD = '" + i_HanbaihinCd + "' ) SEL_DATA ";

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=SUPRE-PC\SQLEXPRESS;Initial Catalog=YUMEDB;User Id=" + i_id.Trim() + "; Password= " + i_pass.Trim() + "; ";

            // 接続します。
            conn.Open();

            // 非接続（Open=>Select=>Close）実行
            SqlDataAdapter sqlda = new SqlDataAdapter(strSQL_Noyaku, conn);

            sqlda.Fill(Ds_SD_SAGYO_TBL, "SD_SAGYO_TBL");

            // 接続を解除
            conn.Close();

            // SQLでSELECTされた結果が１件であるかどうかチェックする。
            int row_cnt = 0;                                    // SELECT件数

            // SELECTしたROW件数を取得
            row_cnt = Ds_SD_SAGYO_TBL.Tables["SD_SAGYO_TBL"].Rows.Count;

            foreach (DataRow row_SD_SAGYO in Ds_SD_SAGYO_TBL.Tables["SD_SAGYO_TBL"].Rows)
            {
                o_strCount = row_SD_SAGYO["CNT"].ToString().Trim();
                break;
            }

            return true;
        }


        public bool SM_NOYAKU_DataSet(ref DataSet o_DataSet_Noyaku, string i_KinMusi, string i_id, string i_pass)
        {
            // DataSetを準備する
            DataSet Ds_SM_NOYAKU_TBL = new DataSet();

            string strSQL = "SELECT ";
            strSQL += " SM_NOYAKU_TBL.SM_NOYAKU_CD, ";
            strSQL += " SM_NOYAKU_TBL.SM_NOYAKU_NAME ";
            strSQL += "     FROM dbo.SM_NOYAKU_TBL ";
            strSQL += " WHERE SM_NOYAKU_KBN_SAKKIN_MUSI = '" + i_KinMusi + "' ";
            strSQL += " ORDER BY SM_NOYAKU_CD ";

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=SUPRE-PC\SQLEXPRESS;Initial Catalog=YUMEDB;User Id=" + i_id.Trim() + "; Password= " + i_pass.Trim() + "; ";

            // 接続します。
            conn.Open();

            // 非接続（Open=>Select=>Close）実行
            SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, conn);

            sqlda.Fill(Ds_SM_NOYAKU_TBL, "SM_NOYAKU_TBL");

            // 接続を解除
            conn.Close();

            o_DataSet_Noyaku = Ds_SM_NOYAKU_TBL;

            return true;
        }

        /// <summary>
        /// 農薬倍率マスタを検索
        /// </summary>
        /// <param name="o_ryo_g"></param>
        /// <param name="i_Bairitu"></param>
        /// <param name="i_Omosa"></param>
        /// <param name="i_id"></param>
        /// <param name="i_pass"></param>
        /// <returns></returns>
        public bool CalcNoyakuRyo(ref double o_ryo_g, string i_Bairitu, string i_Omosa, string i_id, string i_pass)
        {
            string strSQL = string.Empty;

            // DataSetを準備する
            DataSet Ds_SM_BAIRITU_TBL = new DataSet();

            // SQL Set Timestamp型をTO_CHARで変換しただけでは成功しない。AS文でRENAMEする
            strSQL = "SELECT * FROM dbo.SM_BAIRITU_TBL ";
            strSQL += " WHERE SM_BAIRITU_CD = '" + i_Bairitu.Trim().PadLeft(4, '0') + "' ";
            strSQL += " ORDER BY SM_BAIRITU_CD";

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=SUPRE-PC\SQLEXPRESS;Initial Catalog=YUMEDB;User Id=" + i_id.Trim() + "; Password= " + i_pass.Trim() + "; ";

            // 接続します。
            conn.Open();

            // 非接続（Open=>Select=>Close）実行
            SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, conn);

            sqlda.Fill(Ds_SM_BAIRITU_TBL, "SM_BAIRITU_TBL");

            // 接続を解除
            conn.Close();

            // SQLでSELECTされた結果が１件であるかどうかチェックする。
            int row_cnt = 0;                                    // SELECT件数

            // SELECTしたROW件数を取得
            row_cnt = Ds_SM_BAIRITU_TBL.Tables["SM_BAIRITU_TBL"].Rows.Count;

            // ＜DuplicateKey（重複キー）チェック＞SQLでSELECTされた結果が1件であるかどうかチェックする。 
            if (row_cnt > 1)
            {
                return false;
            }

            double nouyaku_ryo = 0;

            if (row_cnt == 1)
            {
                foreach (DataRow row_BAIRITU in Ds_SM_BAIRITU_TBL.Tables["SM_BAIRITU_TBL"].Rows)
                {
                    nouyaku_ryo = (Convert.ToDouble(row_BAIRITU["SM_BAIRITU_SUU"].ToString().Trim()) * Convert.ToDouble(i_Omosa.Trim())) / 10;
                }

                o_ryo_g = nouyaku_ryo;
            }
            else
            {
                o_ryo_g = 0;
            }

            return true;
        }

        /// <summary>
        /// 農薬名称の取得
        /// </summary>
        /// <param name="o_Name"></param>
        /// <param name="i_NoyakuCd"></param>
        /// <param name="i_id"></param>
        /// <param name="i_pass"></param>
        /// <returns></returns>
		public bool GetNoyakuName(ref string o_Name, string i_NoyakuCd, string i_id, string i_pass)
        {
            string strSQL = string.Empty;

            // DataSetを準備する
            DataSet Ds_SM_NOYAKU_TBL = new DataSet();

            // SQL Set Timestamp型をTO_CHARで変換しただけでは成功しない。AS文でRENAMEする
            strSQL = "SELECT * FROM dbo.SM_NOYAKU_TBL ";
            strSQL += " WHERE SM_NOYAKU_CD = '" + i_NoyakuCd.Trim() + "' ";
            strSQL += " ORDER BY SM_NOYAKU_CD";

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=SUPRE-PC\SQLEXPRESS;Initial Catalog=YUMEDB;User Id=" + i_id.Trim() + "; Password= " + i_pass.Trim() + "; ";

            // 接続します。
            conn.Open();

            // 非接続（Open=>Select=>Close）実行
            SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, conn);

            sqlda.Fill(Ds_SM_NOYAKU_TBL, "SM_NOYAKU_TBL");

            // 接続を解除
            conn.Close();

            // SQLでSELECTされた結果が１件であるかどうかチェックする。
            int row_cnt = 0;                                    // SELECT件数

            // SELECTしたROW件数を取得
            row_cnt = Ds_SM_NOYAKU_TBL.Tables["SM_NOYAKU_TBL"].Rows.Count;

            // ＜DuplicateKey（重複キー）チェック＞SQLでSELECTされた結果が1件であるかどうかチェックする。 
            if (row_cnt > 1)
            {
                return false;
            }

            if (row_cnt == 1)
            {
                foreach (DataRow row_SM_NOYAKU in Ds_SM_NOYAKU_TBL.Tables["SM_NOYAKU_TBL"].Rows)
                {
                    if (row_SM_NOYAKU["SM_NOYAKU_KBN_SAKKIN_MUSI"].ToString().Trim() == "1")
                    {
                        o_Name = "菌 " + row_SM_NOYAKU["SM_NOYAKU_NAME"].ToString().Trim();
                    }

                    if (row_SM_NOYAKU["SM_NOYAKU_KBN_SAKKIN_MUSI"].ToString().Trim() == "2")
                    {
                        o_Name = "虫 " + row_SM_NOYAKU["SM_NOYAKU_NAME"].ToString().Trim();
                    }

                    if (row_SM_NOYAKU["SM_NOYAKU_KBN_SAKKIN_MUSI"].ToString().Trim() == "9")
                    {
                        o_Name = "他 " + row_SM_NOYAKU["SM_NOYAKU_NAME"].ToString().Trim();
                    }
                }
            }
            else
            {
                o_Name = "";
            }

            return true;
        }

        /// <summary>
        /// 農薬単価の取得
        /// </summary>
        /// <param name="o_1Honml"></param>
        /// <param name="o_Tanka"></param>
        /// <param name="i_NoyakuCd"></param>
        /// <param name="i_id"></param>
        /// <param name="i_pass"></param>
        /// <returns></returns>
		public bool GetNoyakuTanka(ref string o_1Honml, ref string o_Tanka, string i_NoyakuCd, string i_id, string i_pass)
        {
            string strSQL = string.Empty;

            // DataSetを準備する
            DataSet Ds_SM_NOYAKU_TBL = new DataSet();

            // SQL Set Timestamp型をTO_CHARで変換しただけでは成功しない。AS文でRENAMEする
            strSQL = "SELECT * FROM dbo.SM_NOYAKU_TBL ";
            strSQL += " WHERE SM_NOYAKU_CD = '" + i_NoyakuCd.Trim() + "' ";
            strSQL += " ORDER BY SM_NOYAKU_CD";

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=SUPRE-PC\SQLEXPRESS;Initial Catalog=YUMEDB;User Id=" + i_id.Trim() + "; Password= " + i_pass.Trim() + "; ";

            // 接続します。
            conn.Open();

            // 非接続（Open=>Select=>Close）実行
            SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, conn);

            sqlda.Fill(Ds_SM_NOYAKU_TBL, "SM_NOYAKU_TBL");

            // 接続を解除
            conn.Close();

            // SQLでSELECTされた結果が１件であるかどうかチェックする。
            int row_cnt = 0;                                    // SELECT件数

            // SELECTしたROW件数を取得
            row_cnt = Ds_SM_NOYAKU_TBL.Tables["SM_NOYAKU_TBL"].Rows.Count;

            // ＜DuplicateKey（重複キー）チェック＞SQLでSELECTされた結果が1件であるかどうかチェックする。 
            if (row_cnt > 1)
            {
                return false;
            }

            if (row_cnt == 1)
            {
                foreach (DataRow row_SM_NOYAKU in Ds_SM_NOYAKU_TBL.Tables["SM_NOYAKU_TBL"].Rows)
                {
                    o_1Honml = row_SM_NOYAKU["SM_NOYAKU_RYO"].ToString().Trim();
                    o_Tanka = row_SM_NOYAKU["SM_NOYAKU_TANKA"].ToString().Trim();
                }
            }
            else
            {
                o_1Honml = "";
                o_Tanka = "";
            }

            return true;
        }

        /// <summary>
        /// 販売品農薬マスタの取得
        /// </summary>
        /// <param name="o_Name"></param>
        /// <param name="i_NoyakuCd"></param>
        /// <param name="i_id"></param>
        /// <param name="i_pass"></param>
        /// <returns></returns>
        public bool getNoyakuHanbaihinNisuu(ref int o_KonoNisuu, string i_HanbaihinCd, string i_NoyakuCd, string i_id, string i_pass)
        {
            string strSQL = string.Empty;

            // DataSetを準備する
            DataSet Ds_SM_NOYAKU_HANBAIHIN_TBL = new DataSet();

            // SQL Set Timestamp型をTO_CHARで変換しただけでは成功しない。AS文でRENAMEする
            strSQL = "SELECT * FROM dbo.SM_NOYAKU_HANBAIHIN_TBL ";
            strSQL += " WHERE SM_NH_HANBAIHIN_CD = '" + i_HanbaihinCd.Trim() + "' ";
            strSQL += " AND SM_NH_NOYAKU_CD = '" + i_NoyakuCd.Trim() + "' ";
            strSQL += " ORDER BY SM_NH_HANBAIHIN_CD,SM_NH_NOYAKU_CD";

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=SUPRE-PC\SQLEXPRESS;Initial Catalog=YUMEDB;User Id=" + i_id.Trim() + "; Password= " + i_pass.Trim() + "; ";

            // 接続します。
            conn.Open();

            // 非接続（Open=>Select=>Close）実行
            SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, conn);

            sqlda.Fill(Ds_SM_NOYAKU_HANBAIHIN_TBL, "SM_NOYAKU_HANBAIHIN_TBL");

            // 接続を解除
            conn.Close();

            // SQLでSELECTされた結果が１件であるかどうかチェックする。
            int row_cnt = 0;                                    // SELECT件数

            // SELECTしたROW件数を取得
            row_cnt = Ds_SM_NOYAKU_HANBAIHIN_TBL.Tables["SM_NOYAKU_HANBAIHIN_TBL"].Rows.Count;

            // ＜DuplicateKey（重複キー）チェック＞SQLでSELECTされた結果が1件であるかどうかチェックする。 
            if (row_cnt > 1)
            {
                return false;
            }

            if (row_cnt == 1)
            {
                foreach (DataRow row_SM_NOYAKU_HANBAIHIN in Ds_SM_NOYAKU_HANBAIHIN_TBL.Tables["SM_NOYAKU_HANBAIHIN_TBL"].Rows)
                {
                    if (row_SM_NOYAKU_HANBAIHIN["SM_NH_SIYO_JIKI_DAY"].ToString().Trim() != "")
                    {

                        o_KonoNisuu = Convert.ToInt16(row_SM_NOYAKU_HANBAIHIN["SM_NH_SIYO_JIKI_DAY"].ToString().Trim());
                    }
                    else
                    {
                        o_KonoNisuu = 0;
                    }
                }
            }
            else
            {
                o_KonoNisuu = 0;
            }

            return true;
        }

        /// <summary>
        /// 販売品農薬マスタの有無
        /// </summary>
        /// <param name="i_HanbaihinCd"></param>
        /// <param name="i_NoyakuCd"></param>
        /// <param name="i_id"></param>
        /// <param name="i_pass"></param>
        /// <returns></returns>
        public bool SeekNoyakuHanbaihin(string i_HanbaihinCd, string i_NoyakuCd, string i_id, string i_pass)
        {
            string strSQL = string.Empty;

            // DataSetを準備する
            DataSet Ds_SM_NOYAKU_HANBAIHIN_TBL = new DataSet();

            // SQL Set Timestamp型をTO_CHARで変換しただけでは成功しない。AS文でRENAMEする
            strSQL = "SELECT * FROM dbo.SM_NOYAKU_HANBAIHIN_TBL ";
            strSQL += " WHERE SM_NH_HANBAIHIN_CD = '" + i_HanbaihinCd.Trim() + "' ";
            strSQL += " AND SM_NH_NOYAKU_CD = '" + i_NoyakuCd.Trim() + "' ";
            strSQL += " ORDER BY SM_NH_HANBAIHIN_CD,SM_NH_NOYAKU_CD";

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=SUPRE-PC\SQLEXPRESS;Initial Catalog=YUMEDB;User Id=" + i_id.Trim() + "; Password= " + i_pass.Trim() + "; ";

            // 接続します。
            conn.Open();

            // 非接続（Open=>Select=>Close）実行
            SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, conn);

            sqlda.Fill(Ds_SM_NOYAKU_HANBAIHIN_TBL, "SM_NOYAKU_HANBAIHIN_TBL");

            // 接続を解除
            conn.Close();

            // SQLでSELECTされた結果が１件であるかどうかチェックする。
            int row_cnt = 0;                                    // SELECT件数

            // SELECTしたROW件数を取得
            row_cnt = Ds_SM_NOYAKU_HANBAIHIN_TBL.Tables["SM_NOYAKU_HANBAIHIN_TBL"].Rows.Count;

            // ＜DuplicateKey（重複キー）チェック＞SQLでSELECTされた結果が1件であるかどうかチェックする。 
            if (row_cnt < 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 販売品農薬マスタの取得（詳細）
        /// </summary>
        /// <param name="o_Name"></param>
        /// <param name="i_NoyakuCd"></param>
        /// <param name="i_id"></param>
        /// <param name="i_pass"></param>
        /// <returns></returns>
        public bool getNoyakuHanbaihin(ref int o_iKisyakubairitu,
                                          ref string o_strSanpuTani,
                                        string i_HanbaihinCd, string i_NoyakuCd, string i_id, string i_pass)
        {
            string strSQL = string.Empty;

            // DataSetを準備する
            DataSet Ds_SM_NOYAKU_HANBAIHIN_TBL = new DataSet();

            // SQL Set Timestamp型をTO_CHARで変換しただけでは成功しない。AS文でRENAMEする
            strSQL = "SELECT * FROM dbo.SM_NOYAKU_HANBAIHIN_TBL ";
            strSQL += " WHERE SM_NH_HANBAIHIN_CD = '" + i_HanbaihinCd.Trim() + "' ";
            strSQL += " AND SM_NH_NOYAKU_CD = '" + i_NoyakuCd.Trim() + "' ";
            strSQL += " ORDER BY SM_NH_HANBAIHIN_CD,SM_NH_NOYAKU_CD";

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=SUPRE-PC\SQLEXPRESS;Initial Catalog=YUMEDB;User Id=" + i_id.Trim() + "; Password= " + i_pass.Trim() + "; ";

            // 接続します。
            conn.Open();

            // 非接続（Open=>Select=>Close）実行
            SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, conn);

            sqlda.Fill(Ds_SM_NOYAKU_HANBAIHIN_TBL, "SM_NOYAKU_HANBAIHIN_TBL");

            // 接続を解除
            conn.Close();

            // SQLでSELECTされた結果が１件であるかどうかチェックする。
            int row_cnt = 0;                                    // SELECT件数

            // SELECTしたROW件数を取得
            row_cnt = Ds_SM_NOYAKU_HANBAIHIN_TBL.Tables["SM_NOYAKU_HANBAIHIN_TBL"].Rows.Count;

            // ＜DuplicateKey（重複キー）チェック＞SQLでSELECTされた結果が1件であるかどうかチェックする。 
            if (row_cnt > 1)
            {
                return false;
            }

            if (row_cnt == 1)
            {
                foreach (DataRow row_SM_NOYAKU_HANBAIHIN in Ds_SM_NOYAKU_HANBAIHIN_TBL.Tables["SM_NOYAKU_HANBAIHIN_TBL"].Rows)
                {
                    if (row_SM_NOYAKU_HANBAIHIN["SM_NH_NOYAKU_JISSAI_KISYAKU"].ToString().Trim() != "")
                    {
                        o_iKisyakubairitu = Convert.ToInt32(row_SM_NOYAKU_HANBAIHIN["SM_NH_NOYAKU_JISSAI_KISYAKU"].ToString());
                        o_strSanpuTani = row_SM_NOYAKU_HANBAIHIN["SM_NH_NOYAKU_SANPU_TANI"].ToString();
                    }
                }
            }
            else
            {
                o_iKisyakubairitu = 0;
                o_strSanpuTani = "";
            }

            return true;
        }


    }
}
