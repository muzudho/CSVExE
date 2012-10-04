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
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function04Impl.PM_NAME_TABLE);
                list_Param.Add(Expression_Node_Function04Impl.PM_POPUP);
                list_Param.Add(Expression_Node_Function04Impl.PM_FLOWSKIP);
                Collection_Function.SetFunction(Expression_Node_Function04Impl.NAME_FUNCTION, new Expression_Node_Function04Impl(EnumEventhandler.O_Ea, list_Param,trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function05Impl.PM_NAME_TABLE_SOURCE);
                list_Param.Add(Expression_Node_Function05Impl.PM_NAME_TABLE_DESTINATION);
                Collection_Function.SetFunction(Expression_Node_Function05Impl.NAME_FUNCTION, new Expression_Node_Function05Impl(EnumEventhandler.O_Ea, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function06Impl.PM_NAME_TABLE_SOURCE);
                list_Param.Add(Expression_Node_Function06Impl.PM_FILEPATH_EXTERNALAPPLICATION);
                Collection_Function.SetFunction(Expression_Node_Function06Impl.NAME_FUNCTION, new Expression_Node_Function06Impl(EnumEventhandler.O_Ea, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function11Impl.NAME_FUNCTION, new Expression_Node_Function11Impl(EnumEventhandler.O_Lr, list_Param, transUnknown), log_Reports_ThisMethod);
            }
            {
                //dic_E_Sf.Add(E_Sf17Impl_OLD.NAME_FUNCTION, new E_Sf17Impl_OLD(null, cf_Node));//todo:
            }
            {
                List<string> list_Param = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function19Impl.NAME_FUNCTION, new Expression_Node_Function19Impl(EnumEventhandler.O_Lr, list_Param, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function20Impl.PM_NAME_TABLE);
                list_Param.Add(Expression_Node_Function20Impl.PM_NAME_CONTROL_LISTBOX);
                Collection_Function.SetFunction(Expression_Node_Function20Impl.NAME_FUNCTION, new Expression_Node_Function20Impl(EnumEventhandler.O_Lr, list_Param, trans20), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function21Impl.NAME_FUNCTION, new Expression_Node_Function21Impl(EnumEventhandler.O_Kea, list_Param, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function22Impl.NAME_FUNCTION, new Expression_Node_Function22Impl(EnumEventhandler.O_Lr, list_Param, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function25Impl.PM_NAME_FIELD);
                list_Param.Add(Expression_Node_Function25Impl.PM_NAME_VAR_DESTINATION);
                Collection_Function.SetFunction(Expression_Node_Function25Impl.NAME_FUNCTION, new Expression_Node_Function25Impl(EnumEventhandler.O_Ea, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function27Impl.PM_NAME_TOGETHER);
                Collection_Function.SetFunction(Expression_Node_Function27Impl.NAME_FUNCTION, new Expression_Node_Function27Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function28Impl.PM_MESSAGE);
                Collection_Function.SetFunction(Expression_Node_Function28Impl.NAME_FUNCTION, new Expression_Node_Function28Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function29Impl.PM_NAME_CONTROL);
                Collection_Function.SetFunction(Expression_Node_Function29Impl.NAME_FUNCTION, new Expression_Node_Function29Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function30Impl.PM_NAME_TOGETHER);
                list_Param.Add(Expression_Node_Function30Impl.PM_NAME_FORM);
                Collection_Function.SetFunction(Expression_Node_Function30Impl.NAME_FUNCTION, new Expression_Node_Function30Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function31Impl.PM_NAME_CONTROL);
                Collection_Function.SetFunction(Expression_Node_Function31Impl.NAME_FUNCTION, new Expression_Node_Function31Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function32Impl.PM_NAME_TABLE);
                list_Param.Add(Expression_Node_Function32Impl.PM_NAME_FIELD);
                list_Param.Add(Expression_Node_Function32Impl.PM_NAME_CONTROL_DESTINATION);
                Collection_Function.SetFunction(Expression_Node_Function32Impl.NAME_FUNCTION, new Expression_Node_Function32Impl(EnumEventhandler.O_Ea, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function33Impl.PM_NAME_CONTROL);
                list_Param.Add(Expression_Node_Function33Impl.PM_NAME_FIELD_KEY);
                list_Param.Add(Expression_Node_Function33Impl.PM_VALUE_EXPECTED);
                list_Param.Add(Expression_Node_Function33Impl.PM_VALUE_EXPECTED2);
                list_Param.Add(Expression_Node_Function33Impl.PM_VALUE_EMPTY);
                Collection_Function.SetFunction(Expression_Node_Function33Impl.NAME_FUNCTION, new Expression_Node_Function33Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function34Impl.PM_NAME_VAR);
                list_Param.Add(Expression_Node_Function34Impl.PM_VALUE);
                list_Param.Add(Expression_Node_Function34Impl.PM_FLOWSKIP);
                Collection_Function.SetFunction(Expression_Node_Function34Impl.NAME_FUNCTION, new Expression_Node_Function34Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                // arg 無し
                Collection_Function.SetFunction(Expression_Node_Function35Impl.NAME_FUNCTION, new Expression_Node_Function35Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function36Impl.PM_CONTROL_NAME);
                Collection_Function.SetFunction(Expression_Node_Function36Impl.NAME_FUNCTION, new Expression_Node_Function36Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function37Impl.PM_FROM);
                list_Param.Add(Expression_Node_Function37Impl.PM_TO);
                Collection_Function.SetFunction(Expression_Node_Function37Impl.NAME_FUNCTION, new Expression_Node_Function37Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function38Impl.PM_FROM);
                list_Param.Add(Expression_Node_Function38Impl.PM_TO);
                Collection_Function.SetFunction(Expression_Node_Function38Impl.NAME_FUNCTION, new Expression_Node_Function38Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function39Impl.PM_NAME_CONTROL);
                list_Param.Add(Expression_Node_Function39Impl.PM_VALUE_ENABLED);
                Collection_Function.SetFunction(Expression_Node_Function39Impl.NAME_FUNCTION, new Expression_Node_Function39Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function40Impl.PM_NAME_CONTROL);
                list_Param.Add(Expression_Node_Function40Impl.PM_VALUE_VISIBLED);
                Collection_Function.SetFunction(Expression_Node_Function40Impl.NAME_FUNCTION, new Expression_Node_Function40Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function42Impl.PM_EXECUTE);
                list_Param.Add(Expression_Node_Function42Impl.PM_FLOWSKIP);
                Collection_Function.SetFunction(Expression_Node_Function42Impl.NAME_FUNCTION, new Expression_Node_Function42Impl(EnumEventhandler.O_Ea, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function43Impl.PM_NAME_VAR);
                list_Param.Add(Expression_Node_Function43Impl.PM_NAME_CONTROL);
                Collection_Function.SetFunction(Expression_Node_Function43Impl.NAME_FUNCTION, new Expression_Node_Function43Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function44Impl.NAME_FUNCTION, new Expression_Node_Function44Impl(EnumEventhandler.O_Lr, list_Param, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function45Impl.NAME_FUNCTION, new Expression_Node_Function45Impl(EnumEventhandler.O_Ea, list_Param, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function46Impl.NAME_FUNCTION, new Expression_Node_Function46Impl(EnumEventhandler.O_Ea, list_Param, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function_BootCsvEditorImpl.NAME_FUNCTION, new Expression_Node_Function_BootCsvEditorImpl(EnumEventhandler.O_Ea, list_Param, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function_OnEditorSelected_Impl.NAME_FUNCTION, new Expression_Node_Function_OnEditorSelected_Impl(EnumEventhandler.Editor_B_Lr, list_Param, transUnknown), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function47Impl.PM_FOLDER_SOURCE);
                list_Param.Add(Expression_Node_Function47Impl.PM_FILE_EXPORT);
                list_Param.Add(Expression_Node_Function47Impl.PM_FILTER);
                list_Param.Add(Expression_Node_Function47Impl.PM_POPUP);
                Collection_Function.SetFunction(Expression_Node_Function47Impl.NAME_FUNCTION, new Expression_Node_Function47Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
            }
            {
                List<string> list_Param = new List<string>();
                list_Param.Add(Expression_Node_Function48Impl.PM_FILE_LISTFILE);
                list_Param.Add(Expression_Node_Function48Impl.PM_FOLDER_SOURCE);
                list_Param.Add(Expression_Node_Function48Impl.PM_FOLDER_DESTINATION);
                Collection_Function.SetFunction(Expression_Node_Function48Impl.NAME_FUNCTION, new Expression_Node_Function48Impl(EnumEventhandler.O_Lr, list_Param, trans00), log_Reports_ThisMethod);
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

            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sName_Fnc, log_Reports);//関数名
                tmpl.SetParameter(2, "static Collection_Functionコンストラクター", log_Reports);//記述先の関数名

                ((MemoryApplication)owner_MemoryApplication).CreateErrorReport("Er:110002;", tmpl, log_Reports);
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
