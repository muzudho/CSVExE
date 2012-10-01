using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//HumanInputFilePath,WarningReports
using Xenon.Middle;

namespace Xenon.Expr
{

    /// <summary>
    /// フォーム設定テーブルのレコードです。
    /// 
    /// コントロール１件分の初期値です。
    /// </summary>
    public class RecordUserformconfigImpl : RecordUserformconfig
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="olParent"></param>
        public RecordUserformconfigImpl(TableUserformconfig parent_TableUserformconfig)
        {
            this.dictionary_Field = new Dictionary<string, FieldUserformtable>();

            this.parent_TableUserformconfig = parent_TableUserformconfig;

            this.no = -1;
            this.name = "";

            this.tabindex = -1;
            this.IsEnabled = true;//活性化
            this.tree = 1;
            this.itemDisplayFormat = "";

            this.CheckboxValuetype = "";
            this.newline = "";
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void Set(string sName, EnumTypedb enum_Typedb, object value, Log_Reports log_Reports)
        {
            if (this.Dictionary_Field.ContainsKey(sName))
            {
                //todo:この連想配列は大文字小文字を区別しないので不具合を起こす可能性がある。
                this.Dictionary_Field[sName] = new FieldUserformtableImpl(sName, enum_Typedb, value);
            }
            else
            {
                this.Dictionary_Field.Add(sName, new FieldUserformtableImpl(sName, enum_Typedb, value));
            }
        }

        public void TryGetInt(out int out_NValue, string sName, bool bRequired, int nAlt, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "TryGetInt",log_Reports);
            //

            if (!this.Dictionary_Field.ContainsKey(sName))
            {
                //該当なし。

                if (bRequired)
                {
                    out_NValue = -1;
                    goto gt_Error_NotFound;
                }
                else
                {
                    out_NValue = nAlt;
                    goto gt_EndMethod;
                }
            }

            FieldUserformtable fo_Field = this.Dictionary_Field[sName];

            if (EnumTypedb.Int != fo_Field.EnumTypedb)
            {
                //型が異なる。

                if (bRequired)
                {
                    out_NValue = -1;
                    goto gt_Error_Type;
                }
                else
                {
                    out_NValue = nAlt;
                    goto gt_EndMethod;
                }
            }
            out_NValue = (int)fo_Field.Data;

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFound:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー101！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定のフィールドはありませんでした。");
                s.Append(Environment.NewLine);
                s.Append("フィールド名=[");
                s.Append(sName);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Type:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー102！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定のフィールドの型が異なりました。");
                s.Append(Environment.NewLine);
                s.Append("フィールド名=[");
                s.Append(sName);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append("フィールドの型=[");
                s.Append(fo_Field.EnumTypedb);
                s.Append("]");
                
                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        public void TryGetString(out string out_SValue, string sName, bool bRequired, string sAlt, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "TryGetString",log_Reports);
            //

            if (!this.Dictionary_Field.ContainsKey(sName))
            {
                //該当なし。

                if (bRequired)
                {
                    out_SValue = "";
                    goto gt_Error_NotFound;
                }
                else
                {
                    out_SValue = sAlt;
                    goto gt_EndMethod;
                }
            }

            FieldUserformtable fo_Field = this.Dictionary_Field[sName];

            if (EnumTypedb.String != fo_Field.EnumTypedb)
            {
                //型が異なる。

                if (bRequired)
                {
                    out_SValue = "";
                    goto gt_Error_Type;
                }
                else
                {
                    out_SValue = sAlt;
                    goto gt_EndMethod;
                }
            }
            out_SValue = (string)fo_Field.Data;

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFound:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー101！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定のフィールドはありませんでした。");
                s.Append(Environment.NewLine);
                s.Append("フィールド名=[");
                s.Append(sName);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Type:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー102！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定のフィールドの型が異なりました。");
                s.Append(Environment.NewLine);
                s.Append("フィールド名=[");
                s.Append(sName);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append("フィールドの型=[");
                s.Append(fo_Field.EnumTypedb);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        public void TryGetBool(out bool out_BValue, string sName, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "TryGetBool",log_Reports);
            //

            if (!this.Dictionary_Field.ContainsKey(sName))
            {
                //該当なし。
                out_BValue = false;
                goto gt_Error_NotFound;
            }

            FieldUserformtable fo_Field = this.Dictionary_Field[sName];

            if (EnumTypedb.Bool != fo_Field.EnumTypedb)
            {
                //型が異なる。
                out_BValue = false;
                goto gt_Error_Type;
            }
            out_BValue = (bool)fo_Field.Data;

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFound:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー101！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定のフィールドはありませんでした。");
                s.Append(Environment.NewLine);
                s.Append("フィールド名=[");
                s.Append(sName);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Type:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー102！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定のフィールドの型が異なりました。");
                s.Append(Environment.NewLine);
                s.Append("フィールド名=[");
                s.Append(sName);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append("フィールドの型=[");
                s.Append(fo_Field.EnumTypedb);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        public void TryGetFilepath_Configurationtree(out Configurationtree_NodeFilepath out_Value, string sName, bool bRequired, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "TryGetFilepath_Configurationtree", log_Reports);
            //

            if (!this.Dictionary_Field.ContainsKey(sName))
            {
                //該当なし。

                if (bRequired)
                {
                    out_Value = new Configurationtree_NodeFilepathImpl(log_Method.Fullname,null);//ヌル・オブジェクト。
                    goto gt_Error_NotFound;
                }
                else
                {
                    out_Value = new Configurationtree_NodeFilepathImpl(log_Method.Fullname, null);//ヌル・オブジェクト。
                    goto gt_EndMethod;
                }
            }

            FieldUserformtable fo_Field = this.Dictionary_Field[sName];

            if (EnumTypedb.GcavFilepath != fo_Field.EnumTypedb)
            {
                //型が異なる。

                if (bRequired)
                {
                    out_Value = new Configurationtree_NodeFilepathImpl(log_Method.Fullname, null);//ヌル・オブジェクト。
                    goto gt_Error_Type;
                }
                else
                {
                    out_Value = new Configurationtree_NodeFilepathImpl(log_Method.Fullname, null);//ヌル・オブジェクト。
                    goto gt_EndMethod;
                }
            }
            out_Value = (Configurationtree_NodeFilepath)fo_Field.Data;

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFound:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー101！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定のフィールドはありませんでした。");
                s.Append(Environment.NewLine);
                s.Append("フィールド名=[");
                s.Append(sName);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Type:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー102！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定のフィールドの型が異なりました。");
                s.Append(Environment.NewLine);
                s.Append("フィールド名=[");
                s.Append(sName);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append("フィールドの型=[");
                s.Append(fo_Field.EnumTypedb);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 各属性を出したい。
        /// </summary>
        /// <param name="txt"></param>
        public void ToDescription(Log_TextIndented txt)
        {
            txt.Increment();


            txt.Append("<" + this.GetType().Name + "クラス");
            txt.Newline();

            txt.AppendI(1, "no=[");
            txt.Append(this.No);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "tree=[");
            txt.Append(this.tree);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "] type=[");
            txt.Append(this.name_Type);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "text=[");
            txt.Append(this.text);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "enabled=[");
            txt.Append(this.isEnabled);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "visible=[");
            txt.Append(this.isVisibled);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "readOnly=[");
            txt.Append(this.isReadonly);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "wordWrap=[");
            txt.Append(this.isWordwrapped);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "newLine=[");
            txt.Append(this.newline);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "scrollBars=[");
            txt.Append(this.scrollbars);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "fontSizePt=[");
            txt.Append(this.fontsizePt);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "itemHeightPx=[");
            txt.Append(this.itemheightPx);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "itemDisplayFormat=[");
            txt.Append(this.itemDisplayFormat);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "picZoom=[");
            txt.Append(this.piczoom);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "absXLt=[");
            txt.Append(this.left_Abstract);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "absYLt=[");
            txt.Append(this.top_Absolute);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "width=[");
            txt.Append(this.width);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "height=[");
            txt.Append(this.height);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "tabIndex=[");
            txt.Append(this.tabindex);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "backColor=[");
            txt.Append(this.backcolor);
            txt.Append("]");
            txt.Newline();

            txt.Append("/>");
            txt.Newline();


            txt.Decrement();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<string, FieldUserformtable> dictionary_Field;

        public Dictionary<string, FieldUserformtable> Dictionary_Field
        {
            get
            {
                return this.dictionary_Field;
            }
        }

        //────────────────────────────────────────

        private TableUserformconfig parent_TableUserformconfig;

        /// <summary>
        /// 親要素。
        /// </summary>
        public TableUserformconfig Parent_TableUserformconfig
        {
            get
            {
                return parent_TableUserformconfig;
            }
        }

        //────────────────────────────────────────

        private int no;

        /// <summary>
        /// NO フィールド値。
        /// </summary>
        public int No
        {
            get
            {
                return no;
            }
            set
            {
                no = value;
            }
        }

        //────────────────────────────────────────

        private int tree;

        /// <summary>
        /// 相対座標のネスト階層。
        /// 最上位を 1 とし、その子は 2 となる。
        /// 2 の子は 3 となる。
        /// </summary>
        public int Tree
        {
            get
            {
                return tree;
            }
            set
            {
                tree = value;
            }
        }

        //────────────────────────────────────────

        private string name;

        /// <summary>
        /// コントロールの名前。
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //────────────────────────────────────────

        private string name_Type;

        /// <summary>
        /// コントロールの種類。
        /// </summary>
        public string Name_Type
        {
            get
            {
                return name_Type;
            }
            set
            {
                name_Type = value;
            }
        }

        //────────────────────────────────────────

        private string text;

        /// <summary>
        /// 初期値。
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        //────────────────────────────────────────

        private Configurationtree_NodeFilepath file_Configurationtree;

        /// <summary>
        /// コンポーネント設定ファイルへのパス。
        /// </summary>
        public Configurationtree_NodeFilepath File_Configurationtree
        {
            get
            {
                return file_Configurationtree;
            }
            set
            {
                file_Configurationtree = value;
            }
        }

        //────────────────────────────────────────

        private bool isEnabled;

        /// <summary>
        /// ENABLED     入力できるか否か。
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
            }
        }

        //────────────────────────────────────────

        private bool isVisibled;

        /// <summary>
        /// VISIBLE     可視か否か。
        /// </summary>
        public bool IsVisibled
        {
            get
            {
                return isVisibled;
            }
            set
            {
                isVisibled = value;
            }
        }

        //────────────────────────────────────────

        private bool isReadonly;

        /// <summary>
        /// テキストボックス等を読み取り専用にするなら真。
        /// </summary>
        public bool IsReadonly
        {
            get
            {
                return isReadonly;
            }
            set
            {
                isReadonly = value;
            }
        }

        //────────────────────────────────────────

        private bool isWordwrapped;

        /// <summary>
        /// テキストエリアで行を自動的に折り返すなら真。
        /// (word wrap)
        /// </summary>
        public bool IsWordwrapped
        {
            get
            {
                return isWordwrapped;
            }
            set
            {
                isWordwrapped = value;
            }
        }

        //────────────────────────────────────────

        private string newline;

        /// <summary>
        /// テキストエリアで改行を表す文字列。
        /// </summary>
        public string Newline
        {
            get
            {
                return newline;
            }
            set
            {
                newline = value;
            }
        }

        //────────────────────────────────────────

        private string scrollbars;

        /// <summary>
        /// テキストエリア等で利用。None,Horizontal,Vertical,Bothの４つ。使わないなら空欄。
        /// </summary>
        public string Scrollbars
        {
            get
            {
                return scrollbars;
            }
            set
            {
                scrollbars = value;
            }
        }

        //────────────────────────────────────────

        private string checkboxValuetype;

        /// <summary>
        /// チェックボックスの値の型。(空欄：false,true。ZERO_ONE：0,1）
        /// (CHK_VALUE_TYPE)
        /// </summary>
        public string CheckboxValuetype
        {
            get
            {
                return checkboxValuetype;
            }
            set
            {
                checkboxValuetype = value;
            }
        }

        //────────────────────────────────────────

        private string fontsizePt;

        /// <summary>
        /// フォント・サイズのpt指定。未指定の場合、nullが入っています。
        /// 
        /// SRSの仕様に浮動小数点型はないので、文字列で対応します。
        /// 例："6.75"
        /// </summary>
        public string FontsizePt
        {
            get
            {
                return fontsizePt;
            }
            set
            {
                fontsizePt = value;
            }
        }

        //────────────────────────────────────────

        private int itemheightPx;

        /// <summary>
        /// リストボックスの項目の縦幅。（ピクセル）
        /// 
        /// 例：フォントサイズが12ptのとき、リストボックスの項目の縦幅は16pxがちょうどよい。
        /// (ITEM_HEIGHT_PX)
        /// </summary>
        public int ItemheightPx
        {
            get
            {
                return itemheightPx;
            }
            set
            {
                itemheightPx = value;
            }
        }

        //────────────────────────────────────────

        private string itemDisplayFormat;

        /// <summary>
        /// リストボックスの各項目の表示書式。
        /// 
        /// 例：「%1%:%2%|ID|NAME」など。
        /// </summary>
        public string ItemDisplayFormat
        {
            get
            {
                return itemDisplayFormat;
            }
            set
            {
                itemDisplayFormat = value;
            }
        }

        //────────────────────────────────────────

        private string listValueField;

        /// <summary>
        /// リストボックスの値が入っている、レコードのフィールド名。
        /// </summary>
        public string ListValueField
        {
            get
            {
                return listValueField;
            }
            set
            {
                listValueField = value;
            }
        }

        //────────────────────────────────────────

        private int piczoom;

        /// <summary>
        /// 画像の倍角サイズ。2000なら2倍。
        /// (PIC_ZOOM)
        /// </summary>
        public int Piczoom
        {
            get
            {
                return piczoom;
            }
            set
            {
                piczoom = value;
            }
        }

        //────────────────────────────────────────

        private int left_Abstract;

        /// <summary>
        /// 左上角(Left Top)の絶対座標X。
        /// 旧名：NAbsXLt
        /// </summary>
        public int Left_Absolute
        {
            get
            {
                return left_Abstract;
            }
            set
            {
                left_Abstract = value;
            }
        }

        //────────────────────────────────────────

        private int top_Absolute;

        /// <summary>
        /// 左上角(Left Top)の絶対座標Y。
        /// 旧名：NAbsYLt
        /// </summary>
        public int Top_Absolute
        {
            get
            {
                return top_Absolute;
            }
            set
            {
                top_Absolute = value;
            }
        }

        //────────────────────────────────────────

        private int width;

        /// <summary>
        /// 横幅ピクセル。
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        //────────────────────────────────────────

        private int height;

        /// <summary>
        /// 縦幅ピクセル。
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        //────────────────────────────────────────

        private int tabindex;

        /// <summary>
        /// タブ・インデックス。未指定の場合 -1 が入っています。
        /// </summary>
        public int Tabindex
        {
            get
            {
                return tabindex;
            }
            set
            {
                tabindex = value;
            }
        }

        //────────────────────────────────────────

        private string backcolor;

        /// <summary>
        /// 背景色名
        /// </summary>
        public string Backcolor
        {
            get
            {
                return backcolor;
            }
            set
            {
                backcolor = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }

}
