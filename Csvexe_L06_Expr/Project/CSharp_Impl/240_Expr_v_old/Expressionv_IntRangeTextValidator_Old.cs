using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Middle;

namespace Xenon.Expr
{


    /// <summary>
    /// 指定の範囲の数値であれば 可とする判定を出します。
    /// ヌルの場合は　無判定で続行されます。
    /// </summary>
    public class Expressionv_IntRangeTextValidator_Old : Expressionv_TextValidator_Old
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Expressionv_IntRangeTextValidator_Old(int nBegin, int nEnd)
        {
            this.nBegin = nBegin;
            this.nEnd = nEnd;
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        public EnumValidation_Old JudgeValidity(string sText)
        {
            int nValueInt;

            sText = sText.Trim();
            if ("" == sText)
            {
                return EnumValidation_Old.Thru;
            }

            if (!int.TryParse(sText, out nValueInt))
            {
                // エラー
                return EnumValidation_Old.Ng;
            }

            if (nBegin <= nValueInt && nValueInt <= nEnd)
            {
                return EnumValidation_Old.Ok;
            }

            return EnumValidation_Old.Ng;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// これを含む開始値。
        /// </summary>
        private int nBegin;

        /// <summary>
        /// これを含む終了値。
        /// </summary>
        private int nEnd;

        //────────────────────────────────────────
        #endregion



    }


}
