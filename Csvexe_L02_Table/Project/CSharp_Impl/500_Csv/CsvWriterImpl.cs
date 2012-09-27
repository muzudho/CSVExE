using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;

namespace Xenon.Table
{
    public class CsvWriterImpl
    {



        #region アクション
        //────────────────────────────────────────

        public void Write(
            string sText_Csv,
            string sFpatha,//絶対ファイルパス
            bool bSuccessfulDialogPopup
            )
        {


            try
            {
                System.IO.File.WriteAllText(sFpatha, sText_Csv, Encoding.Default);

                if (bSuccessfulDialogPopup)
                {
                    Log_TextIndented s = new Log_TextIndentedImpl();

                    s.Append("ファイルに書き込みました。");
                    s.Append(Environment.NewLine);
                    s.Append("[");
                    s.Append(sFpatha);
                    s.Append("]");

                    MessageBox.Show(s.ToString(), "▲実行結果！（L02）");
                }
            }
            catch (Exception ex)
            {
                // 異常時は必ずポップアップが出る。
                MessageBox.Show(
                    ex.Message,
                    "▲エラー201！(" + Info_Table.SName_Library + ") " + this.GetType().Name + "#Write"
                    );
            }


        }

        //────────────────────────────────────────
        #endregion



    }
}
