using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;//Pen

namespace Xenon.Operating
{
    public class BuilderPen
    {



        #region 生成と破棄
        //────────────────────────────────────────

        static BuilderPen()
        {
            dictionary_Pen = new Dictionary<string, Pen>();
            dictionary_Pen["AliceBlue"] = Pens.AliceBlue;
            dictionary_Pen["AntiqueWhite"] = Pens.AntiqueWhite;
            dictionary_Pen["Aqua"] = Pens.Aqua;
            dictionary_Pen["Aquamarine"] = Pens.Aquamarine;
            dictionary_Pen["Azure"] = Pens.Azure;
            dictionary_Pen["Beige"] = Pens.Beige;
            dictionary_Pen["Bisque"] = Pens.Bisque;
            dictionary_Pen["Black"] = Pens.Black;
            dictionary_Pen["BlanchedAlmond"] = Pens.BlanchedAlmond;
            dictionary_Pen["Blue"] = Pens.Blue;
            dictionary_Pen["BlueViolet"] = Pens.BlueViolet;
            dictionary_Pen["Brown"] = Pens.Brown;
            dictionary_Pen["BurlyWood"] = Pens.BurlyWood;
            dictionary_Pen["CadetBlue"] = Pens.CadetBlue;
            dictionary_Pen["Chartreuse"] = Pens.Chartreuse;
            dictionary_Pen["Chocolate"] = Pens.Chocolate;
            dictionary_Pen["Coral"] = Pens.Coral;
            dictionary_Pen["CornflowerBlue"] = Pens.CornflowerBlue;
            dictionary_Pen["Cornsilk"] = Pens.Cornsilk;
            dictionary_Pen["Crimson"] = Pens.Crimson;
            dictionary_Pen["Cyan"] = Pens.Cyan;
            dictionary_Pen["DarkBlue"] = Pens.DarkBlue;
            dictionary_Pen["DarkCyan"] = Pens.DarkCyan;
            dictionary_Pen["DarkGoldenrod"] = Pens.DarkGoldenrod;
            dictionary_Pen["DarkGray"] = Pens.DarkGray;
            dictionary_Pen["DarkGreen"] = Pens.DarkGreen;
            dictionary_Pen["DarkKhaki"] = Pens.DarkKhaki;
            dictionary_Pen["DarkMagenta"] = Pens.DarkMagenta;
            dictionary_Pen["DarkOliveGreen"] = Pens.DarkOliveGreen;
            dictionary_Pen["DarkOrange"] = Pens.DarkOrange;
            dictionary_Pen["DarkOrchid"] = Pens.DarkOrchid;
            dictionary_Pen["DarkRed"] = Pens.DarkRed;
            dictionary_Pen["DarkSalmon"] = Pens.DarkSalmon;
            dictionary_Pen["DarkSeaGreen"] = Pens.DarkSeaGreen;
            dictionary_Pen["DarkSlateBlue"] = Pens.DarkSlateBlue;
            dictionary_Pen["DarkSlateGray"] = Pens.DarkSlateGray;
            dictionary_Pen["DarkTurquoise"] = Pens.DarkTurquoise;
            dictionary_Pen["DarkViolet"] = Pens.DarkViolet;
            dictionary_Pen["DeepPink"] = Pens.DeepPink;
            dictionary_Pen["DeepSkyBlue"] = Pens.DeepSkyBlue;
            dictionary_Pen["DimGray"] = Pens.DimGray;
            dictionary_Pen["DodgerBlue"] = Pens.DodgerBlue;
            dictionary_Pen["Firebrick"] = Pens.Firebrick;
            dictionary_Pen["FloralWhite"] = Pens.FloralWhite;
            dictionary_Pen["ForestGreen"] = Pens.ForestGreen;
            dictionary_Pen["Fuchsia"] = Pens.Fuchsia;
            dictionary_Pen["Gainsboro"] = Pens.Gainsboro;
            dictionary_Pen["GhostWhite"] = Pens.GhostWhite;
            dictionary_Pen["Gold"] = Pens.Gold;
            dictionary_Pen["Goldenrod"] = Pens.Goldenrod;
            dictionary_Pen["Gray"] = Pens.Gray;
            dictionary_Pen["Green"] = Pens.Green;
            dictionary_Pen["GreenYellow"] = Pens.GreenYellow;
            dictionary_Pen["Honeydew"] = Pens.Honeydew;
            dictionary_Pen["HotPink"] = Pens.HotPink;
            dictionary_Pen["IndianRed"] = Pens.IndianRed;
            dictionary_Pen["Indigo"] = Pens.Indigo;
            dictionary_Pen["Ivory"] = Pens.Ivory;
            dictionary_Pen["Khaki"] = Pens.Khaki;
            dictionary_Pen["Lavender"] = Pens.Lavender;
            dictionary_Pen["LavenderBlush"] = Pens.LavenderBlush;
            dictionary_Pen["LawnGreen"] = Pens.LawnGreen;
            dictionary_Pen["LemonChiffon"] = Pens.LemonChiffon;
            dictionary_Pen["LightBlue"] = Pens.LightBlue;
            dictionary_Pen["LightCoral"] = Pens.LightCoral;
            dictionary_Pen["LightCyan"] = Pens.LightCyan;
            dictionary_Pen["LightGoldenrodYellow"] = Pens.LightGoldenrodYellow;
            dictionary_Pen["LightGray"] = Pens.LightGray;
            dictionary_Pen["LightGreen"] = Pens.LightGreen;
            dictionary_Pen["LightPink"] = Pens.LightPink;
            dictionary_Pen["LightSalmon"] = Pens.LightSalmon;
            dictionary_Pen["LightSeaGreen"] = Pens.LightSeaGreen;
            dictionary_Pen["LightSkyBlue"] = Pens.LightSkyBlue;
            dictionary_Pen["LightSlateGray"] = Pens.LightSlateGray;
            dictionary_Pen["LightSteelBlue"] = Pens.LightSteelBlue;
            dictionary_Pen["LightYellow"] = Pens.LightYellow;
            dictionary_Pen["Lime"] = Pens.Lime;
            dictionary_Pen["LimeGreen"] = Pens.LimeGreen;
            dictionary_Pen["Linen"] = Pens.Linen;
            dictionary_Pen["Magenta"] = Pens.Magenta;
            dictionary_Pen["Maroon"] = Pens.Maroon;
            dictionary_Pen["MediumAquamarine"] = Pens.MediumAquamarine;
            dictionary_Pen["MediumBlue"] = Pens.MediumBlue;
            dictionary_Pen["MediumOrchid"] = Pens.MediumOrchid;
            dictionary_Pen["MediumPurple"] = Pens.MediumPurple;
            dictionary_Pen["MediumSeaGreen"] = Pens.MediumSeaGreen;
            dictionary_Pen["MediumSlateBlue"] = Pens.MediumSlateBlue;
            dictionary_Pen["MediumSpringGreen"] = Pens.MediumSpringGreen;
            dictionary_Pen["MediumTurquoise"] = Pens.MediumTurquoise;
            dictionary_Pen["MediumVioletRed"] = Pens.MediumVioletRed;
            dictionary_Pen["MidnightBlue"] = Pens.MidnightBlue;
            dictionary_Pen["MintCream"] = Pens.MintCream;
            dictionary_Pen["MistyRose"] = Pens.MistyRose;
            dictionary_Pen["Moccasin"] = Pens.Moccasin;
            dictionary_Pen["NavajoWhite"] = Pens.NavajoWhite;
            dictionary_Pen["Navy"] = Pens.Navy;
            dictionary_Pen["OldLace"] = Pens.OldLace;
            dictionary_Pen["Olive"] = Pens.Olive;
            dictionary_Pen["OliveDrab"] = Pens.OliveDrab;
            dictionary_Pen["Orange"] = Pens.Orange;
            dictionary_Pen["OrangeRed"] = Pens.OrangeRed;
            dictionary_Pen["Orchid"] = Pens.Orchid;
            dictionary_Pen["PaleGoldenrod"] = Pens.PaleGoldenrod;
            dictionary_Pen["PaleGreen"] = Pens.PaleGreen;
            dictionary_Pen["PaleTurquoise"] = Pens.PaleTurquoise;
            dictionary_Pen["PaleVioletRed"] = Pens.PaleVioletRed;
            dictionary_Pen["PapayaWhip"] = Pens.PapayaWhip;
            dictionary_Pen["PeachPuff"] = Pens.PeachPuff;
            dictionary_Pen["Peru"] = Pens.Peru;
            dictionary_Pen["Pink"] = Pens.Pink;
            dictionary_Pen["Plum"] = Pens.Plum;
            dictionary_Pen["PowderBlue"] = Pens.PowderBlue;
            dictionary_Pen["Purple"] = Pens.Purple;
            dictionary_Pen["Red"] = Pens.Red;
            dictionary_Pen["RosyBrown"] = Pens.RosyBrown;
            dictionary_Pen["RoyalBlue"] = Pens.RoyalBlue;
            dictionary_Pen["SaddleBrown"] = Pens.SaddleBrown;
            dictionary_Pen["Salmon"] = Pens.Salmon;
            dictionary_Pen["SandyBrown"] = Pens.SandyBrown;
            dictionary_Pen["SeaGreen"] = Pens.SeaGreen;
            dictionary_Pen["SeaShell"] = Pens.SeaShell;
            dictionary_Pen["Sienna"] = Pens.Sienna;
            dictionary_Pen["Silver"] = Pens.Silver;
            dictionary_Pen["SkyBlue"] = Pens.SkyBlue;
            dictionary_Pen["SlateBlue"] = Pens.SlateBlue;
            dictionary_Pen["SlateGray"] = Pens.SlateGray;
            dictionary_Pen["Snow"] = Pens.Snow;
            dictionary_Pen["SpringGreen"] = Pens.SpringGreen;
            dictionary_Pen["SteelBlue"] = Pens.SteelBlue;
            dictionary_Pen["Tan"] = Pens.Tan;
            dictionary_Pen["Teal"] = Pens.Teal;
            dictionary_Pen["Thistle"] = Pens.Thistle;
            dictionary_Pen["Tomato"] = Pens.Tomato;
            dictionary_Pen["Transparent"] = Pens.Transparent;
            dictionary_Pen["Turquoise"] = Pens.Turquoise;
            dictionary_Pen["Violet"] = Pens.Violet;
            dictionary_Pen["Wheat"] = Pens.Wheat;
            dictionary_Pen["White"] = Pens.White;
            dictionary_Pen["WhiteSmoke"] = Pens.WhiteSmoke;
            dictionary_Pen["Yellow"] = Pens.Yellow;
            dictionary_Pen["YellowGreen"] = Pens.YellowGreen;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ペンの名前から、ペン・オブジェクトを取得します。
        /// </summary>
        /// <param name="penName"></param>
        /// <returns></returns>
        static public Pen Parse(string sName_Pen)
        {
            if (dictionary_Pen.ContainsKey(sName_Pen))
            {
                return dictionary_Pen[sName_Pen];
            }
            else
            {
                return Pens.Black;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// ペン。
        /// </summary>
        private static Dictionary<string, Pen> dictionary_Pen;

        //────────────────────────────────────────
        #endregion



    }
}
