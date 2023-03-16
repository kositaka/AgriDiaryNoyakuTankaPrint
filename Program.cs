using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgriDiaryNoyakuTankaPrint
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 2重起動の抑止
            Mutex exe_mutex = new Mutex(false, "AgriDiaryNoyakuTankaPrint");
            if (exe_mutex.WaitOne(0, false))
            {
                Application.Run(new AllMainForm());
                exe_mutex.ReleaseMutex();
            }
            else
            {
                // 既に起動していると判断する。注意メッセージアイコンを使用する
                MessageBox.Show("このソフトは、既に起動しています。\n重複して起動することはできません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
                return;
            }
            exe_mutex.Close();
        }
    }
}
