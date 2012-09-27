﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{
    /// <summary>
    /// 関数。
    /// 
    /// 引数をセットし、実行することができます。
    /// </summary>
    public interface Expression_Node_Function : Expression_Node_String, Functionexecutable
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクターでは行わなかった初期値の設定を行います。
        /// </summary>
        /// <param name="parent_Expression"></param>
        /// <param name="cur_Gcav"></param>
        /// <param name="moApplication"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression,
            Givechapterandverse_Node cur_Gcav,
            object/*MoApplication*/ moApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        List<string> ListS_ArgName
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// Expression_Stringを関数として使うときの『ユーザー定義引数』のディクショナリー。
        /// </summary>
        DicExpression_Node_String DicExpression_Param
        {
            get;
            set;// 関数の引数を丸ごと渡す時に使う。
        }

        /// <summary>
        /// 呼び出されたイベントハンドラーの種類。
        /// </summary>
        EnumEventhandler EnumEventhandler
        {
            get;
            set;
        }

        ExpressionfncPrmset ExpressionfncPrmset
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
