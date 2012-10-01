using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Table;//DefaultTable,FldDefinition

namespace Xenon.Expr
{

    /// <summary>
    /// ＜ｆ－ｆｎｃ＞要素です。
    /// </summary>
    public class Expression_FfncImpl : Expression_NodeImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param oVariableName="s_ParentNode"></param>
        /// <param oVariableName="moOpyopyo"></param>
        public Expression_FfncImpl(
            Expression_Node_String parent_Expression, Configurationtree_Node parent_Configurationtree, MemoryApplication owner_MemoryApplication)
            : base(parent_Expression, parent_Configurationtree, owner_MemoryApplication)
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ユーザー定義プログラムの実行。
        /// </summary>
        /// <returns></returns>
        public override string Expression_ExecuteMain(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Expression_ExecuteMain",log_Reports);
            //
            //

            string sResult = "";

            if (!log_Reports.Successful)
            {
                // エラーが出ていたら、さっさと抜ける。
                sResult = "＜「E■ｆ－ｆｎｃ」エラー101＞";
                goto gt_EndMethod;
            }

            // ｎａｍｅ属性
            string sFncName;
            if (!this.Dictionary_Expression_Attribute.TrySelect(out sFncName, PmNames.S_NAME.Name_Pm, true, Request_SelectingImpl.Unconstraint, log_Reports))
            {
                // エラー時
                sResult = "＜エラー：ｎａｍｅ属性無し＞";
                // #エラー
                System.Console.WriteLine(this.GetType().Name + "#Expression_ExecuteMain: ｎａｍｅ属性なし");
                goto gt_EndMethod;
            }




            Expression_Node_Function ec_CommonFunction;
            if (!this.Owner_MemoryApplication.MemoryFunctions.TryGetFunction(out ec_CommonFunction, sFncName, log_Reports))
            {
                // エラー時
                sResult = "";

                // #エラー
                System.Console.WriteLine(this.GetType().Name + "#Expression_ExecuteMain: calll=[" + sFncName + "] コモン関数登録なし");
                this.Owner_MemoryApplication.MemoryFunctions.WriteDebug_ToConsole();
                goto gt_EndMethod;
            }
            else
            {
                // ＜ａｒｇ＞一覧
                Dictionary_Expression_Node_String ecDic_Argument = new Dictionary_Expression_Node_StringImpl(ec_CommonFunction.Cur_Configurationtree);
                this.Dictionary_Expression_Attribute.ForEach(delegate(string sAttrName, Expression_Node_String e_Attr, ref bool bBreak)
                {
                    if (log_Reports.Successful)
                    {
                        ecDic_Argument.Set(sAttrName, e_Attr, log_Reports);
                    }
                });

                // 関数に引数を渡したい。
                ec_CommonFunction.Dictionary_Expression_Parameter = ecDic_Argument;

                //ystem.Console.WriteLine(this.GetType().Name + "#Expression_ExecuteMain: ★★★＜ｆ－ｆｎｃ＞要素実行 sCall=[" + sCall + "] e_Function.クラス名=[" + e_DefFunction.GetType().Name + "]");// ＜ａｒｇ＞=[" + d_sArg.ToString() + "]
                // e_Function=" + Environment.NewLine + s2.ToString()

                // 登録されている「ユーザー定義関数」を実行します。
                sResult = ec_CommonFunction.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
            }

            goto gt_EndMethod;

            //
            //
            //
            //

        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return sResult;
        }



        ///// <summary>
        ///// レコードセットと、セレクト文を取得。
        ///// </summary>
        ///// <param name="log_Reports"></param>
        ///// <returns>該当がなければヌル。</returns>
        //private RecordSet E_Execute_P1_Reccond_CellType(
        //    bool bExists_Awhr,//ｗｈｅｒｅ
        //    Selectstatement selectSt,
        //    Configurationtree_Node s_ParentNode_Query,
        //    Log_Reports log_Reports
        //    )
        //{
        //    Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
        //    log_Method.SetPath(Info_E.LibraryName, this, "E_Execute_P1_Reccond_CellType");
        //    log_Method.BeginMethod(log_Reports);
        //    //
        //    //

        //    RecordSet dst_Rs;


        //    bool bLoad = false;

        //    //ystem.Console.WriteLine(Info_N.LibraryName + ":" + this.GetType().Name + "#E_Execute: （＜f-cell＞開始１０）");

        //    //
        //    // 一時記憶から、レコードセットのロードをするか否か。
        //    {
        //        {
        //            //ｗｈｅｒｅ
        //            Expression_Node_String e_Awhr_RecordSetLoadFrom;//ソース情報利用
        //            bool bHit = this.Dictionary_Expression_Attribute.TryGet(
        //                 out e_Awhr_RecordSetLoadFrom,
        //                NamesNode.S_RECORD_SET_LOAD_FROM5,
        //                false,
        //                Request_SelectingImpl.Unconstraint,
        //                log_Reports //null
        //                );

