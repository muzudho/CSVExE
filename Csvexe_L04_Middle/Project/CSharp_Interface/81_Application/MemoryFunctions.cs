using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{
    public delegate void DELEGATE_E_DefFnc_Children(
        string sKey, Expression_Node_Function ec_Child, ref bool bRemove, ref bool bBreak);

    public interface MemoryFunctions
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// コントロール集のディクショナリー。
        /// </summary>
        void ForEach_Children(DELEGATE_E_DefFnc_Children dlgt1);

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// new した直後の内容に戻します。
        /// </summary>
        void Clear(object/*MemoryApplication*/ owner_MemoryApplication);//, Log_Reports log_Reports

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 『ユーザー定義関数設定ファイル(Fnc)』を読み取ります。
        /// </summary>
        void LoadFile(
            Expression_Node_Filepath ec_Fpath_Fnc,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ユーザー定義関数を登録します。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="e_CommonFunction"></param>
        /// <param name="log_Reports"></param>
        void AddFunction(string sName, Expression_Node_Function ec_CommonFunction, Log_Reports log_Reports);

        /// <summary>
        /// ユーザー定義関数を取得。
        /// </summary>
        /// <param name="e_CommonFunction"></param>
        /// <param name="sCall"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        bool TryGetFunction(out Expression_Node_Function ec_CommonFunction, string sCall, Log_Reports log_Reports);

        /// <summary>
        /// デバッグ出力。
        /// </summary>
        void WriteDebug_ToConsole();

        //────────────────────────────────────────
        #endregion



    }
}
