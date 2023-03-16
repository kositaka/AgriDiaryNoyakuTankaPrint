//////////////////////////////////////////////////////////////////////////////////////////////
// 
// 	システム名	    ：ゆめみるきかい技術情報システム	
// 
// 	プログラム名	：YumeTechnology.application
//	ソースプログラム：ClassButtonColor.cs
// 	開発言語		：VisualStudio.Net C# 2019
// 	処理内容		：ボタン・パネル背景色変更処理
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriDiaryNoyakuTankaPrint
{
    class ClassButtonColor
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ClassButtonColor()
        {

        }

        /// <summary>
        /// ボタン背景色変更処理
        /// </summary>
        /// <param name="ButonBitmap"></param>
        /// <param name="iWidth"></param>
        /// <param name="iHeight"></param>
		public void SetButtonColor(ref Bitmap ButonBitmap, int iWidth, int iHeight)
        {
            // ビットマップとGraphicsオブジェクトの作成
            Bitmap bmp_Button = new Bitmap(iWidth, iHeight);
            Graphics g_Button = Graphics.FromImage(bmp_Button);

            // グラデーション・ブラシの作成
            LinearGradientBrush gradBrush = new LinearGradientBrush(
                g_Button.VisibleClipBounds, // ビットマップの領域サイズ
                Color.Silver,   // 開始色
                Color.Azure,    // 終了色
                LinearGradientMode.Vertical); // 縦方向にグラデーション

            // ビットマップをグラデーション・ブラシで塗る
            g_Button.FillRectangle(gradBrush, g_Button.VisibleClipBounds);

            gradBrush.Dispose();
            g_Button.Dispose();

            // ビットマップをボタンの背景にセット
            ButonBitmap = bmp_Button;
        }

        /// <summary>
        /// ヘッダーパネル背景色変更処理
        /// </summary>
        /// <param name="PanelBitmap"></param>
        /// <param name="iWidth"></param>
        /// <param name="iHeight"></param>
        public void SetPanel_HeaderColor(ref Bitmap PanelBitmap, int iWidth, int iHeight)
        {
            // ビットマップとGraphicsオブジェクトの作成
            Bitmap bmp_Panel = new Bitmap(iWidth, iHeight);
            Graphics g_Panel = Graphics.FromImage(bmp_Panel);

            // グラデーション・ブラシの作成
            LinearGradientBrush gradBrush_Paneru = new LinearGradientBrush(
                g_Panel.VisibleClipBounds, // ビットマップの領域サイズ
                Color.LightBlue,   // 開始色
                Color.Azure,    // 終了色
                LinearGradientMode.Vertical); // 縦方向にグラデーション

            // ビットマップをグラデーション・ブラシで塗る
            g_Panel.FillRectangle(gradBrush_Paneru, g_Panel.VisibleClipBounds);

            gradBrush_Paneru.Dispose();
            g_Panel.Dispose();

            // ビットマップをヘッダーパネル背景にセット
            PanelBitmap = bmp_Panel;
        }

        /// <summary>
        /// トレーラーパネル背景色変更処理
        /// </summary>
        /// <param name="PanelBitmap"></param>
        /// <param name="iWidth"></param>
        /// <param name="iHeight"></param>
        public void SetPanel__TralerColor(ref Bitmap PanelBitmap, int iWidth, int iHeight)
        {
            // ビットマップとGraphicsオブジェクトの作成
            Bitmap bmp_Panel = new Bitmap(iWidth, iHeight);
            Graphics g_Panel = Graphics.FromImage(bmp_Panel);

            // グラデーション・ブラシの作成
            LinearGradientBrush gradBrush_Paneru = new LinearGradientBrush(
                g_Panel.VisibleClipBounds, // ビットマップの領域サイズ
                Color.LightBlue,   // 開始色
                Color.Azure,    // 終了色
                LinearGradientMode.Vertical); // 縦方向にグラデーション

            // ビットマップをグラデーション・ブラシで塗る
            g_Panel.FillRectangle(gradBrush_Paneru, g_Panel.VisibleClipBounds);

            gradBrush_Paneru.Dispose();
            g_Panel.Dispose();

            // ビットマップをトレーラーパネル背景にセット
            PanelBitmap = bmp_Panel;
        }
    }
}
