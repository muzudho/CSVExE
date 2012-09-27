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
        /// <param name="sKeyFieldName"></param>
        /// <param name="o_KeyFldDef"></param>
        /// <param name="sExpectedValue"></param>
        /// <param name="childReccondList"></param>
        /// <param name="o_Table"></param>
        /// <param name="log_Reports"></param>
        public void GetFirstAwhrReccond(
            out string sKeyFieldName,
            out XenonFielddefinition o_KeyFldDef,
            out string sExpectedValue,
            List<Recordcondition> list_ChildReccond,
            XenonTable o_Table,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.SName_Library, this, "GetFirstAwhrReccond",log_Reports);
            //
            //


            Recordcondition err_Recordcondition = null;
            if (0 < list_ChildReccond.Count)
            {
                Recordcondition recCond_First = list_ChildReccond[0];

                err_Recordcondition = recCond_First;

                //
                // 検索のキーとなるフィールドの定義を調べます。

                List<string> sList_KeyFldName;
                {
                    // 要素数１個
                    sList_KeyFldName = new List<string>();
                    sList_KeyFldName.Add(recCond_First.SField);
                }



                // 該当なしの場合、ヌルを返す。
                //o_KeyFldDef;
                {
                    List<XenonFielddefinition> o_KeyFldDefList;
                    bool bHit = o_Table.TryGetFieldDefinitionByName(
                        out o_KeyFldDefList,
                        sList_KeyFldName,
                        true,// 必須指定。
                        log_Reports
                        );
                    if (!log_Reports.BSuccessful || !bHit)
                    {
                        // エラー
                        sKeyFieldName = "";
                        o_KeyFldDef = null;
                        sExpectedValue = "";
                        goto gt_EndMethod;
                    }

                    o_KeyFldDef = o_KeyFldDefList[0];
                }



                sKeyFieldName = recCond_First.SField;
                sExpectedValue = recCond_First.SValue;
            }
            else
            {
                sKeyFieldName = "";
                o_KeyFldDef = null;
                sExpectedValue = "";
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
