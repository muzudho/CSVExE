using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Middle;

namespace Xenon.Expr
{


    /// <summary>
    /// 指定の値と一致すれば 可とする判定を出します。
    /// </summary>
    public class Expressionv_MatchTextValidator_Old : Expressionv_TextValidator_Old
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Expressionv_MatchTextValidator_Old(string sExpecetedText)
        {
            this.sExpeceted = sExpecetedText;
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// 期待値。トリムはされる。
        /// </summary>
        protected string sExpeceted;

        public EnumValidation_Old JudgeValidity(string sText)
        {
            if (this.sExpeceted == sText.Trim())
            {
                return EnumValidation_Old.Ok;
            }

            return EnumValidation_Old.Thru;
        }

        //────────────────────────────────────────
        #endregion



    }


}
