using System;
using System.Data;//DataTable,DataRow
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//ManualFilePath,WarningReports


namespace Xenon.Table
{



    /// <summary>
    /// テーブルです。
    /// 他のテーブル・クラスと名称の被りを防ぐために前置詞が付いています。
    /// </summary>
    public interface XenonTable : Configurationtree_Node
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 設定された型リストで、テーブルの構造を作成します。
        /// </summary>
        /// <param name="list_XenonFielddefinition"></param>
        /// <param name="log_Reports"></param>
        void CreateTable(List<XenonFielddefinition> list_XenonFielddefinition, Log_Reports log_Reports);

        /// <summary>
        /// レコードを追加します。
        /// </summary>
        /// <param name="record"></param>
        void AddRecord(DataRow record);

        /// <summary>
        /// 空レコードを作成します。
        /// </summary>
        /// <param name="sErrorMsg"></param>
        /// <returns></returns>
        DataRow CreateNewRecord(
            out string sErrorMsg
            );

        /// <summary>
        /// 行データを渡すことで、テーブル内容を追加します。
        /// テーブルの型定義と、データを渡します。
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="list_XenonFielddefinition"></param>
        /// <param name="log_Reports"></param>
        void AddRecordList(
            List<List<string>> rows, List<XenonFielddefinition> list_XenonFielddefinition, Log_Reports log_Reports);

        /// <summary>
        /// NOフィールドを 0からの連番に振りなおします。
        /// 
        /// NOフィールド値は、プログラム中で主キーとして使うことがあるので、
        /// 変更するのであれば、ファイルを読み込んだ直後にするものとします。
        /// </summary>
        void RenumberingNoField();

        /// <summary>
        /// 行の削除。
        /// </summary>
        /// <param name="dataRow"></param>
        void Remove(DataRow dataRow);

        /// <summary>
        /// 指定したレコードの並び順を１つ上に上げます。
        /// </summary>
        /// <param name="nRowIndex"></param>
        void MoveRecordToUpByIndex(int nRowIndex);

        /// <summary>
        /// 指定したレコードの並び順を１つ下に下げます。
        /// </summary>
        /// <param name="nRowIndex"></param>
        void MoveRecordToDownByIndex(int nRowIndex);

        /// <summary>
        /// 指定項目A（1～複数件）を、指定項目Bの下に移動させます。
        /// </summary>
        /// <param name="nSourceIndices">移動待ち要素のリスト。インデックスの昇順に並んでいる必要があります。</param>
        /// <param name="nDestinationIndex"></param>
        void MoveItemsBefore(int[] nSourceIndices, int nDestinationIndex);

        /// <summary>
        /// フィールドの定義を取得します。
        /// 
        /// フィールド名の英字大文字、小文字は無視します。
        /// </summary>
        /// <param name="list_XenonFielddefinition"></param>
        /// <param name="sList_ExpectedFieldName"></param>
        /// <param name="bRequired">該当なしの時に例外を投げるなら真。</param>
        /// <param name="log_Reports"></param>
        /// <returns>該当無しがあれば偽。</returns>
        bool TryGetFieldDefinitionByName(
            out List<XenonFielddefinition> list_XenonFielddefinition,
            List<string> sList_ExpectedFieldName,
            bool bRequired,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 指定のstring型フィールドの値で指定したレコードを返します。なければヌルです。
        /// </summary>
        /// <param name="sFieldName"></param>
        /// <param name="sExpectedStringParam"></param>
        /// <param name="hits"></param>
        /// <param name="log_Reports"></param>
        /// <returns>一致しなければヌル。</returns>
        List<DataRow> SelectByString(
            string sFieldName,
            XenonValue_StringImpl sExpectedStringParam,
            EnumHitcount hits,
            Log_Reports log_Reports
            );

        /// <summary>
        /// NOフィールドの値で指定したレコードを返します。なければヌルです。
        /// </summary>
        /// <param name="exceptedNo"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        DataRow SelectByNo(
            XenonValue_IntImpl exceptedNo,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 指定のInt型フィールドの値で指定したレコードを返します。なければヌルです。
        /// </summary>
        /// <param name="sName_Field"></param>
        /// <param name="expectedInt"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        DataRow SelectByInt(
            string sName_Field,
            XenonValue_IntImpl expectedInt,
            Log_Reports log_Reports
            );

        /// <summary>
        /// フィールドの型のデバッグ情報です。
        /// </summary>
        /// <returns></returns>
        string DebugFields();

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// 【2012-08-25 追加】
        /// </summary>
        /// <param name="sName_Field"></param>
        /// <param name="bRequired"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        bool ContainsField(string sName_Field, bool bRequired, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion

        

        #region プロパティー
        //────────────────────────────────────────

        Expression_Node_Filepath Expression_Filepath_ConfigStack
        {
            get;
        }

        List<XenonFielddefinition> List_Fielddefinition
        {
            get;
        }

        DataTable DataTable
        {
            get;
            set;
        }

        /// <summary>
        /// テーブルの名前。
        /// </summary>
        string Name_Table
        {
            get;
            set;
        }

        /// <summary>
        /// このテーブルの「テーブル_ユニット名」。なければ空文字列。使ってる？
        /// （NAME_FORM）
        /// (旧：table unit？)
        /// </summary>
        string Tableunit
        {
            get;
            set;
        }

        /// <summary>
        /// 「TYPE_DATA」フィールド値。
        /// 「T:～;」といった文字列が入る。
        /// (フィールド名：TYPE_DATA)
        /// </summary>
        string Typedata
        {
            get;
            set;
        }

        /// <summary>
        /// 「日別バックアップ」を行うなら真。
        /// (date backup)
        /// </summary>
        bool IsDatebackupActivated
        {
            get;
            set;
        }

        /// <summary>
        /// テーブルの内容保存方法などの設定。
        /// </summary>
        XenonTableformat XenonTableformat
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