        //            selectSt.Expression_Where_RecordSetLoadFrom = e_Awhr_RecordSetLoadFrom;
        //        }


        //        if ("" != selectSt.Expression_Where_RecordSetLoadFrom.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports).Trim())
        //        {
        //            bLoad = true;
        //        }
        //    }


        //    // レコードセットの取得。
        //    if (bLoad)
        //    {
        //        //ystem.Console.WriteLine(Info_N.LibraryName + ":" + this.GetType().Name + "#E_Execute: （２０＿＜f-cell＞）【一時記憶から取得】");

        //        //
        //        // 一時記憶からロード。
        //        P1_RecordSetLoader sel1 = new P1_RecordSetLoader(this.Owner_MemoryApplication);
        //        dst_Rs = sel1.P1_Load(
        //            selectSt.Expression_Where_RecordSetLoadFrom,
        //            this.Cur_Configurationtree,
        //            log_Reports
        //            );
        //    }
        //    else
        //    {
        //        XenonTable o_Table = owner_MemoryApplication.MemoryTables.GetXenonTableByName(selectSt.Expression_From,true,log_Reports);
        //        if (null == o_Table)
        //        {
        //            // エラー。
        //            dst_Rs = null;
        //            goto gt_Error_NullTable;
        //        }
        //        // レコードセットを用意。
        //        dst_Rs = new RecordSetImpl(o_Table);


        //        bool bExpectedValueRequired;
        //        {
        //            bool parseSuccessful = bool.TryParse(selectSt.Required, out bExpectedValueRequired);
        //        }




        //        //
        //        // 検索実行。
        //        {

        //            //
        //            //
        //            //
        //            // 条件
        //            //
        //            //
        //            //
        //            string sKeyFieldName;
        //            XenonFielddefinition o_KeyFldDef;
        //            string sExpectedValue;
        //            P2_ReccondImpl sel2 = new P2_ReccondImpl();
        //            sel2.GetFirstAwhrReccond(
        //                out sKeyFieldName,
        //                out o_KeyFldDef,
        //                out sExpectedValue,
        //                selectSt.List_Recordcondition,
        //                o_Table,
        //                log_Reports
        //                );
        //            List<DataRow> dst_Row = new List<DataRow>();

        //            // TODO:セル型でない場合、キーフィールド名がないこともある。

        //            SelectPerformerImpl sp = new SelectPerformerImpl();
        //            sp.Select(
        //                out dst_Row,
        //                sKeyFieldName,
        //                sExpectedValue,
        //                bExpectedValueRequired,
        //                o_KeyFldDef,
        //                o_Table.DataTable,
        //                s_ParentNode_Query,
        //                log_Reports
        //                );



        //            dst_Rs.AddList(dst_Row, log_Reports);
        //            if (!log_Reports.Successful)
        //            {
        //                // 既エラー。
        //                goto gt_EndMethod;
        //            }

        //        }
        //    }

        //    goto gt_EndMethod;





        //    //
        //    //
        //    //
        //    //



        //                //
        //// エラー。
        //gt_Error_NullTable:
        //    if (log_Reports.CanCreateReport)
        //    {
        //        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
        //        r.STitle = "▲エラー433！(" + Info_E.LibraryName + ":" + this.GetType().Name + "#P2_ReadRecordSet)";

        //        Log_TextIndented t = new Log_TextIndentedImpl();

        //        t.Append("　テーブルがヌルです。プログラムのミスの可能性があります。");
        //        t.Newline();

        //        // ヒント
        //        t.Append(r.Message_Configurationtree(s_ParentNode_Query));

        //        r.Message = t.ToString();
        //        log_Reports.EndCreateReport();
        //    }
        //    goto gt_EndMethod;
        //    //
        //    //
        //gt_EndMethod:
        //    log_Method.EndMethod(log_Reports);
        //    return dst_Rs;
        //}

        ///// <summary>
        ///// 制約の判定。
        ///// </summary>
        ///// <param name="log_Reports"></param>
        ///// <returns></returns>
        //private void E_Execute_P4(
        //    int nHitsCount,//eRecordList.Count
        //    Request_Selecting request,
        //    Log_Reports log_Reports
        //    )
        //{
        //    Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
        //    log_Method.SetPath(Info_E.LibraryName, this, "E_Execute_P4");
        //    log_Method.BeginMethod(log_Reports);
        //    //
        //    //

