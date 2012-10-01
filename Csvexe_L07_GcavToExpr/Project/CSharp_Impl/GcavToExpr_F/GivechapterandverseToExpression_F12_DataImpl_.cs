using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.GcavToExpr
{


    /// <summary>
    /// ＜ｄａｔａ＞
    /// 
    /// データターゲット用。
    /// 
    /// S→E 変換。
    /// </summary>
    class ConfigurationtreeToExpression_F12_DataImpl_ : ConfigurationtreeToExpression_AbstractImpl, ConfigurationtreeToExpression_F12_
    {


        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ＜ｄａｔａ＞要素の読取。
        /// </summary>
        /// <param select="xDataSource"></param>
        /// <param select="fcUc"></param>
        public void Translate(
            Configurationtree_Node cur_Cf,//＜ｄａｔａ＞要素
            Expression_Node_String parent_Ec,//「S■ｆｏｒｍ－ｃｏｍｐｏｎｅｎｔ」
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "CfToEc",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(2)" + cur_Cf.Name);
            }

            //
            //
            //
            //


            //
            //
            //
            // 自
            //
            //
            //
            Expression_NodeImpl cur_Ec = new Expression_NodeImpl(parent_Ec, cur_Cf, memoryApplication);


            //
            //
            //
            // 属性
            //
            //
            //
            string err_SAttrName;
            cur_Cf.Dictionary_Attribute.ForEach(delegate(string sPmName, string sValue, ref bool bBreak)
            {
                if (
                    PmNames.S_MEMORY.Name_Pm == sPmName ||
                    PmNames.S_ACCESS.Name_Pm == sPmName ||
                    PmNames.S_NAME_TABLE.Name_Pm == sPmName ||
                    PmNames.S_NAME_VAR.Name_Pm == sPmName || //.Z_ITEM_VALUE_TO_VARIABLE
                    PmNames.S_DESCRIPTION.Name_Pm == sPmName
                    )
                {
                    //ystem.Console.WriteLine(Info_SToE.LibraryName + ":" + this.GetType().Name + "#SToE:　＜データT　＞に属性追加　[" + sKey + "]←[" + sValue + "]");

                    // なんでも属性として追加。
                    Expression_Node_String ec_Value = new Expression_Leaf_StringImpl(sValue, cur_Ec, cur_Cf);
                    cur_Ec.Dictionary_Expression_Attribute.Set(sPmName, ec_Value, log_Reports);
                }
                else
                {
                    err_SAttrName = sPmName;
                    bBreak = true;
                    goto gt_Error_UndefinedAttr;
                }

                goto gt_gt_EndMethod2;
                //
                //
                //
                //
            gt_Error_UndefinedAttr:
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー701！", log_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();

                    s.Append("＜[");
                    s.Append(cur_Cf.Name);
                    s.Append("]＞要素に、未定義の属性[");
                    s.Append(err_SAttrName);
                    s.Append("]が記述されていました。");
                    s.Newline();
                    s.Newline();

                    //s.Append("親「S■[" + sParentNodeName + "]　ｎａｍｅ＝”[" + sFncName + "]”」");
                    s.Newline();
                    s.Newline();

                    // ヒント
                    s.Append(r.Message_Configurationtree(cur_Cf));

                    r.Message = s.ToString();
                    log_Reports.EndCreateReport();
                }
                goto gt_gt_EndMethod2;

            gt_gt_EndMethod2:
                ;
            });


            //
            //
            //
            // 子
            //
            //
            //
            {
                this.ParseChild_InConfigurationtreeToExpression(
                    cur_Cf,
                    cur_Ec,
                    memoryApplication,
                    pg_ParsingLog,
                    log_Reports
                    );
            }


            //
            //
            //
            // 親へ連結
            //
            //
            //
            parent_Ec.List_Expression_Child.Add(cur_Ec, log_Reports);



            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement(cur_Cf.Name);
            }

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
