using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Middle
{
    /// <summary>
    /// テキストボックス用バリデーター。
    /// </summary>
    public interface Expressionv_TextValidator_Old : Expressionv_Validator_Old
    {


        
        #region アクション
        //────────────────────────────────────────

        EnumValidation_Old JudgeValidity(string sText);

        //────────────────────────────────────────
        #endregion



    }
}
