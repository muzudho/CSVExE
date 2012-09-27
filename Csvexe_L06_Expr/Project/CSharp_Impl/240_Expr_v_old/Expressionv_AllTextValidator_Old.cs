using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Middle;

namespace Xenon.Expr
{

    /// <summary>
    /// 常に指定の判断結果を出します。
    /// </summary>
    public class Expressionv_AllTextValidator_Old : Expressionv_TextValidator_Old
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Expressionv_AllTextValidator_Old(EnumValidation_Old enumResultValidation)
        {
            this.enumResult = enumResultValidation;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 常に出す判定結果です。
        /// </summary>
        private EnumValidation_Old enumResult;

        public EnumValidation_Old JudgeValidity(string sText)
        {
            return this.enumResult;
        }

        //────────────────────────────────────────
        #endregion



    }

}
