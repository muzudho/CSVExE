using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Middle;
using Xenon.Syntax;

namespace Xenon.Expr
{

    /// <summary>
    /// ＜f-var＞要素。
    /// 
    /// 変数名を入れると、実行時に中身を返してくれる。
    /// </summary>
    public class Expression_FvarImpl : Expression_NodeImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="s_ParentNode"></param>
        /// <param name="moOpyopyo"></param>
        public Expression_FvarImpl(
            Expression_Node_String parent_Expression_Node,
            Configurationtree_Node parent_Configurationtree_Node,
            MemoryApplication owner_MemoryApplication
            )
            : base(parent_Expression_Node, parent_Configurationtree_Node, owner_MemoryApplication)
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 子要素は変数名。
        /// </summary>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        private string Get00VariableName(
            Log_Reports log_Reports
            )
        {
            StringBuilder s = new StringBuilder();

            if (log_Reports.Successful)//null != log_Reports && 
            {
                List<Expression_Node_String> ecList = this.List_Expression_Child.SelectList(EnumHitcount.Unconstraint, log_Reports);

                foreach (Expression_Node_String ec_11 in ecList)
                {
                    string sStr = ec_11.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                    s.Append(sStr);
                }
            }

            return s.ToString();
        }

        //────────────────────────────────────────

        public override string Execute5_Main(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute5_Main", log_Reports);
            //
            //
            string sResult;

            //
            // 変数の名前が入っています。
            string sVarName = this.Get00VariableName(log_Reports).Trim();

            {
                // 変数名。
                Expression_Leaf_StringImpl ec_Atom = new Expression_Leaf_StringImpl(this, this.Cur_Configurationtree.Parent);
                ec_Atom.SetString(
                    sVarName,
                    log_Reports
                );

                //
                // 値を取り出し。
                sResult = this.Owner_MemoryApplication.MemoryVariables.GetStringByVariablename(
                    ec_Atom,
                    true,
                    log_Reports
                    );
            }
            //ystem.Console.WriteLine(this.GetType().Name + "#GetString: ＜f-var＞変数名＝[" + sVarName + "]　結果＝["+sResult+"]");

            //
            //
            //
            //

            log_Method.EndMethod(log_Reports);
            return sResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// このデータは、ファイルパス型だ、と想定して、ファイルパスを取得します。
        /// </summary>
        /// <param oNodeName="request"></param>
        /// <param oNodeName="log_Reports"></param>
        /// <returns></returns>
        public Expression_Node_Filepath GetEFilePath(
            EnumHitcount hits,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "GetFilePath",log_Reports);
            //
            //

            Expression_Node_Filepath ec_Fpath_reslt;

            //
            // ファイルパス変数の名前
            string sVariableName = this.Get00VariableName(log_Reports).Trim();
            {
                // 変数名。
                Expression_Leaf_StringImpl ec_Atom = new Expression_Leaf_StringImpl(this, this.Cur_Configurationtree.Parent);
                ec_Atom.SetString(
                    sVariableName,
                    log_Reports
                );

                ec_Fpath_reslt = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(
                    ec_Atom,
                    true,
                    log_Reports
                    );
            }

            //
            //
            //
            //

            log_Method.EndMethod(log_Reports);
            return ec_Fpath_reslt;
        }

        //────────────────────────────────────────
        #endregion



    }
}
