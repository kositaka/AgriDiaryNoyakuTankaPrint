//////////////////////////////////////////////////////////////////////////////////////////////
// 
// 	システム名	    ：ゆめみるきかい技術情報システム	
// 
// 	プログラム名	：YumeTechnology.application
//	ソースプログラム：ClassCheck.cs
// 	開発言語		：VisualStudio.Net C# 2019
// 	処理内容		：チェック処理
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
    public class ClassCheck
    {
        private Encoding sjis_enc;
        private Encoding uni_enc;
        static Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ClassCheck()
        {

        }

        /// <summary>
        /// 半角チェック
        /// </summary>
        /// <param name="i_strData"></param>
        /// <returns>True:半角である（OK)　false:半角でない（NO）</returns>
        public bool CheckHankaku(ref string errMsg, string i_strData)
        {
            int num = sjisEnc.GetByteCount(i_strData);
            if (num == i_strData.Length)
            {
                errMsg = "";
                return true;
            }
            else
            {
                errMsg = "半角文字ではありません。";
                return false;
            }
        }

        /// <summary>
        ///  漢字チェック
        /// </summary>
        /// <param name="i_strData">入力（チェック）文字列</param>
        /// <returns>True:漢字である（OK)　false:漢字でない（NO）</returns>
        public bool CheckKanji(ref string errMsg, string i_strData)
        {
            int sjis_length = 0;
            int uni_length = 0;

            sjis_enc = Encoding.GetEncoding("Shift_JIS");
            uni_enc = Encoding.Unicode;

            try
            {
                // SJISでのバイト数取得
                sjis_length = sjis_enc.GetByteCount(i_strData);

                // UNICODEでのバイト数取得
                uni_length = uni_enc.GetByteCount(i_strData);

                // Byte比較
                if (sjis_length != uni_length)
                {
                    errMsg = "漢字ではありません。";

                    // バイト数に違いがある場合は、漢字でない
                    return false;
                }
            }
            catch
            {
                errMsg = "漢字ではありません。";

                // 漢字でない
                return false;
            }

            errMsg = "";

            // 漢字である
            return true;
        }

        /// <summary>
        ///  全角カナチェック
        /// </summary>
        /// <param name="i_strData">入力（チェック）文字列</param>
        /// <returns>True:全角カナである（OK)　false:全角カナでない（NO）</returns>
        public bool CheckZenKana(ref string errMsg, string i_strData)
        {
            int sjis_length = 0;
            int uni_length = 0;
            byte[] bytesData;
            int sjis_kana_length = 0;

            sjis_enc = Encoding.GetEncoding("Shift_JIS");
            uni_enc = Encoding.Unicode;

            try
            {
                // SJISでのバイト数取得
                sjis_length = sjis_enc.GetByteCount(i_strData);

                // UNICODEでのバイト数取得
                uni_length = uni_enc.GetByteCount(i_strData);

                // Byte比較
                if (sjis_length != uni_length)
                {
                    errMsg = "全角カナではありません";

                    // バイト数に違いがある場合は、漢字でない
                    return false;
                }
            }
            catch
            {
                errMsg = "全角カナではありません";

                // 全角カナでない
                return false;
            }

            sjis_kana_length = sjis_enc.GetByteCount(i_strData);

            // 全角カナである
            if (i_strData.Length * 2 <= sjis_kana_length)
            {
                int i = 0;
                for (i = 0; i <= (i_strData.Trim().Length - 1); i++)
                {
                    bytesData = System.Text.Encoding.GetEncoding(932).GetBytes(i_strData.Trim().Substring(i, 1));

                    // カナ全角は文字コード833F～8390なので、先頭83が全角カナである 82は全角数字
                    if (bytesData[0] == 0x83)
                    {
                        errMsg = "";

                        return true;
                    }
                    else
                    {
                        if (bytesData[0] == 0x82)
                        {
                            if ((bytesData[1] >= 0x4f) && (bytesData[1] <= 0x58))
                            {
                                errMsg = "";

                                return true;
                            }
                        }
                    }
                }
            }

            errMsg = "全角カナではありません";

            return false;
        }

        /// <summary>
        ///  アルファベットチェック
        /// </summary>
        /// <param name="i_strData">入力（チェック）文字列</param>
        /// <returns>True:アルファベットである（OK)　false:アルファベットでない（NO）</returns>
        public bool CheckAlphabet(ref string errMsg, string i_strData)
        {
            int ilength = 0;
            int i = 0;
            bool bKekka = false;
            string strChar = "";

            try
            {
                ilength = i_strData.Trim().Length;

                for (i = 0; i < ilength; i++)
                {
                    strChar = i_strData.Trim().Substring(i, 1);

                    switch (strChar.ToUpper())
                    {
                        case "A":
                        case "B":
                        case "C":
                        case "D":
                        case "E":
                        case "F":
                        case "G":
                        case "H":
                        case "I":
                        case "J":
                        case "K":
                        case "L":
                        case "M":
                        case "N":
                        case "O":
                        case "P":
                        case "Q":
                        case "R":
                        case "S":
                        case "T":
                        case "U":
                        case "V":
                        case "W":
                        case "X":
                        case "Y":
                        case "Z":
                            bKekka = true;
                            break;
                        default:
                            bKekka = false;
                            break;
                    }
                }
            }
            catch
            {
                errMsg = "アルファベットではありません";

                // アルファベットでない
                return false;
            }

            // アルファベットである
            errMsg = "";

            return bKekka;
        }

        /// <summary>
        ///  数字チェック
        /// </summary>
        /// <param name="i_strData">入力（チェック）文字列</param>
        /// <returns>True:数字である（OK)　false:数字でない（NO）</returns>
        public bool CheckNumeric(ref string errMsg, string i_strData)
        {
            int ilength = 0;
            int i = 0;
            bool bKekka = false;
            string strChar = "";

            try
            {
                ilength = i_strData.Trim().Length;

                for (i = 0; i < ilength; i++)
                {
                    strChar = i_strData.Trim().Substring(i, 1);

                    switch (strChar.ToUpper())
                    {
                        case "0":
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                        case "5":
                        case "6":
                        case "7":
                        case "8":
                        case "9":
                            bKekka = true;
                            break;
                        default:
                            bKekka = false;
                            break;
                    }
                }
            }
            catch
            {
                // 数字でない
                errMsg = "数字ではありません";

                return false;
            }

            // 数字である
            errMsg = "";

            return bKekka;
        }

        /// <summary>
        ///  バイト数チェック
        /// </summary>
        /// <param name="i_strData">入力（チェック）文字列</param>
        /// <returns>True:数字である（OK)　false:数字でない（NO）</returns>
        public bool CheckByte(ref string errMsg, string i_strData, int i_Length)
        {
            int iByteCount = LenByte(i_strData);

            if (iByteCount > i_Length)
            {
                errMsg = "長すぎます。";

                return false;
            }

            errMsg = "";

            return true;
        }

        /// <summary>
        ///  バイト数イコールチェック
        /// </summary>
        /// <param name="i_strData">入力（チェック）文字列</param>
        /// <returns>True:イコールである（OK)　false:イコールでない（NO）</returns>
        public bool CheckByteEqual(ref string errMsg, string i_strData, int i_Length)
        {
            int iByteCount = LenByte(i_strData);

            if (iByteCount == i_Length)
            {
            }
            else
            {
                errMsg = "既定値の桁数に足りません。";

                return false;
            }

            errMsg = "";

            return true;
        }

        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     半角 1 バイト、全角 2 バイトとして、指定された文字列のバイト数を返します。</summary>
        /// <param name="stTarget">
        ///     バイト数取得の対象となる文字列。</param>
        /// <returns>
        ///     半角 1 バイト、全角 2 バイトでカウントされたバイト数。</returns>
        /// -----------------------------------------------------------------------------------------
        public static int LenByte(string stTarget)
        {
            return System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(stTarget);
        }

    }
}
