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

            this.nNo = -1;
            this.sName = "";

            this.nTabindex = -1;
            this.BEnabled = true;//活性化
            this.nTree = 1;
            this.sItemDisplayFormat = "";

            this.SCheckboxValuetype = "";
            this.sNewline = "";
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

        public void TryGetFilepath_Givechapterandverse(out Givechapterandverse_Filepath out_Value, string sName, bool bRequired, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "TryGetFilepath_Givechapterandverse", log_Reports);
            //

            if (!this.Dictionary_Field.ContainsKey(sName))
            {
                //該当なし。

                if (bRequired)
                {
                    out_Value = new Givechapterandverse_FilepathImpl(log_Method.Fullname,null);//ヌル・オブジェクト。
                    goto gt_Error_NotFound;
                }
                else
                {
                    out_Value = new Givechapterandverse_FilepathImpl(log_Method.Fullname, null);//ヌル・オブジェクト。
                    goto gt_EndMethod;
                }
            }

            FieldUserformtable fo_Field = this.Dictionary_Field[sName];

            if (EnumTypedb.GcavFilepath != fo_Field.EnumTypedb)
            {
                //型が異なる。

                if (bRequired)
                {
                    out_Value = new Givechapterandverse_FilepathImpl(log_Method.Fullname, null);//ヌル・オブジェクト。
                    goto gt_Error_Type;
                }
                else
                {
                    out_Value = new Givechapterandverse_FilepathImpl(log_Method.Fullname, null);//ヌル・オブジェクト。
                    goto gt_EndMethod;
                }
            }
            out_Value = (Givechapterandverse_Filepath)fo_Field.Data;

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
            txt.Append(this.NNo);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "tree=[");
            txt.Append(this.nTree);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "] type=[");
            txt.Append(this.sType);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "text=[");
            txt.Append(this.sText);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "enabled=[");
            txt.Append(this.bEnabled);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "visible=[");
            txt.Append(this.bVisible);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "readOnly=[");
            txt.Append(this.bReadonly);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "wordWrap=[");
            txt.Append(this.bWordwrap);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "newLine=[");
            txt.Append(this.sNewline);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "scrollBars=[");
            txt.Append(this.sScrollbars);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "fontSizePt=[");
            txt.Append(this.sFontsizePt);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "itemHeightPx=[");
            txt.Append(this.nItemheightPx);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "itemDisplayFormat=[");
            txt.Append(this.sItemDisplayFormat);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "picZoom=[");
            txt.Append(this.nPiczoom);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "absXLt=[");
            txt.Append(this.nLeft_Abstract);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "absYLt=[");
            txt.Append(this.nTop_Absolute);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "width=[");
            txt.Append(this.nWidth);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "height=[");
            txt.Append(this.nHeight);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "tabIndex=[");
            txt.Append(this.nTabindex);
            txt.Append("]");
            txt.Newline();

            txt.AppendI(1, "backColor=[");
            txt.Append(this.sBackcolor);
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

        private int nNo;

        /// <summary>
        /// NO フィールド値。
        /// </summary>
        public int NNo
        {
            get
            {
                return nNo;
            }
            set
            {
                nNo = value;
            }
        }

        //────────────────────────────────────────

        private int nTree;

        /// <summary>
        /// 相対座標のネスト階層。
        /// 最上位を 1 とし、その子は 2 となる。
        /// 2 の子は 3 となる。
        /// </summary>
        public int NTree
        {
            get
            {
                return nTree;
            }
            set
            {
                nTree = value;
            }
        }

        //────────────────────────────────────────

        private string sName;

        /// <summary>
        /// コントロールの名前。
        /// </summary>
        public string SName
        {
            get
            {
                return sName;
            }
            set
            {
                sName = value;
            }
        }

        //────────────────────────────────────────

        private string sType;

        /// <summary>
        /// コントロールの種類。
        /// </summary>
        public string SType
        {
            get
            {
                return sType;
            }
            set
            {
                sType = value;
            }
        }

        //────────────────────────────────────────

        private string sText;

        /// <summary>
        /// 初期値。
        /// </summary>
        public string SText
        {
            get
            {
                return sText;
            }
            set
            {
                sText = value;
            }
        }

        //────────────────────────────────────────

        private Givechapterandverse_Filepath file_Givechapterandverse;

        /// <summary>
        /// コンポーネント設定ファイルへのパス。
        /// </summary>
        public Givechapterandverse_Filepath File_Givechapterandverse
        {
            get
            {
                return file_Givechapterandverse;
            }
            set
            {
                file_Givechapterandverse = value;
            }
        }

        //────────────────────────────────────────

        private bool bEnabled;

        /// <summary>
        /// ENABLED     入力できるか否か。
        /// </summary>
        public bool BEnabled
        {
            get
            {
                return bEnabled;
            }
            set
            {
                bEnabled = value;
            }
        }

        //────────────────────────────────────────

        private bool bVisible;

        /// <summary>
        /// VISIBLE     可視か否か。
        /// </summary>
        public bool BVisible
        {
            get
            {
                return bVisible;
            }
            set
            {
                bVisible = value;
            }
        }

        //────────────────────────────────────────

        private bool bReadonly;

        /// <summary>
        /// テキストボックス等を読み取り専用にするなら真。
        /// </summary>
        public bool BReadonly
        {
            get
            {
                return bReadonly;
            }
            set
            {
                bReadonly = value;
            }
        }

        //────────────────────────────────────────

        private bool bWordwrap;

        /// <summary>
        /// テキストエリアで行を自動的に折り返すなら真。
        /// (word wrap)
        /// </summary>
        public bool BWordwrap
        {
            get
            {
                return bWordwrap;
            }
            set
            {
                bWordwrap = value;
            }
        }

        //────────────────────────────────────────

        private string sNewline;

        /// <summary>
        /// テキストエリアで改行を表す文字列。
        /// </summary>
        public string SNewline
        {
            get
            {
                return sNewline;
            }
            set
            {
                sNewline = value;
            }
        }

        //────────────────────────────────────────

        private string sScrollbars;

        /// <summary>
        /// テキストエリア等で利用。None,Horizontal,Vertical,Bothの４つ。使わないなら空欄。
        /// </summary>
        public string SScrollbars
        {
            get
            {
                return sScrollbars;
            }
            set
            {
                sScrollbars = value;
            }
        }

        //────────────────────────────────────────

        private string sCheckboxValuetype;

        /// <summary>
        /// チェックボックスの値の型。(空欄：false,true。ZERO_ONE：0,1）
        /// (CHK_VALUE_TYPE)
        /// </summary>
        public string SCheckboxValuetype
        {
            get
            {
                return sCheckboxValuetype;
            }
            set
            {
                sCheckboxValuetype = value;
            }
        }

        //────────────────────────────────────────

        private string sFontsizePt;

        /// <summary>
        /// フォント・サイズのpt指定。未指定の場合、nullが入っています。
        /// 
        /// SRSの仕様に浮動小数点型はないので、文字列で対応します。
        /// 例："6.75"
        /// </summary>
        public string SFontsizePt
        {
            get
            {
                return sFontsizePt;
            }
            set
            {
                sFontsizePt = value;
            }
        }

        //────────────────────────────────────────

        private int nItemheightPx;

        /// <summary>
        /// リストボックスの項目の縦幅。（ピクセル）
        /// 
        /// 例：フォントサイズが12ptのとき、リストボックスの項目の縦幅は16pxがちょうどよい。
        /// (ITEM_HEIGHT_PX)
        /// </summary>
        public int NItemheightPx
        {
            get
            {
                return nItemheightPx;
            }
            set
            {
                nItemheightPx = value;
            }
        }

        //────────────────────────────────────────

        private string sItemDisplayFormat;

        /// <summary>
        /// リストボックスの各項目の表示書式。
        /// 
        /// 例：「%1%:%2%|ID|NAME」など。
        /// </summary>
        public string SItemDisplayFormat
        {
            get
            {
                return sItemDisplayFormat;
            }
            set
            {
                sItemDisplayFormat = value;
            }
        }

        //────────────────────────────────────────

        private string sListValueField;

        /// <summary>
        /// リストボックスの値が入っている、レコードのフィールド名。
        /// </summary>
        public string SListValueField
        {
            get
            {
                return sListValueField;
            }
            set
            {
                sListValueField = value;
            }
        }

        //────────────────────────────────────────

        private int nPiczoom;

        /// <summary>
        /// 画像の倍角サイズ。2000なら2倍。
        /// (PIC_ZOOM)
        /// </summary>
        public int NPiczoom
        {
            get
            {
                return nPiczoom;
            }
            set
            {
                nPiczoom = value;
            }
        }

        //────────────────────────────────────────

        private int nLeft_Abstract;

        /// <summary>
        /// 左上角(Left Top)の絶対座標X。
        /// 旧名：NAbsXLt
        /// </summary>
        public int NLeft_Absolute
        {
            get
            {
                return nLeft_Abstract;
            }
            set
            {
                nLeft_Abstract = value;
            }
        }

        //────────────────────────────────────────

        private int nTop_Absolute;

        /// <summary>
        /// 左上角(Left Top)の絶対座標Y。
        /// 旧名：NAbsYLt
        /// </summary>
        public int NTop_Absolute
        {
            get
            {
                return nTop_Absolute;
            }
            set
            {
                nTop_Absolute = value;
            }
        }

        //────────────────────────────────────────

        private int nWidth;

        /// <summary>
        /// 横幅ピクセル。
        /// </summary>
        public int NWidth
        {
            get
            {
                return nWidth;
            }
            set
            {
                nWidth = value;
            }
        }

        //────────────────────────────────────────

        private int nHeight;

        /// <summary>
        /// 縦幅ピクセル。
        /// </summary>
        public int NHeight
        {
            get
            {
                return nHeight;
            }
            set
            {
                nHeight = value;
            }
        }

        //────────────────────────────────────────

        private int nTabindex;

        /// <summary>
        /// タブ・インデックス。未指定の場合 -1 が入っています。
        /// </summary>
        public int NTabindex
        {
            get
            {
                return nTabindex;
            }
            set
            {
                nTabindex = value;
            }
        }

        //────────────────────────────────────────

        private string sBackcolor;

        /// <summary>
        /// 背景色名
        /// </summary>
        public string SBackcolor
        {
            get
            {
                return sBackcolor;
            }
            set
            {
                sBackcolor = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }

}
