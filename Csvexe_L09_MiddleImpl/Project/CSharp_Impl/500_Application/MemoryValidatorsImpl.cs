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

        public MemoryValidatorsImpl()
        {
            this.Clear();
        }

        //────────────────────────────────────────

        /// <summary>
        /// クリアーします。
        /// </summary>
        public void Clear()
        {
            this.xToGivechapterandverse_V = new XToGivechapterandverse_Validator_ConfigImpl();
            this.givechapterandverseToExpression_V = new GivechapterandverseToExpression_V51_ConfigImpl();

            this.givechapterandverse_Validatorsconfig = new Givechapterandverse_NodeImpl(NamesNode.S_CODEFILE_VALIDATORS, new Givechapterandverse_NodeImpl(this.GetType().Name + "#<init>", null));
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
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "LoadFile",log_Reports);
            //
            //

            this.xToGivechapterandverse_V.XToGivechapterandverse(
                sFpatha,
                owner_MemoryApplication,
                log_Reports
                );

            Log_TextIndented_GivechapterandverseToExpressionImpl pg_ParsingLog = new Log_TextIndented_GivechapterandverseToExpressionImpl();
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

        /// <summary>
        /// validation設定ファイルの X → S。
        /// </summary>
        private XToGivechapterandverse_V51_Config xToGivechapterandverse_V;

        /// <summary>
        /// validation設定ファイルの S → E。
        /// </summary>
        private GivechapterandverseToExpression_V51_Config givechapterandverseToExpression_V;

        //────────────────────────────────────────

        private Givechapterandverse_Node givechapterandverse_Validatorsconfig;

        /// <summary>
        /// 「バリデーション設定ファイル」。
        /// </summary>
        public Givechapterandverse_Node Givechapterandverse_Validatorsconfig
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
