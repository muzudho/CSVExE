using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;//Usercontrol
using Xenon.Table;

namespace Xenon.Functions
{
    public class Expression_Node_Function20Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string NAME_FUNCTION = "Sf:リストボックス_表関連付け;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// テーブル名。
        /// </summary>
        public static readonly string PM_NAME_TABLE = PmNames.S_NAME_TABLE.Name_Pm;

        /// <summary>
        /// リストボックス・コントロールの名前。
        /// このアクションを記述しているコントロールの名前を入れたい場合は、省略（空文字列）にしておけばよい。
        /// </summary>
        public static readonly string PM_NAME_CONTROL_LISTBOX = PmNames.S_NAME_CONTROL_LST.Name_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function20Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configuration_Node cur_Conf,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function20Impl(this.EnumEventhandler,this.List_NameArgumentInitializer,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configuration = cur_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Conf), log_Reports);

            f0.SetAttribute(Expression_Node_Function20Impl.PM_NAME_TABLE, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function20Impl.PM_NAME_CONTROL_LISTBOX, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);

            //
            log_Method.EndMethod(log_Reports);
            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventMonitor"></param>
        /// <param name="log_Reports"></param>
        public override string Execute5_Main(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main", log_Reports);

            string sFncName0;
            this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "「E■[" + sFncName0 + "]アクション」実行(A)";
                log_Method.Log_Stopwatch.Begin();
            }


            if (this.EnumEventhandler == EnumEventhandler.O_Lr)
            {
                string sName_Usercontrol;
                if (this.Functionparameterset.Sender is Customcontrol)
                {
                    Customcontrol ccFc = (Customcontrol)this.Functionparameterset.Sender;

                    sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                    log_Reports.Comment_EventCreationMe += "／追記：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    sName_Usercontrol = "（▲不明101！）";
                    log_Reports.Comment_EventCreationMe += "／追記：[" + sFncName0 + "]アクションを実行。";
                }

                //
                //
                //
                //

                List<Usercontrol> ucFcList;
                if (log_Reports.Successful)
                {
                    // 正常時

                    // テーブルデータをコントロールにセットします。

                    //
                    // 指定のコントロール（無指定の場合、自コントロール）を
                    // まず取得。
                    //
                    Expression_Node_String ec_ArgListboxName;
                    this.TrySelectAttribute(out ec_ArgListboxName, Expression_Node_Function20Impl.PM_NAME_CONTROL_LISTBOX, EnumHitcount.One_Or_Zero, log_Reports);

                    ucFcList = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                        ec_ArgListboxName, true, log_Reports);
                }
                else
                {
                    ucFcList = new List<Usercontrol>();
                }


                // リストボックスにテーブルのデータソースを関連付けます。
                if (log_Reports.Successful)
                {
                    // 正常時

                    // リストボックス コントロール。
                    Usercontrol fcUc = ucFcList[0];


                    Expression_Node_String ec_TableName = null;
                    string sTableName;
                    this.TrySelectAttribute(out sTableName, Expression_Node_Function20Impl.PM_NAME_TABLE, EnumHitcount.One_Or_Zero, log_Reports);

                    if ("" != sTableName)//this.E_SysArgDic.ContainsKey(E_SysFnc20Impl.S_ARG_TABLE_NAME)
                    {
                        //テーブル名を指定（アクション用引数）
                        this.TrySelectAttribute(out ec_TableName, Expression_Node_Function20Impl.PM_NAME_TABLE, EnumHitcount.One_Or_Zero, log_Reports);

                        // #デバッグ
                        if (log_Method.CanWarning())
                        {
                            log_Method.WriteWarning_ToConsole(" ＜ａｒｇ３　ｔａｂｌｅＮａｍｅ＝”[" + ec_TableName.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]”＞属性でした。");
                        }
                    }
                    else
                    {
                        // #デバッグ
                        if (log_Method.CanWarning())
                        {
                            log_Method.WriteWarning_ToConsole(" ＜ａｒｇ３　ｔａｂｌｅＮａｍｅ＝”☆”＞属性が未指定でした。");
                        }






                        Configuration_Node owner_Configurationtree_Control;
                        {
                            owner_Configurationtree_Control = this.Cur_Configuration.GetParentByNodename(
                                NamesNode.S_CONTROL1, EnumConfiguration.Tree, true, log_Reports);
                        }

                        //
                        // 次を期待。
                        // ＜ｄａｔａ　ｔａｒｇｅｔ＝”ｌｉｓｔ－ｂｏｘ”＞
                        // 　　　　＜ａｒｇ５　ｎａｍｅ＝”ｔａｂｌｅＮａｍｅ”　ｖａｌｕｅ＝”☆”＞
                        //
                        List<Configurationtree_Node> cfList_Data = ((Configurationtree_Node)owner_Configurationtree_Control).GetChildrenByNodename(
                            NamesNode.S_DATA, false, log_Reports);
                        foreach (Configurationtree_Node cf_Data in cfList_Data)
                        {
                            string sAccess;
                            cf_Data.Dictionary_Attribute.TryGetValue(PmNames.S_ACCESS, out sAccess, false, log_Reports);

                            List<string> sList_Access = new CsvTo_ListImpl().Read(sAccess);

                            if (sList_Access.Contains(ValuesAttr.S_FROM))
                            {
                                // ＜ｄａｔａ　ａｃｃｅｓｓ＝”ｆｒｏｍ”＞

                                string sDataMemory;
                                cf_Data.Dictionary_Attribute.TryGetValue(PmNames.S_MEMORY, out sDataMemory, true, log_Reports);

                                if (!log_Reports.Successful)
                                {
                                    goto gt_EndMethod;
                                }

                                if (ValuesAttr.S_RECORDS == sDataMemory)
                                {

                                    cf_Data.Dictionary_Attribute.TryGetValue(PmNames.S_NAME_TABLE, out sTableName, true, log_Reports);
                                    if (!log_Reports.Successful)
                                    {
                                        goto gt_EndMethod;
                                    }

                                    ec_TableName = new Expression_Leaf_StringImpl(sTableName, this, cf_Data);

                                    // #デバッグ
                                    if (log_Method.CanWarning())
                                    {
                                        log_Method.WriteWarning_ToConsole(" ＜ｄａｔａ　ｔａｂｌｅＮａｍｅ＝”[" + sTableName + "]”＞属性でした。");
                                    }
                                }
                                else
                                {
                                    //#連続エラー
                                    {
                                        Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                                        tmpl.SetParameter(1, sDataMemory, log_Reports);//属性memoryの値

                                        this.Owner_MemoryApplication.CreateErrorReport("Er:110007;", tmpl, log_Reports);
                                    }
                                }
                            }
                        }






                        if (null == ec_TableName)
                        {
                            // エラー処理？
                            if (log_Method.CanError())
                            {
                                log_Method.WriteError_ToConsole(" 直接指定されなかったので、既に＜ｄａｔａ＞にｔａｂｌｅＮａｍｅ属性があると期待しましたが、ありませんでした。");
                            }

                            sTableName = "";//string sTableName = "";
                            ec_TableName = new Expression_Leaf_StringImpl(sTableName, this, owner_Configurationtree_Control);// owner_Cf_Fc.S_DataSource
                        }
                    }

                    //↓この中で時間かかってる。
                    Utility_Listbox.BindTableToDatasource(
                        fcUc,// リストボックス・コントロール
                        ec_TableName,
                        this.Owner_MemoryApplication,
                        log_Reports
                        );
                    //↑この中で時間かかってる。
                }
            }

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────
        #endregion



    }
}
