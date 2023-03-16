//////////////////////////////////////////////////////////////////////////////////////////////
// 
// 	システム名	    ：ゆめみるきかいプログラム管理システム	
// 
// 	プログラム名	：AgriDiarySizaiInput.exe
//	ソースプログラム：AllMainForm.cs
// 	開発言語		：VisualStudio.Net C# 2019
// 	処理内容		：資材購入品データ入力処理
// 	著作権			：有限会社　ゆめみるきかい
// 	作成者			：越高 日出夫
// 	完成日（西暦）	：2022/02/16
// 	バージョン		：Ver 1.0.0
// 	備考			：
// 
//////////////////////////////////////////////////////////////////////////////////////////////
// 	このソースプログラムは、有限会社　ゆめみるきかいの所有する情報を含み、
// 	著作権法によって保護されています。
// 	したがって、著作物の文書による許諾を行わずに、本ソースプログラムを複写、
// 	または、再生産することを禁じます。
//////////////////////////////////////////////////////////////////////////////////////////////
using ClosedXML;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YumeClassLibrary;

namespace AgriDiaryNoyakuTankaPrint
{
    public partial class AllMainForm : Form
    {
        // SQLServer用ID・PASSWORD
        private string sqlServer_id = "sa";
        private string sqlServer_pass = "VTeP8vWI";
        private string sqlServer_dataSource;        // 接続DB

        // SQLServer ID Set
        public string copy_SQLServerID
        {
            get { return sqlServer_id; }
            set { sqlServer_id = value; }
        }
        // SQLServer Pass Set
        public string copy_SQLServerPass
        {
            get { return sqlServer_pass; }
            set { sqlServer_pass = value; }
        }
        /// <summary>
        /// プロパティ DataSource用 MainWindowsに戻す
        /// </summary>
        public string copy_DataSource
        {
            set { sqlServer_dataSource = value; }
            get { return sqlServer_dataSource; }
        }

        public AllMainForm()
        {
            InitializeComponent();

            // ==============================================================
            // コンストラクタ
            // ==============================================================

        }

        /// <summary>
        /// 初画面ロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllMainForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            // ボタンの背景色を変更する--------------------------------------------------------------------
            // 背景色を変更するボタンの数だけ設定
            ClassButtonColor buttonColor = new ClassButtonColor();
            Bitmap bmp_Button = new Bitmap(button_Quit.Width, button_Quit.Height);
            buttonColor.SetButtonColor(ref bmp_Button, button_Quit.Width, button_Quit.Height);

            button_Quit.Image = bmp_Button;
            button_Seek.Image = bmp_Button;
            button_Prn.Image = bmp_Button;
            button_Print.Image = bmp_Button;
            buttonF3.Image = bmp_Button;
            // ボタンの背景色を変更する--------------------------------------------------------------------

            // SQLServer接続データソースをセット
            sqlServer_dataSource = Constants.AGRI_PC + sqlServer_id.Trim() + "; Password= " + sqlServer_pass.Trim() + "; ";

            this.comboBox_KinMusi.SelectedIndex = 0;

            // 年度セット
            NendoSet();

            this.dateTimePicker_From.Value = DateTime.Parse(this.comboBox_Nendo.Text.Trim() + "/01/01");
            this.dateTimePicker_To.Value = DateTime.Parse(this.comboBox_Nendo.Text.Trim() + "/12/31");

            checkBox_Ja.Checked = true;

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 年度セット
        /// </summary>
        public void NendoSet()
        {
            string strNendo_Start = "";
            string strNendo_End = "";

            // 年度開始日をシステム管理マスタキー[N001]から検索しセットする
            CSystemMst sys = new CSystemMst();
            if (sys.GetASystemKey(ref strNendo_Start, "Q001", sqlServer_id, sqlServer_pass) == false) { strNendo_Start = ""; }

            // 年度終了日をシステム管理マスタキー[N001]から検索しセットする
            if (sys.GetASystemKey(ref strNendo_End, "Q002", sqlServer_id, sqlServer_pass) == false) { strNendo_End = ""; }

            // 年度
            string strNendo_Sv = strNendo_Start.ToString().Trim().Substring(0, 4);
            int combo_index = this.comboBox_Nendo.FindString(strNendo_Sv.Trim(), -1);
            if (combo_index > 0)
            {
                this.comboBox_Nendo.SelectedIndex = combo_index;
            }
            else
            {

                this.comboBox_Nendo.SelectedIndex = 0;

            }

            this.comboBox_Nendo.Refresh();
        }

