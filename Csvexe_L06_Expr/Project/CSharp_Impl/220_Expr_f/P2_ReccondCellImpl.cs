using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Table;//NFldName

namespace Xenon.Expr
{

    /// <summary>
    /// Ｗｈｅｒｅ句の最初のｒｅｃ－ｃｏｎｄ要素を求めます。
    /// </summary>
    public class P2_ReccondImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public P2_ReccondImpl()
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ｗｈｅｒｅ句の最初の条件を引っこ抜く。
        /// 条件に合うものを一気に集めてくる形になっているが、
        /// SelectedRecords に機能を持たせるか？
        /// </summary>
        /// <param name="out_Name_KeyField"></param>
        /// <param name="out_FielddefinitionKey2"></param>
        /// <param name="out_Value_Expected"></param>
        /// <param name="childReccondList"></param>
        /// <param name="tableH"></param>
        /// <param name="log_Reports"></param>
        public void GetFirstAwhrReccond(
            out string out_Name_KeyField,
            out Fielddefinition out_FielddefinitionKey2,
            out string out_Value_Expected,
            List<Recordcondition> list_ChildReccond,
            Table_Humaninput tableH,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "GetFirstAwhrReccond",log_Reports);
            //
            //


            Recordcondition err_Recordcondition = null;
            if (0 < list_ChildReccond.Count)
            {
                Recordcondition recCond_First = list_ChildReccond[0];

                err_Recordcondition = recCond_First;

                //
                // 検索のキーとなるフィールドの定義を調べます。

                List<string> list_Name_KeyFld;
                {
                    // 要素数１個
                    list_Name_KeyFld = new List<string>();
                    list_Name_KeyFld.Add(recCond_First.Name_Field);
                }



                // 該当なしの場合、ヌルを返す。
                RecordFielddefinition recordFielddefinition;
                bool bHit = tableH.TryGetFieldDefinitionByName(
                    out recordFielddefinition,
                    list_Name_KeyFld,
                    true,// 必須指定。
                    log_Reports
                    );
                if (!log_Reports.Successful || !bHit)
                {
                    // エラー
                    out_Name_KeyField = "";
                    out_FielddefinitionKey2 = null;
                    out_Value_Expected = "";
                    goto gt_EndMethod;
                }

                //正常
                out_FielddefinitionKey2 = recordFielddefinition.ValueAt(0);
                out_Name_KeyField = recCond_First.Name_Field;
                out_Value_Expected = recCond_First.Value;
            }
            else
            {
                //正常
                out_Name_KeyField = "";
                out_FielddefinitionKey2 = null;
                out_Value_Expected = "";
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
        #endregion



    }
}
