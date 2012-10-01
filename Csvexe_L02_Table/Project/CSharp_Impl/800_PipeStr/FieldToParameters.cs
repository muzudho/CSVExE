using System;
using System.Collections.Generic;
using System.Data;//DataRowView
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Table
{

    /// <summary>
    /// 
    /// </summary>
    public class FieldToParameters
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public FieldToParameters()
        {
            this.list_FieldKeies = new List<XenonFieldkey>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// テーブルのフィールドを特定する情報。
        /// </summary>
        protected List<XenonFieldkey> list_FieldKeies;

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sName_Field"></param>
        /// <param name="value_XenonTable"></param>
        /// <param name="log_Reports"></param>
        public void AddField(
            string sName_Field,
            XenonTable value_XenonTable,
            Log_Reports log_Reports
            )
        {
            List<string> sList_FieldName = new CsvTo_ListImpl().Read(sName_Field);
            List<XenonFielddefinition> list_FieldDef;

             bool bHit = value_XenonTable.TryGetFieldDefinitionByName(
                  out list_FieldDef,
                sList_FieldName,
                true,
                log_Reports
                );
            if (!log_Reports.Successful || !bHit)
            {
                // 既エラー。
                goto gt_EndMethod;
            }

            int nIx = 0;
            foreach (XenonFielddefinition o_FldDef in list_FieldDef)
            {
                this.list_FieldKeies.Add(
                    new XenonFieldkey(sList_FieldName[nIx], o_FldDef.GetTypeString(), o_FldDef.Comment));

                nIx++;
            }


            //
            //
            //
            //
        gt_EndMethod:
            return;
        }

        // ──────────────────────────────

        public void Perform(
            ref TextP1pImpl ref_FormatString,
            DataRowView dataRowView,
            XenonTable xenonTable,
            Log_Reports log_Reports
            )
        {

            // TODO IDは「前ゼロ付き文字列」または「int型」なので、念のため一度文字列に変換。
            int nP1pNumber = 1;
            foreach (XenonFieldkey fieldKey in list_FieldKeies)
            {
                //"[" + oTable.Name + "]テーブルの或る行の[" + fieldKey.Name + "]フィールド値。"//valueOTable.SourceFilePath.HumanInputText

                object obj = Utility_Row.GetFieldvalue(
                    fieldKey.SName,
                    dataRowView.Row,
                    true,
                    log_Reports,
                    fieldKey.SDescription
                );
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }


                // 正常時

                if (XenonFielddefinitionImpl.S_STRING == fieldKey.SType)
                {
                    ref_FormatString.Dictionary_NumberAndValue_Parameter.Add(nP1pNumber, XenonValue_StringImpl.ParseString(obj));
                }
                if (XenonFielddefinitionImpl.S_INT == fieldKey.SType)
                {
                    ref_FormatString.Dictionary_NumberAndValue_Parameter.Add(nP1pNumber, XenonValue_IntImpl.ParseString(obj));
                }
                else if (XenonFielddefinitionImpl.S_BOOL == fieldKey.SType)
                {
                    ref_FormatString.Dictionary_NumberAndValue_Parameter.Add(nP1pNumber, XenonValue_BoolImpl.ParseString(obj));
                }
                else
                {
                    //
                    // 未定義の型は、string扱い。
                    //
                    ref_FormatString.Dictionary_NumberAndValue_Parameter.Add(nP1pNumber, XenonValue_StringImpl.ParseString(obj));
                }

                nP1pNumber++;
            }//foreach

            // 正常
            goto gt_EndMethod;

            //
            //
            //
            //
        gt_EndMethod:
            return;
        }

        //────────────────────────────────────────
        #endregion



    }
}
