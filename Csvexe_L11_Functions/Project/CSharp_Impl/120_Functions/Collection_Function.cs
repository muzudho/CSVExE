using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.Functions
{
    public class Collection_Function
    {



        #region 用意
        //────────────────────────────────────────

        static Collection_Function()
        {
            Log_Method log_Method = new Log_MethodImpl(1);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Functions.Name_Library, "Collection_Function", "static Collection_Function",log_Reports_ThisMethod);
            //

            dictionary_Interlibrary = new Dictionary<string, Expression_Node_Function>();


            ConfigurationtreeToFunction_Item transUnknown = new ConfigurationtreeToFunction00_ItemImpl();//暫定
            ConfigurationtreeToFunction_Item trans00 = new ConfigurationtreeToFunction00_ItemImpl();
            ConfigurationtreeToFunction_Item trans20 = new ConfigurationtreeToFunction20_ItemImpl();

            //関数名未設定のインスタンスを、ディクショナリーに追加します。#NewInstance 実行時に関数名を付けます。
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function04Impl.S_PM_NAME_TABLE);
                sList.Add(Expression_Node_Function04Impl.S_PM2_POPUP);
                sList.Add(Expression_Node_Function04Impl.S_PM2_FLOW_SKIP);
                Collection_Function.SetFunction(Expression_Node_Function04Impl.S_ACTION_NAME, new Expression_Node_Function04Impl(EnumEventhandler.O_Ea, sList,trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function05Impl.S_PM_NAME_TABLE_SRC);
                sList.Add(Expression_Node_Function05Impl.S_PM_NAME_TABLE_DST);
                Collection_Function.SetFunction(Expression_Node_Function05Impl.S_ACTION_NAME, new Expression_Node_Function05Impl(EnumEventhandler.O_Ea, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function06Impl.S_PM_NAME_TABLE_SRC);
                sList.Add(Expression_Node_Function06Impl.S_PM_FILEPATH_EXTERNALAPPLICATION);
                Collection_Function.SetFunction(Expression_Node_Function06Impl.S_ACTION_NAME, new Expression_Node_Function06Impl(EnumEventhandler.O_Ea, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function11Impl.S_ACTION_NAME, new Expression_Node_Function11Impl(EnumEventhandler.Wr_Rhn, sList, transUnknown), log_Reports_ThisMethod);
            }
            {
                //dic_E_Sf.Add(E_Sf17Impl_OLD.S_ACTION_NAME, new E_Sf17Impl_OLD(null, cf_Node));//todo:
            }
            {
                List<string> sList = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function19Impl.S_ACTION_NAME, new Expression_Node_Function19Impl(EnumEventhandler.Wr_Rhn, sList, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function20Impl.S_PM_NAME_TABLE);
                sList.Add(Expression_Node_Function20Impl.S_PM_NAME_FC_LST);
                Collection_Function.SetFunction(Expression_Node_Function20Impl.S_ACTION_NAME, new Expression_Node_Function20Impl(EnumEventhandler.Wr_Rhn, sList, trans20), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function21Impl.S_ACTION_NAME, new Expression_Node_Function21Impl(EnumEventhandler.O_Kea, sList, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function22Impl.S_ACTION_NAME, new Expression_Node_Function22Impl(EnumEventhandler.Wr_Rhn, sList, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function25Impl.S_PM_NAME_FIELD);
                sList.Add(Expression_Node_Function25Impl.S_PM_NAME_VAR_DESTINATION);
                Collection_Function.SetFunction(Expression_Node_Function25Impl.S_ACTION_NAME, new Expression_Node_Function25Impl(EnumEventhandler.O_Ea, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function27Impl.S_PM_NAME_TOGETHER);
                Collection_Function.SetFunction(Expression_Node_Function27Impl.S_ACTION_NAME, new Expression_Node_Function27Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function28Impl.S_PM_MESSAGE);
                Collection_Function.SetFunction(Expression_Node_Function28Impl.S_ACTION_NAME, new Expression_Node_Function28Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function29Impl.S_PM_NAME_CONTROL);
                Collection_Function.SetFunction(Expression_Node_Function29Impl.S_ACTION_NAME, new Expression_Node_Function29Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function30Impl.S_PM_NAME_TOGETHER);
                sList.Add(Expression_Node_Function30Impl.S_PM_NAME_FORM);
                Collection_Function.SetFunction(Expression_Node_Function30Impl.S_ACTION_NAME, new Expression_Node_Function30Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function31Impl.S_PM_NAME_FC);
                Collection_Function.SetFunction(Expression_Node_Function31Impl.S_ACTION_NAME, new Expression_Node_Function31Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function32Impl.S_PM_NAME_TABLE);
                sList.Add(Expression_Node_Function32Impl.S_PM_NAME_FIELD);
                sList.Add(Expression_Node_Function32Impl.S_PM_NAME_FC_DESTINATION);
                Collection_Function.SetFunction(Expression_Node_Function32Impl.S_ACTION_NAME, new Expression_Node_Function32Impl(EnumEventhandler.O_Ea, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function33Impl.S_PM_NAME_FC);
                sList.Add(Expression_Node_Function33Impl.S_PM_NAME_FIELD_KEY);
                sList.Add(Expression_Node_Function33Impl.S_PM_VALUE_EXPECTED);
                sList.Add(Expression_Node_Function33Impl.S_PM_VALUE_EXPECTED2);
                sList.Add(Expression_Node_Function33Impl.S_PM_VALUE_EMPTY);
                Collection_Function.SetFunction(Expression_Node_Function33Impl.S_ACTION_NAME, new Expression_Node_Function33Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function34Impl.S_PM_NAME_VAR);
                sList.Add(Expression_Node_Function34Impl.S_PM_VALUE);
                sList.Add(Expression_Node_Function34Impl.S_PM_FLOWSKIP);
                Collection_Function.SetFunction(Expression_Node_Function34Impl.S_ACTION_NAME, new Expression_Node_Function34Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                // arg 無し
                Collection_Function.SetFunction(Expression_Node_Function35Impl.S_ACTION_NAME, new Expression_Node_Function35Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function36Impl.S_PM_FC_NAME);
                Collection_Function.SetFunction(Expression_Node_Function36Impl.S_ACTION_NAME, new Expression_Node_Function36Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function37Impl.S_PM_FROM);
                sList.Add(Expression_Node_Function37Impl.S_PM_TO);
                Collection_Function.SetFunction(Expression_Node_Function37Impl.S_ACTION_NAME, new Expression_Node_Function37Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function38Impl.S_PM_FROM);
                sList.Add(Expression_Node_Function38Impl.S_PM_TO);
                Collection_Function.SetFunction(Expression_Node_Function38Impl.S_ACTION_NAME, new Expression_Node_Function38Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function39Impl.S_PM_NAME_FC);
                sList.Add(Expression_Node_Function39Impl.S_PM_VALUE_ENABLED);
                Collection_Function.SetFunction(Expression_Node_Function39Impl.S_ACTION_NAME, new Expression_Node_Function39Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function40Impl.S_PM_NAME_FC);
                sList.Add(Expression_Node_Function40Impl.S_PM_VALUE_VISIBLED);
                Collection_Function.SetFunction(Expression_Node_Function40Impl.S_ACTION_NAME, new Expression_Node_Function40Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function42Impl.S_PM_EXECUTE);
                sList.Add(Expression_Node_Function42Impl.S_PM_FLOWSKIP);
                Collection_Function.SetFunction(Expression_Node_Function42Impl.S_ACTION_NAME, new Expression_Node_Function42Impl(EnumEventhandler.O_Ea, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function43Impl.S_PM_NAME_VAR);
                sList.Add(Expression_Node_Function43Impl.S_PM_NAME_FC);
                Collection_Function.SetFunction(Expression_Node_Function43Impl.S_ACTION_NAME, new Expression_Node_Function43Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function44Impl.S_ACTION_NAME, new Expression_Node_Function44Impl(EnumEventhandler.Wr_Rhn, sList, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function45Impl.S_ACTION_NAME, new Expression_Node_Function45Impl(EnumEventhandler.O_Ea, sList, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function46Impl.S_ACTION_NAME, new Expression_Node_Function46Impl(EnumEventhandler.O_Ea, sList, transUnknown), log_Reports_ThisMethod);
            }

            {
                List<string> sList = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function_BootCsvEditorImpl.S_ACTION_NAME, new Expression_Node_Function_BootCsvEditorImpl(EnumEventhandler.O_Ea, sList, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function_OnEditorSelected_Impl.S_ACTION_NAME, new Expression_Node_Function_OnEditorSelected_Impl(EnumEventhandler.Tp_B_Wr_Rhn, sList, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> sList = new List<string>();
                sList.Add(Expression_Node_Function47Impl.S_PM_FOLDER_SOURCE);
                sList.Add(Expression_Node_Function47Impl.S_PM_FILE_EXPORT);
                sList.Add(Expression_Node_Function47Impl.S_PM_FILTER);
                sList.Add(Expression_Node_Function47Impl.S_PM_POPUP);
                Collection_Function.SetFunction(Expression_Node_Function47Impl.S_ACTION_NAME, new Expression_Node_Function47Impl(EnumEventhandler.Wr_Rhn, sList, trans00), log_Reports_ThisMethod);
            }

            //
            log_Method.EndMethod(log_Reports_ThisMethod);
            log_Reports_ThisMethod.EndLogging(log_Method);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 関数を登録します。
        /// </summary>
        /// <param name="sName_Fnc"></param>
        /// <param name="expr_Func"></param>
        public static void SetFunction(string sName_Fnc, Expression_Node_Function expr_Func, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(1);
            log_Method.BeginMethod(Info_Functions.Name_Library, "Collection_Function", "SetFunction",log_Reports);
            //

            dictionary_Interlibrary[sName_Fnc] = expr_Func;
            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole("関数[" + sName_Fnc + "]を登録しました。dictionary.count=[" + dictionary_Interlibrary.Count + "]");
            }

            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sName_Fnc"></param>
        /// <param name="parent_Expression"></param>
        /// <param name="cur_Gcav"></param>
        /// <param name="owner_MemoryApplication"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public static Expression_Node_Function NewFunction2(
            string sName_Fnc,
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav,
            //EnumEventhandler enumEventhandler,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, "Collection_Function", "NewFunction2", log_Reports);

            Expression_Node_Function expr_Func;
            if (dictionary_Interlibrary.ContainsKey(sName_Fnc))
            {
                expr_Func = dictionary_Interlibrary[sName_Fnc].NewInstance(
                    parent_Expression,
                    cur_Gcav, 
                    //enumEventhandler,
                    owner_MemoryApplication,
                    log_Reports
                    );
                //expr_Func.EnumEventhandler = enumEventhandler;
            }
            else
            {
                goto gt_Error_NotSupportedFunction;
            }

            goto gt_EndMethod;
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotSupportedFunction:
            expr_Func = null;
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー202！", log_Method);

                StringBuilder sb = new StringBuilder();
                sb.Append("指定の[" + sName_Fnc + "]という関数はありませんでした。");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                sb.Append("もしかして？");
                sb.Append(Environment.NewLine);
                sb.Append("　・プログラマー向け情報：[" + log_Method.Name_Method + "]関数に登録されていますか？");
                sb.Append(Environment.NewLine);

                sb.Append("　・または、そのイベントに追加できないアクションを記述しているのかもしれません。");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                // ヒント
                //todo: t.Append(r.Message_Configurationtree(e_Uic.Cur_Configurationtree));

                r.Message = sb.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return expr_Func;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 関数のディクショナリー。複数のDLLから利用。
        /// </summary>
        private static readonly Dictionary<string, Expression_Node_Function> dictionary_Interlibrary;

        //────────────────────────────────────────
        #endregion



    }
}
