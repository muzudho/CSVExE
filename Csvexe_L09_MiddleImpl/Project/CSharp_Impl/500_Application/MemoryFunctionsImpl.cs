using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using Xenon.Syntax;
using Xenon.Middle;
using Xenon.XToGcav;
using Xenon.Expr;
using Xenon.GcavToExpr;

namespace Xenon.MiddleImpl
{
    /// <summary>
    /// ユーザー定義関数。
    /// </summary>
    public class MemoryFunctionsImpl : MemoryFunctions
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public MemoryFunctionsImpl(MemoryApplication owner_MemoryApplication)
        {
            this.Clear(owner_MemoryApplication);
        }

        /// <summary>
        /// クリアーします。
        /// </summary>
        public void Clear(object/*MemoryApplication*/ owner_MemoryApplication)
        {
            this.owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            if (null == this.dictionary_Item)
            {
                this.dictionary_Item = new Dictionary<string, Expression_Node_Function>();
            }
            else
            {
                this.dictionary_Item.Clear();
            }
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        public void ForEach_Children(DELEGATE_E_DefFnc_Children dlgt1)
        {
            bool bBreak = false;
            bool bRemove = false;

            // 読取り順は予想できない。
            foreach (KeyValuePair<string, Expression_Node_Function> kvP in this.dictionary_Item)
            {
                dlgt1(kvP.Key, kvP.Value, ref bRemove, ref bBreak);

                if (bRemove)
                {
                    this.dictionary_Item.Remove(kvP.Key);
                    bRemove = false;
                }

                if (bBreak)
                {
                    break;
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ユーザー定義関数を登録します。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="e_Func"></param>
        /// <param name="log_Reports"></param>
        public void AddFunction(string sName, Expression_Node_Function ec_CommonFunction, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "AddFunc", log_Reports);

            if (log_Method.CanDebug(1))
            {
            }

            //
            //

            if (this.dictionary_Item.ContainsKey(sName))
            {
                goto gt_Error_Exists;
            }

            this.dictionary_Item.Add(sName, ec_CommonFunction);

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole(" ユーザー定義関数の追加登録 [" + sName + "]");
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Exists:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲設定エラー101！", log_Method);
                r.Message = "ユーザー定義関数[" + sName + "]は既に定義されていますが、さらに定義されました。同じ名前のユーザー定義関数は１つしか定義してはいけません。";
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
        /// ユーザー定義関数を取得。
        /// </summary>
        /// <param name="e_Func"></param>
        /// <param name="sCall"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public bool TryGetFunction(out Expression_Node_Function ec_CommonFunction, string sCall, Log_Reports log_Reports)
        {
            bool bResult;

            if (!this.dictionary_Item.ContainsKey(sCall))
            {
                bResult = false;
                ec_CommonFunction = null;
            }
            else
            {
                bResult = true;
                ec_CommonFunction = this.dictionary_Item[sCall];
            }

            return bResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// デバッグ出力。
        /// </summary>
        public void WriteDebug_ToConsole()
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "DebugWrite", log_Reports_ThisMethod);

            //
            //

            if (log_Method.CanInfo())
            {
                log_Method.WriteInfo_ToConsole(" ──────────登録関数名一覧");
                foreach (string sKey in this.dictionary_Item.Keys)
                {
                    log_Method.WriteInfo_ToConsole(" key=[" + sKey + "]");
                }
                log_Method.WriteInfo_ToConsole(" ──────────");
            }

            log_Method.EndMethod(log_Reports_ThisMethod);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 『ユーザー定義関数設定ファイル(Fnc)』を読み取ります。
        /// </summary>
        public void LoadFile(
            Expression_Node_Filepath expr_Fpath_Fnc,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "LoadFile_Fnc", log_Reports);

            //
            //

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole(" ユーザー定義関数設定ファイルの読み取り。");
            }

            Configurationtree_Node parent_Cf = new Configurationtree_NodeImpl(NamesNode.S_CODEFILE_FUNCTIONS, expr_Fpath_Fnc.Cur_Configurationtree);//Info_OpyopyoImpl.LibraryName + ":" + this.GetType().Name + ".LoadFile_Fnc"
            Expression_Node_String expr_FuncConfig = new Expression_Node_StringImpl(null, parent_Cf);

            string sFpatha = expr_Fpath_Fnc.Execute_OnExpressionString(
                Request_SelectingImpl.Unconstraint, log_Reports);

            if (!log_Reports.Successful)
            {
                goto gt_Error_Fpath;
            }

            if (!System.IO.File.Exists(sFpatha))
            {
                goto gt_Error_File;
            }


            XmlDocument xDoc = new XmlDocument();
            Exception err_Excp = null;
            try
            {
                xDoc.Load(sFpatha);
            }
            catch (System.IO.IOException ex)
            {
                //
                // エラー。
                err_Excp = ex;
                goto gt_Error_Doc;
            }
            catch (ArgumentException ex)
            {
                //
                // エラー。
                err_Excp = ex;
                goto gt_Error_Doc;
            }
            catch (Exception ex)
            {
                //
                // エラー。
                err_Excp = ex;
                goto gt_Error_Doc;
            }

            XmlElement xRoot = null;
            if (log_Reports.Successful)
            {
                // ルート要素を取得
                xRoot = xDoc.DocumentElement;

                // スクリプトファイルのバージョンチェック。（関数登録ファイル）
                ValuesAttr.Test_Codefileversion(
                    xRoot.GetAttribute(PmNames.S_CODEFILE_VERSION.Name_Attribute),
                    log_Reports,
                    new Configurationtree_NodeImpl(sFpatha, null),
                    NamesNode.S_CODEFILE_FUNCTIONS
                    );
            }

            string sErrorElementName = "";
            if (log_Reports.Successful)
            {
                XmlNodeList xTopNL = xRoot.ChildNodes;
                foreach (XmlNode xTopNode in xTopNL)
                {
                    if (XmlNodeType.Element == xTopNode.NodeType)
                    {
                        if (NamesNode.S_COMMON_FUNCTION == xTopNode.Name)
                        {
                            XmlElement x_Cur = (XmlElement)xTopNode;

                            string sNameValue = x_Cur.GetAttribute(PmNames.S_NAME.Name_Attribute);
                            if (log_Method.CanDebug(1))
                            {
                                log_Method.WriteDebug_ToConsole(" ユーザー定義関数の追加を開始：" + sNameValue);
                            }

                            // XToCf
                            XToConfigurationtree_C15_Elm xToCf = XToConfigurationtree_Collection.GetTranslatorByNodeName(NamesNode.S_COMMON_FUNCTION, log_Reports);
                            xToCf.XToConfigurationtree(
                                x_Cur,
                                parent_Cf,
                                this.Owner_MemoryApplication,
                                log_Reports
                                );

                            Configurationtree_Node s_Cur = null;
                            parent_Cf.List_Child.ForEach(delegate(Configurationtree_Node s_Child, ref bool bBreak)
                            {
                                s_Cur = s_Child;
                                bBreak = true;
                            });

                            // SToE
                            Expression_Node_FunctionImpl ec_CommonFunction = new Expression_Node_FunctionImpl(expr_FuncConfig, s_Cur, new List<string>());

                            Log_TextIndented_ConfigurationtreeToExpressionImpl pg_ParsingLog = new Log_TextIndented_ConfigurationtreeToExpressionImpl();
                            pg_ParsingLog.BEnabled = false;
                            ConfigurationtreeToExpression_AbstractImpl.ParseChild_InAnotherLibrary(
                                s_Cur,
                                ec_CommonFunction,
                                this.Owner_MemoryApplication,
                                pg_ParsingLog,
                                log_Reports
                                );
                            if (log_Method.CanInfo() && pg_ParsingLog.BEnabled)
                            {
                                log_Method.WriteInfo_ToConsole(" d_ParsingLog=" + Environment.NewLine + pg_ParsingLog.ToString());
                            }

                            this.Owner_MemoryApplication.MemoryFunctions.AddFunction(sNameValue, ec_CommonFunction, log_Reports);
                        }
                        else
                        {
                            //
                            // エラー。
                            sErrorElementName = xTopNode.Name;
                            goto gt_Error_UndefinedChild;
                        }
                    }
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Fpath:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー101！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("ユーザー定義関数設定ファイルへのパスにエラーがありました。");
                s.Newline();
                s.Newline();

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_File:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー102！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("ユーザー定義関数設定ファイルがありません。");
                s.Newline();
                s.Append("file=[");
                s.Append(sFpatha);
                s.Append("]");
                s.Newline();
                s.Newline();

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Doc:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー103！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("エラー：" + err_Excp.Message);
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedChild:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー104！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("未定義の要素：" + sErrorElementName);
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント

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

        private Dictionary<string, Expression_Node_Function> dictionary_Item;

        //────────────────────────────────────────
        #endregion



    }
}
