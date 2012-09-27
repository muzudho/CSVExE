using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Middle;

namespace Xenon.Expr
{


    /// <summary>
    /// 空欄を不可とする判定を出します。
    /// </summary>
    public class Expressionv_SpacesTextValidator_Old : Expressionv_TextValidator_Old
    {


        
        #region 生成と破棄
        //────────────────────────────────────────

        public Expressionv_SpacesTextValidator_Old(EnumValidation_Old enumResultValidation)
        {
            this.enumResult = enumResultValidation;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 空白だった場合の結果です。
        /// </summary>
        private EnumValidation_Old enumResult;

        public EnumValidation_Old JudgeValidity(string sText)
        {
            if ("" == sText.Trim())
            {
                return this.enumResult;
            }

            return EnumValidation_Old.Thru;
        }

        //────────────────────────────────────────
        #endregion



    }


}
