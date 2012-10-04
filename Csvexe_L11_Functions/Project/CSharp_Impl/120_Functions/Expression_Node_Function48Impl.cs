using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;//Application
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol

namespace Xenon.Functions
{

    /// <summary>
    /// フォルダー構造を、別のフォルダー下に複製します。
    /// </summary>
    public class Expression_Node_Function48Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string NAME_FUNCTION = "Sf:フォルダー構造の複製;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 表示文章。
        /// </summary>
        public static string PM_FILE_LISTFILE = "Pm:file-listfile;";
        public static string PM_FOLDER_SOURCE = "Pm:folder-source;";
        public static string PM_FOLDER_DESTINATION = "Pm:folder-destination;";

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function48Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function48Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Gcav), log_Reports);

            f0.SetAttribute(Expression_Node_Function48Impl.PM_FILE_LISTFILE, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.SetAttribute(Expression_Node_Function48Impl.PM_FOLDER_DESTINATION, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.SetAttribute(Expression_Node_Function48Impl.PM_FOLDER_SOURCE, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);

            //
            log_Method.EndMethod(log_Reports);
            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override string Expression_ExecuteMain(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Expression_ExecuteMain",log_Reports);

            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.Functionparameterset.Node_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";


                this.Perform2(
                    log_Reports
                    );


                //
                //

                //
                //
                //
                // 必ずフラグをオフにします。
                //
                //
                //
                ((EventMonitor)this.Functionparameterset.EventMonitor).BNowactionworking = false;
            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Perform2(
                    log_Reports
                    );
            }

            //
            //
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        protected void Perform2(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform2",log_Reports);

            string sName_Fnc;
            this.TrySelectAttribute(out sName_Fnc, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sName_Fnc + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }

            //
            // メッセージボックスの表示。
            StringBuilder sb = new StringBuilder();
            sb.Append(log_Method.Fullname);
            sb.Append(":");
            sb.Append(Environment.NewLine);

            string sPmFileListfile;
            this.TrySelectAttribute(out sPmFileListfile, Expression_Node_Function48Impl.PM_FILE_LISTFILE, EnumHitcount.One_Or_Zero, log_Reports);
            string sPmFolderSource;
            this.TrySelectAttribute(out sPmFolderSource, Expression_Node_Function48Impl.PM_FOLDER_SOURCE, EnumHitcount.One_Or_Zero, log_Reports);
            string sPmFolderDestination;
            this.TrySelectAttribute(out sPmFolderDestination, Expression_Node_Function48Impl.PM_FOLDER_DESTINATION, EnumHitcount.One_Or_Zero, log_Reports);

            sb.Append(
                "\n"+
                "file-listfile = " + sPmFileListfile + "\n\n" +
                "folder-source = " + sPmFolderSource + "\n\n" +
                "folder-destination = " + sPmFolderDestination + "\n\n"
                );

            MessageBox.Show(sb.ToString(), "デバッグ表示");


            // CSVファイル読取り


            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
