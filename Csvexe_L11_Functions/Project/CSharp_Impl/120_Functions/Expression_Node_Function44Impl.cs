using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Operating;
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.Functions
{

    /// <summary>
    /// 『日付別バックアップ』を取ります。
    /// </summary>
    public class Expression_Node_Function44Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// </summary>
        public static readonly string S_ACTION_NAME = "Sf:E_Sf44Impl;";

        //────────────────────────────────────────
        #endregion




        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function44Impl(
            EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem
            )
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports pg_Logging)
        {
            Expression_Node_Function f0 = new Expression_Node_Function44Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            return f0;
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 今日の分のバックアップを取ります。
        /// </summary>
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",pg_Logging);

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";


                // 日付毎のバックアップ（バックアップ対象ファイルを、設定ファイルから読取り後）
                if (pg_Logging.BSuccessful)
                {
                    // 正常時

                    // １日につき１回まで、バックアップを取ります。
                    DatebackupImpl dateBackup = new DatebackupImpl();

                    dateBackup.NKeptbackups = this.Owner_MemoryApplication.MemoryBackup.NBackupKeptbackups;

                    // アプリケーション個別に付ける「フォルダ・サブ名」
                    dateBackup.SName_Sub = this.Owner_MemoryApplication.MemoryBackup.SName_SubFolder;

                    //
                    // バックアップ・フォルダー
                    //
                    Expression_Node_Filepath ec_Fopath_BackupBase;
                    {
                        XenonNameImpl o_Name_Variable = new XenonNameImpl(
                            NamesVar.S_SP_BACKUP_FOLDER,
                            new Givechapterandverse_NodeImpl("!ハードコーディング_ExAction00031#Perform_WrRhn", null)
                            );

                        // 変数名。
                        Expression_Leaf_StringImpl ec_Atom = new Expression_Leaf_StringImpl(o_Name_Variable.SValue, null, o_Name_Variable.Cur_Givechapterandverse);

                        // フォルダーパス。
                        pg_Logging.Log_Callstack.Push(pg_Method, "⑥");
                        ec_Fopath_BackupBase = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(
                            ec_Atom,
                            true,
                            pg_Logging
                            );
                        pg_Logging.Log_Callstack.Pop(pg_Method, "⑥");
                    }

                    dateBackup.List_Expression_Filepath_Request = this.Expression_FilepathList_Backup;// バックアップ対象のファイルのパス一覧。
                    dateBackup.Expression_Filepath_Backuphome = ec_Fopath_BackupBase;
                    dateBackup.SName_Sub = this.Owner_MemoryApplication.MemoryBackup.SName_SubFolder;
                    dateBackup.Perform(pg_Logging);
                }
            }

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
            return "";
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private List<Expression_Node_Filepath> expression_FilepathList_Backup;

        /// <summary>
        /// バックアップしたいファイルパスのリスト。
        /// </summary>
        public List<Expression_Node_Filepath> Expression_FilepathList_Backup
        {
            get
            {
                return expression_FilepathList_Backup;
            }
            set
            {
                expression_FilepathList_Backup = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