        /// <summary>
        /// 終了ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Quit_Click(object sender, EventArgs e)
        {
            this.Close();

            Application.Exit();
        }

        /// <summary>
        /// 検索ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Seek_Click(object sender, EventArgs e)
        {
            // 検索
            P_Seek();
        }

        /// <summary>
        /// 検索メッソド
        /// </summary>
        private void P_Seek()
        {
            this.Cursor = Cursors.WaitCursor;

            // SQLをセットする
            string strSQL = string.Empty;

            if ((this.checkBox_Ja.Checked == false)&&(this.checkBox_Kojin.Checked == false)&&(this.checkBox_Ippan.Checked == false))
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("チェックを付けてください。", "確認");
                return;
            }

            if (this.checkBox_Ja.Checked == true)
            {
                strSQL += "SELECT ";
                strSQL += " SM_NOYAKU_TBL.SM_NOYAKU_CD, ";
                strSQL += " CASE SM_NOYAKU_TBL.SM_NOYAKU_KBN_SAKKIN_MUSI ";
                strSQL += "     WHEN '1' THEN '殺菌剤' ";
                strSQL += "     WHEN '2' THEN '殺虫剤' ";
                strSQL += "     ELSE 'その他' ";
                strSQL += " END AS SM_NOYAKU_KBN_SAKKIN_MUSI, ";
                strSQL += " SM_NOYAKU_TBL.SM_NOYAKU_NAME, ";
                strSQL += " CASE SM_NOYAKU_TBL.SM_NOYAKU_KBN_TUBU_KONA_EKI ";
                strSQL += "     WHEN '1' THEN '粉' ";
                strSQL += "     WHEN '2' THEN '粒' ";
                strSQL += "     WHEN '3' THEN '液' ";
                strSQL += "     ELSE 'その他' ";
                strSQL += " END AS SM_NOYAKU_KBN_TUBU_KONA_EKI, ";
                strSQL += " SM_NOYAKU_TBL.SM_NOYAKU_YOKI, ";
                strSQL += " SM_SIZAI_TBL.SM_SIZAI_TANKA, ";
                strSQL += " ' ' AS TYOUSA_TANKA ";
                strSQL += "		FROM dbo.SM_NOYAKU_TBL ";
                strSQL += " LEFT JOIN dbo.SM_SIZAI_TBL ";
                strSQL += " ON SM_SIZAI_TBL.SM_SIZAI_CD = SM_NOYAKU_TBL.SM_SIZAI_CD ";
                strSQL += "	WHERE SM_NOYAKU_KBN_SAKKIN_MUSI = '" + comboBox_KinMusi.Text.Trim().Substring(0, 1) + "'";
                strSQL += "	AND   SM_NOYAKU_STOP_KBN = '0' ";
                strSQL += "	AND   SM_JA_SUISYO_KBN = '1' ";
            }
            if ((this.checkBox_Ja.Checked == true)&&(this.checkBox_Kojin.Checked == true))
            {
                strSQL += " UNION ";
                strSQL += " SELECT ";
                strSQL += " SM_NOYAKU_TBL.SM_NOYAKU_CD, ";
                strSQL += " CASE SM_NOYAKU_TBL.SM_NOYAKU_KBN_SAKKIN_MUSI ";
                strSQL += "     WHEN '1' THEN '殺菌剤' ";
                strSQL += "     WHEN '2' THEN '殺虫剤' ";
                strSQL += "     ELSE 'その他' ";
                strSQL += " END AS SM_NOYAKU_KBN_SAKKIN_MUSI, ";
                strSQL += " SM_NOYAKU_TBL.SM_NOYAKU_NAME, ";
                strSQL += " CASE SM_NOYAKU_TBL.SM_NOYAKU_KBN_TUBU_KONA_EKI ";
                strSQL += "     WHEN '1' THEN '粉' ";
                strSQL += "     WHEN '2' THEN '粒' ";
                strSQL += "     WHEN '3' THEN '液' ";
                strSQL += "     ELSE 'その他' ";
                strSQL += " END AS SM_NOYAKU_KBN_TUBU_KONA_EKI, ";
                strSQL += " SM_NOYAKU_TBL.SM_NOYAKU_YOKI, ";
                strSQL += " SM_SIZAI_TBL.SM_SIZAI_TANKA, ";
                strSQL += " ' ' AS TYOUSA_TANKA ";
                strSQL += "		FROM dbo.SM_NOYAKU_TBL ";
                strSQL += " LEFT JOIN dbo.SM_SIZAI_TBL ";
                strSQL += " ON SM_SIZAI_TBL.SM_SIZAI_CD = SM_NOYAKU_TBL.SM_SIZAI_CD ";
                strSQL += "	WHERE SM_NOYAKU_KBN_SAKKIN_MUSI = '" + comboBox_KinMusi.Text.Trim().Substring(0, 1) + "'";
                strSQL += "	AND   SM_NOYAKU_STOP_KBN = '0' ";
                strSQL += "	AND   SM_JA_SUISYO_KBN = '2' ";
            }
            if ((this.checkBox_Ja.Checked == true) && (this.checkBox_Kojin.Checked == true) && (this.checkBox_Ippan.Checked == true))
            {
                strSQL += " UNION ";
                strSQL += " SELECT ";
                strSQL += " SM_NOYAKU_TBL.SM_NOYAKU_CD, ";
                strSQL += " CASE SM_NOYAKU_TBL.SM_NOYAKU_KBN_SAKKIN_MUSI ";
                strSQL += "     WHEN '1' THEN '殺菌剤' ";
                strSQL += "     WHEN '2' THEN '殺虫剤' ";
                strSQL += "     ELSE 'その他' ";
                strSQL += " END AS SM_NOYAKU_KBN_SAKKIN_MUSI, ";
                strSQL += " SM_NOYAKU_TBL.SM_NOYAKU_NAME, ";
                strSQL += " CASE SM_NOYAKU_TBL.SM_NOYAKU_KBN_TUBU_KONA_EKI ";
                strSQL += "     WHEN '1' THEN '粉' ";
                strSQL += "     WHEN '2' THEN '粒' ";
                strSQL += "     WHEN '3' THEN '液' ";
                strSQL += "     ELSE 'その他' ";
                strSQL += " END AS SM_NOYAKU_KBN_TUBU_KONA_EKI, ";
                strSQL += " SM_NOYAKU_TBL.SM_NOYAKU_YOKI, ";
                strSQL += " SM_SIZAI_TBL.SM_SIZAI_TANKA, ";
                strSQL += " ' ' AS TYOUSA_TANKA ";
                strSQL += "		FROM dbo.SM_NOYAKU_TBL ";
                strSQL += " LEFT JOIN dbo.SM_SIZAI_TBL ";
                strSQL += " ON SM_SIZAI_TBL.SM_SIZAI_CD = SM_NOYAKU_TBL.SM_SIZAI_CD ";
                strSQL += "	WHERE SM_NOYAKU_KBN_SAKKIN_MUSI = '" + comboBox_KinMusi.Text.Trim().Substring(0, 1) + "'";
                strSQL += "	AND   SM_NOYAKU_STOP_KBN = '0' ";
                strSQL += "	AND   SM_JA_SUISYO_KBN = '0' ";
            }