        //    switch (request.EnumHitcount)
        //    {
        //        case EnumHitcount.One:
        //            if (1 != nHitsCount)
        //            {
        //                //
        //                // エラー。
        //                goto gt_Error_NotOne;
        //                // オブジェクトに設定されているプロパティーが想定しない操作と判断。
        //            }
        //            break;

        //        case EnumHitcount.One_Or_Zero:
        //            if (!(1 == nHitsCount || 0 == nHitsCount))
        //            {
        //                //
        //                // エラー。
        //                goto gt_Error_NotOneOrZero;
        //                // オブジェクトに設定されているプロパティーが想定しない操作と判断。
        //            }
        //            break;

        //        case EnumHitcount.First_Exist_Or_Zero:
        //            {
        //                //
        //                // 特にエラーとなる条件はありません。
        //            }
        //            break;

        //        case EnumHitcount.Exists:
        //            if (nHitsCount < 1)
        //            {
        //                //
        //                // エラー。
        //                goto gt_Error_NotExists;
        //                // オブジェクトに設定されているプロパティーが想定しない操作と判断。
        //            }
        //            break;

        //        case EnumHitcount.Unconstraint:
        //            {
        //                //
        //                // 特にエラーとなる条件はありません。
        //            }
        //            break;

        //        default:
        //            {
        //                //
        //                // エラー。
        //                goto gt_Error_UndefinedEnum;
        //                // オブジェクトに設定されているプロパティーが想定しない操作と判断。
        //            }
        //        //break;
        //    }

        //    goto gt_EndMethod;

        //    //
        //// エラー。
        //gt_Error_NotOne:
        //    if (log_Reports.CanCreateReport)
        //    {
        //        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
        //        r.STitle = "▲エラー341！（" + Info_E.LibraryName + "）";

        //        Log_TextIndented t = new Log_TextIndentedImpl();

        //        t.Append("検索に1個だけ必ずヒットする予定でしたが、[");
        //        t.Append(nHitsCount);
        //        t.Append("]個ヒットしてしまいました。");
        //        t.Append(Environment.NewLine);
        //        t.Append(Environment.NewLine);

        //        // ヒント

        //        r.Message = t.ToString();
        //        log_Reports.EndCreateReport();
        //    }
        //    goto gt_EndMethod;


        //    //
        //// エラー。
        //gt_Error_NotOneOrZero:
        //    if (log_Reports.CanCreateReport)
        //    {
        //        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
        //        r.STitle = "▲エラー342！（" + Info_E.LibraryName + "）";

        //        Log_TextIndented t = new Log_TextIndentedImpl();

        //        t.Append("検索に1個だけヒットするか、またはヒットしないかのどちらかの予定でしたが、[");
        //        t.Append(nHitsCount);
        //        t.Append("]個ヒットしてしまいました。");
        //        t.Append(Environment.NewLine);
        //        t.Append(Environment.NewLine);

        //        // ヒント

        //        r.Message = t.ToString();
        //        log_Reports.EndCreateReport();
        //    }
        //    goto gt_EndMethod;

        //                //
        //// エラー。
        //gt_Error_NotExists:
        //    if (log_Reports.CanCreateReport)
        //    {
        //        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
        //        r.STitle = "▲エラー343！（" + Info_E.LibraryName + "）";

        //        Log_TextIndented t = new Log_TextIndentedImpl();

        //        t.Append("検索で1個以上ヒットする予定でしたが、[");
        //        t.Append(nHitsCount);
        //        t.Append("]個のヒットでした。");
        //        t.Append(Environment.NewLine);
        //        t.Append(Environment.NewLine);

        //        // ヒント

        //        r.Message = t.ToString();
        //        log_Reports.EndCreateReport();
        //    }
        //    goto gt_EndMethod;

        //    //
        //// エラー。
        //gt_Error_UndefinedEnum:
        //    if (log_Reports.CanCreateReport)
        //    {
        //        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
        //        r.STitle = "▲エラー344！（" + Info_E.LibraryName + "）";

        //        Log_TextIndented t = new Log_TextIndentedImpl();

        //        t.Append("request.EnumHitcount=[");
        //        t.Append(request.EnumHitcount.ToString());
        //        t.Append("]には、プログラム側でまだ未対応です。");
        //        t.Append(Environment.NewLine);
        //        t.Append(Environment.NewLine);

        //        // ヒント

        //        r.Message = t.ToString();
        //        log_Reports.EndCreateReport();
        //    }
        //    goto gt_EndMethod;

        //    //
        //    //
        //    //
        //    //
        //gt_EndMethod:
        //    log_Method.EndMethod(log_Reports);
        //    return;
        //}

        //────────────────────────────────────────
        #endregion



    }
}
