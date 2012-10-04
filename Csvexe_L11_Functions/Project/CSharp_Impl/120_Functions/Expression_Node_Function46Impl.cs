using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;//DataRow
using System.Windows.Forms;//Application
using Xenon.Syntax;
using Xenon.Table;
using Xenon.Middle;

namespace Xenon.Functions
{


    /// <summary>
    /// フォーム・モデルを、CSVに書出します。
    /// </summary>
    public class Expression_Node_Function46Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string NAME_FUNCTION = "Sf:CSV書出し_フォーム;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 表示文章。
        /// </summary>
        public static string PM_MESSAGE = PmNames.S_MESSAGE.Name_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function46Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function46Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Gcav), log_Reports);

            f0.SetAttribute(Expression_Node_Function46Impl.PM_MESSAGE, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);

            //
            log_Method.EndMethod(log_Reports);
            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override string Expression_ExecuteMain(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Expression_ExecuteMain",log_Reports);

            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Lr)
            {
                this.Functionparameterset.Node_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";


                this.Perform2(
                    log_Reports
                    );


                //
                //

                //
                //
                //
                // 必ずフラグをオフにします。
                //
                //
                //
                ((EventMonitor)this.Functionparameterset.EventMonitor).BNowactionworking = false;
            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Perform2(
                    log_Reports
                    );
            }

            //
            //
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        protected void Perform2(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform2",log_Reports);

            string sName_Fnc;
            this.TrySelectAttribute(out sName_Fnc, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sName_Fnc + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }


            //
            // 変数は、登録されている名前の変数は存在し、登録されていない名前の変数は（自動作成されたもの以外は）存在しない。
            //
            // 元となるテーブルを見ながら、変数オブジェクトの内容を調べていく。
            //
            //


            Configurationtree_Node cur_Cf = new Configurationtree_NodeImpl(log_Method.Fullname, null);


            // 変数ログを吐く。
            {
                StringBuilder sb = new StringBuilder();

                //１行目
                sb.Append(NamesFld.S_NO);//NO
                sb.Append(",");
                sb.Append(NamesFld.S_ID);//ID
                sb.Append(",");
                sb.Append(NamesFld.S_TREE);//TREE
                sb.Append(",");
                sb.Append(NamesFld.S_EXPL);//Expl
                sb.Append(",");
                sb.Append(NamesFld.S_FILE);//FILE
                sb.Append(",");
                sb.Append(NamesFld.S_NAME);//NAME
                sb.Append(",");
                sb.Append(NamesFld.S_TYPE);//TYPE
                sb.Append(",");
                sb.Append(NamesFld.S_TEXT);//TEXT
                sb.Append(",");
                sb.Append(NamesFld.S_FONT_SIZE_PT);//FONT_SIZE_PT
                sb.Append(",");
                sb.Append(NamesFld.S_X_LT);//X_LT
                sb.Append(",");
                sb.Append(NamesFld.S_Y_LT);//Y_LT
                sb.Append(",");
                sb.Append(NamesFld.S_WIDTH);//WIDTH
                sb.Append(",");
                sb.Append(NamesFld.S_HEIGHT);//HEIGHT
                sb.Append(",");
                sb.Append(NamesFld.S_ENABLED);//ENABLED
                sb.Append(",");
                sb.Append(NamesFld.S_VISIBLE);//VISIBLE
                sb.Append(",");
                sb.Append(NamesFld.S_READ_ONLY);//READ_ONLY
                sb.Append(",");
                sb.Append(NamesFld.S_WORD_WRAP);//WORD_WRAP
                sb.Append(",");
                sb.Append(NamesFld.S_NEW_LINE);//NEW_LINE
                sb.Append(",");
                sb.Append(NamesFld.S_SCROLL_BARS);//SCROLL_BARS
                sb.Append(",");
                sb.Append(NamesFld.S_CHK_VALUE_TYPE);//CHK_VALUE_TYPE
                sb.Append(",");
                sb.Append(NamesFld.S_PIC_ZOOM);//PIC_ZOOM
                sb.Append(",");
                sb.Append(NamesFld.S_TAB_INDEX);//TAB_INDEX
                sb.Append(",");
                sb.Append(NamesFld.S_BACK_COLOR);//BACK_COLOR
                sb.Append(",");
                //ここまで基本テーブル。
                sb.Append(NamesFld.S_ITEM_HEIGHT_PX);//ITEM_HEIGHT_PX
                sb.Append(",");
                sb.Append(NamesFld.S_ITEM_DISPLAY_FORMAT);//ITEM_DISPLAY_FORMAT
                sb.Append(",");
                sb.Append(NamesFld.S_LIST_VALUE_FIELD);//LIST_VALUE_FIELD
                sb.Append(",");
                sb.Append(NamesFld.S_END);
                sb.Append(Environment.NewLine);

                //２行目
                sb.Append(NamesTypedb.S_INT);//NO
                sb.Append(",");
                sb.Append(NamesTypedb.S_INT);//ID
                sb.Append(",");
                sb.Append(NamesTypedb.S_INT);//TREE
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//Expl
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//FILE
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//NAME
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//TYPE
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//TEXT
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//FONT_SIZE_PT
                sb.Append(",");
                sb.Append(NamesTypedb.S_INT);//X_LT
                sb.Append(",");
                sb.Append(NamesTypedb.S_INT);//Y_LT
                sb.Append(",");
                sb.Append(NamesTypedb.S_INT);//WIDTH
                sb.Append(",");
                sb.Append(NamesTypedb.S_INT);//HEIGHT
                sb.Append(",");
                sb.Append(NamesTypedb.S_BOOL);//ENABLED
                sb.Append(",");
                sb.Append(NamesTypedb.S_BOOL);//VISIBLE
                sb.Append(",");
                sb.Append(NamesTypedb.S_BOOL);//READ_ONLY
                sb.Append(",");
                sb.Append(NamesTypedb.S_BOOL);//WORD_WRAP
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//NEW_LINE
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//SCROLL_BARS
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//CHK_VALUE_TYPE
                sb.Append(",");
                sb.Append(NamesTypedb.S_INT);//PIC_ZOOM
                sb.Append(",");
                sb.Append(NamesTypedb.S_INT);//TAB_INDEX
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//BACK_COLOR
                sb.Append(",");
                //ここまで基本テーブル。
                sb.Append(NamesTypedb.S_INT);//ITEM_HEIGHT_PX
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//ITEM_DISPLAY_FORMAT
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//LIST_VALUE_FIELD
                sb.Append(",");
                sb.Append(NamesFld.S_END);
                sb.Append(Environment.NewLine);

                //３行目
                sb.Append("-1,");//NO
                sb.Append("使わない,");//ID
                sb.Append("ネスト関係,");//TREE
                sb.Append("解説,");//Expl
                sb.Append("コントロール設定ファイルパス,");//FILE
                sb.Append("コントロール固有名,");//NAME
                sb.Append("コントロールの型,");//TYPE
                sb.Append("初期値,");//TEXT
                sb.Append("フォントサイズ（pt）,");//FONT_SIZE_PT
                sb.Append("左上角の座標X,");//X_LT
                sb.Append("左上角の座標Y,");//Y_LT
                sb.Append("横幅ピクセル,");//WIDTH
                sb.Append("縦幅ピクセル,");//HEIGHT
                sb.Append("活性化,");//ENABLED
                sb.Append("可視,");//VISIBLE
                sb.Append("テキストボックス等を読み取り専用にするなら真。,");//READ_ONLY
                sb.Append("テキストエリアで行を自動的に折り返すなら真。,");//WORD_WRAP
                sb.Append("（テキストエリア）改行記号。,");//NEW_LINE
                sb.Append("テキストエリア等で利用。None,Horizontal,Vertical,Bothの４つ。使わないなら空欄。,");//SCROLL_BARS
                sb.Append("チェックボックスの値の型。(空欄：false,true。ZERO_ONE：0,1）,");//CHK_VALUE_TYPE
                sb.Append("（未実装）画像の倍角サイズ。2000で２倍。,");//PIC_ZOOM
                sb.Append("タブ・インデックス,");//TAB_INDEX
                sb.Append("背景色,");//BACK_COLOR
                //ここまで基本テーブル。
                sb.Append("リストボックスの項目の高さ（ピクセル）,");//ITEM_HEIGHT_PX
                sb.Append("リストボックスの各項目の表示書式,");//ITEM_DISPLAY_FORMAT
                sb.Append("（開発中）リストボックスの値が入っている、レコードのフィールド名。,");//LIST_VALUE_FIELD
                sb.Append(NamesFld.S_END);
                sb.Append(Environment.NewLine);

                int nAuto = 0;
                this.Owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol uct_Child, ref bool bRemove, ref bool bBreak)
                {
                    //uct_Child.ControlCommon.Configurationtree_Control.Dictionary_Attribute.

                    

                    sb.Append(nAuto);//NO
                    sb.Append(",");
                    //ID は使わない。
                    sb.Append(",");
                    sb.Append(NamesFld.S_TREE);//TREE
                    sb.Append(",");
                    sb.Append(NamesFld.S_EXPL);//Expl
                    sb.Append(",");
                    sb.Append(NamesFld.S_FILE);//FILE
                    sb.Append(",");
                    sb.Append(uct_Child.ControlCommon.Configurationtree_Control.Name);//NAME
                    sb.Append(",");
                    sb.Append(NamesFld.S_TYPE);//TYPE
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolText);//TEXT
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolFontsizept);//FONT_SIZE_PT
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolXlt);//X_LT
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolYlt);//Y_LT
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolWidth);//WIDTH
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolHeight);//HEIGHT
                    sb.Append(",");
                    if (uct_Child.UsercontrolEnabled)
                    {
                        sb.Append(uct_Child.UsercontrolEnabled);//ENABLED
                    }
                    sb.Append(",");
                    if (uct_Child.UsercontrolVisible)
                    {
                        sb.Append(uct_Child.UsercontrolVisible);//VISIBLE
                    }
                    sb.Append(",");
                    if (uct_Child.UsercontrolReadonly)
                    {
                        sb.Append(uct_Child.UsercontrolReadonly);//READ_ONLY
                    }
                    sb.Append(",");
                    if (uct_Child.UsercontrolWordwrap)
                    {
                        sb.Append(uct_Child.UsercontrolWordwrap);//WORD_WRAP
                    }
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolNewline);//NEW_LINE
                    sb.Append(",");
                    switch (uct_Child.UsercontrolScrollbars)
                    {
                        case ScrollBars.Both:
                            sb.Append(ValuesAttr.S_BOTH);
                            break;
                        case ScrollBars.Horizontal:
                            sb.Append(ValuesAttr.S_HORIZONTAL);
                            break;
                        case ScrollBars.Vertical:
                            sb.Append(ValuesAttr.S_VERTICAL);
                            break;
                        default:
                            //TODO:「無視」と、「無し」は、分けたい。
                            //sb.Append(ValuesAttr.S_NONE);
                            break;
                    }
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolChkvaluetype);//CHK_VALUE_TYPE
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolPiczoom);//PIC_ZOOM
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolTabindex);//TAB_INDEX
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolBackcolor);//BACK_COLOR
                    sb.Append(",");
                    //ここまで基本テーブル。
                    sb.Append(uct_Child.UsercontrolItemheightpx);//ITEM_HEIGHT_PX
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolItemdisplayformat);//ITEM_DISPLAY_FORMAT
                    sb.Append(",");
                    sb.Append(uct_Child.UsercontrolListvaluefield/*"NO"*/);//TODO:LIST_VALUE_FIELD
                    sb.Append(",");
                    sb.Append(NamesFld.S_END);
                    sb.Append(Environment.NewLine);

                    nAuto++;
                });


                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole(sb.ToString());
                }

                //ログ出力
                {
                    Expression_Node_Filepath ec_Fpath_Logs = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(NamesVar.S_SP_LOGS, null, cur_Cf), true, log_Reports);

                    string sFpatha_LogVariables = ec_Fpath_Logs.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + System.IO.Path.DirectorySeparatorChar + NamesFile.S_LOG_FORM;

                    if (log_Reports.Successful)
                    {
                        CsvWriterImpl writer = new CsvWriterImpl();
                        writer.Write(
                            sb.ToString(),
                            sFpatha_LogVariables,
                            true
                            );
                    }
                }
            }



            //変数CSVを吐き出したい。（登録されている順序を保って）
            {
                // 変数ファイルの読取り
                XenonTable o_Table_Variables;
                this.Owner_MemoryApplication.MemoryVariables.TryGetTable_Variables(
                    out o_Table_Variables,
                    Application.StartupPath,
                    log_Reports
                    );

                if (null != o_Table_Variables)
                {
                    StringBuilder sb = new StringBuilder();

                    //１行目
                    sb.Append(NamesFld.S_NO);//NO
                    sb.Append(",");
                    sb.Append(NamesFld.S_ID);//ID
                    sb.Append(",");
                    sb.Append(NamesFld.S_TREE);//TREE
                    sb.Append(",");
                    sb.Append(NamesFld.S_EXPL);//Expl
                    sb.Append(",");
                    sb.Append(NamesFld.S_NAME);
                    sb.Append(",");
                    sb.Append(NamesFld.S_FOLDER);
                    sb.Append(",");
                    sb.Append(NamesFld.S_VALUE);
                    sb.Append(",");
                    sb.Append(NamesFld.S_END);
                    sb.Append(Environment.NewLine);

                    //２行目
                    sb.Append(NamesTypedb.S_INT);//NO
                    sb.Append(",");
                    sb.Append(NamesTypedb.S_INT);//ID
                    sb.Append(",");
                    sb.Append(NamesTypedb.S_STRING);//Expl
                    sb.Append(",");
                    sb.Append(NamesTypedb.S_STRING);//NAME
                    sb.Append(",");
                    sb.Append(NamesTypedb.S_STRING);//FOLDER
                    sb.Append(",");
                    sb.Append(NamesTypedb.S_STRING);//VALUE
                    sb.Append(",");
                    sb.Append(NamesFld.S_END);//END
                    sb.Append(Environment.NewLine);

                    //３行目
                    sb.Append("-1,");//NO
                    sb.Append("使わない,");//ID
                    sb.Append("解説,");//Expl
                    sb.Append("変数名,");//NAME
                    sb.Append("（ファイルパス変数のみ指定有効）フォルダーパス,");//FOLDER
                    sb.Append("初期値,");//VALUE
                    sb.Append(NamesFld.S_END);//END
                    sb.Append(Environment.NewLine);


                    int nAuto = 0;
                    foreach (DataRow row in o_Table_Variables.DataTable.Rows)
                    {

                        if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_NO))
                        {
                            int nValue;
                            XenonValue_IntImpl.TryParse(row[NamesFld.S_NO], out nValue, EnumOperationIfErrorvalue.Spaces_To_Alt_Value, 0, log_Reports);
                            sb.Append(nValue);
                            sb.Append(",");
                        }

                        // IDは空欄が正しいが、int型なので空欄にできないので 0 を入れる。
                        if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_ID))
                        {
                            int nValue;
                            XenonValue_IntImpl.TryParse(row[NamesFld.S_ID], out nValue, EnumOperationIfErrorvalue.Spaces_To_Alt_Value, 0, log_Reports);
                            sb.Append(nValue);
                            sb.Append(",");
                        }

                        if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_EXPL))
                        {
                            string sValue;
                            XenonValue_StringImpl.TryParse(row[NamesFld.S_EXPL], out sValue, "", "", log_Method, log_Reports);
                            sb.Append(sValue);
                            sb.Append(",");
                        }

                        string sName_Var = "";
                        if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_NAME))
                        {
                            string sValue;
                            XenonValue_StringImpl.TryParse(row[NamesFld.S_NAME], out sValue, "", "", log_Method, log_Reports);
                            sb.Append(sValue);
                            sb.Append(",");

                            sName_Var = sValue;
                        }

                        // 現在の変数の内容
                        string sValue_Var = this.Owner_MemoryApplication.MemoryVariables.GetStringByVariablename(new Expression_Leaf_StringImpl(sName_Var, null, cur_Cf), true, log_Reports);

                        //現在の変数の内容を検索
                        if (NamesVar.Test_Filepath(sName_Var))
                        {
                            Expression_Node_Filepath ec_Fpath = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(sName_Var, null, cur_Cf), true, log_Reports);
                            // 絶対パスとは限らない。フォルダーを指していることもある。
                            string sFpath = ec_Fpath.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                            //フォルダー列値を取得。
                            string sNamevar_Folder_Src;
                            if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_FOLDER))
                            {
                                XenonValue_StringImpl.TryParse(row[NamesFld.S_FOLDER], out sNamevar_Folder_Src, "", "", log_Method, log_Reports);

                                //フォルダーパス
                                Expression_Node_Filepath ec_Folder = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(sNamevar_Folder_Src,null,cur_Cf), false, log_Reports);
                                if (null != ec_Folder)
                                {
                                    // FOLDER列に入力があれば。

                                    string sFpath_Folder = ec_Folder.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                                    if (sValue_Var.StartsWith(sFpath_Folder))
                                    {
                                        // FOLDER列値をそのままキープ。
                                        sb.Append(sNamevar_Folder_Src);

                                        // 値のフォルダー部分を削る。
                                        sValue_Var = sValue_Var.Substring(sFpath_Folder.Length);

                                        // 先頭が　ディレクトリー区切り文字なら削る。
                                        if (sValue_Var.StartsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
                                        {
                                            sValue_Var = sValue_Var.Substring(System.IO.Path.DirectorySeparatorChar.ToString().Length);
                                        }
                                    }
                                    else
                                    {
                                        // FOLDER列値はそのまま使えない。
                                    }
                                }

                                sb.Append(",");
                            }

                            if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_VALUE))
                            {
                                //string sValue;
                                //XenonValue_StringImpl.TryParse(row[NamesFld.S_VALUE], out sValue, "", "", log_Method, log_Reports);
                                //sb.Append(sValue);
                                //sb.Append(",");

                                // 現在の変数の値（の削った残り）を入れる。
                                sb.Append(sValue_Var);
                                sb.Append(",");
                            }
                        }
                        else// if (NamesVar.Test_String(sName_Var))
                        {

                            // FOLDER列値は無し。
                            sb.Append(",");

                            if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_VALUE))
                            {
                                // 現在の変数の値を入れる。
                                sb.Append(sValue_Var);
                                sb.Append(",");
                            }
                        }

                        sb.Append(NamesFld.S_END);
                        sb.Append(Environment.NewLine);

                        nAuto++;
                    }

                    //ファイル書出し
                    {
                        Expression_Node_Filepath ec_Fpath_Logs = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(NamesVar.S_SP_LOGS, null, cur_Cf), true, log_Reports);

                        string sFpatha_LogVariables = ec_Fpath_Logs.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + System.IO.Path.DirectorySeparatorChar + NamesFile.S_SAVE_FORM;

                        if (log_Reports.Successful)
                        {
                            CsvWriterImpl writer = new CsvWriterImpl();
                            writer.Write(
                                sb.ToString(),
                                sFpatha_LogVariables,
                                true
                                );
                        }
                    }
                }
            }



            //
            // メッセージボックスの表示。
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(this.GetType().Name);
                sb.Append("#Perform:");
                sb.Append(Environment.NewLine);
                string sArgMessage;
                this.TrySelectAttribute(out sArgMessage, Expression_Node_Function46Impl.PM_MESSAGE, EnumHitcount.One_Or_Zero, log_Reports);

                sb.Append(sArgMessage);

                MessageBox.Show(sb.ToString(), "変数をCSVファイルに書き出したい。");
            }

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
