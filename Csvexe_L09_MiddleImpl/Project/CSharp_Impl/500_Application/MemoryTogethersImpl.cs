using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;
using Xenon.XToGcav;

namespace Xenon.MiddleImpl
{
    public class MemoryTogethersImpl : MemoryTogethers
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public MemoryTogethersImpl()
        {
            this.Clear();
        }

        /// <summary>
        /// クリアーします。
        /// </summary>
        public void Clear()
        {
            this.givechapterandverse_Togetherconfig = new Configurationtree_NodeImpl(NamesNode.S_CODEFILE_TOGETHERS, new Configurationtree_NodeImpl(this.GetType().Name + "#<init>", null));
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// Rfr 設定ファイル読取。
        /// </summary>
        /// <param name="n_FilePath_Rfr"></param>
        /// <param name="log_Reports"></param>
        public void LoadFile(
            Expression_Node_Filepath ec_Fpath_Rfr,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "LoadFile",log_Reports);
            //
            //

            // （Ｒ９）絶対ファイルパスの取得
            string sFpatha_rfr;
            if (log_Reports.Successful)
            {
                // 正常時

                sFpatha_rfr = ec_Fpath_Rfr.Execute_OnExpressionString(
                    Request_SelectingImpl.Unconstraint, log_Reports);
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }
            else
            {
                sFpatha_rfr = "";
            }

            // （Ｒ１０）ファイルから内容を読み込んでモデルに挿入
            if (log_Reports.Successful)
            {
                // 正常時

                XToConfigurationtree_Together to = new XToConfigurationtree_Together_ConfigImpl();
                this.Configurationtree_Togetherconfig = to.XToConfigurationtree(sFpatha_rfr, owner_MemoryApplication, log_Reports);
            }

            //
        //
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// フォームのデータの再読み込みを行います。
        /// 
        /// どのフォームを再読み込みするかは、コントロール・リローディング設定ファイルで
        /// 設定しているリローダー要素の名前を指定します。
        /// </summary>
        /// <param select="o_Name_Together"></param>
        public void RefreshDataRange(
            XenonName o_Name_Together,
            MemoryApplication moApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "RefreshDataRange",log_Reports);

            //
            //
            //
            //

            List<Configurationtree_Node> listCf_Together = this.Configurationtree_Togetherconfig.GetChildrenByNodename(NamesNode.S_TOGETHER, false, log_Reports);
            foreach (Configurationtree_Node cf_Together in listCf_Together)
            {
                string sFncName;
                cf_Together.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sFncName, false, log_Reports);

                // 一致するのは１件しかない前提。
                if (sFncName == o_Name_Together.SValue)
                {
                    if (log_Reports.Successful)
                    {
                        // 最新表示にするコントロールの名前のリスト。
                        List<Configurationtree_Node> cfList_RfrTarget = cf_Together.GetChildrenByNodename(NamesNode.S_TARGET, false, log_Reports);


                        foreach (Configurationtree_Node cf_RfrTarget in cfList_RfrTarget)
                        {
                            List<Usercontrol> list_FcUc;
                            {
                                string sName;
                                cf_RfrTarget.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName, true, log_Reports);

                                Expression_Node_StringImpl e_str = new Expression_Node_StringImpl(null, cf_RfrTarget);
                                e_str.AppendTextNode(
                                    sName,
                                    cf_RfrTarget,
                                    log_Reports
                                    );

                                list_FcUc = moApplication.MemoryForms.GetUsercontrolsByName(
                                    e_str,
                                    true,
                                    log_Reports
                                    );
                            }

                            if (log_Reports.Successful)
                            {
                                Usercontrol fcUc = list_FcUc[0];

                                fcUc.RefreshData(
                                    log_Reports
                                    );
                            }

                        }
                    }

                }

            }

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロールに、最新のデータを表示します。
        /// </summary>
        /// <param select="cf_Together">トゥゲザー要素の名前です。</param>
        /// <param select="log_Reports"></param>
        public void RefreshDataByTogether(
            Configurationtree_Node cf_Together,
            MemoryApplication moApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "RefreshDataByTogether(1)",log_Reports);
            //
            //

            moApplication.MemoryForms.RefreshDataByTogether(
                cf_Together,
                this.Configurationtree_Togetherconfig,
                moApplication,
                log_Reports
                );

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Configurationtree_Node givechapterandverse_Togetherconfig;

        /// <summary>
        /// 「リローディング設定ファイル」。
        /// </summary>
        public Configurationtree_Node Configurationtree_Togetherconfig
        {
            set
            {
                givechapterandverse_Togetherconfig = value;
            }
            get
            {
                return givechapterandverse_Togetherconfig;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
