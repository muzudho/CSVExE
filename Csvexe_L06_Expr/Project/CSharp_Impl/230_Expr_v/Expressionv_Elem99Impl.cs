using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;

namespace Xenon.Expr
{

    /// <summary>
    /// バリデーション用。
    /// </summary>
    public class Expressionv_Elem99Impl : Expression_NodeImpl, Expressionv_Elem99
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Expressionv_Elem99Impl(Expression_Node_String parent_Expression_Node, Configurationtree_Node cf_MyNode, MemoryApplication owner_MemoryApplication)
            : base(parent_Expression_Node, cf_MyNode, owner_MemoryApplication)
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 基底クラスに比べて、SetDataRow をする箇所が追加された。
        /// </summary>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public override string Expression_ExecuteMain(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Expression_ExecuteMain",log_Reports);
            //
            //

            StringBuilder sb_Result = new StringBuilder();

            List<Expression_Node_String> ecList_Child = this.List_Expression_Child.SelectList(
                Request_SelectingImpl.Unconstraint,
                log_Reports
                );



            switch (this.Request_Selecting.EnumHitcount)
            {
                case EnumHitcount.First_Exist:
                    {
                        //
                        // 最初の１件のみ。存在しない場合エラー。
                        //
                        if (0 < ecList_Child.Count)
                        {
                            Expressionv_Elem99 ecv_Child = (Expressionv_Elem99)ecList_Child[0];
                            ecv_Child.SetDataRow(dataRow);
                            string str1 = ecv_Child.Execute_OnExpressionString(this.Request_Selecting, log_Reports);

                            sb_Result.Append(str1);
                        }
                        else
                        {
                            //
                            // エラー
                            goto gt_ErrorNotFoundOne;
                        }
                    }
                    break;

                case EnumHitcount.First_Exist_Or_Zero:
                    {
                        //
                        // 最初の１件のみ。存在しない場合、空文字列。
                        //
                        if (0 < ecList_Child.Count)
                        {
                            Expressionv_Elem99 ecv_Child = (Expressionv_Elem99)ecList_Child[0];
                            ecv_Child.SetDataRow(dataRow);
                            string str1 = ecv_Child.Execute_OnExpressionString(this.Request_Selecting, log_Reports);

                            sb_Result.Append(str1);
                        }
                        else
                        {
                            //
                            // 存在しないので、空文字列。
                            //

                            // そのままスルー。
                        }
                    }
                    break;

                case EnumHitcount.Unconstraint:
                    {
                        //
                        // 制限なし
                        //

                        foreach (Expression_Node_String ec_Child in ecList_Child)
                        {
                            string str1 = ec_Child.Execute_OnExpressionString(this.Request_Selecting, log_Reports);

                            sb_Result.Append(str1);
                        }

                    }
                    break;

                default:
                    {
                        //
                        // エラー
                        goto gt_ErrorUndefinedEnum;
                    }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_ErrorNotFoundOne:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                this.Owner_MemoryApplication.CreateErrorReport("Er:6037;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_ErrorUndefinedEnum:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, this.Request_Selecting.EnumHitcount.ToString(), log_Reports);//要求した検索ヒット区分

                this.Owner_MemoryApplication.CreateErrorReport("Er:6038;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return sb_Result.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private DataRow dataRow;

        /// <summary>
        /// E_Executeの引数。
        /// </summary>
        /// <param name="request"></param>
        public DataRow DataRow
        {
            get
            {
                return this.dataRow;
            }
        }

        /// <summary>
        /// E_Executeの引数。
        /// </summary>
        /// <param name="request"></param>
        public void SetDataRow(
            DataRow dataRow
            )
        {
            this.dataRow = dataRow;
        }

        //────────────────────────────────────────
        #endregion



    }
}
