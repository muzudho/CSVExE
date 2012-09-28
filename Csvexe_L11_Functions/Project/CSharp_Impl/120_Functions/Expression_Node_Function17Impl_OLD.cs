using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol

namespace Xenon.Functions
{

    /// <summary>
    /// @Deprecated 使ってないのでは？
    /// 
    /// コントロールに、妥当性判定条件を設定していきます。
    /// </summary>
    public class Expression_Node_Function17Impl_OLD : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        /// <summary>
        /// 関数名。
        /// </summary>
        public static readonly string S_ACTION_NAME = "Sf:Action17;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// ファイルパス。未設定ならヌル。
        /// 
        /// 元は名無し。
        /// </summary>
        public static readonly string S_PM_FILEPATH = PmNames.S_FILEPATH.SName_Pm;

        ///// <summary>
        ///// 「バリデーション設定ファイル」のファイルパスが入っている変数の名前。
        ///// 
        ///// 元は名無し。
        ///// </summary>
        //public static readonly string S_PM_NAME_VAR_FILEPATH = PmNames.S_NAME_VAR_FILEPATH.SName_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function17Impl_OLD(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            : base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "NewInstance",pg_Logging);
            //

            Expression_Node_Function f0 = new Expression_Node_Function17Impl_OLD(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function17Impl_OLD.S_PM_FILEPATH, null, pg_Logging);


            //
            pg_Method.EndMethod(pg_Logging);
            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",pg_Logging);

            string sFncName;
            this.TrySelectAttr(out sFncName, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            // デバッグ
            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.SMessage = "Nアクション[" + sFncName + "]実行";
                pg_Method.Log_Stopwatch.Begin();
            }

            // タスク・デスクリプション
            if (this.ExpressionfncPrmset.Sender is Customcontrol)
            {
                Customcontrol fcCc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(
                    Request_SelectingImpl.Unconstraint,
                    pg_Logging
                    );

                pg_Logging.SComment_EventCreationMe += "／追記：[" + sName_Usercontrol + "]コントロールが、[" + sFncName + "]アクションを実行。";
            }
            else
            {
                pg_Logging.SComment_EventCreationMe += "／追記：[" + sFncName + "]アクションを実行。";
            }


            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {

                //
                //
                //
                //
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + pg_Method.SHead + ":＞";


                Expression_Node_String e_ArgFilePath;
                this.TrySelectAttr(out e_ArgFilePath, Expression_Node_Function17Impl_OLD.S_PM_FILEPATH, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                // ファイルパス
                if (null == e_ArgFilePath)
                {
                    if (pg_Logging.BSuccessful)
                    {
                        // 正常時
                        if (pg_Method.CanDebug(1))
                        {
                            pg_Method.WriteDebug_ToConsole("①[" + Expression_Node_Function17Impl_OLD.S_PM_FILEPATH + "]はヌルだった。");
                        }

                        throw new Exception("バリデーション設定ファイルのファイルパスを１つ１つ当たるプログラムが未実装です。");

                        //// 変数名。
                        //Expression_Node_String e_Atom;
                        //this.TrySelectAttr(out e_Atom, Ec_Sf17Impl_OLD.S_PM_NAME_VAR_FILEPATH, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                        //// ファイルパス。
                        //pg_Logging.Log_Callstack.Push(pg_Method, "④");
                        //Expression_Node_Filepath efp = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(e_Atom, true, pg_Logging);
                        //pg_Logging.Log_Callstack.Pop(pg_Method, "④");

                        //e_ArgFilePath = efp;
                        //this.DicExpression_Attr.Set(Ec_Sf17Impl_OLD.S_PM_FILEPATH, efp, pg_Logging);
                    }
                    else
                    {
                    }
                }
                else
                {
                    if (pg_Method.CanDebug(1))
                    {
                        pg_Method.WriteDebug_ToConsole( "②");
                    }
                }


                //絶対ファイルパス
                string sFpatha_vcnf;
                if (pg_Logging.BSuccessful)
                {
                    // 正常時
                    if (pg_Method.CanDebug(1))
                    {
                        pg_Method.WriteDebug_ToConsole( "③");
                    }

                    sFpatha_vcnf = e_ArgFilePath.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);
                    if (!pg_Logging.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    if (pg_Method.CanDebug(1))
                    {
                        pg_Method.WriteDebug_ToConsole( "④");
                    }

                    sFpatha_vcnf = "";
                }

                // 『バリデーション設定ファイル』を読み込みます。
                if (pg_Logging.BSuccessful)
                {
                    // 正常時

                    if (pg_Method.CanDebug(1))
                    {
                        pg_Method.WriteDebug_ToConsole( "⑤sFpatha_vcnf=[" + sFpatha_vcnf + "]");
                    }

                    this.Owner_MemoryApplication.MemoryValidators.LoadFile(sFpatha_vcnf,this.Owner_MemoryApplication, pg_Logging);//ここでバグる。
                }
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            //
            //
            //
            // 必ずフラグをオフにします。
            //
            //
            //
            ((EventMonitor)this.ExpressionfncPrmset.EventMonitor).BNowactionworking = false;

            pg_Method.EndMethod(pg_Logging);
            return "";
        }

        //────────────────────────────────────────
        #endregion



    }
}
