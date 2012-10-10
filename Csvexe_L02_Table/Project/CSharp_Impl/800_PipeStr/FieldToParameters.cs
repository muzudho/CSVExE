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
            this.list_FieldKeies = new List<Fieldkey>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// テーブルのフィールドを特定する情報。
        /// </summary>
        protected List<Fieldkey> list_FieldKeies;

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sName_Field"></param>
        /// <param name="value_XenonTable"></param>
        /// <param name="log_Reports"></param>
        public void AddField(
            string sName_Field,
            TableHumaninput value_XenonTable,
            Log_Reports log_Reports
            )
        {
            List<string> sList_FieldName = new CsvTo_ListImpl().Read(sName_Field);
            List<Fielddefinition> list_FieldDef;

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
            foreach (Fielddefinition o_FldDef in list_FieldDef)
            {
                this.list_FieldKeies.Add(
                    new Fieldkey(sList_FieldName[nIx], o_FldDef.GetTypeString(), o_FldDef.Comment));

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
            ref Builder_TexttemplateP1pImpl ref_FormatString,
            DataRowView dataRowView,
            TableHumaninput xenonTable,
            Log_Reports log_Reports
            )
        {

            // TODO IDは「前ゼロ付き文字列」または「int型」なので、念のため一度文字列に変換。
            int nP1pNumber = 1;
            foreach (Fieldkey fieldKey in list_FieldKeies)
            {
                //"[" + oTable.Name + "]テーブルの或る行の[" + fieldKey.Name + "]フィールド値。"//valueOTable.SourceFilePath.HumanInputText

                object obj = Utility_Row.GetFieldvalue(
                    fieldKey.Name,
                    dataRowView.Row,
                    true,
                    log_Reports,
                    fieldKey.Description
                );
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }


                // 正常時

                if (FielddefinitionImpl.S_STRING == fieldKey.Name_Type)
                {
                    ref_FormatString.Dictionary_NumberAndValue_Parameter.Add(nP1pNumber, String_HumaninputImpl.ParseString(obj));
                }
                if (FielddefinitionImpl.S_INT == fieldKey.Name_Type)
                {
                    ref_FormatString.Dictionary_NumberAndValue_Parameter.Add(nP1pNumber, Int_HumaninputImpl.ParseString(obj));
                }
                else if (FielddefinitionImpl.S_BOOL == fieldKey.Name_Type)
                {
                    ref_FormatString.Dictionary_NumberAndValue_Parameter.Add(nP1pNumber, Bool_HumaninputImpl.ParseString(obj));
                }
                else
                {
                    //
                    // 未定義の型は、string扱い。
                    //
                    ref_FormatString.Dictionary_NumberAndValue_Parameter.Add(nP1pNumber, String_HumaninputImpl.ParseString(obj));
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
