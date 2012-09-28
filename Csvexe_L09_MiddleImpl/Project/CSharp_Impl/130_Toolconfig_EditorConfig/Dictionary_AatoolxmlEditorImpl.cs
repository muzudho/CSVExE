using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//WarningReports
using Xenon.Middle;


namespace Xenon.MiddleImpl
{
    /// <summary>
    /// project要素の集まり。
    /// </summary>
    public class Dictionary_AatoolxmlEditorImpl : Dictionary_AatoolxmlEditor
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Dictionary_AatoolxmlEditorImpl(MemoryAatoolxml moAatoolxml)
        {
            this.moAatoolxml = moAatoolxml;
            this.dictionary_Item = new Dictionary<string, MemoryAatoolxml_Editor>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// project要素を返します。該当がなければヌルを返します。
        /// </summary>
        /// <param name="inputName"></param>
        /// <param name="bRequired">該当がない場合にエラー扱いにするなら真</param>
        /// <returns></returns>
        public MemoryAatoolxml_Editor GetEditorByName(
            string sName_Editor,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "GetEditorByName",log_Reports);

            MemoryAatoolxml_Editor result;

            if (this.dictionary_Item.ContainsKey(sName_Editor))
            {
                result = this.dictionary_Item[sName_Editor];
            }
            else
            {
                result = null;

                if (bRequired)
                {
                    // エラーとして扱います。
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー311！", log_Method);

                        StringBuilder s = new StringBuilder();
                        s.Append("指定された<"+NamesNode.S_EDITOR+">要素は存在しませんでした。");
                        s.Append(Environment.NewLine);
                        s.Append(Environment.NewLine);


                        s.Append(NamesNode.S_EDITOR + "要素名=[");
                        s.Append(sName_Editor);
                        s.Append("]");
                        s.Append(Environment.NewLine);

                        r.SMessage = s.ToString();
                        log_Reports.EndCreateReport();
                    }
                    goto gt_EndMethod;
                }
            }
            goto gt_EndMethod;


            //
        //
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 内容をデバッグ出力します。
        /// </summary>
        public void CreateMessage_Debug(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            Log_Reports d_Logging_Dammy = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "CreateMessage_Debug",d_Logging_Dammy);
            //
            //

            //ystem.Console.WriteLine(this.GetType().Name + "#DebugWrite: 【デバッグ出力】 project要素の個数=[" + this.Items.Count + "]");

            foreach (MemoryAatoolxml_Editor aatool_Editor in this.Dictionary_Item.Values)
            {
                //ystem.Console.WriteLine(this.GetType().Name + "#DebugWrite: 【デバッグ出力】 project名=[" + st_Project.SName + "]");

                aatool_Editor.WriteDebug_ToConsole(aatool_Editor.Dictionary_Fsetvar_Givechapterandverse, log_Reports);
            }


            //
            //
            d_Logging_Dammy.EndCreateReport();
            log_Method.EndMethod(d_Logging_Dammy);
            if (!d_Logging_Dammy.BSuccessful)
            {
                log_Method.WriteDebug_ToConsole(d_Logging_Dammy.ToMessage());
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<string, MemoryAatoolxml_Editor> dictionary_Item;

        /// <summary>
        /// input要素の連想配列。
        /// </summary>
        public Dictionary<string, MemoryAatoolxml_Editor> Dictionary_Item
        {
            get
            {
                return dictionary_Item;
            }
            set
            {
                dictionary_Item = value;
            }
        }

        //────────────────────────────────────────

        private MemoryAatoolxml moAatoolxml;

        /// <summary>
        /// 親要素。ツール設定。
        /// </summary>
        public MemoryAatoolxml MemoryAatoolxml
        {
            get
            {
                return moAatoolxml;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
