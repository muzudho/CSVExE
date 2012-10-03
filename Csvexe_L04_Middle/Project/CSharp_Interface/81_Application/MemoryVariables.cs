using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Table;

namespace Xenon.Middle
{

    public delegate void DELEGATE_EachVariable(string sKey, Expression_Node_String ec_String, ref bool bBreak);

    /// <summary>
    /// 変数モデル。
    /// 
    /// (Model Of Variables)
    /// </summary>
    public interface MemoryVariables
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// ファイルパス一覧。
        /// </summary>
        /// <param name="dlgt_EachEFilePath"></param>
        void EachVariable(DELEGATE_EachVariable dlgt_EachVariable);

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// new した直後の内容に戻します。
        /// </summary>
        void Clear(MemoryApplication owner_MemoryApplication);

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        void TryGetTable_Variables(
            out XenonTable out_O_Table_Variables,
            String sFpath_Startup,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 変数設定ファイルを読込みます。
        /// </summary>
        void LoadVariables(
            String sStartupPath,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 「変数設定ファイル」のテーブルを読み取り、変数を登録します。
        /// </summary>
        /// <param name="o_Table_Variable"></param>
        /// <param name="log_Reports"></param>
        void Load(
            XenonTable o_Table_Variable,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 変数を設定します。
        /// </summary>
        void SetVariable(
            XenonName oVariableName,
            Expression_Node_String ec_Value,
            bool bRequired,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 文字列型の変数を登録します。
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="initialString"></param>
        /// <param name="log_Reports"></param>
        void PutString(string sName_Variable, string sInitial, Log_Reports log_Reports);

        /// <summary>
        /// ファイルパス型変数を登録します。
        /// </summary>
        /// <param name="sVariableName"></param>
        /// <param name="e_InitialValue"></param>
        /// <param name="bDuplicatedIsError">既に追加されているものを、更に追加しようとしたときにエラーにするなら真。</param>
        /// <param name="log_Reports"></param>
        void PutFilepath(
            string sName_Variable,
            Expression_Node_Filepath ec_InitialValue,
            bool bDuplicatedIsError,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 文字列型の変数の値をセットします。
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="sValue"></param>
        /// <param name="bRequired"></param>
        void SetStringValue(
            XenonName variableName,
            string sValue,
            bool bRequired,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ファイル・パス型変数の値をセットします。
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="n_filePath"></param>
        /// <param name="bRequired"></param>
        void SetFilepathValue(
            string sName_Variable,
            Expression_Node_Filepath ec_Fpath, bool bRequired, Log_Reports log_Reports);

        /// <summary>
        /// 変数名を指定することで、文字列型変数の値を返します。
        /// </summary>
        /// <param name="nVariableName"></param>
        /// <param name="bRequired"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        string GetStringByVariablename(
            Expression_Node_String ecName_Variable,
            bool bRequired,
            Log_Reports log_Reports
        );

        /// <summary>
        /// 変数名を指定することで、ファイルパスを返します。
        /// </summary>
        /// <param name="nVariableName"></param>
        /// <param name="bRequired"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        Expression_Node_Filepath GetExpressionfilepathByVariablename(
            Expression_Node_String ec_Name_Variable,
            bool bRequired,
            Log_Reports log_Reports
            );

        /// <summary>
        /// デバッグ出力。
        /// </summary>
        void WriteDebug_ToConsole();

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 変数の一覧。
        /// </summary>
        Dictionary<string, Expression_Node_String> DictionaryExpression_Item
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