            // DataSetを準備する
            DataSet Ds_SM_NOYAKU_TBL = new DataSet();

            // マシン名の取得
            string strPcName = Environment.MachineName;

            if (strPcName.Trim() == "SUPRE-PC")
            {
                // データソース
                sqlServer_dataSource = Constants.AGRI_PC + sqlServer_id.Trim().Trim() + "; Password= " + sqlServer_pass.Trim() + "; ";
            }

            // 接続開始
            SqlConnection conn = new SqlConnection();

            // データソースセット
            conn.ConnectionString = sqlServer_dataSource;

            try
            {
                // データベースのオープン
                conn.Open();

                // 非接続（Open=>Select=>Close）
                SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, conn);

                // データの取得
                sqlda.Fill(Ds_SM_NOYAKU_TBL, "SM_NOYAKU_TBL");
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show("データベースサーバーに接続できません", "確認");
                // 接続をキャンセルし戻る
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            finally
            {
                //データベースの接続終了
                conn.Close();
            }

            // 接続OK
            int data_cnt = Ds_SM_NOYAKU_TBL.Tables["SM_NOYAKU_TBL"].Rows.Count;

            // DataGridViewにデータセットを設定
            // 以下を使うと、２回目に子リストを作成できませんになる
            // 下の方のDs_Z_COM_HISTORY_TBL.Tables["Z_COM_HISTORY_TBL"]のようにTablesでセットしなければならない
            // DataGridViewにデータセットを設定
            //dataGridView_Sizai.DataMember = Ds_SM_NOYAKU_TBL.Tables["Z_ALLOC_HISTORY_TBL"].TableName;

