﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Xenon.Syntax;

namespace Xenon.Table
{
    public class SelectPerformerImpl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 無条件で、全てのレコードを返す。
        /// </summary>
        /// <param name="dst_Row"></param>
        /// <param name="bRequired_ExpectedValue"></param>
        /// <param name="dataTable"></param>
        /// <param name="s_ParentNode_query"></param>
        /// <param name="log_Reports"></param>
        public void Select(
            out List<DataRow> out_List_DstRow,
            bool bRequired_ExpectedValue,
            DataTable dataTable,
            Givechapterandverse_Node parent_Gcav,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.SName_Library, this, "Select",log_Reports);

            //
            //
            //
            //

            out_List_DstRow = new List<DataRow>();


            foreach (DataRow row in dataTable.Rows)
            {
                out_List_DstRow.Add(row);
            }

            goto gt_EndMethod;

            //
        //
        //
        //

        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「フィールド名＝値」という条件１つで検索。該当するレコード０～Ｎ件を返す。
        /// </summary>
        /// <param name="dst_Row"></param>
        /// <param name="sName_KeyField"></param>
        /// <param name="sValue_Expected"></param>
        /// <param name="bRequired_ExpectedValue"></param>
        /// <param name="xenonFileddef_Key"></param>
        /// <param name="dataTable"></param>
        /// <param name="s_ParentNode_query"></param>
        /// <param name="log_Reports"></param>
        public void Select(
            out List<DataRow> out_List_DstRow,
            string sName_KeyField,
            string sValue_Expected,
            bool bRequired_ExpectedValue,
            XenonFielddefinition xenonFileddef_Key,
            DataTable dataTable,
            Givechapterandverse_Node parent_Query,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.SName_Library, this, "Select",log_Reports);

            //
            //
            //
            //

            out_List_DstRow = new List<DataRow>();

            Judge_FieldBoolImpl judgeB = new Judge_FieldBoolImpl();
            Judge_FieldIntImpl judgeI = new Judge_FieldIntImpl();
            Judge_FieldStringImpl judgeS = new Judge_FieldStringImpl();


            foreach (DataRow row in dataTable.Rows)
            {
                bool bJudge;

                if (xenonFileddef_Key.Type == typeof(XenonValue_StringImpl))
                {
                    // string型フィールドなら

                    judgeS.Judge(
                        out bJudge,
                        sName_KeyField,
                        sValue_Expected,
                        bRequired_ExpectedValue,
                        row,
                        parent_Query,
                        log_Reports
                    );
                }
                else if (xenonFileddef_Key.Type == typeof(XenonValue_IntImpl))
                {
                    // int型フィールドなら

                    judgeI.Judge(
                        out bJudge,
                        sName_KeyField,
                        sValue_Expected,
                        bRequired_ExpectedValue,
                        row,
                        parent_Query,
                        log_Reports
                    );
                }
                else if (xenonFileddef_Key.Type == typeof(XenonValue_BoolImpl))
                {
                    // bool型フィールドなら

                    judgeB.Judge(
                        out bJudge,
                        sName_KeyField,
                        sValue_Expected,
                        bRequired_ExpectedValue,
                        row,
                        parent_Query,
                        log_Reports
                    );
                }
                else
                {
                    //
                    // エラー。
                    goto gt_Error_UndefinedClass;
                }

                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }

                if (bJudge)
                {
                    out_List_DstRow.Add(row);
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedClass:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー899", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.AppendI(0, "<NFuncCellUpdaterImplクラス>");
                s.Append(Environment.NewLine);

                s.AppendI(1, "予期しない型です。");
                s.Append(Environment.NewLine);

                s.AppendI(1, "keyFldDefinition.Type=[");
                s.Append(xenonFileddef_Key.Type);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.AppendI(1, r.Message_Givechapterandverse(parent_Query));

                s.AppendI(0, "</NFuncCellUpdaterImplクラス>");

                r.SMessage = s.ToString();
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



    }
}
