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
    /// validationファイル用。＜f-listbox-for-items＞要素。
    /// </summary>
    public class Expressionv_3FListboxValidationImpl : Expressionv_Elem99Impl, Expressionv_3FListboxValidation
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Expressionv_3FListboxValidationImpl(
            Expression_Node_String parent_Expression, Configurationtree_Node parent_Conf, MemoryApplication owner_MemoryApplication)
            : base(parent_Expression, parent_Conf, owner_MemoryApplication)//"f-listbox-for-items",
        {
            this.Owner_MemoryApplication = owner_MemoryApplication;

            this.list_Expressionv_ADisplay = new List<Expressionv_4ADisplay>();
            this.list_Expressionv_ASelectRecord = new List<Expressionv_4ASelectRecord>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ユーザー定義プログラムの実行。
        /// </summary>
        /// <param name="hits"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public override string Execute4_OnExpressionString(
            EnumHitcount hits,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnExpressionString",log_Reports);
            //
            //

            //
            //
            //
            //

            log_Method.EndMethod(log_Reports);
            return "＜未実装＞";
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private List<Expressionv_4ADisplay> list_Expressionv_ADisplay;

        /// <summary>
        /// ＜a-display＞要素のリスト。
        /// </summary>
        public List<Expressionv_4ADisplay> List_Expressionv_ADisplay
        {
            get
            {
                return list_Expressionv_ADisplay;
            }
            set
            {
                list_Expressionv_ADisplay = value;
            }
        }

        //────────────────────────────────────────

        private List<Expressionv_4ASelectRecord> list_Expressionv_ASelectRecord;

        /// <summary>
        /// ＜a-select-record＞要素のリスト。
        /// </summary>
        public List<Expressionv_4ASelectRecord> List_Expressionv_ASelectRecord
        {
            get
            {
                return list_Expressionv_ASelectRecord;
            }
            set
            {
                list_Expressionv_ASelectRecord = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
