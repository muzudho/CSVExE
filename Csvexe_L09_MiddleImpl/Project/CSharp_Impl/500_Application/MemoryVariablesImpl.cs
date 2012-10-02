using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;
using System.Windows.Forms;//Application

using Xenon.Syntax;//N_FilePath
using Xenon.Table;//DefaultTable
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.MiddleImpl
{
    /// <summary>
    /// 変数モデル。
    /// </summary>
    public class MemoryVariablesImpl : MemoryVariables
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public MemoryVariablesImpl(MemoryApplication owner_MemoryApplication)
        {
            this.Clear(owner_MemoryApplication);
        }

        /// <summary>
        /// クリアーします。
        /// </summary>
        public void Clear(object/*MemoryApplication*/ owner_MemoryApplication)
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "Clear",log_Reports_ThisMethod);
            //

            this.owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;

            if (null == this.DictionaryExpression_Item)
            {
                this.dictionaryExpression_Item = new Dictionary<string, Expression_Node_String>();
            }
            else
            {
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("次の変数を消します。");
                    log_Method.WriteDebug_ToConsole("────────────────────");
                    foreach (KeyValuePair<string, Expression_Node_String> kvp in this.DictionaryExpression_Item)
                    {
                        log_Method.WriteDebug_ToConsole("　　" + kvp.Key + "=" + kvp.Value.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports_ThisMethod));
                    }
                    log_Method.WriteDebug_ToConsole("────────────────────");
                }

                this.DictionaryExpression_Item.Clear();
            }

            this.parent_Variablesconfig_Configurationtree = null;


            goto gt_EndMethod;
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports_ThisMethod);
            log_Reports_ThisMethod.EndLogging(log_Method);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void TryGetTable_Variables(
            out XenonTable out_O_Table_Variables,
            String sFpath_Startup,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "TryGetTable_Variables",log_Reports);

            out_O_Table_Variables = null;

            //『Sp:Variables;』で指定されているテーブル
            XenonName o_Name_Variable = new XenonNameImpl(NamesVar.S_SP_VARIABLES, new Configurationtree_NodeImpl("!ハードコーディング_MoNorenImpl#LoadVariables", null));

            //
            // 「変数設定ファイル」のファイルパス。
            //
            log_Reports.Log_Callstack.Push(log_Method, "①");
            Expression_Node_Filepath ec_Fpath_Variables = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(
                new Expression_Leaf_StringImpl(o_Name_Variable.SValue, null, o_Name_Variable.Cur_Configurationtree),
                false,//必須ではありません。未該当であればヌルを返します。
                log_Reports
                );
            log_Reports.Log_Callstack.Pop(log_Method, "①");

            if (log_Reports.Successful)
            {
                if (null == ec_Fpath_Variables)
                {
                    //
                    // "Ｓｐ：Ｖａｒｉａｂｌｅｓ；" が未指定の場合、何もしません。
                    //
                    goto gt_EndMethod;
                }
            }

            //指定されていた場合。
            if (log_Reports.Successful)
            {
                //
                // CSVソースファイル読取
                //
                CsvTo_XenonTableImpl reader = new CsvTo_XenonTableImpl();

                Request_ReadsTable request_tblReads = new Request_ReadsTableImpl();
                XenonTableformat tblFormat_puts = new XenonTableformatImpl();
                request_tblReads.Name_PutToTable = NamesVar.S_ST_VARIABLES2;
                request_tblReads.Expression_Filepath = ec_Fpath_Variables;

                out_O_Table_Variables = reader.Read(
                    request_tblReads,
                    tblFormat_puts,
                    true,
                    log_Reports
                    );
            }

            goto gt_EndMethod;
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        /// <summary>
        /// 変数設定ファイルを読込みます。
        /// </summary>
        public void LoadVariables(
            String sFpath_Startup,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "LoadVariables",log_Reports);
            //

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole("「変数登録ファイル」を読込みます。");
            }

            XenonTable o_Table_Variables;
            this.TryGetTable_Variables(
                out o_Table_Variables,
                sFpath_Startup,
                log_Reports
                );

            if (null==o_Table_Variables)
            {
                //変数登録ファイルが無ければ無視。
                goto gt_EndMethod;
            }

            if (log_Reports.Successful)
            {

                this.Owner_MemoryApplication.MemoryVariables.Load(
                    o_Table_Variables,
                    log_Reports
                    );
            }

            goto gt_EndMethod;
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 変数を登録します。
        /// 
        /// 既に使われている変数の名前で登録しようとした場合、エラーです。
        /// 
        /// 文字列、ファイルパスの区別はありません。
        /// </summary>
        /// <param select="oVariableName"></param>
        /// <param select="initialString"></param>
        /// <param select="log_Reports"></param>
        public void PutString(string sName_Variable, string sInitial, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "PutString",log_Reports);

            if (NamesVar.Test_Filepath(sName_Variable))
            {
                //エラー。この関数で、ファイルパスを登録してはいけません。
                goto gt_Error_Filepath;
            }

            if (this.dictionaryExpression_Item.ContainsKey(sName_Variable))
            {
                goto gt_Error_ContainsKey;
            }

            Expression_Leaf_StringImpl ec_Str = new Expression_Leaf_StringImpl(null, new Configurationtree_NodeImpl("＜変数PutStringから＞", null));
            ec_Str.SetString(sInitial, log_Reports);

            try
            {
                this.dictionaryExpression_Item.Add(sName_Variable, ec_Str);
            }
            catch (ArgumentException e)
            {
                // キーの重複。
                throw e;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Filepath:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー35！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("プログラムエラー！　文字列変数登録関数を使って、ファイルパス変数を追加しようとしました。");
                s.Newline();
                s.Append("変数[" + sName_Variable + "]。");
                s.Newline();

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_ContainsKey:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("Er:401;", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("同じ名前の変数を２度登録しないでください。");
                s.Newline();
                s.Append("変数[" + sName_Variable + "]は既に登録されていますが、さらに登録されました。");
                s.Newline();

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
        /// 「変数設定ファイル」のテーブルを読み取り、変数を登録します。
        /// </summary>
        /// <param oVariableName="varOTable"></param>
        /// <param oVariableName="log_Reports"></param>
        public void Load(
            XenonTable o_Table_Var,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "Load",log_Reports);
            //

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole("「変数登録ファイル」を Load します。");
            }

            //
            //
            //
            //

            if (null == o_Table_Var)
            {
                goto gt_Error_NullTable;
            }



            if (null != this.parent_Variablesconfig_Configurationtree)
            {
                goto gt_Error_DoubleLoad;
            }


            string err_SFolder;
            string err_SName;
            if (log_Reports.Successful)
            {
                this.parent_Variablesconfig_Configurationtree = new Configurationtree_NodeImpl(NamesNode.S_VARIABLE_CONFIG, o_Table_Var.Expression_Filepath_ConfigStack.Cur_Configurationtree);
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }

                foreach (DataRow dataRow in o_Table_Var.DataTable.Rows)
                {
                    string sStringValue;// = "";

                    // ソース情報として使うだけ。
                    Configurationtree_Node cf_VarRecord1 = new Configurationtree_NodeImpl(NamesNode.S_VARIABLE_RECORD, parent_Variablesconfig_Configurationtree);

                    // 注意: dataRow[]の連想配列は大文字・小文字を区別しないのが欠点。

                    //ＮＡＭＥ列
                    {
                        string sFldName = NamesFld.S_NAME;//フィールド名。
                        if (o_Table_Var.ContainsField(sFldName,true,log_Reports))
                        {
                            if (XenonValue_StringImpl.TryParse(
                                dataRow[sFldName],
                                out sStringValue,
                                o_Table_Var.Name,
                                sFldName,
                                log_Method,
                                log_Reports))
                            {
                            }
                            else
                            {
                                sStringValue = "";
                            }

                            if (!log_Reports.Successful)
                            {
                                // エラー
                                goto gt_EndMethod;
                            }

                            cf_VarRecord1.Dictionary_Attribute.Set(PmNames.S_NAME.Name_Pm, sStringValue, log_Reports);
                        }
                    }

                    // ＦＯＬＤＥＲ列　（オプション）
                    {
                        string sFldName = NamesFld.S_FOLDER;
                        if (o_Table_Var.ContainsField(sFldName, false, log_Reports))
                        {
                            if (XenonValue_StringImpl.TryParse(
                                dataRow[sFldName],
                                out sStringValue,
                                o_Table_Var.Name,
                                sFldName,
                                log_Method,
                                log_Reports))
                            {
                            }
                            else
                            {
                                sStringValue = "";
                            }

                            if (!log_Reports.Successful)
                            {
                                // エラー
                                goto gt_EndMethod;
                            }

                            //if (log_Method.CanDebug(1))
                            //{
                            //    log_Method.WriteDebug_ToConsole("「変数登録ファイル」FOLDER列=[" + sStringValue + "]");
                            //}
                            cf_VarRecord1.Dictionary_Attribute.Set(PmNames.S_FOLDER.Name_Pm, sStringValue, log_Reports);
                        }
                        else
                        {
                            //なければ無視。
                        }
                    }

                    // ＶＡＬＵＥ列
                    {
                        string sFldName = NamesFld.S_VALUE;//フィールド名。
                        if (o_Table_Var.ContainsField(sFldName, true, log_Reports))
                        {
                            if (XenonValue_StringImpl.TryParse(
                                dataRow[sFldName],
                                out sStringValue,
                                o_Table_Var.Name,
                                sFldName,
                                log_Method,
                                log_Reports))
                            {
                            }
                            else
                            {
                                sStringValue = "";
                            }

                            if (!log_Reports.Successful)
                            {
                                // エラー
                                goto gt_EndMethod;
                            }

                            cf_VarRecord1.Dictionary_Attribute.Set(PmNames.S_VALUE.Name_Pm, sStringValue, log_Reports);
                        }
                    }

                    //
                    // 変数を登録。
                    //
                    if (log_Reports.Successful)
                    {
                        //ＮＡＭＥ列
                        string sName;
                        cf_VarRecord1.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName, true, log_Reports);

                        //ＦＯＬＤＥＲ列　（オプション）
                        string sFolder;
                        bool bExistsFolder = cf_VarRecord1.Dictionary_Attribute.TryGetValue(PmNames.S_FOLDER, out sFolder, false, log_Reports);

                        string sValue;
                        cf_VarRecord1.Dictionary_Attribute.TryGetValue(PmNames.S_VALUE, out sValue,
                            false, //空文字列でも可。
                            log_Reports);

                        if (NamesVar.Test_Filepath(sName))
                        {
                            //ファイルパス変数の場合。
                            Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("変数[" + sName + "]", this.parent_Variablesconfig_Configurationtree);
                            cf_Fpath.InitPath(
                                sValue,
                                log_Reports
                                );
                            if ("" != sFolder)
                            {
                                //if (log_Method.CanDebug(1))
                                //{
                                //    log_Method.WriteDebug_ToConsole("「変数登録ファイル」FOLDER列指定あり=[" + sFolder + "]");
                                //}

                                Expression_Node_String ec_Namevar_Folder = new Expression_Leaf_StringImpl(sFolder, null, this.parent_Variablesconfig_Configurationtree);
                                Expression_Node_Filepath ec_Fopath_Folder = this.GetExpressionfilepathByVariablename(
                                    ec_Namevar_Folder,
                                    true,
                                    log_Reports
                                    );
                                cf_Fpath.SetDirectory_Base(ec_Fopath_Folder.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                            }
                            //else
                            //{
                            //    if (log_Method.CanDebug(1))
                            //    {
                            //        log_Method.WriteDebug_ToConsole("「変数登録ファイル」FOLDER列指定なし");
                            //    }
                            //}

                            Expression_Node_Filepath ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath);

                            this.PutFilepath(
                                sName,
                                ec_Fpath,
                                true,
                                log_Reports
                                );

                            //if (log_Method.CanDebug(1))
                            //{
                            //    log_Method.WriteDebug_ToConsole("「変数登録ファイル」ファイルパス変数=[" + sName + "] 値=[" + ec_Fpath.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports) + "]");
                            //}
                        }
                        else
                        {
                            //ファイルパス以外の変数の場合。
                            //if (log_Method.CanDebug(1))
                            //{
                            //    log_Method.WriteDebug_ToConsole("「変数登録ファイル」ファイルパス以外の変数=[" + sName + "]");
                            //}

                            if (bExistsFolder && "" != sFolder)
                            {
                                //ファイルパス変数以外の変数で、FOLDER列値を指定しているのはエラーです。
                                //※FOLDER列が存在する場合だけエラーチェックします。FOLDER列値がない場合は、sFolderには"null"が入っているので無視します。

                                err_SName = sName;
                                err_SFolder = sFolder;
                                goto gt_Error_InputFolder;
                            }

                            this.PutString(
                                sName,
                                sValue,
                                log_Reports
                                );
                        }

                    }

                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_InputFolder:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("Er:402;", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("[");
                s.Append(err_SName);
                s.Append("]変数に、");
                s.Append(PmNames.S_FOLDER.Name_Attribute);
                s.Append( "列値を指定しているのはエラーです。");
                s.Newline();
                s.Append( PmNames.S_FOLDER.Name_Attribute );
                s.Append("列値は、ファイルパス変数にしか書いてはいけません。");
                s.Newline();
                s.Append("ファイルパス変数は、「");
                s.Append(NamesVar.S_SP_);
                s.Append("」、「");
                s.Append(NamesVar.S_UP_);
                s.Append("」で始まる名前の変数です。");
                s.Newline();
                s.Newline();

                s.AppendI(1, PmNames.S_FOLDER.Name_Attribute);
                if (null == err_SFolder)
                {
                    s.Append("=ヌル。");
                }
                else
                {
                    s.Append("=[");
                    s.Append(err_SFolder);
                    s.Append("]");
                }
                s.Newline();
                s.Newline();

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullTable:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー918！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("指定されたテーブルは、ヌルでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_DoubleLoad:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー919！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("既に「変数設定ファイル」はロードされているのに、");
                t.Append(Environment.NewLine);
                t.Append("また　「変数設定ファイル」をロードしようとしました。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                r.Message = t.ToString();
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
        /// ファイルパス型変数を登録します。
        /// 
        /// todo:文字列、ファイルパスの区別なく登録したい。
        /// </summary>
        /// <param name="sVariableName"></param>
        /// <param name="e_InitialValue"></param>
        /// <param name="bDuplicatedIsError">既に追加されているものを、更に追加しようとしたときにエラーにするなら真。</param>
        /// <param name="log_Reports"></param>
        public void PutFilepath(
            string sName_Variable,
            Expression_Node_Filepath ec_InitialValue,
            bool bDuplicatedIsError,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "PutFilepath",log_Reports);
            //
            //

            if (this.dictionaryExpression_Item.ContainsKey(sName_Variable))
            {
                if (bDuplicatedIsError)
                {
                    goto gt_Error_Duplicated;
                }
                else
                {
                    // 上書き
                    string sOldValue = "";
                    if (log_Method.CanInfo())
                    {
                        sOldValue = this.dictionaryExpression_Item[sName_Variable].Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                    }

                    this.dictionaryExpression_Item[sName_Variable] = ec_InitialValue;

                    if (log_Method.CanInfo())
                    {
                        log_Method.WriteInfo_ToConsole("変数[" + sName_Variable + "]は既に[" + sOldValue + "]と定義されていましたが、[" + ec_InitialValue.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports) + "]で上書きしました。");
                    }
                }
            }
            else
            {
                this.dictionaryExpression_Item.Add(sName_Variable, ec_InitialValue);
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Duplicated:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー922！", log_Method);
                r.Message = "変数[" + sName_Variable + "]は既に定義されていますが、さらに定義されました。";
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
        /// 変数を設定します。
        /// </summary>
        public void SetVariable(
            XenonName o_Name_Variable,
            Expression_Node_String ec_Value,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "SetVariable",log_Reports);
            //
            //

            if (
                o_Name_Variable.SValue.StartsWith(NamesVar.S_SP_) ||
                o_Name_Variable.SValue.StartsWith(NamesVar.S_UP_)
                )
            {
                string sFilePath = ec_Value.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

                Configurationtree_Node parent_Configurationtree_Node = new Configurationtree_NodeImpl("!ハードコーディング_" + this.GetType().Name + "#SetVariable", null);

                Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L09Mid_4", parent_Configurationtree_Node);
                cf_Fpath.InitPath(
                    sFilePath,
                    log_Reports
                    );
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }

                Expression_Node_Filepath ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath);

                this.SetFilepathValue(
                    o_Name_Variable.SValue,
                    ec_Fpath,
                    bRequired,
                    log_Reports
                    );
            }
            else if (
                // 新仕様
                o_Name_Variable.SValue.StartsWith(NamesVar.S_SS_) ||
                o_Name_Variable.SValue.StartsWith(NamesVar.S_US_)
                )
            {
                string str1 = ec_Value.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

                this.SetStringValue(
                    o_Name_Variable,
                    str1,
                    bRequired,
                    log_Reports
                    );
            }
            else
            {
            }

            //
        //
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 文字列型変数の値をセットします。
        /// </summary>
        /// <param select="oVariableName"></param>
        /// <param select="nValue"></param>
        /// <param select="bRequired"></param>
        public void SetStringValue(
            XenonName o_Name_Variable,
            string sValue,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "SetStringValue",log_Reports);
            //
            //

            if (bRequired && !this.dictionaryExpression_Item.ContainsKey(o_Name_Variable.SValue))
            {
                goto gt_Error_NotFoundVariable;
            }
            else
            {
                Expression_Leaf_StringImpl ec_Str = new Expression_Leaf_StringImpl(null, new Configurationtree_NodeImpl("＜SetStringValueから＞", null));
                ec_Str.SetString(sValue, log_Reports);
                this.dictionaryExpression_Item[o_Name_Variable.SValue] = ec_Str;

                //.WriteLine(this.GetType().Name + "#SetStringValue: ◆　文字列型変数[" + oVariableName.OValue + "]に、値["+value+"]をセットしました。");

            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundVariable:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー923！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("[");
                t.Append(o_Name_Variable.SValue);
                t.Append("]という名前の　文字列型の変数は、存在しませんでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("　ヒント：　「変数設定ファイル」に登録されている変数だけ使えます。");
                t.Append(Environment.NewLine);
                t.Append("　ヒント：　変数名の英字の大文字・小文字は完全に一致していますか？");
                t.Append(Environment.NewLine);
                t.Append("　ヒント：　「ファイルパス型」と「文字列型」の２つがあります。");
                t.Append("　　　　　　文字列型として利用されようとしました。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("　「変数設定ファイル」のファイルパス：");
                t.Append(Environment.NewLine);
                t.Append("　　");
                if (null != this.parent_Variablesconfig_Configurationtree)
                {
                    this.parent_Variablesconfig_Configurationtree.ToText_Locationbreadcrumbs(t);
                }
                else
                {
                    t.Append("ヌル");
                }
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);


                t.Append("　問題箇所ヒント：");
                t.Append(Environment.NewLine);
                t.Append("　　");
                o_Name_Variable.Cur_Configurationtree.ToText_Locationbreadcrumbs(t);
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                t.Append(r.Message_SSeparator());
                t.Append("　変数一覧：");
                t.Append(Environment.NewLine);
                foreach (string sVarName in this.DictionaryExpression_Item.Keys)
                {
                    t.Append("　　");
                    t.Append(sVarName);
                    t.Append(Environment.NewLine);
                }
                t.Append(Environment.NewLine);

                r.Message = t.ToString();
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
        /// ファイル・パス型変数の値をセットします。
        /// </summary>
        /// <param select="oVariableName"></param>
        /// <param select="nValue"></param>
        /// <param select="bRequired"></param>
        public void SetFilepathValue(string sVariableName, Expression_Node_Filepath ec_Fpath, bool bRequired, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "SetFilepathValue",log_Reports);

            if (bRequired && !this.dictionaryExpression_Item.ContainsKey(sVariableName))
            {
                goto gt_Error_NotFoundVariable;
            }
            else
            {
                this.dictionaryExpression_Item[sVariableName] = ec_Fpath;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundVariable:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー924！", log_Method);
                r.Message = "変数[" + sVariableName + "]は存在しませんでした。";
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
        /// 変数名を指定することで、文字列を返します。
        /// 
        /// </summary>
        /// <param select="oVariableName"></param>
        /// <param select="bRequired"></param>
        /// <param select="log_Reports"></param>
        /// <returns></returns>
        public string GetStringByVariablename(
            Expression_Node_String ec_VariableName,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "GetStringByVariablename",log_Reports);

            //
            //
            //
            //

            string sResult;
            string sVarName = ec_VariableName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

            // 【仕様変更 2011-03-03】「変数名無し」（つまり「$」だけ）は、文字「$」を返します。
            //if ("" == sVarName)
            //{
            //    return "$";
            //}
            //else

            if (!this.dictionaryExpression_Item.ContainsKey(sVarName))
            {
                sResult = null;

                if (bRequired)
                {
                    goto gt_Error_NotFoundVariable;
                }
            }
            else
            {
                sResult = this.dictionaryExpression_Item[sVarName].Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundVariable:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー925！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("変数[");
                t.Append(sVarName);
                t.Append("]は存在しませんでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("　問題箇所ヒント：");
                ec_VariableName.Cur_Configurationtree.Parent.ToText_Locationbreadcrumbs(t);
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("　実行経路ヒント：");
                ec_VariableName.Cur_Configurationtree.Parent.ToText_Locationbreadcrumbs(t);
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("ヒント：登録されている変数の個数=[");
                t.Append(this.dictionaryExpression_Item.Count);
                t.Append("]");
                t.Append(Environment.NewLine);

                foreach (KeyValuePair<string, Expression_Node_String> pair in this.dictionaryExpression_Item)
                {
                    t.Append(pair.Key);
                    t.Append("＝");
                    t.Append(pair.Value);
                    t.Append(Environment.NewLine);
                }

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return sResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 変数名を指定することで、ファイルパスを返します。
        /// </summary>
        /// <param select="oVariableName"></param>
        /// <param select="bRequired"></param>
        /// <param select="log_Reports"></param>
        /// <returns></returns>
        public Expression_Node_Filepath GetExpressionfilepathByVariablename(
            Expression_Node_String ec_Name_Variable,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "GetExpressionfilepathByVariablename",log_Reports);

            //
            //
            //
            //

            Expression_Node_Filepath ec_Fpath_Result;

            string sName_Var = ec_Name_Variable.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

            if (!this.dictionaryExpression_Item.ContainsKey(sName_Var))
            {
                ec_Fpath_Result = null;

                if (bRequired)
                {
                    // 未該当の場合、エラーにします。
                    goto gt_Error_NotFoundVariable;
                }
            }
            else
            {
                Expression_Node_String ec_Str = this.dictionaryExpression_Item[sName_Var];
                if (ec_Str is Expression_Node_Filepath)
                {
                    ec_Fpath_Result = (Expression_Node_Filepath)ec_Str;

                    //if (ec_Fpath_Result.SDirectory_Base == "" && null != this.ec_FpathBaseOrNull)
                    //{
                    //    string sFopath = this.ec_FpathBaseOrNull.Execute_OnExpressionString(
                    //        Request_SelectingImpl.Unconstraint, log_Reports);
                    //    if (log_Reports.Successful)
                    //    {
                    //        ec_Fpath_Result.SetDirectory_Base(sFopath, log_Reports);
                    //    }
                    //}
                }
                else
                {
                    ec_Fpath_Result = null;
                    goto gt_Error_AnotherClass;
                }

            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundVariable:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー376！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("変数[");
                s.Append(sName_Var);
                s.Append("]は存在しませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("ヒント：登録されている変数の個数=[");
                s.Append(this.dictionaryExpression_Item.Count);
                s.Append("]");
                s.Append(Environment.NewLine);

                s.Append("──────────ここから");
                s.Append(Environment.NewLine);
                foreach (KeyValuePair<string, Expression_Node_String> kvp in this.dictionaryExpression_Item)
                {
                    s.Append("key=[" + kvp.Key + "]　value=[" + kvp.Value.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint,log_Reports) + "]");
                    s.Append(Environment.NewLine);
                }
                s.Append("──────────ここまで");
                s.Append(Environment.NewLine);


                // ヒント
                s.Append(r.Message_Configurationtree(ec_Name_Variable.Cur_Configurationtree));
                //s.Append(r.Message_Configurationtree(ec_Name_Variable.Cur_Configurationtree.Parent));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_AnotherClass:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー909", log_Method);
                r.Message = "変数[" + sName_Var + "]はファイルパス型を期待しましたが、ファイルパス型ではありませんでした。";
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return ec_Fpath_Result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// デバッグ出力。
        /// </summary>
        public void WriteDebug_ToConsole()
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            Log_Reports d_Logging_Dammy = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "WriteDebug_ToConsole",d_Logging_Dammy);
            //
            //

            if (log_Method.CanInfo())
            {
                log_Method.WriteInfo_ToConsole("要素数=[" + this.dictionaryExpression_Item.Count + "]");

                // 項目（キーと値）の列挙
                foreach (KeyValuePair<string, Expression_Node_String> kvp in this.dictionaryExpression_Item)
                {
                    if (null == kvp.Value)
                    {
                        log_Method.WriteInfo_ToConsole(" [" + kvp.Key + "]=空っぽ");
                    }
                    else
                    {
                        if (kvp.Value is Expression_Node_Filepath)
                        {
                            // ファイルパス型。
                            // bug: 絶対パスでない場合、空白になるので、SHumanInput で取得することになるはず。
                            log_Method.WriteInfo_ToConsole(" [" + kvp.Key + "]=P型[" + kvp.Value.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, d_Logging_Dammy) + "]　／　SHumanInput=[" + ((Expression_Node_Filepath)kvp.Value).Humaninput + "]");
                        }
                        else
                        {
                            log_Method.WriteInfo_ToConsole(" [" + kvp.Key + "]=[" + kvp.Value.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, d_Logging_Dammy) + "]");
                        }
                    }

                }
            }

            //
            //
            log_Method.EndMethod(d_Logging_Dammy);
            d_Logging_Dammy.EndLogging(log_Method);
            if (!d_Logging_Dammy.Successful)
            {
                log_Method.WriteDebug_ToConsole(d_Logging_Dammy.ToMessage());
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ファイルパス一覧。
        /// </summary>
        /// <param name="dlgt_EachEFilePath"></param>
        public void EachVariable(DELEGATE_EachVariable dlgt_EachVariable)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            Log_Reports d_Logging_Dammy = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "EachVariable",d_Logging_Dammy);

            //
            //

            bool bBreak = false;
            foreach (KeyValuePair<string, Expression_Node_String> kvp in this.dictionaryExpression_Item)
            {
                dlgt_EachVariable(kvp.Key, kvp.Value, ref bBreak);

                if (bBreak)
                {
                    break;
                }
            }

            //
            //
            log_Method.EndMethod(d_Logging_Dammy);
            d_Logging_Dammy.EndLogging(log_Method);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryApplication owner_MemoryApplication;

        /// <summary>
        /// このオブジェクトを所有するオブジェクト。
        /// </summary>
        public MemoryApplication Owner_MemoryApplication
        {
            get
            {
                return owner_MemoryApplication;
            }
            set
            {
                owner_MemoryApplication = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 変数のマップ。
        /// </summary>
        private Dictionary<string, Expression_Node_String> dictionaryExpression_Item;

        public Dictionary<string, Expression_Node_String> DictionaryExpression_Item
        {
            get
            {
                return this.dictionaryExpression_Item;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// まだ読み込んでいないときは、ヌル。
        /// </summary>
        private Configurationtree_Node parent_Variablesconfig_Configurationtree;

        //────────────────────────────────────────
        #endregion




    }

}
