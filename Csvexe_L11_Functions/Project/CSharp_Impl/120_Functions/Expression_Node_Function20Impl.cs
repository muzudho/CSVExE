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

        public static readonly string S_ACTION_NAME = "Sf:リストボックス_表関連付け;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// テーブル名。
        /// </summary>
        public static readonly string S_PM_NAME_TABLE = PmNames.S_NAME_TABLE.SName_Pm;

        /// <summary>
        /// リストボックス・コントロールの名前。
        /// このアクションを記述しているコントロールの名前を入れたい場合は、省略（空文字列）にしておけばよい。
        /// </summary>
        public static readonly string S_PM_NAME_FC_LST = PmNames.S_NAME_CONTROL_LST.SName_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function20Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "NewInstance",pg_Logging);
            //

            Expression_Node_Function f0 = new Expression_Node_Function20Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function20Impl.S_PM_NAME_TABLE, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);
            f0.DicExpression_Attr.Set(Expression_Node_Function20Impl.S_PM_NAME_FC_LST, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);

            //
            pg_Method.EndMethod(pg_Logging);
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
        /// <param name="pg_Logging"></param>
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain", pg_Logging);

            string sFncName0;
            this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.SMessage = "「E■[" + sFncName0 + "]アクション」実行(A)";
                pg_Method.Log_Stopwatch.Begin();
            }


            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                string sName_Usercontrol;
                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol ccFc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                    pg_Logging.SComment_EventCreationMe += "／追記：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    sName_Usercontrol = "（▲不明101！）";
                    pg_Logging.SComment_EventCreationMe += "／追記：[" + sFncName0 + "]アクションを実行。";
                }

                //
                //
                //
                //
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";




                List<Usercontrol> ucFcList;
                if (pg_Logging.BSuccessful)
                {
                    // 正常時

                    // テーブルデータをコントロールにセットします。

                    //
                    // 指定のコントロール（無指定の場合、自コントロール）を
                    // まず取得。
                    //
                    Expression_Node_String ec_ArgListboxName;
                    this.TrySelectAttr(out ec_ArgListboxName, Expression_Node_Function20Impl.S_PM_NAME_FC_LST, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                    ucFcList = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                        ec_ArgListboxName, true, pg_Logging);
                }
                else
                {
                    ucFcList = new List<Usercontrol>();
                }


                // リストボックスにテーブルのデータソースを関連付けます。
                if (pg_Logging.BSuccessful)
                {
                    // 正常時

                    // リストボックス コントロール。
                    Usercontrol fcUc = ucFcList[0];


                    Expression_Node_String ec_TableName = null;
                    string sTableName;
                    this.TrySelectAttr(out sTableName, Expression_Node_Function20Impl.S_PM_NAME_TABLE, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                    if ("" != sTableName)//this.E_SysArgDic.ContainsKey(E_SysFnc20Impl.S_ARG_TABLE_NAME)
                    {
                        //テーブル名を指定（アクション用引数）
                        this.TrySelectAttr(out ec_TableName, Expression_Node_Function20Impl.S_PM_NAME_TABLE, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                        // #デバッグ
                        if (pg_Method.CanWarning())
                        {
                            pg_Method.WriteWarning_ToConsole(" ＜ａｒｇ３　ｔａｂｌｅＮａｍｅ＝”[" + ec_TableName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging) + "]”＞属性でした。");
                        }
                    }
                    else
                    {
                        // #デバッグ
                        if (pg_Method.CanWarning())
                        {
                            pg_Method.WriteWarning_ToConsole(" ＜ａｒｇ３　ｔａｂｌｅＮａｍｅ＝”☆”＞属性が未指定でした。");
                        }






                        Givechapterandverse_Node owner_Givechapterandverse_Control;
                        {
                            owner_Givechapterandverse_Control = this.Cur_Givechapterandverse.GetParentByNodename(NamesNode.S_CONTROL1, true, pg_Logging);
                        }

                        //
                        // 次を期待。
                        // ＜ｄａｔａ　ｔａｒｇｅｔ＝”ｌｉｓｔ－ｂｏｘ”＞
                        // 　　　　＜ａｒｇ５　ｎａｍｅ＝”ｔａｂｌｅＮａｍｅ”　ｖａｌｕｅ＝”☆”＞
                        //
                        List<Givechapterandverse_Node> cfList_Data = owner_Givechapterandverse_Control.GetChildrenByNodename(NamesNode.S_DATA, false, pg_Logging);
                        foreach (Givechapterandverse_Node cf_Data in cfList_Data)
                        {
                            string sAccess;
                            cf_Data.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_ACCESS, out sAccess, false, pg_Logging);

                            List<string> sList_Access = new CsvTo_ListImpl().Read(sAccess);

                            if (sList_Access.Contains(ValuesAttr.S_FROM))
                            {
                                // ＜ｄａｔａ　ａｃｃｅｓｓ＝”ｆｒｏｍ”＞

                                string sDataMemory;
                                cf_Data.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_MEMORY, out sDataMemory, true, pg_Logging);

                                if (!pg_Logging.BSuccessful)
                                {
                                    goto gt_EndMethod;
                                }

                                if (ValuesAttr.S_RECORDS == sDataMemory)
                                {

                                    cf_Data.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME_TABLE, out sTableName, true, pg_Logging);
                                    if (!pg_Logging.BSuccessful)
                                    {
                                        goto gt_EndMethod;
                                    }

                                    ec_TableName = new Expression_Leaf_StringImpl(sTableName, this, cf_Data);

                                    // #デバッグ
                                    if (pg_Method.CanWarning())
                                    {
                                        pg_Method.WriteWarning_ToConsole(" ＜ｄａｔａ　ｔａｂｌｅＮａｍｅ＝”[" + sTableName + "]”＞属性でした。");
                                    }
                                }
                                else
                                {
                                    //#連続エラー
                                    if (pg_Logging.CanCreateReport)
                                    {
                                        Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                                        r.SetTitle("▲エラー902！", pg_Method);

                                        StringBuilder s = new StringBuilder();
                                        s.Append("＜ｄａｔａ　ｍｅｍｏｒｙ＝”[");
                                        s.Append(sDataMemory);
                                        s.Append("]”＞属性でした。");
                                        r.SMessage = s.ToString();
                                        pg_Logging.EndCreateReport();
                                    }
                                }
                            }
                        }






                        if (null == ec_TableName)
                        {
                            // エラー処理？
                            if (pg_Method.CanError())
                            {
                                pg_Method.WriteError_ToConsole(" 直接指定されなかったので、既に＜ｄａｔａ＞にｔａｂｌｅＮａｍｅ属性があると期待しましたが、ありませんでした。");
                            }

                            sTableName = "";//string sTableName = "";
                            ec_TableName = new Expression_Leaf_StringImpl(sTableName, this, owner_Givechapterandverse_Control);// owner_Cf_Fc.S_DataSource
                        }
                    }

                    //↓この中で時間かかってる。
                    Utility_Listbox.BindTableToDatasource(
                        fcUc,// リストボックス・コントロール
                        ec_TableName,
                        this.Owner_MemoryApplication,
                        pg_Logging
                        );
                    //↑この中で時間かかってる。
                }

                //
                //
                //
                // 必ずフラグをオフにします。
                //
                //
                //
                ((EventMonitor)this.ExpressionfncPrmset.EventMonitor).BNowactionworking = false;
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



    }
}
