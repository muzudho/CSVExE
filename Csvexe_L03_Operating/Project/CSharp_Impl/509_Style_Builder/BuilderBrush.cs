using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;//Brush

namespace Xenon.Operating
{
    public class BuilderBrush
    {



        #region 生成と破棄
        //────────────────────────────────────────

        static BuilderBrush()
        {
            dictionary_Brush = new Dictionary<string, Brush>();
            dictionary_Brush["AliceBlue"] = Brushes.AliceBlue;
            dictionary_Brush["AntiqueWhite"] = Brushes.AntiqueWhite;
            dictionary_Brush["Aqua"] = Brushes.Aqua;
            dictionary_Brush["Aquamarine"] = Brushes.Aquamarine;
            dictionary_Brush["Azure"] = Brushes.Azure;
            dictionary_Brush["Beige"] = Brushes.Beige;
            dictionary_Brush["Bisque"] = Brushes.Bisque;
            dictionary_Brush["Black"] = Brushes.Black;
            dictionary_Brush["BlanchedAlmond"] = Brushes.BlanchedAlmond;
            dictionary_Brush["Blue"] = Brushes.Blue;
            dictionary_Brush["BlueViolet"] = Brushes.BlueViolet;
            dictionary_Brush["Brown"] = Brushes.Brown;
            dictionary_Brush["BurlyWood"] = Brushes.BurlyWood;
            dictionary_Brush["CadetBlue"] = Brushes.CadetBlue;
            dictionary_Brush["Chartreuse"] = Brushes.Chartreuse;
            dictionary_Brush["Chocolate"] = Brushes.Chocolate;
            dictionary_Brush["Coral"] = Brushes.Coral;
            dictionary_Brush["CornflowerBlue"] = Brushes.CornflowerBlue;
            dictionary_Brush["Cornsilk"] = Brushes.Cornsilk;
            dictionary_Brush["Crimson"] = Brushes.Crimson;
            dictionary_Brush["Cyan"] = Brushes.Cyan;
            dictionary_Brush["DarkBlue"] = Brushes.DarkBlue;
            dictionary_Brush["DarkCyan"] = Brushes.DarkCyan;
            dictionary_Brush["DarkGoldenrod"] = Brushes.DarkGoldenrod;
            dictionary_Brush["DarkGray"] = Brushes.DarkGray;
            dictionary_Brush["DarkGreen"] = Brushes.DarkGreen;
            dictionary_Brush["DarkKhaki"] = Brushes.DarkKhaki;
            dictionary_Brush["DarkMagenta"] = Brushes.DarkMagenta;
            dictionary_Brush["DarkOliveGreen"] = Brushes.DarkOliveGreen;
            dictionary_Brush["DarkOrange"] = Brushes.DarkOrange;
            dictionary_Brush["DarkOrchid"] = Brushes.DarkOrchid;
            dictionary_Brush["DarkRed"] = Brushes.DarkRed;
            dictionary_Brush["DarkSalmon"] = Brushes.DarkSalmon;
            dictionary_Brush["DarkSeaGreen"] = Brushes.DarkSeaGreen;
            dictionary_Brush["DarkSlateBlue"] = Brushes.DarkSlateBlue;
            dictionary_Brush["DarkSlateGray"] = Brushes.DarkSlateGray;
            dictionary_Brush["DarkTurquoise"] = Brushes.DarkTurquoise;
            dictionary_Brush["DarkViolet"] = Brushes.DarkViolet;
            dictionary_Brush["DeepPink"] = Brushes.DeepPink;
            dictionary_Brush["DeepSkyBlue"] = Brushes.DeepSkyBlue;
            dictionary_Brush["DimGray"] = Brushes.DimGray;
            dictionary_Brush["DodgerBlue"] = Brushes.DodgerBlue;
            dictionary_Brush["Firebrick"] = Brushes.Firebrick;
            dictionary_Brush["FloralWhite"] = Brushes.FloralWhite;
            dictionary_Brush["ForestGreen"] = Brushes.ForestGreen;
            dictionary_Brush["Fuchsia"] = Brushes.Fuchsia;
            dictionary_Brush["Gainsboro"] = Brushes.Gainsboro;
            dictionary_Brush["GhostWhite"] = Brushes.GhostWhite;
            dictionary_Brush["Gold"] = Brushes.Gold;
            dictionary_Brush["Goldenrod"] = Brushes.Goldenrod;
            dictionary_Brush["Gray"] = Brushes.Gray;
            dictionary_Brush["Green"] = Brushes.Green;
            dictionary_Brush["GreenYellow"] = Brushes.GreenYellow;
            dictionary_Brush["Honeydew"] = Brushes.Honeydew;
            dictionary_Brush["HotPink"] = Brushes.HotPink;
            dictionary_Brush["IndianRed"] = Brushes.IndianRed;
            dictionary_Brush["Indigo"] = Brushes.Indigo;
            dictionary_Brush["Ivory"] = Brushes.Ivory;
            dictionary_Brush["Khaki"] = Brushes.Khaki;
            dictionary_Brush["Lavender"] = Brushes.Lavender;
            dictionary_Brush["LavenderBlush"] = Brushes.LavenderBlush;
            dictionary_Brush["LawnGreen"] = Brushes.LawnGreen;
            dictionary_Brush["LemonChiffon"] = Brushes.LemonChiffon;
            dictionary_Brush["LightBlue"] = Brushes.LightBlue;
            dictionary_Brush["LightCoral"] = Brushes.LightCoral;
            dictionary_Brush["LightCyan"] = Brushes.LightCyan;
            dictionary_Brush["LightGoldenrodYellow"] = Brushes.LightGoldenrodYellow;
            dictionary_Brush["LightGray"] = Brushes.LightGray;
            dictionary_Brush["LightGreen"] = Brushes.LightGreen;
            dictionary_Brush["LightPink"] = Brushes.LightPink;
            dictionary_Brush["LightSalmon"] = Brushes.LightSalmon;
            dictionary_Brush["LightSeaGreen"] = Brushes.LightSeaGreen;
            dictionary_Brush["LightSkyBlue"] = Brushes.LightSkyBlue;
            dictionary_Brush["LightSlateGray"] = Brushes.LightSlateGray;
            dictionary_Brush["LightSteelBlue"] = Brushes.LightSteelBlue;
            dictionary_Brush["LightYellow"] = Brushes.LightYellow;
            dictionary_Brush["Lime"] = Brushes.Lime;
            dictionary_Brush["LimeGreen"] = Brushes.LimeGreen;
            dictionary_Brush["Linen"] = Brushes.Linen;
            dictionary_Brush["Magenta"] = Brushes.Magenta;
            dictionary_Brush["Maroon"] = Brushes.Maroon;
            dictionary_Brush["MediumAquamarine"] = Brushes.MediumAquamarine;
            dictionary_Brush["MediumBlue"] = Brushes.MediumBlue;
            dictionary_Brush["MediumOrchid"] = Brushes.MediumOrchid;
            dictionary_Brush["MediumPurple"] = Brushes.MediumPurple;
            dictionary_Brush["MediumSeaGreen"] = Brushes.MediumSeaGreen;
            dictionary_Brush["MediumSlateBlue"] = Brushes.MediumSlateBlue;
            dictionary_Brush["MediumSpringGreen"] = Brushes.MediumSpringGreen;
            dictionary_Brush["MediumTurquoise"] = Brushes.MediumTurquoise;
            dictionary_Brush["MediumVioletRed"] = Brushes.MediumVioletRed;
            dictionary_Brush["MidnightBlue"] = Brushes.MidnightBlue;
            dictionary_Brush["MintCream"] = Brushes.MintCream;
            dictionary_Brush["MistyRose"] = Brushes.MistyRose;
            dictionary_Brush["Moccasin"] = Brushes.Moccasin;
            dictionary_Brush["NavajoWhite"] = Brushes.NavajoWhite;
            dictionary_Brush["Navy"] = Brushes.Navy;
            dictionary_Brush["OldLace"] = Brushes.OldLace;
            dictionary_Brush["Olive"] = Brushes.Olive;
            dictionary_Brush["OliveDrab"] = Brushes.OliveDrab;
            dictionary_Brush["Orange"] = Brushes.Orange;
            dictionary_Brush["OrangeRed"] = Brushes.OrangeRed;
            dictionary_Brush["Orchid"] = Brushes.Orchid;
            dictionary_Brush["PaleGoldenrod"] = Brushes.PaleGoldenrod;
            dictionary_Brush["PaleGreen"] = Brushes.PaleGreen;
            dictionary_Brush["PaleTurquoise"] = Brushes.PaleTurquoise;
            dictionary_Brush["PaleVioletRed"] = Brushes.PaleVioletRed;
            dictionary_Brush["PapayaWhip"] = Brushes.PapayaWhip;
            dictionary_Brush["PeachPuff"] = Brushes.PeachPuff;
            dictionary_Brush["Peru"] = Brushes.Peru;
            dictionary_Brush["Pink"] = Brushes.Pink;
            dictionary_Brush["Plum"] = Brushes.Plum;
            dictionary_Brush["PowderBlue"] = Brushes.PowderBlue;
            dictionary_Brush["Purple"] = Brushes.Purple;
            dictionary_Brush["Red"] = Brushes.Red;
            dictionary_Brush["RosyBrown"] = Brushes.RosyBrown;
            dictionary_Brush["RoyalBlue"] = Brushes.RoyalBlue;
            dictionary_Brush["SaddleBrown"] = Brushes.SaddleBrown;
            dictionary_Brush["Salmon"] = Brushes.Salmon;
            dictionary_Brush["SandyBrown"] = Brushes.SandyBrown;
            dictionary_Brush["SeaGreen"] = Brushes.SeaGreen;
            dictionary_Brush["SeaShell"] = Brushes.SeaShell;
            dictionary_Brush["Sienna"] = Brushes.Sienna;
            dictionary_Brush["Silver"] = Brushes.Silver;
            dictionary_Brush["SkyBlue"] = Brushes.SkyBlue;
            dictionary_Brush["SlateBlue"] = Brushes.SlateBlue;
            dictionary_Brush["SlateGray"] = Brushes.SlateGray;
            dictionary_Brush["Snow"] = Brushes.Snow;
            dictionary_Brush["SpringGreen"] = Brushes.SpringGreen;
            dictionary_Brush["SteelBlue"] = Brushes.SteelBlue;
            dictionary_Brush["Tan"] = Brushes.Tan;
            dictionary_Brush["Teal"] = Brushes.Teal;
            dictionary_Brush["Thistle"] = Brushes.Thistle;
            dictionary_Brush["Tomato"] = Brushes.Tomato;
            dictionary_Brush["Transparent"] = Brushes.Transparent;
            dictionary_Brush["Turquoise"] = Brushes.Turquoise;
            dictionary_Brush["Violet"] = Brushes.Violet;
            dictionary_Brush["Wheat"] = Brushes.Wheat;
            dictionary_Brush["White"] = Brushes.White;
            dictionary_Brush["WhiteSmoke"] = Brushes.WhiteSmoke;
            dictionary_Brush["Yellow"] = Brushes.Yellow;
            dictionary_Brush["YellowGreen"] = Brushes.YellowGreen;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ブラシの名前から、ブラシ・オブジェクトを取得します。
        /// </summary>
        /// <param name="brushName"></param>
        /// <returns></returns>
        static public Brush Parse(string sName_Brush)
        {
            if (dictionary_Brush.ContainsKey(sName_Brush))
            {
                return dictionary_Brush[sName_Brush];
            }
            else
            {
                return Brushes.Black;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// ブラシ。
        /// </summary>
        private static Dictionary<string, Brush> dictionary_Brush;

        //────────────────────────────────────────
        #endregion



    }
}
