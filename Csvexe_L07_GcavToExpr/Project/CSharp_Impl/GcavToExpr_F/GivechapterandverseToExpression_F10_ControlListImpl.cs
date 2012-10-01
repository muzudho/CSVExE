using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{

    /// <summary>
    /// S → E
    /// 
    /// </summary>
    public class GivechapterandverseToExpression_F10_ControlListImpl : GivechapterandverseToExpression_AbstractImpl, GivechapterandverseToExpression_F10_ControlList
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// S → E
        /// 
        /// データソース、
        /// データターゲット、
        /// ＜view＞
        /// の３つを変換。
        /// </summary>
        /// <param oNodeName="sList_Name_Control"></param>
        /// <param oNodeName="s_FcConfig"></param>
        /// <param oNodeName="moOpyopyo"></param>
        /// <param oNodeName="log_Reports"></param>
        public void Translate(
            List<string> sList_Name_Control,
            Givechapterandverse_Node cf_FcConfig,
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            //throw new Exception(Info_SToE.LibraryName + ":" + this.GetType().Name + "#SToE: このメソッドは廃止方針です。");

            //
            //
            //
            // デバッグ開始
            //
            //
            //
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.Name_Library, this, "SToE_DsrcDtrg",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(1)データソース・データターゲット・ＳＳＲ");
            }

            //
            //
            //
            //

            string sName_Usercontrol;
            if (log_Reports.Successful)
            {
                // 正常時

                foreach(string sFcName in sList_Name_Control)
                {
                    // コントロール名。
                    Expression_Node_StringImpl ec_FcName = new Expression_Node_StringImpl(null,cf_FcConfig);
                    ec_FcName.AppendTextNode(
                        sFcName,
                        cf_FcConfig,
                        log_Reports
                        );


                    // コントロール名の指定は、１件のみと想定。
                    List<Usercontrol> list_Usercontrol = memoryApplication.MemoryForms.GetUsercontrolsByName(
                        ec_FcName,
                        true,
                        log_Reports
                        );

                    Usercontrol fcUc;
                    if (list_Usercontrol.Count<1)
                    {
                        sName_Usercontrol = sFcName;
                        goto gt_Error_NotFoundUsercontrol;
                    }
                    else
                    {
                        fcUc = list_Usercontrol[0];
                    }




                    Givechapterandverse_Node cf_Control = fcUc.ControlCommon.Givechapterandverse_Control;

                    if (null == cf_Control)
                    {
                        //
                        // O_コントロール要素を新規作成。
                        cf_Control = new Givechapterandverse_NodeImpl(NamesNode.S_CONTROL1, cf_FcConfig);
                        fcUc.ControlCommon.Givechapterandverse_Control = cf_Control;
                    }
                    else
                    {
                        //
                        // O_コントロール要素は既存。
                    }


                    //
                    // コントロール名。
                    fcUc.ControlCommon.Givechapterandverse_Control.Dictionary_Attribute_Givechapterandverse.Set(PmNames.S_NAME.Name_Pm, sFcName, log_Reports);


                    GivechapterandverseToExpression_F11_ControlImpl_ to0 = new GivechapterandverseToExpression_F11_ControlImpl_();
                    to0.Translate(
                        cf_Control,
                        fcUc.ControlCommon.Expression_Control,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );
                }
            }
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundUsercontrol:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("△情報35！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("「コントロール設定ファイル」で指定されている、");
                t.Append(Environment.NewLine);
                t.Append("[");
                t.Append(sName_Usercontrol);
                t.Append("]という名前のコントロールは、登録されていませんでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(cf_FcConfig));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }

            // 処理を中断。
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:

            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement("データソース・データターゲット・ＳＳＲ");
            }
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
