using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;

namespace Xenon.MiddleImpl
{
    /// <summary>
    /// コントロールから、データソース、データターゲットを一時的に取り外し、
    /// また、元に再セットするロジックです。
    /// </summary>
    public class AccessorEjector
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nFcNameArray">コントロール名の一覧。</param>
        public AccessorEjector(Expression_Node_String[] ecArray_FcName)
        {
            this.array_Expression_NameUsercontrol = ecArray_FcName;

            this.array_BEnabled_Old = new bool[ecArray_FcName.Length];
            this.array_BAutomaticinputting_Old = new bool[ecArray_FcName.Length];
            this.listArray_Expression_DatasourceQuery_Old = new List<Expression_Node_String>[ecArray_FcName.Length];//NString
            this.listArray_Expression_DatatargetQuery_Old = new List<Expression_Node_String>[ecArray_FcName.Length];//NString
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param select="moOpyopyo"></param>
        /// <param select="log_Reports"></param>
        public void Eject(
            MemoryApplication moApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "Eject",log_Reports);
            //
            //

            // コンピューターの自動入力モード・フラグを立てます。
            // コントロールを不活性化させます。
            int nIndex = 0;
            foreach (Expression_Node_String ec_FcName in this.array_Expression_NameUsercontrol)
            {
                List<Usercontrol> list_FcUc = moApplication.MemoryForms.GetUsercontrolsByName(
                    ec_FcName,
                    true,
                    log_Reports
                    );

                if (0 < list_FcUc.Count)
                {
                    Usercontrol fcUc = list_FcUc[0];
                    this.array_BEnabled_Old[nIndex] = fcUc.UsercontrolEnabled;
                    fcUc.UsercontrolEnabled = false;

                    this.array_BAutomaticinputting_Old[nIndex] = fcUc.ControlCommon.BAutomaticinputting;
                    fcUc.ControlCommon.BAutomaticinputting = true;
                }

                nIndex++;
            }

            nIndex = 0;
            foreach (Expression_Node_String ec_FcName in array_Expression_NameUsercontrol)
            {
                List<Usercontrol> list_FcUc = moApplication.MemoryForms.GetUsercontrolsByName(
                    ec_FcName,
                    true,
                    log_Reports
                    );

                if (0 < list_FcUc.Count)
                {
                    Usercontrol fcUc = list_FcUc[0];

                    //
                    //
                    //
                    // 注　データソースの子要素　Ｓｆ：ｃｅｌｌ；　等を退避。
                    //
                    //
                    //

                    // 最初のデータソースを抜き取る。
                    Expression_Node_String ec_DataSource;
                    {
                        List<Expression_Node_String> ecList_Data = fcUc.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_DATA, false, EnumHitcount.Unconstraint, log_Reports);
                        // 抜き取りフラグ。
                        List<Expression_Node_String> ecList_DataSource = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(ecList_Data, PmNames.S_ACCESS.Name_Pm, ValuesAttr.S_FROM, true, EnumHitcount.First_Exist, log_Reports);
                        if (!log_Reports.Successful)
                        {
                            goto gt_EndMethod;
                        }
                        ec_DataSource = ecList_DataSource[0];
                    }

                    {
                        List<Expression_Node_String> ecList = new List<Expression_Node_String>();
                        ec_DataSource.List_Expression_Child.ForEach(delegate(Expression_Node_String e_Node, ref bool bRemove, ref bool bBreak)
                        {
                            ecList.Add(e_Node);
                        });
                        this.listArray_Expression_DatasourceQuery_Old[nIndex] = ecList;
                    }


                    //
                    //
                    //
                    // データソースが設定されていない状態で RefreshData をします。フォームのクリアーになります。
                    //
                    //
                    //
                    fcUc.RefreshData(log_Reports);


                    //
                    //
                    //
                    // 注　データターゲットの子要素　Ｓｆ：ｃｅｌｌ；　等を退避。
                    //
                    //
                    //

                    // 最初のデータターゲットを抜き取る。
                    Expression_Node_String ec_DataTarget;
                    {
                        List<Expression_Node_String> ecList_Data = fcUc.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_DATA, false, EnumHitcount.Unconstraint, log_Reports);
                        // 抜き取りフラグ。
                        List<Expression_Node_String> ecList_DataTarget = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(ecList_Data, PmNames.S_ACCESS.Name_Pm, ValuesAttr.S_TO, true, EnumHitcount.First_Exist, log_Reports);
                        if (!log_Reports.Successful)
                        {
                            goto gt_EndMethod;
                        }
                        ec_DataTarget = ecList_DataTarget[0];
                    }

                    {
                        List<Expression_Node_String> ecList = new List<Expression_Node_String>();
                        ec_DataTarget.List_Expression_Child.ForEach(delegate(Expression_Node_String e_Node, ref bool bRemove, ref bool bBreak)
                        {
                            ecList.Add(e_Node);
                        });
                        this.listArray_Expression_DatatargetQuery_Old[nIndex] = ecList;
                    }

                    //ystem.Console.WriteLine(Info_OpyopyoImpl.LibraryName + ":" + this.GetType().Name + "#Eject: データターゲット数＝[" + fcUc.ControlCommon.Expression_Control.List_E_DataT.Count + "]");
                }

            }

            // コンピューターの自動入力モード・フラグを元に戻します。
            // コントロールの活性は、不活性のままにします。
            nIndex = 0;
            foreach (Expression_Node_String ec_FcName in array_Expression_NameUsercontrol)
            {
                List<Usercontrol> list_FcUc = moApplication.MemoryForms.GetUsercontrolsByName(
                    ec_FcName,
                    true,
                    log_Reports
                    );

                if (0 < list_FcUc.Count)
                {
                    Usercontrol fcUc = list_FcUc[0];

                    //fcUc.FoEnabled = this.oldEnabledArray[index];

                    fcUc.ControlCommon.BAutomaticinputting = this.array_BAutomaticinputting_Old[nIndex];
                }

                nIndex++;
            }

            goto gt_EndMethod;
        //
        //
        //
        //

        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 元に戻します。
        /// </summary>
        public void Reset(
            MemoryApplication moApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "Reset",log_Reports);
            //
            //

            // コンピューターの自動入力モード・フラグを立てます。
            // コントロールの活性は変えません。
            int nIndex = 0;
            foreach (Expression_Node_String ec_FcName in this.array_Expression_NameUsercontrol)
            {
                List<Usercontrol> list_FcUc = moApplication.MemoryForms.GetUsercontrolsByName(
                    ec_FcName,
                    true,
                    log_Reports
                    );

                if (0 < list_FcUc.Count)
                {
                    Usercontrol fcUc = list_FcUc[0];

                    this.array_BAutomaticinputting_Old[nIndex] = fcUc.ControlCommon.BAutomaticinputting;
                    fcUc.ControlCommon.BAutomaticinputting = true;
                }

                nIndex++;
            }

            nIndex = 0;
            foreach (Expression_Node_String ec_FcName in array_Expression_NameUsercontrol)
            {
                List<Usercontrol> list_FcUc = moApplication.MemoryForms.GetUsercontrolsByName(
                    ec_FcName,
                    true,
                    log_Reports
                    );

                if (0 < list_FcUc.Count)
                {
                    Usercontrol fcUc = list_FcUc[0];


                    Expression_Node_String ec_DataSource;
                    {
                        List<Expression_Node_String> ecList_Data = fcUc.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_DATA, false, EnumHitcount.Unconstraint, log_Reports);
                        List<Expression_Node_String> ecList_DataSource = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(ecList_Data, PmNames.S_ACCESS.Name_Pm, ValuesAttr.S_FROM, false, EnumHitcount.First_Exist, log_Reports);
                        if (!log_Reports.Successful)
                        {
                            goto gt_EndMethod;
                        }
                        ec_DataSource = ecList_DataSource[0];
                    }

                    // データソースの子要素　Ｓｆ：ｃｅｌｌ；等を、復元します。
                    ec_DataSource.List_Expression_Child.SetList(
                        this.listArray_Expression_DatasourceQuery_Old[nIndex],
                        log_Reports
                    );


                    //
                    //
                    //
                    // データソースが設定されていない状態で RefreshData をするとフォームのクリアーになります。
                    //
                    //
                    //
                    fcUc.RefreshData(log_Reports);


                    Expression_Node_String ec_DataTarget;
                    {
                        List<Expression_Node_String> ecList_Data = fcUc.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_DATA, false, EnumHitcount.Unconstraint, log_Reports);
                        List<Expression_Node_String> ecList_DataTarget = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(ecList_Data, PmNames.S_ACCESS.Name_Pm, ValuesAttr.S_TO, false, EnumHitcount.First_Exist, log_Reports);
                        if (!log_Reports.Successful)
                        {
                            goto gt_EndMethod;
                        }
                        ec_DataTarget = ecList_DataTarget[0];
                    }
                    // データターゲットの子要素　Ｓｆ：ｃｅｌｌ；等を、復元します。
                    ec_DataTarget.List_Expression_Child.SetList(
                        this.listArray_Expression_DatatargetQuery_Old[nIndex],
                        log_Reports
                    );
                    //ystem.Console.WriteLine(Info_OpyopyoImpl.LibraryName + ":" + this.GetType().Name + "#Reset: データターゲット数＝[" + fcUc.ControlCommon.Expression_Control.List_E_DataT.Count + "]");
                }

            }

            // コンピューターの自動入力モード・フラグを元に戻します。
            // コントロールの活性を元に戻します。
            nIndex = 0;
            foreach (Expression_Node_String ec_FcName in array_Expression_NameUsercontrol)
            {
                List<Usercontrol> list_FcUc = moApplication.MemoryForms.GetUsercontrolsByName(
                    ec_FcName,
                    true,
                    log_Reports
                    );

                if (0 < list_FcUc.Count)
                {
                    Usercontrol fcUc = list_FcUc[0];

                    fcUc.UsercontrolEnabled = this.array_BEnabled_Old[nIndex];

                    fcUc.ControlCommon.BAutomaticinputting = this.array_BAutomaticinputting_Old[nIndex];
                }

                nIndex++;
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// データソース、データターゲットを元に戻さずに、Enabled属性だけを元に戻します。
        /// </summary>
        public void ResetEnabled(
            MemoryApplication moApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "ResetEnabled",log_Reports);
            //
            //

            // コンピューターの自動入力モード・フラグを元に戻します。
            // コントロールの活性を元に戻します。
            int nIndex = 0;
            foreach (Expression_Node_String ec_FcName in array_Expression_NameUsercontrol)
            {
                List<Usercontrol> list_FcUc = moApplication.MemoryForms.GetUsercontrolsByName(
                    ec_FcName,
                    true,
                    log_Reports
                    );

                if (0 < list_FcUc.Count)
                {
                    Usercontrol fcUc = list_FcUc[0];

                    fcUc.ControlCommon.BAutomaticinputting = true;

                    fcUc.UsercontrolEnabled = this.array_BEnabled_Old[nIndex];

                    fcUc.ControlCommon.BAutomaticinputting = this.array_BAutomaticinputting_Old[nIndex];
                }

                nIndex++;
            }

            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// コントロール名の一覧。
        /// </summary>
        private Expression_Node_String[] array_Expression_NameUsercontrol;

        /// <summary>
        /// コントロールの、変更する前のEnabled属性の一覧。
        /// </summary>
        private bool[] array_BEnabled_Old;

        /// <summary>
        /// コントロールの、変更する前のAutomaticInputting属性の一覧。
        /// </summary>
        private bool[] array_BAutomaticinputting_Old;

        /// <summary>
        /// コントロールの、外す前のデータソースのquery要素一覧。
        /// </summary>
        private List<Expression_Node_String>[] listArray_Expression_DatasourceQuery_Old;

        /// <summary>
        /// コントロールの、外す前のデータターゲットのquery要素一覧。
        /// </summary>
        private List<Expression_Node_String>[] listArray_Expression_DatatargetQuery_Old;

        //────────────────────────────────────────
        #endregion



    }
}
