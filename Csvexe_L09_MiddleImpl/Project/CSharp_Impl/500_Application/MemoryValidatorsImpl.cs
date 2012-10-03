using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;
using Xenon.XToGcav;
using Xenon.GcavToExpr;

namespace Xenon.MiddleImpl
{
    public class MemoryValidatorsImpl : MemoryValidators
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public MemoryValidatorsImpl(MemoryApplication owner_MemoryApplication)
        {
            this.Clear(owner_MemoryApplication);
        }

        //────────────────────────────────────────

        /// <summary>
        /// クリアーします。
        /// </summary>
        public void Clear(MemoryApplication owner_MemoryApplication)
        {
            this.owner_MemoryApplication = owner_MemoryApplication;
            this.xToConfigurationtree_V = new XToConfigurationtree_Validator_ConfigImpl();
            this.givechapterandverseToExpression_V = new ConfigurationtreeToExpression_V51_ConfigImpl();

            this.givechapterandverse_Validatorsconfig = new Configurationtree_NodeImpl(NamesNode.S_CODEFILE_VALIDATORS, new Configurationtree_NodeImpl(this.GetType().Name + "#<init>", null));
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 妥当性判定のグローバル設定ファイルの読取り。
        /// </summary>
        /// <param name="sFpatha">絶対ファイルパス</param>
        /// <param name="log_Reports"></param>
        public void LoadFile(
            string sFpatha,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "LoadFile",log_Reports);
            //
            //

            this.xToConfigurationtree_V.XToConfigurationtree(
                sFpatha,
                owner_MemoryApplication,
                log_Reports
                );

            Log_TextIndented_ConfigurationtreeToExpressionImpl pg_ParsingLog = new Log_TextIndented_ConfigurationtreeToExpressionImpl();
            pg_ParsingLog.BEnabled = false;
            this.givechapterandverseToExpression_V.Translate(
                owner_MemoryApplication,
                pg_ParsingLog,
                log_Reports
                );
            if (log_Method.CanInfo() && pg_ParsingLog.BEnabled)
            {
                log_Method.WriteInfo_ToConsole(" d_ParsingLog=" + Environment.NewLine + pg_ParsingLog.ToString());
            }

            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryApplication owner_MemoryApplication;

        /// <summary>
        /// このオブジェクトを所有するオブジェクト。
        /// </summary>
        public MemoryApplication Owner_MemoryApplication
        {
            get
            {
                return owner_MemoryApplication;
            }
            set
            {
                owner_MemoryApplication = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// validation設定ファイルの X → S。
        /// </summary>
        private XToConfigurationtree_V51_Config xToConfigurationtree_V;

        /// <summary>
        /// validation設定ファイルの S → E。
        /// </summary>
        private ConfigurationtreeToExpression_V51_Config givechapterandverseToExpression_V;

        //────────────────────────────────────────

        private Configurationtree_Node givechapterandverse_Validatorsconfig;

        /// <summary>
        /// 「バリデーション設定ファイル」。
        /// </summary>
        public Configurationtree_Node Configurationtree_Validatorsconfig
        {
            set
            {
                givechapterandverse_Validatorsconfig = value;
            }
            get
            {
                return givechapterandverse_Validatorsconfig;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
