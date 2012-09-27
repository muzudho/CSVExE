using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{

    /// <summary>
    /// 
    /// </summary>
    public interface GivechapterandverseToExpression_Event
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nActionCollection"></param>
        /// <param name="log_Reports"></param>
        void Translate(
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// </summary>
        string SName
        {
            get;
            set;
        }

        //────────────────────────────────────────

        Functionlist Owner_Functionlist
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// このアクションの一覧が記述されている、対応するイベント。
        /// </summary>
        Givechapterandverse_Node Givechapterandverse_Event
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        bool BTranslatedGivechapterandverseToExpression
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
