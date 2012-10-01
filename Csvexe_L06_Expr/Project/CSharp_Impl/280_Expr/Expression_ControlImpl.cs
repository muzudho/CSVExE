using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;//Log_TextIndented

namespace Xenon.Expr
{

    /// <summary>
    /// 
    /// </summary>
    public class Expression_ControlImpl : Expression_NodeImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_ControlImpl(Expression_Node_String parent_Expr, Givechapterandverse_Node cur_Cf, Usercontrol parent_Usercontrol, MemoryApplication owner_MemoryApplication)
            : base(parent_Expr, cur_Cf, owner_MemoryApplication)
        {
            this.parent_Usercontrol = parent_Usercontrol;
            this.list_Expression_Data = new List<Expression_Node_String>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        private void ToDescription(Log_TextIndented txt)
        {
            txt.Increment();


            txt.AppendI(0, "<");
            txt.Append(this.GetType().Name);
            txt.Append("クラス>");
            txt.Newline();

            //
            txt.AppendI(0, "＜ｄａｔａ＞（データソース）のExplainは省略。");//コールスタックがオーバーフローするので。
            txt.Newline();

            //
            txt.AppendI(0, "＜ｄａｔａ＞（データターゲット）のExplainは省略。");//コールスタックがオーバーフローするので。
            txt.Newline();

            txt.AppendI(0, "</");
            txt.Append(this.GetType().Name);
            txt.Append("クラス>");
            txt.Newline();


            txt.Decrement();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        private void ToConfigStack(Log_TextIndented txt)
        {
            txt.Increment();


            txt.Append("・");
            txt.Append(this.GetType().Name);
            txt.Append("クラス");
            txt.Newline();

            if (null != this.parent_Usercontrol)
            {
                txt.Append("コントロールのfcName=[");
                txt.Append(this.parent_Usercontrol.ControlCommon.Expression_Name_Control);
                txt.Append("]");
            }
            else
            {
                txt.Append("(ソース不明)");
            }



            txt.Decrement();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private List<Expression_Node_String> list_Expression_Data;

        /// <summary>
        /// データ・ソースと、データ・ターゲット。
        /// </summary>
        public List<Expression_Node_String> List_Expression_Data
        {
            get
            {
                return list_Expression_Data;
            }
            set
            {
                list_Expression_Data = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 親要素。
        /// </summary>
        private Usercontrol parent_Usercontrol;

        //────────────────────────────────────────
        #endregion



    }
}
