using System;
using System.Collections.Generic;
using System.Drawing;//Color
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// 色名は、全て小文字として設定しています。（大文字・小文字を区別しないようにするため）
    /// </summary>
    public class BuilderColor
    {



        #region 生成と破棄
        //────────────────────────────────────────

        static BuilderColor()
        {
            dictionary_Color = new Dictionary<string, Color>();
            dictionary_Color["aliceblue"] = Color.AliceBlue;
            dictionary_Color["antiquewhite"] = Color.AntiqueWhite;
            dictionary_Color["aqua"] = Color.Aqua;
            dictionary_Color["aquamarine"] = Color.Aquamarine;
            dictionary_Color["azure"] = Color.Azure;
            dictionary_Color["beige"] = Color.Beige;
            dictionary_Color["bisque"] = Color.Bisque;
            dictionary_Color["black"] = Color.Black;
            dictionary_Color["blanchedalmond"] = Color.BlanchedAlmond;
            dictionary_Color["blue"] = Color.Blue;
            dictionary_Color["blueviolet"] = Color.BlueViolet;
            dictionary_Color["brown"] = Color.Brown;
            dictionary_Color["burlywood"] = Color.BurlyWood;
            dictionary_Color["cadetblue"] = Color.CadetBlue;
            dictionary_Color["chartreuse"] = Color.Chartreuse;
            dictionary_Color["chocolate"] = Color.Chocolate;
            dictionary_Color["coral"] = Color.Coral;
            dictionary_Color["cornflowerblue"] = Color.CornflowerBlue;
            dictionary_Color["cornsilk"] = Color.Cornsilk;
            dictionary_Color["crimson"] = Color.Crimson;
            dictionary_Color["cyan"] = Color.Cyan;
            dictionary_Color["darkblue"] = Color.DarkBlue;
            dictionary_Color["darkcyan"] = Color.DarkCyan;
            dictionary_Color["darkgoldenrod"] = Color.DarkGoldenrod;
            dictionary_Color["darkgray"] = Color.DarkGray;
            dictionary_Color["darkgreen"] = Color.DarkGreen;
            dictionary_Color["darkkhaki"] = Color.DarkKhaki;
            dictionary_Color["darkmagenta"] = Color.DarkMagenta;
            dictionary_Color["darkolivegreen"] = Color.DarkOliveGreen;
            dictionary_Color["darkorange"] = Color.DarkOrange;
            dictionary_Color["darkorchid"] = Color.DarkOrchid;
            dictionary_Color["darkred"] = Color.DarkRed;
            dictionary_Color["darksalmon"] = Color.DarkSalmon;
            dictionary_Color["darkseagreen"] = Color.DarkSeaGreen;
            dictionary_Color["darkslateblue"] = Color.DarkSlateBlue;
            dictionary_Color["darkslategray"] = Color.DarkSlateGray;
            dictionary_Color["sarkturquoise"] = Color.DarkTurquoise;
            dictionary_Color["darkviolet"] = Color.DarkViolet;
            dictionary_Color["deeppink"] = Color.DeepPink;
            dictionary_Color["deepskyblue"] = Color.DeepSkyBlue;
            dictionary_Color["dimgray"] = Color.DimGray;
            dictionary_Color["dodgerblue"] = Color.DodgerBlue;
            dictionary_Color["firebrick"] = Color.Firebrick;
            dictionary_Color["floralwhite"] = Color.FloralWhite;
            dictionary_Color["forestgreen"] = Color.ForestGreen;
            dictionary_Color["fuchsia"] = Color.Fuchsia;
            dictionary_Color["gainsboro"] = Color.Gainsboro;
            dictionary_Color["ghostwhite"] = Color.GhostWhite;
            dictionary_Color["gold"] = Color.Gold;
            dictionary_Color["goldenrod"] = Color.Goldenrod;
            dictionary_Color["gray"] = Color.Gray;
            dictionary_Color["green"] = Color.Green;
            dictionary_Color["greenyellow"] = Color.GreenYellow;
            dictionary_Color["honeydew"] = Color.Honeydew;
            dictionary_Color["hotpink"] = Color.HotPink;
            dictionary_Color["indianred"] = Color.IndianRed;
            dictionary_Color["indigo"] = Color.Indigo;
            dictionary_Color["ivory"] = Color.Ivory;
            dictionary_Color["khaki"] = Color.Khaki;
            dictionary_Color["lavender"] = Color.Lavender;
            dictionary_Color["lavenderblush"] = Color.LavenderBlush;
            dictionary_Color["lawngreen"] = Color.LawnGreen;
            dictionary_Color["lemonchiffon"] = Color.LemonChiffon;
            dictionary_Color["lightblue"] = Color.LightBlue;
            dictionary_Color["lightcoral"] = Color.LightCoral;
            dictionary_Color["lightcyan"] = Color.LightCyan;
            dictionary_Color["lightgoldenrodyellow"] = Color.LightGoldenrodYellow;
            dictionary_Color["lightgray"] = Color.LightGray;
            dictionary_Color["lightgreen"] = Color.LightGreen;
            dictionary_Color["lightpink"] = Color.LightPink;
            dictionary_Color["lightsalmon"] = Color.LightSalmon;
            dictionary_Color["lightseagreen"] = Color.LightSeaGreen;
            dictionary_Color["lightskyblue"] = Color.LightSkyBlue;
            dictionary_Color["lightslategray"] = Color.LightSlateGray;
            dictionary_Color["lightsteelblue"] = Color.LightSteelBlue;
            dictionary_Color["lightyellow"] = Color.LightYellow;
            dictionary_Color["lime"] = Color.Lime;
            dictionary_Color["limegreen"] = Color.LimeGreen;
            dictionary_Color["linen"] = Color.Linen;
            dictionary_Color["magenta"] = Color.Magenta;
            dictionary_Color["maroon"] = Color.Maroon;
            dictionary_Color["mediumaquamarine"] = Color.MediumAquamarine;
            dictionary_Color["mediumblue"] = Color.MediumBlue;
            dictionary_Color["mediumorchid"] = Color.MediumOrchid;
            dictionary_Color["mediumpurple"] = Color.MediumPurple;
            dictionary_Color["mediumseagreen"] = Color.MediumSeaGreen;
            dictionary_Color["mediumslateblue"] = Color.MediumSlateBlue;
            dictionary_Color["mediumspringgreen"] = Color.MediumSpringGreen;
            dictionary_Color["mediumturquoise"] = Color.MediumTurquoise;
            dictionary_Color["mediumvioletred"] = Color.MediumVioletRed;
            dictionary_Color["midnightblue"] = Color.MidnightBlue;
            dictionary_Color["mintcream"] = Color.MintCream;
            dictionary_Color["mistyrose"] = Color.MistyRose;
            dictionary_Color["moccasin"] = Color.Moccasin;
            dictionary_Color["navajowhite"] = Color.NavajoWhite;
            dictionary_Color["navy"] = Color.Navy;
            dictionary_Color["oldlace"] = Color.OldLace;
            dictionary_Color["olive"] = Color.Olive;
            dictionary_Color["olivedrab"] = Color.OliveDrab;
            dictionary_Color["orange"] = Color.Orange;
            dictionary_Color["orangered"] = Color.OrangeRed;
            dictionary_Color["orchid"] = Color.Orchid;
            dictionary_Color["palegoldenrod"] = Color.PaleGoldenrod;
            dictionary_Color["palegreen"] = Color.PaleGreen;
            dictionary_Color["paleturquoise"] = Color.PaleTurquoise;
            dictionary_Color["palevioletred"] = Color.PaleVioletRed;
            dictionary_Color["papayawhip"] = Color.PapayaWhip;
            dictionary_Color["peachpuff"] = Color.PeachPuff;
            dictionary_Color["peru"] = Color.Peru;
            dictionary_Color["pink"] = Color.Pink;
            dictionary_Color["plum"] = Color.Plum;
            dictionary_Color["powderblue"] = Color.PowderBlue;
            dictionary_Color["purple"] = Color.Purple;
            dictionary_Color["red"] = Color.Red;
            dictionary_Color["rosybrown"] = Color.RosyBrown;
            dictionary_Color["royalblue"] = Color.RoyalBlue;
            dictionary_Color["saddlebrown"] = Color.SaddleBrown;
            dictionary_Color["salmon"] = Color.Salmon;
            dictionary_Color["sandybrown"] = Color.SandyBrown;
            dictionary_Color["seagreen"] = Color.SeaGreen;
            dictionary_Color["seashell"] = Color.SeaShell;
            dictionary_Color["sienna"] = Color.Sienna;
            dictionary_Color["silver"] = Color.Silver;
            dictionary_Color["skyblue"] = Color.SkyBlue;
            dictionary_Color["slateblue"] = Color.SlateBlue;
            dictionary_Color["slategray"] = Color.SlateGray;
            dictionary_Color["snow"] = Color.Snow;
            dictionary_Color["springgreen"] = Color.SpringGreen;
            dictionary_Color["steelblue"] = Color.SteelBlue;
            dictionary_Color["tan"] = Color.Tan;
            dictionary_Color["teal"] = Color.Teal;
            dictionary_Color["thistle"] = Color.Thistle;
            dictionary_Color["tomato"] = Color.Tomato;
            dictionary_Color["transparent"] = Color.Transparent;
            dictionary_Color["turquoise"] = Color.Turquoise;
            dictionary_Color["violet"] = Color.Violet;
            dictionary_Color["wheat"] = Color.Wheat;
            dictionary_Color["white"] = Color.White;
            dictionary_Color["whitesmoke"] = Color.WhiteSmoke;
            dictionary_Color["yellow"] = Color.Yellow;
            dictionary_Color["yellowgreen"] = Color.YellowGreen;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ブラシの名前から、ブラシ・オブジェクトを取得します。
        /// </summary>
        /// <param name="colorName"></param>
        /// <param name="defaultColor">該当がなかった場合に返す値。</param>
        /// <param name="noHitIsNull">該当がなかった場合に、第二引数を無視してヌルを返すなら真。</param>
        /// <returns></returns>
        static public ColorResult Parse(string sName_Color, Color defaultColor, bool bNoHitIsNull)
        {
            // 大文字・小文字を無視するために。
            string sName_ColorL = sName_Color.ToLower();

            // ContainsKeyは大文字・小文字を区別します。
            if (dictionary_Color.ContainsKey(sName_ColorL))
            {
                // インデクサは、大文字・小文字を区別しません。
                // が、挙動がいまひとつその通りでないので小文字にして検索。
                return new ColorResult(dictionary_Color[sName_ColorL], false);
            }
            else
            {
                if(bNoHitIsNull)
                {
                    return new ColorResult(Color.Black,true);
                }
                else
                {
                    return new ColorResult(defaultColor,false);
                }
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// ブラシ。
        /// </summary>
        private static Dictionary<string, Color> dictionary_Color;

        //────────────────────────────────────────
        #endregion



    }

    /// <summary>
    /// パース結果の色。
    /// </summary>
    public class ColorResult
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public ColorResult(Color color, bool bNotFound)
        {
            this.color = color;
            this.bNotFound = bNotFound;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Color color;

        /// <summary>
        /// パース結果の色。該当なしの場合には無効な値。
        /// </summary>
        public Color Color
        {
            get
            {
                return color;
            }
        }

        //────────────────────────────────────────

        private bool bNotFound;

        /// <summary>
        /// 該当なしなら真。
        /// </summary>
        public bool BNotFound
        {
            get
            {
                return bNotFound;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
