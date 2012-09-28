using System;
using System.Collections.Generic;
using System.Data;//DataRowView
using System.Linq;
using System.Text;
using System.Windows.Forms;//DrawItemEventArgs

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Table; //OTable
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.MiddleImpl
{
    /// <summary>
    /// リストボックスの項目の描画。
    /// 
    /// ＜view＞で設定する場合。
    /// </summary>
    public class ListboxItemDrawer_02Impl : ListboxItemDrawer_01Impl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="moOpyopyo"></param>
        public ListboxItemDrawer_02Impl(MemoryApplication owner_MemoryApplication)
            : base(owner_MemoryApplication)
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 項目の文字列。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="cctLst"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public override string P1_GetItemString(
            int nCurIx,//DrawItemEventArgs e,//e.Index
            CustomcontrolListbox cctLst,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "P1_GetItemLabel",log_Reports);
            //
            //

            string sDisplayText;

            // ↓2012-01-20 追加
            if (nCurIx < cctLst.List_SText_Display.Count)
            {
                sDisplayText = cctLst.List_SText_Display[nCurIx];
                if (null != sDisplayText)
                {
                    goto gt_EndMethod;
                }
            }

            //
            // 項目の数だけ呼び出される。
            // 処理はできるだけ軽く。


            if (null == this.Expression_ItemLabel)
            {
                sDisplayText = "(" + Info_MiddleImpl.SName_Library + "#P1_GetItemString:リストボックスに＜ａ－ｉｔｅｍ－ｌａｂｅｌ＞が指定されていません)";
                goto gt_EndMethod;
            }


            //
            // dataRowViewが入っている。
            DataRowView dataRowView = (DataRowView)cctLst.Items[nCurIx];
            //
            //
            // ID値を取得し、キー値とする。
            int nKey;
            XenonValue_IntImpl.TryParse(// ※仮。
                dataRowView.Row["ID"],
                out nKey,
                EnumOperationIfErrorvalue.Error,
                -1,
                log_Reports
                );
            if (!log_Reports.BSuccessful)
            {
                // エラー
                sDisplayText = "（エラー発生中）";
                goto gt_EndMethod;
            }

            if (log_Reports.BSuccessful)
            {
                string sKey = nKey.ToString(); // ※仮。


                //
                // value-variable-name="" 属性
                if (null == this.Expression_ValueVariableName)
                {
                    //
                    // エラー。
                    sDisplayText = "(変数名取得失敗)";
                    goto gt_Error_NullValueVariableName;
                }
                else
                {
                    //
                    // 変数名取得。

                    StringBuilder sbHint = new StringBuilder();
                    sbHint.Append(Info_MiddleImpl.SName_Library);
                    sbHint.Append(":");
                    sbHint.Append(this.GetType().Name);
                    Givechapterandverse_Node parent_Givechapterandverse_Node = new Givechapterandverse_NodeImpl(sbHint.ToString(), null);

                    string sVariableName = this.Expression_ValueVariableName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                    XenonNameImpl o_Name_Variable = new XenonNameImpl(sVariableName, parent_Givechapterandverse_Node);

                    //ystem.Console.WriteLine(this.GetType().Name + "#P1_GetItemLabel: sVariableName=[" + sVariableName + "]　sValue=[" + sValue + "]");


                    //
                    // ループカウンター変数に、キー値を上書き。
                    this.Owner_MemoryApplication.MemoryVariables.SetStringValue(
                        o_Name_Variable,
                        sKey,
                        true,
                        log_Reports
                        );
                }


                //
                // 表示文字列。
                sDisplayText = this.Expression_ItemLabel.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
            }
            else
            {
                sDisplayText = "(エラー発生中)";
                goto gt_EndMethod;
            }

            if (!log_Reports.BSuccessful)
            {
                sDisplayText = "(エラー発生中)";
                goto gt_EndMethod;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullValueVariableName:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー926！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("＜view＞の＜f-listbox-for-items＞に、");
                t.Append(Environment.NewLine);
                t.Append("value-variable-name=””属性がありませんでした。");

                t.Append(Environment.NewLine);
                t.Append("コントロール名＝[");
                t.Append(cctLst.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                t.Append("]");

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:

            // ↓2012-01-20 追加
            while (cctLst.List_SText_Display.Count <= nCurIx)
            {
                cctLst.List_SText_Display.Add(null);
            }
            cctLst.List_SText_Display[nCurIx] = sDisplayText;

            log_Method.EndMethod(log_Reports);
            return sDisplayText;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Expression_Node_String expression_ValueVariableName;

        /// <summary>
        /// value-variable-name=""属性で指定された変数名。
        /// </summary>
        public Expression_Node_String Expression_ValueVariableName
        {
            get
            {
                return expression_ValueVariableName;
            }
            set
            {
                expression_ValueVariableName = value;
            }
        }

        //────────────────────────────────────────

        private Expression_Node_String expression_ItemLabel;

        /// <summary>
        /// ＜ａ－ｉｔｅｍ－ｌａｂｅｌ＞で指定された表示文字列。
        /// </summary>
        public Expression_Node_String Expression_ItemLabel
        {
            get
            {
                return expression_ItemLabel;
            }
            set
            {
                expression_ItemLabel = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
