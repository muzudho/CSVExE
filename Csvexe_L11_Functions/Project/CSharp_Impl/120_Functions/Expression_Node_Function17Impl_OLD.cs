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
        public static readonly string NAME_FUNCTION = "Sf:Action17;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// ファイルパス。未設定ならヌル。
        /// 
        /// 元は名無し。
        /// </summary>
        public static readonly string PM_FILEPATH = PmNames.S_FILEPATH.Name_Pm;

        ///// <summary>
        ///// 「バリデーション設定ファイル」のファイルパスが入っている変数の名前。
        ///// 
        ///// 元は名無し。
        ///// </summary>
        //public static readonly string S_PM_NAME_VAR_FILEPATH = PmNames.S_NAME_VAR_FILEPATH.Name_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function17Impl_OLD(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            : base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Conf,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function17Impl_OLD(this.EnumEventhandler,this.List_NameArgumentInitializer,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Conf), log_Reports);

            f0.SetAttribute(Expression_Node_Function17Impl_OLD.PM_FILEPATH, null, log_Reports);


            //
            log_Method.EndMethod(log_Reports);
            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        public override string Execute5_Main(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main",log_Reports);

            string sFncName;
            this.TrySelectAttribute(out sFncName, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            // デバッグ
            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }

            // タスク・デスクリプション
            if (this.Functionparameterset.Sender is Customcontrol)
            {
                Customcontrol fcCc = (Customcontrol)this.Functionparameterset.Sender;

                string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(
                    EnumHitcount.Unconstraint,
                    log_Reports
                    );

                log_Reports.Comment_EventCreationMe += "／追記：[" + sName_Usercontrol + "]コントロールが、[" + sFncName + "]アクションを実行。";
            }
            else
            {
                log_Reports.Comment_EventCreationMe += "／追記：[" + sFncName + "]アクションを実行。";
            }


            if (this.EnumEventhandler == EnumEventhandler.O_Lr)
            {

                //
                //
                //
                //
                this.Functionparameterset.Node_EventOrigin += "＜" + log_Method.Fullname + ":＞";


                Expression_Node_String e_ArgFilePath;
                this.TrySelectAttribute(out e_ArgFilePath, Expression_Node_Function17Impl_OLD.PM_FILEPATH, EnumHitcount.One_Or_Zero, log_Reports);

                // ファイルパス
                if (null == e_ArgFilePath)
                {
                    if (log_Reports.Successful)
                    {
                        // 正常時
                        if (log_Method.CanDebug(1))
                        {
                            log_Method.WriteDebug_ToConsole("①[" + Expression_Node_Function17Impl_OLD.PM_FILEPATH + "]はヌルだった。");
                        }

                        throw new Exception("バリデーション設定ファイルのファイルパスを１つ１つ当たるプログラムが未実装です。");

                        //// 変数名。
                        //Expression_Node_String e_Atom;
                        //this.TrySelectAttribute(out e_Atom, Ec_Sf17Impl_OLD.S_PM_NAME_VAR_FILEPATH, false, EnumHitcount.Unconstraint, log_Reports);

                        //// ファイルパス。
                        //log_Reports.Log_Callstack.Push(log_Method, "④");
                        //Expression_Node_Filepath efp = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(e_Atom, true, log_Reports);
                        //log_Reports.Log_Callstack.Pop(log_Method, "④");

                        //e_ArgFilePath = efp;
                        //this.SetAttribute(Ec_Sf17Impl_OLD.S_PM_FILEPATH, efp, log_Reports);
                    }
                    else
                    {
                    }
                }
                else
                {
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole( "②");
                    }
                }


                //絶対ファイルパス
                string sFpatha_vcnf;
                if (log_Reports.Successful)
                {
                    // 正常時
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole( "③");
                    }

                    sFpatha_vcnf = e_ArgFilePath.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                    if (!log_Reports.Successful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole( "④");
                    }

                    sFpatha_vcnf = "";
                }

                // 『バリデーション設定ファイル』を読み込みます。
                if (log_Reports.Successful)
                {
                    // 正常時

                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole( "⑤sFpatha_vcnf=[" + sFpatha_vcnf + "]");
                    }

                    this.Owner_MemoryApplication.MemoryValidators.LoadFile(sFpatha_vcnf, log_Reports);//ここでバグる。
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
            ((EventMonitor)this.Functionparameterset.EventMonitor).BNowactionworking = false;

            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────
        #endregion



    }
}