            // データグリッドのスタイルを定義するメッソドをCallする
            // （注意）次のデータセットを設定する前に、グリッドスタイル定義をCallする必要があります。
            P_GridViewFormat();

            if (data_cnt > 0)
            {
                // DataGridViewにデータセットを設定
                // 以下を使うと、２回目に子リストを作成できませんになる
                // 下の方のDs_Z_COM_HISTORY_TBL.Tables["Z_COM_HISTORY_TBL"]のようにTablesでセットしなければならない
                // DataGridViewにデータセットを設定
                //データソースを設定する
                //this.dataGridView_Sizai.DataSource = Ds_SM_NOYAKU_TBL;

                // データグリッドにデータをセットする
                dataGridView_Noyaku.DataSource = Ds_SM_NOYAKU_TBL.Tables["SM_NOYAKU_TBL"];
            }
            else
            {
                //データソースを設定する
                this.dataGridView_Noyaku.DataSource = null;
                // Rows.Clearでは、正しくクリアされない　マイクロソフトのバグ？　Columns.Clearでなければならない
                //this.dataGridView_Sizai.Rows.Clear();
                this.dataGridView_Noyaku.Columns.Clear();
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// DataGridViewのフォーマット（外観）
        /// </summary>
        private void P_GridViewFormat()
        {
            // ---------------------------------------------------------------------------------------------------------
            // DataGridViewTextBoxColumn列を作成する
            // 既に列が存在するかチェックしないと、２回目以降のDataSet連結で、列が増えていくので注意すること
            // ---------------------------------------------------------------------------------------------------------
            // ------SM_NH_NOYAKU_CD--------------//
            if (!this.dataGridView_Noyaku.Columns.Contains("SM_NOYAKU_CD"))
            {
                DataGridViewTextBoxColumn textColumn_SM_NOYAKU_CD = new DataGridViewTextBoxColumn();
                //データソースの"TEC_GROUP"をバインドする
                textColumn_SM_NOYAKU_CD.DataPropertyName = "SM_NOYAKU_CD";
                //名前とヘッダーを設定する
                textColumn_SM_NOYAKU_CD.Name = "SM_NOYAKU_CD";
                textColumn_SM_NOYAKU_CD.HeaderText = "CD";
                //列を新規登録する
                dataGridView_Noyaku.Columns.Add(textColumn_SM_NOYAKU_CD);
            }

            // ------SM_NOYAKU_NAME--------------//
            if (!this.dataGridView_Noyaku.Columns.Contains("SM_NOYAKU_NAME"))
            {
                DataGridViewTextBoxColumn textColumn_SM_NOYAKU_NAME = new DataGridViewTextBoxColumn();
                //データソースの"TEC_GROUP"をバインドする
                textColumn_SM_NOYAKU_NAME.DataPropertyName = "SM_NOYAKU_NAME";
                //名前とヘッダーを設定する
                textColumn_SM_NOYAKU_NAME.Name = "SM_NOYAKU_NAME";
                textColumn_SM_NOYAKU_NAME.HeaderText = "農薬名";
                //列を新規登録する
                dataGridView_Noyaku.Columns.Add(textColumn_SM_NOYAKU_NAME);
            }

            // ------SM_NOYAKU_KBN_SAKKIN_MUSI--------------//
            if (!this.dataGridView_Noyaku.Columns.Contains("SM_NOYAKU_KBN_SAKKIN_MUSI"))
            {
                DataGridViewTextBoxColumn textColumn_SM_NOYAKU_KBN_SAKKIN_MUSI = new DataGridViewTextBoxColumn();
                //データソースの"INFORMATION_CD"をバインドする
                textColumn_SM_NOYAKU_KBN_SAKKIN_MUSI.DataPropertyName = "SM_NOYAKU_KBN_SAKKIN_MUSI";
                //名前とヘッダーを設定する
                textColumn_SM_NOYAKU_KBN_SAKKIN_MUSI.Name = "SM_NOYAKU_KBN_SAKKIN_MUSI";
                textColumn_SM_NOYAKU_KBN_SAKKIN_MUSI.HeaderText = "菌虫他";
                //列を新規登録する
                dataGridView_Noyaku.Columns.Add(textColumn_SM_NOYAKU_KBN_SAKKIN_MUSI);
            }

            // ------SM_NOYAKU_KBN_TUBU_KONA_EKI--------------//
            if (!this.dataGridView_Noyaku.Columns.Contains("SM_NOYAKU_KBN_TUBU_KONA_EKI"))
            {
                DataGridViewTextBoxColumn textColumn_SM_NOYAKU_KBN_TUBU_KONA_EKI = new DataGridViewTextBoxColumn();
                //データソースの"SM_NOYAKU_KBN_TUBU_KONA_EKI"をバインドする
                textColumn_SM_NOYAKU_KBN_TUBU_KONA_EKI.DataPropertyName = "SM_NOYAKU_KBN_TUBU_KONA_EKI";
                //名前とヘッダーを設定する
                textColumn_SM_NOYAKU_KBN_TUBU_KONA_EKI.Name = "SM_NOYAKU_KBN_TUBU_KONA_EKI";
                textColumn_SM_NOYAKU_KBN_TUBU_KONA_EKI.HeaderText = "粒・粉・液";
                //列を新規登録する
                dataGridView_Noyaku.Columns.Add(textColumn_SM_NOYAKU_KBN_TUBU_KONA_EKI);
            }

            // ------SM_NOYAKU_YOKI--------------//
            if (!this.dataGridView_Noyaku.Columns.Contains("SM_NOYAKU_YOKI"))
            {
                DataGridViewTextBoxColumn textColumn_SM_NOYAKU_YOKI = new DataGridViewTextBoxColumn();
                //データソースの"SM_NOYAKU_YOKI"をバインドする
                textColumn_SM_NOYAKU_YOKI.DataPropertyName = "SM_NOYAKU_YOKI";
                //名前とヘッダーを設定する
                textColumn_SM_NOYAKU_YOKI.Name = "SM_NOYAKU_YOKI";
                textColumn_SM_NOYAKU_YOKI.HeaderText = "容器";
                //列を新規登録する
                dataGridView_Noyaku.Columns.Add(textColumn_SM_NOYAKU_YOKI);
            }

            // ------SM_SIZAI_TANKA--------------//
            if (!this.dataGridView_Noyaku.Columns.Contains("SM_SIZAI_TANKA"))
            {
                DataGridViewTextBoxColumn textColumn_SM_SIZAI_TANKA = new DataGridViewTextBoxColumn();
                //データソースの"SM_SIZAI_TANKA"をバインドする
                textColumn_SM_SIZAI_TANKA.DataPropertyName = "SM_SIZAI_TANKA";
                //名前とヘッダーを設定する
                textColumn_SM_SIZAI_TANKA.Name = "SM_SIZAI_TANKA";
                textColumn_SM_SIZAI_TANKA.HeaderText = "単価";
                //列を新規登録する
                dataGridView_Noyaku.Columns.Add(textColumn_SM_SIZAI_TANKA);
            }

            // ------TYOUSA_TANKA--------------//
            if (!this.dataGridView_Noyaku.Columns.Contains("TYOUSA_TANKA"))
            {
                DataGridViewTextBoxColumn textColumn_TYOUSA_TANKA = new DataGridViewTextBoxColumn();
                //データソースの"TYOUSA_TANKA"をバインドする
                textColumn_TYOUSA_TANKA.DataPropertyName = "TYOUSA_TANKA";
                //名前とヘッダーを設定する
                textColumn_TYOUSA_TANKA.Name = "TYOUSA_TANKA";
                textColumn_TYOUSA_TANKA.HeaderText = "調査単価";
                //列を新規登録する
                dataGridView_Noyaku.Columns.Add(textColumn_TYOUSA_TANKA);
            }

            // -----------------------------------------------------------------------
            // カンマ編集
            // -----------------------------------------------------------------------
            this.dataGridView_Noyaku.Columns["SM_SIZAI_TANKA"].DefaultCellStyle.Format = "#,##0";

            // -----------------------------------------------------------------------
            // 各列の幅を設定する
            DataGridViewColumn column_SM_NOYAKU_CD = dataGridView_Noyaku.Columns["SM_NOYAKU_CD"];
            column_SM_NOYAKU_CD.Width = 50;

            DataGridViewColumn column_SM_NOYAKU_NAME = dataGridView_Noyaku.Columns["SM_NOYAKU_NAME"];
            column_SM_NOYAKU_NAME.Width = 170;

            DataGridViewColumn column_SM_NOYAKU_KBN_SAKKIN_MUSI = dataGridView_Noyaku.Columns["SM_NOYAKU_KBN_SAKKIN_MUSI"];
            column_SM_NOYAKU_KBN_SAKKIN_MUSI.Width = 80;

            DataGridViewColumn columntextColumn_SM_NOYAKU_YOKI = dataGridView_Noyaku.Columns["SM_NOYAKU_YOKI"];
            columntextColumn_SM_NOYAKU_YOKI.Width = 100;

            DataGridViewColumn columntextColumn_SM_NOYAKU_KBN_TUBU_KONA_EKI = dataGridView_Noyaku.Columns["SM_NOYAKU_KBN_TUBU_KONA_EKI"];
            columntextColumn_SM_NOYAKU_KBN_TUBU_KONA_EKI.Width = 100;

            DataGridViewColumn columntextColumn_SM_SIZAI_TANKA = dataGridView_Noyaku.Columns["SM_SIZAI_TANKA"];
            columntextColumn_SM_SIZAI_TANKA.Width =100;

            DataGridViewColumn columntextColumn_TYOUSA_TANKA = dataGridView_Noyaku.Columns["TYOUSA_TANKA"];
            columntextColumn_TYOUSA_TANKA.Width = 100;

            // -----------------------------------------------------------------------
            // 列ヘッダの背景色の変更
            // -----------------------------------------------------------------------
            // Visualスタイルを使用しないようにしないと背景色が変わらない
            dataGridView_Noyaku.EnableHeadersVisualStyles = false;
            dataGridView_Noyaku.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // -----------------------------------------------------------------------
            // 列ヘッダの見出しを中央表示にする
            // -----------------------------------------------------------------------
            dataGridView_Noyaku.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // -----------------------------------------------------------------------
            // データ列を中央表示、右寄せ、左寄せにする
            // -----------------------------------------------------------------------
            dataGridView_Noyaku.Columns["SM_NOYAKU_CD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Noyaku.Columns["SM_NOYAKU_NAME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Noyaku.Columns["SM_NOYAKU_KBN_SAKKIN_MUSI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Noyaku.Columns["SM_NOYAKU_KBN_TUBU_KONA_EKI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Noyaku.Columns["SM_NOYAKU_YOKI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Noyaku.Columns["SM_SIZAI_TANKA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_Noyaku.Columns["TYOUSA_TANKA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // -----------------------------------------------------------------------
            // 1行おきに背景色を変える
            // -----------------------------------------------------------------------
            //全ての行の背景色を水色にする
            dataGridView_Noyaku.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            //奇数行を黄色にする
            dataGridView_Noyaku.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;

            // -----------------------------------------------------------------------
            // 最終行を新規登録できなくする
            // -----------------------------------------------------------------------
            dataGridView_Noyaku.AllowUserToAddRows = false;

            // -----------------------------------------------------------------------
            // 1行全体を選択（反転色）する
            // -----------------------------------------------------------------------
            dataGridView_Noyaku.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // -----------------------------------------------------------------------
            // 1行全体を選択（反転色）した時の背景色の指定する
            // -----------------------------------------------------------------------
            dataGridView_Noyaku.DefaultCellStyle.SelectionBackColor = Color.Gray;
            // 行ヘッダの背景色も同上に変更する
            dataGridView_Noyaku.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Gray;
            // 行ヘッダの背景色の変更
            //dataGridView_Calendar.RowHeadersDefaultCellStyle.BackColor = Color.Gray;   

            // -----------------------------------------------------------------------
            // 行ヘッダーの幅を設定する
            // -----------------------------------------------------------------------
            dataGridView_Noyaku.RowHeadersWidth = 20;

            // -----------------------------------------------------------------------
            // 全体をReadOnlyにする
            // -----------------------------------------------------------------------
            dataGridView_Noyaku.ReadOnly = true;

            // -----------------------------------------------------------------------
            // 左から3列を固定する
            // -----------------------------------------------------------------------
            //dataGridView_Noyaku.Columns[3].Frozen = true;
        }

        private void button_F4B_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_F2B_Click(object sender, EventArgs e)
        {
            // 検索
            P_Seek();

            // 操作可能にする
            this.button_Insert.Enabled = true;
            this.button_Update.Enabled = true;
            this.button_Del.Enabled = true;

        }

        private void AllMainForm_Shown(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Validatingチェックを無効にするため　FormClosingで e.Cancel = falseをおこなう
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }


        private void comboBox_NotiKbn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_NotiCD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 防除基準印刷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Print_Click(object sender, EventArgs e)
        {

            // 必要時にコメント解除
            string strMsg = "農薬単価調査表を印刷しますか？";
            DialogResult ret;
            string strMsgTitle = "農薬単価調査表の印刷";
            ret = MessageBox.Show(strMsg, strMsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ret == DialogResult.No)
            {
                return;
            }

            // 販売品データセット
            DataSet Ds_HANBAIHIN_TBL = new DataSet();

            this.Cursor = Cursors.WaitCursor;

            // -----------------------------------------------------------------------------------------------------------------------------------------------------------------
            // EXCELテンプレート（先頭名　原本_)をコピーし出力用エクセルブックを作る 出力先 C:\\AgriDiaryAllUserData\\EXCELフォルダ  Start
            // -----------------------------------------------------------------------------------------------------------------------------------------------------------------
            // 原本Book指定（コピー元）先頭に「原本_」がついている
            string strFile_Moto = Constants.YUME_DIR_EXCEL_GENPON + "\\原本_農薬単価調査表.xlsx";

            // コピー先Book指定（コピー先）先頭の「原本_」を削除（トル）
            string strFile_Saki = Constants.YUME_TEMP_DIR_EXCEL + "\\農薬単価調査表.xlsx";

            // コピー先に、ファイルが存在しているかどうか確認する
            if (System.IO.File.Exists(strFile_Saki))
            {
                // ファイル有り
                // ファイル属性を取得
                FileAttributes FileAtt = File.GetAttributes(strFile_Saki);
                // ReadOnly属性を解除（他の属性は変更しない）
                FileAtt = FileAtt & ~FileAttributes.ReadOnly;
                File.SetAttributes(strFile_Saki, FileAtt);

                // ファイルの上書きコピー　原本Book＝＞出力先Dirへコピー ファイルが有るので「true」でコピー
                File.Copy(strFile_Moto, strFile_Saki, true);
            }
            else
            {
                // ファイルの上書きコピー　原本Book＝＞出力先Dirへコピー ファイルが無いので「false」でコピー
                File.Copy(strFile_Moto, strFile_Saki, false);
            }

            // ファイル属性を取得
            FileAttributes fa = File.GetAttributes(strFile_Saki);
            // 読み取り専用属性を削除（他の属性は変更しない）
            fa = fa & ~FileAttributes.ReadOnly;
            File.SetAttributes(strFile_Saki, fa);

            // この段階でBookテンプレート原本_資材入力チェックリストの完成
            // データ出力先EXCEL完成セット
            string strExcelName = strFile_Saki;
            // -----------------------------------------------------------------------------------------------------------------------------------------------------------------
            // EXCELテンプレート（先頭名　原本_)をコピーし出力用エクセルブックを作る  出力先 C:\\AgriDiaryAllUserData\\EXCELフォルダ  End
            // -----------------------------------------------------------------------------------------------------------------------------------------------------------------

            // 上記のデータ出力先EXCELを使用して印刷処理を開発する
            var book = new XLWorkbook(strExcelName, XLEventTracking.Disabled);

            var sheet = book.Worksheet(1);

            // --------------------------------------------------------------------------------------------
            // グリッドのデータ読み込み
            // --------------------------------------------------------------------------------------------
            int data_cnt = 1;

            for (int i = 0; i <= dataGridView_Noyaku.Rows.Count - 1; i++)
            {
                // 全件の場合
                data_cnt++;

                // 農薬名の周りに罫線を引く
                sheet.Cell("A" + data_cnt.ToString()).Value = "'" + dataGridView_Noyaku.Rows[i].Cells["SM_NOYAKU_NAME"].Value.ToString();
                sheet.Range("A" + data_cnt.ToString() + ":" + "A" + data_cnt.ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                // 菌虫他の周りに罫線を引く
                sheet.Cell("B" + data_cnt.ToString()).Value = "'" + dataGridView_Noyaku.Rows[i].Cells["SM_NOYAKU_KBN_SAKKIN_MUSI"].Value.ToString();
                sheet.Range("B" + data_cnt.ToString() + ":" + "B" + data_cnt.ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                // 粒粉液の周りに罫線を引く
                sheet.Cell("D" + data_cnt.ToString()).Value = dataGridView_Noyaku.Rows[i].Cells["SM_NOYAKU_KBN_TUBU_KONA_EKI"].Value.ToString();
                sheet.Range("D" + data_cnt.ToString() + ":" + "D" + data_cnt.ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                // 容器の周りに罫線を引く
                sheet.Cell("C" + data_cnt.ToString()).Value = "'" + dataGridView_Noyaku.Rows[i].Cells["SM_NOYAKU_YOKI"].Value.ToString();
                sheet.Range("C" + data_cnt.ToString() + ":" + "C" + data_cnt.ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                // 単価の周りに罫線を引く
                sheet.Cell("E" + data_cnt.ToString()).Value = dataGridView_Noyaku.Rows[i].Cells["SM_SIZAI_TANKA"].Value.ToString();
                sheet.Range("E" + data_cnt.ToString() + ":" + "E" + data_cnt.ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                // 調査単価の周りに罫線を引く
                sheet.Range("F" + data_cnt.ToString() + ":" + "F" + data_cnt.ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }

            // 保存 
            book.SaveAs(strExcelName);

            this.Cursor = Cursors.Default;

            // EXCELが起動しているか 既に起動している場合は、脱出する
            string exe_name = "EXCEL";

            try
            {
                if (Process.GetProcessesByName(exe_name).Length >= 1)
                {
                    //起動している
                    MessageBox.Show("既にEXCEL2016が起動しています。", "確認",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
            }

            // WORD2016の起動
            if (Environment.Is64BitOperatingSystem)
            {
                //Console.WriteLine("64bit OS");
                // EXCEL2016の起動
                if (ExeStart("C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\EXCEL.EXE", strExcelName) == true)
                {
                    return;
                }
            }
            else
            {
                //Console.WriteLine("32bit OS");
                if (ExeStart("C:\\Program Files\\Microsoft Office\\root\\Office16\\EXCEL.EXE", strExcelName) == true)
                {
                    return;
                }
            }

            //1秒間待機する
            System.Threading.Thread.Sleep(300);

        }

        /// <summary>
        /// EXCEL2016,WORD2016の起動　同一スレッドで実行
        /// </summary>
        /// <param name="exe_name">EXCEL名</param>
        /// <param name="i_line">オギューメント（コマンドライン）をセット EXCELファイル名</param>
        /// <param name="i_taiki">ON:呼び出し元EXEを待機させる OFF:待機しない</param>
        /// <returns></returns>
        public bool ExeStart(string exe_name, string i_line)
        {
            // exe_nameの先頭に「\\」が付いてない場合、付加する
            string seek_moji = "\\";
            int moji_idx = 0;
            moji_idx = exe_name.Trim().IndexOf(seek_moji);
            if (moji_idx == -1)
            {
                exe_name = "\\" + exe_name;
            }

            // Process生成
            System.Diagnostics.Process exe_process = new Process();

            string exe = "";
            exe = exe_name.Trim();

            // 起動ファイル(exe)がXXXXX.XXX形式かチェックする
            seek_moji = ".";
            moji_idx = 0;
            moji_idx = exe.Trim().IndexOf(seek_moji);
            if (moji_idx == -1)
            {
                MessageBox.Show("起動ファイル名 [ " + exe + " ] がEXE（実行形式）で登録されてません。", "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // 起動ファイル(exe)の拡張子の長さをチェックする
            string kakutyousi = "";
            kakutyousi = exe.Trim().Substring(moji_idx + 1);
            if (kakutyousi.Trim().Length != 3)
            {
                MessageBox.Show("起動ファイル名 [ " + exe + " ]  の拡張子が「EXE」ではありません。", "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // 起動ファイルの存在チェック
            if (System.IO.File.Exists(exe) == false)
            {
                MessageBox.Show("起動ファイル名 [ " + exe + " ]  が存在しません。", "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            //イベントハンドラの追加
            exe_process.Exited += new EventHandler(p_Exited);

            // 起動ファイルが存在している場合、Callする
            const string quote = "\"";                  // ""XXXXX""形式にするためquoteをconstで準備
            string para = quote + i_line + quote;       // オギューメント形成（ID/PASSをセット）

            exe_process.StartInfo.FileName = exe;       // EXE（フルパス）セット
            exe_process.StartInfo.Arguments = para;     // オギューメント（コマンドライン）をセット
            exe_process.Start();                        // EXEを起動
                                                        // 起動したexeの終了を感知するためイベントを発生させる。
            exe_process.EnableRaisingEvents = true;
            exe_process.SynchronizingObject = this;     // スレッドを同一にする

            return true;
        }

        /// <summary>
        /// 起動したexeの終了を感知するためイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_Exited(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = (System.Diagnostics.Process)sender;

            // EXCEL2016・WORD2016の起動
            this.Cursor = Cursors.Default;
        }

        private void checkBox_Kojin_Click(object sender, EventArgs e)
        {
            if (this.checkBox_Kojin.Checked == true)
            {
                this.checkBox_Ja.Checked = true;
            }
        }

        private void checkBox_Ippan_Click(object sender, EventArgs e)
        {
            if (this.checkBox_Ippan.Checked == true)
            {
                this.checkBox_Ja.Checked = true;
            }
        }
    }
}