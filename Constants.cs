//////////////////////////////////////////////////////////////////////////////////////////////
// 
// 	システム名	    ：ゆめみるきかい技術情報システム	
// 
// 	プログラム名	：YumeTechnology.application
//	ソースプログラム：Constants.cs
// 	開発言語		：VisualStudio.Net C# 2019
// 	処理内容		：コンスタントデータ処理
// 	著作権			：有限会社　ゆめみるきかい
// 	作成者			：越高 日出夫
// 	完成日（西暦）	：2021/05/01
// 	バージョン		：Ver 1.0.0
// 	備考			：
// 
//////////////////////////////////////////////////////////////////////////////////////////////
// 	このソースプログラムは、有限会社　ゆめみるきかいの所有する情報を含み、
// 	著作権法によって保護されています。
// 	したがって、著作物の文書による許諾を行わずに、本ソースプログラムを複写、
// 	または、再生産することを禁じます。
//////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriDiaryNoyakuTankaPrint
{
    static class Constants
    {
        // 農業環境接続データソース
        public const string AGRI_PC = "Data Source=SUPRE-PC\\SQLEXPRESS;Initial Catalog=YUMEDB;User Id=";

        // YUME 実行環境ディレクトリ
        public const string YUME_DIR = "C:\\Program Files\\Yume";

        // YUME EXCEL原本ディレクトリ
        public const string YUME_DIR_EXCEL_GENPON = "C:\\Program Files\\Yume\\EXCEL_GENPON";

        // YUME 開発環境ディレクトリ
        public const string YUME_CS = "C:\\Users\\supre\\Documents\\Visual Studio 2019\\Projects\\015_Yume開発_V3";

        // YUME データ処理ディレクトリ
        public const string YUME_TEMP_DIR_EXCEL = "C:\\AgriDiaryAllUserData\\EXCEL";
    }
}

