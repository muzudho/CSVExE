using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;
using System.Windows.Forms;//Form
using System.Xml;

using Xenon.Syntax;//Log_TextIndented
using Xenon.Controls;
using Xenon.Middle;//MoOpyopyo,Usercontrol
using Xenon.Table; //DefaultTable
using Xenon.Expr;


namespace Xenon.Layout
{

    /// <summary>
    /// X→M。
    /// </summary>
    public class XToMemory_FormImpl : XToMemory_Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public XToMemory_FormImpl()
        {
        }

        //────────────────────────────────────────
        #endregion

        

        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 『レイアウト設定ファイル』を読取ります。
        /// </summary>
        public void LoadUserformconfigFile(
            TableUserformconfig fo_Config_Formgroup,
            XenonTable o_Table_Form,
            MemoryApplication memoryApplication,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_LayoutImpl.Name_Library, this, "LoadUserformconfigFile",pg_Logging);
            //
            //


            //
            // データ・タイプです。
            string sTypeData;
            if (pg_Logging.Successful)
            {
                if (null != o_Table_Form.Typedata)
                {
                    sTypeData = o_Table_Form.Typedata;
                }
                else
                {
                    sTypeData = "";
                }
            }
            else
            {
                sTypeData = "";
            }

            if (pg_Logging.Successful)
            {
                // TREEフィールドの有無チェック

                if (
                    ValuesTypeData.S_TABLE_FORM == sTypeData
                    &&
                    !o_Table_Form.DataTable.Columns.Contains(NamesFld.S_TREE))
                {
                    //
                    // エラー
                    goto gt_Error_NotFoundTreeField;
                }
            }


            string sFoundName;
            string sFoundNameRef;
            if (pg_Logging.Successful)
            {
                // NAMEフィールドの存在する有無
                bool bExistsName = o_Table_Form.DataTable.Columns.Contains("NAME");
                // NAME_REFフィールドの存在する有無
                bool bExistsNameRef = o_Table_Form.DataTable.Columns.Contains("NAME_REF");
                // NAME、NAME_REFフィールドが同時に存在する有無
                bool bExistsDoubleNames = bExistsName && bExistsNameRef;

                //
                // コントロールのプロパティー設定を読取。
                //
                foreach (DataRow dataRow in o_Table_Form.DataTable.Rows)
                {
                    RecordUserformconfig fo_Record = null;
                    bool bRecordNew = false;

                    //
                    // ・NAMEとNAME_REFフィールドの両方に記述があればエラー。
                    // ・NAMEフィールドがあり、コントロール名が記述されていれば、レコードを新規作成。
                    // ・NAME_REFフィールドがあり、コントロール名が記述されていれば、既存レコードを編集。
                    //

                    if (bExistsNameRef)
                    {
                        string sFieldName = "NAME_REF";

                        pg_Logging.Log_Callstack.Push(pg_Method, "①");
                        XenonValue_StringImpl.TryParse(
                            dataRow[sFieldName],// この連想配列は大文字・小文字を区別しないのが欠点。
                            out sFoundNameRef,
                            o_Table_Form.Name,
                            sFieldName,
                            pg_Method,
                            pg_Logging
                            );
                        pg_Logging.Log_Callstack.Pop(pg_Method, "①");

                        if (!pg_Logging.Successful)
                        {
                            // エラー
                            goto gt_EndMethod;
                        }

                    }
                    else
                    {
                        sFoundNameRef = "";
                    }

                    if (bExistsName)
                    {
                        string sFieldName = "NAME";
                        if (dataRow[sFieldName] is DBNull)
                        {
                            //
                            // NAMEフィールドが空欄ならレコードを無視。
                            continue;
                        }

                        pg_Logging.Log_Callstack.Push(pg_Method, "②");
                        XenonValue_StringImpl.TryParse(
                            dataRow[sFieldName],
                            out sFoundName,
                            o_Table_Form.Name,
                            sFieldName,
                            pg_Method,
                            pg_Logging
                            );
                        pg_Logging.Log_Callstack.Pop(pg_Method, "②");

                        if (!pg_Logging.Successful)
                        {
                            // エラー
                            goto gt_EndMethod;
                        }
                    }
                    else
                    {
                        sFoundName = "";
                    }

                    if (bExistsDoubleNames && "" != sFoundName && "" != sFoundNameRef)
                    {
                        // エラー
                        goto gt_Error_DoubleNames;
                    }

                    if (bExistsName && "" != sFoundName)
                    {
                        fo_Record = new RecordUserformconfigImpl(fo_Config_Formgroup);
                        bRecordNew = true;
                    }

                    if (bExistsNameRef && "" != sFoundNameRef)
                    {
                        foreach (RecordUserformconfig fo_Record2 in fo_Config_Formgroup.List_RecordUserformconfig)
                        {
                            string sName_Control;
                            fo_Record2.TryGetString(out sName_Control, NamesFld.S_NAME, true, "", memoryApplication, pg_Logging);

                            if (sName_Control == sFoundNameRef)
                            {
                                fo_Record = fo_Record2;
                                break;
                            }
                        }
                    }

                    if (null == fo_Record)
                    {
                        continue;
                    }

                    if (pg_Logging.Successful)
                    {
                        //
                        // レイアウト・テーブル一覧。
                        // またはレイアウト・テーブル。
                        // または未指定。
                        //

                        if (
                            ValuesTypeData.S_TABLES_FORM == sTypeData ||
                            ValuesTypeData.S_TABLE_FORM == sTypeData ||
                            "" == sTypeData)
                        {
                            int nResult = this.Read_Form(
                                fo_Record,
                                dataRow,
                                o_Table_Form,
                                fo_Config_Formgroup,
                                memoryApplication,
                                pg_Logging
                                );

                            if (2 == nResult)
                            {
                                // 追加せず中断する。
                                continue;
                            }
                        }
                    }

                    if (pg_Logging.Successful)
                    {
                        //
                        // レイアウト・テーブル（リスト）
                        //
                        if (ValuesTypeData.S_TABLE_FORM_LST == sTypeData)
                        {
                            int nResult = this.Read_FormLst(
                                true,
                                fo_Record,
                                dataRow,
                                o_Table_Form,
                                pg_Logging
                                );

                            if (2 == nResult)
                            {
                                // 編集せず中断する。
                                continue;
                            }
                        }
                    }


                    if (pg_Logging.Successful)
                    {
                        // 正常時。

                        if (bRecordNew)
                        {
                            fo_Config_Formgroup.List_RecordUserformconfig.Add(fo_Record);
                        }
                    }
                }//各行
            }
            else
            {
                //config_formGroup = null;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundTreeField:
            // テーブルタイプが「Form」で、"TREE" フィールドがないとき。
            // （Form_lstタイプには、TREEフィールドは要らない）
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー91026！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("指定のテーブル[");
                s.Append(o_Table_Form.Name);
                s.Append("に、");
                s.Newline();

                s.Append("TREEフィールドが見つかりませんでした。TREEフィールドは必要です。");
                s.Newline();

                s.Newline();
                s.Newline();

                //
                // 問題箇所ヒント
                //
                s.Append("　BaseDirectory=[");
                s.Append(o_Table_Form.Expression_Filepath_ConfigStack.Directory_Base);
                s.Append("]");
                s.Newline();
                s.Newline();

                s.Append("　HumanInputText=[");
                s.Append(o_Table_Form.Expression_Filepath_ConfigStack.Humaninput);
                s.Append("]");
                s.Newline();
                s.Newline();

                // ヒント
                s.Append(r.Message_Configurationtree(o_Table_Form));

                r.Message = s.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_DoubleNames:
            // NAMEフィールドと、NAME_REFフィールドの両方に記述があれば。
            // （両方に記述してはいけない）
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー901！", pg_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("指定のテーブル[");
                t.Append(o_Table_Form.Name);
                t.Append("の中に、");
                t.Newline();

                t.Append("NAMEとNAME_REFフィールドの両方に記述があるものがありました。");
                t.Newline();
                t.Append("両方同時に記述してはいけません。");
                t.Newline();

                t.Newline();
                t.Newline();

                t.Append("NAME=[");
                t.Append(sFoundName);
                t.Append("]");
                t.Newline();

                t.Append("NAME_REF=[");
                t.Append(sFoundNameRef);
                t.Append("]");
                t.Newline();

                t.Newline();
                t.Newline();

                //
                // 問題箇所ヒント
                //
                t.Append("　BaseDirectory=[");
                t.Append(o_Table_Form.Expression_Filepath_ConfigStack.Directory_Base);
                t.Append("]");
                t.Newline();
                t.Newline();

                t.Append("　HumanInputText=[");
                t.Append(o_Table_Form.Expression_Filepath_ConfigStack.Humaninput);
                t.Append("]");
                t.Newline();
                t.Newline();

                // ヒント
                t.Append(r.Message_Configurationtree(o_Table_Form));

                r.Message = t.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「レイアウト_テーブル」のテーブルタイプが「Form」専用。
        /// </summary>
        /// <param name="fo_Record"></param>
        /// <param name="dataRow"></param>
        /// <param name="o_Table_Form"></param>
        /// <param name="ol_Config2"></param>
        /// <param name="pg_Logging"></param>
        /// <returns>0:正常終了、2:continue。</returns>
        private int Read_Form(
            RecordUserformconfig fo_Record,
            DataRow dataRow,
            XenonTable o_Table_Form,
            TableUserformconfig fo_Config,
            MemoryApplication memoryApplication,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_LayoutImpl.Name_Library, this, "Read_Layout",pg_Logging);
            //
            //

            int nResult = 0;

            int nIntValue;// = 0;
            string sValue;// = "";
            bool bValue;// = false;


            //
            // TREE （特殊判定）
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_TREE;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {
                    //フィールド有り


                    if (dataRow[sFieldName] is DBNull)// この連想配列は大文字・小文字を区別しないのが欠点。
                    {
                        // フィールドは有るが、未記入の時。

                        // TREEフィールドが未記入の場合は、空行と判断して、無視します。
                        nResult = 2;
                        goto gt_EndMethod;
                    }

                    //フィールドが有り、記入もあるとき。

                    pg_Logging.Log_Callstack.Push(pg_Method, "③");
                    bool bParsedSuccessful = XenonValue_IntImpl.TryParse(
                        dataRow[sFieldName],
                        out nIntValue,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value, // 「値が空（-1）」は、空行としてよく使います。
                        -1,
                        pg_Logging
                        );
                    pg_Logging.Log_Callstack.Pop(pg_Method, "③");

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParsedSuccessful)
                    {
                        fo_Record.Set(NamesFld.S_TREE, EnumTypedb.Int, nIntValue, pg_Logging);
                        //fo_Record.NTree = nIntValue;
                    }
                    else
                    {
                        // エラー時
                    }
                }

            }

            //
            // NO
            //
            {
                //必須フィールドではありません。
                string sFieldName = NamesFld.S_NO;

                bool bContained = o_Table_Form.ContainsField(sFieldName, false, pg_Logging);
                if (pg_Logging.Successful)
                {
                    if (bContained)
                    {
                        pg_Logging.Log_Callstack.Push(pg_Method, "④");
                        bool bParsedSuccessful = XenonValue_IntImpl.TryParse(
                            dataRow[sFieldName],
                            out nIntValue,
                            EnumOperationIfErrorvalue.Spaces_To_Alt_Value, // 空行追加時のエラー抑制のため。
                            -1,
                            pg_Logging
                            );
                        pg_Logging.Log_Callstack.Pop(pg_Method, "④");

                        if (!pg_Logging.Successful)
                        {
                            // エラー
                            goto gt_EndMethod;
                        }

                        if (bParsedSuccessful)
                        {
                            fo_Record.Set(NamesFld.S_NO, EnumTypedb.Int, nIntValue, pg_Logging);
                            //fo_Record.NNo = nIntValue;
                        }
                        else
                        {
                            fo_Record.Set(NamesFld.S_NO, EnumTypedb.Int, 0, pg_Logging);
                            //fo_Record.NNo = 0;
                        }
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_NO, EnumTypedb.Int, 0, pg_Logging);
                        //fo_Record.NNo = 0;
                    }

                }
            }

            //
            // NAME
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_NAME;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {

                    pg_Logging.Log_Callstack.Push(pg_Method, "⑤");
                    bool bBool = XenonValue_StringImpl.TryParse(
                        dataRow[sFieldName],
                        out sValue,
                        o_Table_Form.Name,
                        sFieldName,
                        pg_Method,
                        pg_Logging);
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑤");

                    if (bBool)
                    {
                        // コントロール名。
                        fo_Record.Set( NamesFld.S_NAME, EnumTypedb.String, sValue, pg_Logging);
                        //fo_Record.Name = sValue;
                    }
                    else
                    {
                        //
                        // NAME がエラー？
                        //

                        // コントロール名。
                        fo_Record.Set(NamesFld.S_NAME, EnumTypedb.String, "＜エラー＞", pg_Logging);
                        //fo_Record.Name = "＜エラー＞";
                    }

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                }
            }


            //
            // int型のTREEフィールドが-1の場合は、空行と判断します。
            //
            int nCurTree;
            fo_Record.TryGetInt(out nCurTree, NamesFld.S_TREE, true, -1, memoryApplication, pg_Logging);
            if (-1 == nCurTree)
            {
                nResult = 2;
                goto gt_EndMethod;
            }




            //
            // TYPE
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_TYPE;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {

                    pg_Logging.Log_Callstack.Push(pg_Method, "⑦");
                    bool bBool = XenonValue_StringImpl.TryParse(
                        dataRow[sFieldName],
                        out sValue,
                        o_Table_Form.Name,
                        sFieldName,
                        pg_Method,
                        pg_Logging);
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑦");

                    if (bBool)
                    {
                        fo_Record.Set(NamesFld.S_TYPE, EnumTypedb.String, sValue, pg_Logging);
                        //fo_Record.SType = sValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_TYPE, EnumTypedb.String, "", pg_Logging);
                        //fo_Record.SType = "";
                    }

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }
                }
            }


            //
            // TEXT
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_TEXT;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {

                    pg_Logging.Log_Callstack.Push(pg_Method, "⑧");
                    bool bBool = XenonValue_StringImpl.TryParse(
                        dataRow[sFieldName],
                        out sValue,
                        o_Table_Form.Name,
                        sFieldName,
                        pg_Method,
                        pg_Logging);
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑧");

                    if (bBool)
                    {
                        fo_Record.Set(NamesFld.S_TEXT, EnumTypedb.String, sValue, pg_Logging);
                        //fo_Record.SText = sValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_TEXT, EnumTypedb.String, "", pg_Logging);
                        //fo_Record.SText = "";
                    }

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                }
            }

            //
            // FILE
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_FILE;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "⑨");
                    bool bBool = XenonValue_StringImpl.TryParse(
                        dataRow[sFieldName],
                        out sValue,
                        o_Table_Form.Name,
                        sFieldName,
                        pg_Method,
                        pg_Logging);
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑨");

                    if (bBool)
                    {
                        Configurationtree_NodeFilepath cf_Fpath_Control = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L10_1", o_Table_Form);
                        cf_Fpath_Control.InitPath(sValue, pg_Logging);
                        if (pg_Logging.Successful)
                        {
                            fo_Record.Set(NamesFld.S_FILE, EnumTypedb.GcavFilepath, cf_Fpath_Control, pg_Logging);
                            //fo_Record.Cf_File = cf_Fpath_Control;
                        }
                    }
                    else
                    {
                        Configurationtree_NodeFilepath cf_Fpath_Control = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L10_2", o_Table_Form);
                        cf_Fpath_Control.InitPath("", pg_Logging);
                        if (pg_Logging.Successful)
                        {
                            fo_Record.Set(NamesFld.S_FILE, EnumTypedb.GcavFilepath, cf_Fpath_Control, pg_Logging);
                            //fo_Record.Cf_File = cf_Fpath;
                        }
                    }

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                }
            }


            //
            // ENABLED
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_ENABLED;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {

                    pg_Logging.Log_Callstack.Push(pg_Method, "⑩");
                    bool bParseSuccessful = XenonValue_BoolImpl.TryParse(
                        dataRow[sFieldName],
                        out bValue,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value, // 空行追加時のエラー抑制のため。
                        false,
                        pg_Logging
                        );
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑩");

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParseSuccessful)
                    {
                        fo_Record.Set( NamesFld.S_ENABLED, EnumTypedb.Bool, bValue, pg_Logging);
                        //fo_Record.BEnabled = bValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_ENABLED, EnumTypedb.Bool, false, pg_Logging);
                        //fo_Record.BEnabled = false;
                    }
                }
            }


            //
            // VISIBLE
            //
            {
                //必須フィールドではありません。
                string sFieldName = NamesFld.S_VISIBLE;

                bool bContained = o_Table_Form.ContainsField(sFieldName, false, pg_Logging);
                if (bContained)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "⑪");
                    bool bParsedSuccessful = XenonValue_BoolImpl.TryParse(
                        dataRow[sFieldName],
                        out bValue,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value, // 空行追加時のエラー抑制のため。
                        false,
                        pg_Logging
                        );
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑪");

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParsedSuccessful)
                    {
                        fo_Record.Set(NamesFld.S_VISIBLE, EnumTypedb.Bool, bValue, pg_Logging);
                        //fo_Record.BVisible = bValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_VISIBLE, EnumTypedb.Bool, false, pg_Logging);
                        //fo_Record.BVisible = false;
                    }
                }
                else
                {
                    //
                    // VISIBLEフィールドがない場合、常に可視とします。
                    //

                    fo_Record.Set(NamesFld.S_VISIBLE, EnumTypedb.Bool, true, pg_Logging);
                    //fo_Record.BVisible = true;
                }
            }


            //
            // READ_ONLY
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_READ_ONLY;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "⑫");
                    bool bParsedSuccessful = XenonValue_BoolImpl.TryParse(
                        dataRow[sFieldName],
                        out bValue,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value, // 空行追加時のエラー抑制のため。
                        false,
                        pg_Logging
                        );
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑫");

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParsedSuccessful)
                    {
                        fo_Record.Set(NamesFld.S_READ_ONLY, EnumTypedb.Bool, bValue, pg_Logging);
                        //fo_Record.BReadOnly = bValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_READ_ONLY, EnumTypedb.Bool, false, pg_Logging);
                        //fo_Record.BReadOnly = false;
                    }
                }
            }


            //
            // WORD_WRAP
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_WORD_WRAP;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "⑬");
                    bool bParsedSuccessful = XenonValue_BoolImpl.TryParse(
                        dataRow[sFieldName],
                        out bValue,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value, // 空行追加時のエラー抑制のため。
                        false,
                        pg_Logging
                        );
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑬");

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParsedSuccessful)
                    {
                        fo_Record.Set(NamesFld.S_WORD_WRAP, EnumTypedb.Bool, bValue, pg_Logging);
                        //fo_Record.BWordWrap = bValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_WORD_WRAP, EnumTypedb.Bool, false, pg_Logging);
                        //fo_Record.BWordWrap = false;
                    }
                }
            }


            //
            // NEW_LINE
            //
            {
                //必須フィールドではありません。
                string sFieldName = NamesFld.S_NEW_LINE;

                bool bContained = o_Table_Form.ContainsField(sFieldName, false, pg_Logging);
                if (bContained)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "⑭");
                    bool bBool = XenonValue_StringImpl.TryParse(
                        dataRow[sFieldName],
                        out sValue,
                        o_Table_Form.Name,
                        sFieldName,
                        pg_Method,
                        pg_Logging);
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑭");

                    if (bBool)
                    {
                        fo_Record.Set(NamesFld.S_NEW_LINE, EnumTypedb.String, sValue, pg_Logging);
                        //fo_Record.SNewLine = sValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_NEW_LINE, EnumTypedb.String, "", pg_Logging);
                        //fo_Record.SNewLine = "";
                    }

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                }
                else
                {
                    //
                    // VISIBLEフィールドがない場合、指定なしとします。
                    //

                    fo_Record.Set(NamesFld.S_NEW_LINE, EnumTypedb.String, "", pg_Logging);
                    //fo_Record.SNewLine = "";
                }
            }


            //
            // SCROLL_BARS
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_SCROLL_BARS;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "⑮");
                    bool bBool = XenonValue_StringImpl.TryParse(
                        dataRow[sFieldName],
                        out sValue,
                        o_Table_Form.Name,
                        sFieldName,
                        pg_Method,
                        pg_Logging);
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑮");

                    if (bBool)
                    {
                        fo_Record.Set(NamesFld.S_SCROLL_BARS, EnumTypedb.String, sValue, pg_Logging);
                        //fo_Record.SScrollBars = sValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_SCROLL_BARS, EnumTypedb.String, "", pg_Logging);
                        //fo_Record.SScrollBars = "";
                    }

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }
                }
            }


            //
            // CHK_VALUE_TYPE
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_CHK_VALUE_TYPE;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "⑯");
                    bool bBool = XenonValue_StringImpl.TryParse(
                        dataRow[sFieldName],
                        out sValue,
                        o_Table_Form.Name,
                        sFieldName,
                        pg_Method,
                        pg_Logging);
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑯");

                    if (bBool)
                    {
                        fo_Record.Set(NamesFld.S_CHK_VALUE_TYPE, EnumTypedb.String, sValue, pg_Logging);
                        //fo_Record.SChkValueType = sValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_CHK_VALUE_TYPE, EnumTypedb.String, "", pg_Logging);
                        //fo_Record.SChkValueType = "";
                    }

                    if (!pg_Logging.Successful)
                    {
                        goto gt_EndMethod;
                    }
                }
            }


            //
            // FONT_SIZE_PT
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_FONT_SIZE_PT;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "⑰");
                    bool bBool = XenonValue_StringImpl.TryParse(
                        dataRow[sFieldName],
                        out sValue,
                        o_Table_Form.Name,
                        sFieldName,
                        pg_Method,
                        pg_Logging);
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑰");

                    if (bBool)
                    {
                        fo_Record.Set(NamesFld.S_FONT_SIZE_PT, EnumTypedb.String, sValue, pg_Logging);
                        //fo_Record.SFontSizePt = sValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_FONT_SIZE_PT, EnumTypedb.String, "", pg_Logging);
                        //fo_Record.SFontSizePt = "";
                    }

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }
                }
            }


            //
            // PIC_ZOOM
            //
            {
                //必須フィールドではありません。
                string sFieldName = NamesFld.S_PIC_ZOOM;

                bool bContained = o_Table_Form.ContainsField(sFieldName, false, pg_Logging);
                if (bContained)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "⑱");
                    bool bParsedSuccessful = XenonValue_IntImpl.TryParse(
                        dataRow[sFieldName],
                        out nIntValue,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value, // 空行追加時のエラー抑制のため。
                        1000,// 等倍サイズ。千分率なので1000。
                        pg_Logging
                        );
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑱");

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParsedSuccessful)
                    {
                        fo_Record.Set(NamesFld.S_PIC_ZOOM, EnumTypedb.Int, nIntValue, pg_Logging);
                        //fo_Record.NPicZoom = nIntValue;
                    }
                }
                else
                {
                    //
                    // フィールドが無かった場合。
                    //
                    fo_Record.Set(NamesFld.S_PIC_ZOOM, EnumTypedb.Int, 1000, pg_Logging);
                    //fo_Record.NPicZoom = 1000;// 等倍サイズ。千分率なので1000。
                }
            }


            //
            // X_LT
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_X_LT;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "⑲");
                    bool bParsedSuccessful = XenonValue_IntImpl.TryParse(
                        dataRow[sFieldName],
                        out nIntValue,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value, // 空行追加時のエラー抑制のため。
                        -1,
                        pg_Logging
                        );
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑲");

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParsedSuccessful)
                    {
                        fo_Record.Set(NamesFld.S_X_LT, EnumTypedb.Int, nIntValue, pg_Logging);
                        //fo_Record.NAbsXLt = nIntValue;
                    }
                }
            }


            //
            // Y_LT
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_Y_LT;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "⑳");
                    bool bParsedSuccessful = XenonValue_IntImpl.TryParse(
                        dataRow[sFieldName],
                        out nIntValue,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value, // 空行追加時のエラー抑制のため。
                        -1,
                        pg_Logging
                        );
                    pg_Logging.Log_Callstack.Pop(pg_Method, "⑳");

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParsedSuccessful)
                    {
                        fo_Record.Set(NamesFld.S_Y_LT, EnumTypedb.Int, nIntValue, pg_Logging);
                        //fo_Record.NAbsYLt = nIntValue;
                    }
                }
            }


            //
            // WIDTH
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_WIDTH;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "（２１）");
                    bool bParsedSuccessful = XenonValue_IntImpl.TryParse(
                        dataRow[sFieldName],
                        out nIntValue,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value, // 空行追加時のエラー抑制のため。
                        -1,
                        pg_Logging
                        );
                    pg_Logging.Log_Callstack.Pop(pg_Method, "（２１）");

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParsedSuccessful)
                    {
                        fo_Record.Set(NamesFld.S_WIDTH, EnumTypedb.Int, nIntValue, pg_Logging);
                        //fo_Record.NWidth = nIntValue;
                    }
                }
            }


            //
            // HEIGHT
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_HEIGHT;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "（２２）");
                    bool bParsedSuccessful = XenonValue_IntImpl.TryParse(
                        dataRow[sFieldName],
                        out nIntValue,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value, // 空行追加時のエラー抑制のため。
                        -1,
                        pg_Logging
                        );
                    pg_Logging.Log_Callstack.Pop(pg_Method, "（２２）");

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParsedSuccessful)
                    {
                        fo_Record.Set(NamesFld.S_HEIGHT, EnumTypedb.Int, nIntValue, pg_Logging);
                        //fo_Record.NHeight = nIntValue;
                    }
                }
            }


            //
            // TAB_INDEX
            //
            {
                //必須フィールドです。
                string sFieldName = NamesFld.S_TAB_INDEX;

                // フィールドが無ければ、その時点でエラー。
                o_Table_Form.ContainsField(sFieldName, true, pg_Logging);
                if (pg_Logging.Successful)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "（２３）");
                    bool bParsedSuccessful = XenonValue_IntImpl.TryParse(
                        dataRow[sFieldName],
                        out nIntValue,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value,//大したデータではないので、省略すると-1にする。
                        -1,
                        pg_Logging
                        );
                    pg_Logging.Log_Callstack.Pop(pg_Method, "（２３）");

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParsedSuccessful)
                    {
                        fo_Record.Set(NamesFld.S_TAB_INDEX, EnumTypedb.Int, nIntValue, pg_Logging);
                        //fo_Record.NTabIndex = nIntValue;
                    }
                }
            }


            //
            // BACK_COLOR
            //
            {
                //必須フィールドではありません。
                string sFieldName = NamesFld.S_BACK_COLOR;

                bool bContained = o_Table_Form.ContainsField(sFieldName, false, pg_Logging);
                if (bContained)
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "（２４）");
                    bool bBool = XenonValue_StringImpl.TryParse(
                        dataRow[sFieldName],
                        out sValue,
                        o_Table_Form.Name,
                        sFieldName,
                        pg_Method,
                        pg_Logging);
                    pg_Logging.Log_Callstack.Pop(pg_Method, "（２４）");

                    if (bBool)
                    {
                        fo_Record.Set(NamesFld.S_BACK_COLOR, EnumTypedb.String, sValue, pg_Logging);
                        //fo_Record.SBackColor = sValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_BACK_COLOR, EnumTypedb.String, "", pg_Logging);
                        //fo_Record.SBackColor = "";
                    }

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                }
                else
                {
                    fo_Record.Set(NamesFld.S_BACK_COLOR, EnumTypedb.String, "", pg_Logging);
                    //fo_Record.SBackColor = "";
                }
            }



            this.Read_FormLst(
                false,
                fo_Record,
                dataRow,
                o_Table_Form,
                pg_Logging
                );


            //
            //
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
            return nResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「(Form_lst)補完レイアウト_テーブル」用。
        /// </summary>
        /// <returns>0:正常終了、2:continue。</returns>
        private int Read_FormLst(
            bool bNameRefRequired,
            RecordUserformconfig fo_Record,
            DataRow dataRow,
            XenonTable o_Table_Form,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_LayoutImpl.Name_Library, this, "Read_LayoutLst",pg_Logging);
            //
            //

            int nResult = 0;

            int nIntValue;// = 0;
            string sValue;// = "";
            //bool boolValue;// = false;


            if (bNameRefRequired)
            {
                //
                // NAME_REF が未記入ならスキップ
                string sFieldName = NamesFld.S_NAME_REF;
                if (dataRow.Table.Columns.Contains(sFieldName))
                {
                    if (dataRow[sFieldName] is DBNull)
                    {
                        // この連想配列は大文字・小文字を区別しないのが欠点。


                        // NAME_REFフィールドが未記入の場合は、空行と判断して、無視します。
                        nResult = 2;
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    if (pg_Logging.CanCreateReport)
                    {
                        Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー921！", pg_Method);
                        r.Message = "[" + sFieldName + "]フィールドは、[" + o_Table_Form.Name + "]には存在しませんでした。";
                        pg_Logging.EndCreateReport();
                    }
                }
            }


            //
            // ITEM_HEIGHT_PX
            //
            {
                string sFieldName = NamesFld.S_ITEM_HEIGHT_PX;
                if (dataRow.Table.Columns.Contains(sFieldName))
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "（２５）");
                    bool bBool = !XenonValue_IntImpl.TryParse(
                        dataRow[sFieldName],
                        out nIntValue,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value, // 空行追加時のエラー抑制のため。
                        -1,
                        pg_Logging
                        );
                    pg_Logging.Log_Callstack.Pop(pg_Method, "（２５）");

                    if (bBool)
                    {
                        // パース失敗時

                        // 無視
                    }
                    else
                    {
                        if (!pg_Logging.Successful)
                        {
                            // エラー
                            goto gt_EndMethod;
                        }

                        if (nIntValue < 1 || 256 <= nIntValue)
                        {
                            // 1未満、または256以上をセットするとエラーになるので無視。
                            // 空欄(-1)
                        }
                        else
                        {
                            fo_Record.Set(NamesFld.S_ITEM_HEIGHT_PX, EnumTypedb.Int, nIntValue, pg_Logging);
                            //fo_Record.NItemHeightPx = nIntValue;
                        }
                    }


                }
                else
                {
                    //
                    // スルーすること。初期化してはいけない。
                    //
                }
            }


            //
            // ITEM_DISPLAY_FORMAT
            //
            {
                string sFieldName = NamesFld.S_ITEM_DISPLAY_FORMAT;
                if (dataRow.Table.Columns.Contains(sFieldName))
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "（２６）");
                    bool bBool = XenonValue_StringImpl.TryParse(
                        dataRow[sFieldName],
                        out sValue,
                        o_Table_Form.Name,
                        sFieldName,
                        pg_Method,
                        pg_Logging);
                    pg_Logging.Log_Callstack.Pop(pg_Method, "（２６）");

                    if (bBool)
                    {
                        fo_Record.Set(NamesFld.S_ITEM_DISPLAY_FORMAT, EnumTypedb.String, sValue, pg_Logging);
                        //fo_Record.SItemDisplayFormat = sValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_ITEM_DISPLAY_FORMAT, EnumTypedb.String, "", pg_Logging);
                        //fo_Record.SItemDisplayFormat = "";
                    }

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                }
                else
                {
                    //
                    // スルーすること。初期化してはいけない。
                    //
                }
            }

            //
            // LIST_VALUE_FIELD
            //
            {
                string sFieldName = NamesFld.S_LIST_VALUE_FIELD;
                if (dataRow.Table.Columns.Contains(sFieldName))
                {
                    pg_Logging.Log_Callstack.Push(pg_Method, "（２７）");
                    bool bBool = XenonValue_StringImpl.TryParse(
                        dataRow[sFieldName],
                        out sValue,
                        o_Table_Form.Name,
                        sFieldName,
                        pg_Method,
                        pg_Logging);
                    pg_Logging.Log_Callstack.Pop(pg_Method, "（２７）");

                    if (bBool)
                    {
                        fo_Record.Set(NamesFld.S_LIST_VALUE_FIELD, EnumTypedb.String, sValue, pg_Logging);
                        //fo_Record.SListValueField = sValue;
                    }
                    else
                    {
                        fo_Record.Set(NamesFld.S_LIST_VALUE_FIELD, EnumTypedb.String, "", pg_Logging);
                        //fo_Record.SListValueField = "";
                    }

                    if (!pg_Logging.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                }
                else
                {
                    //
                    // スルーすること。初期化してはいけない。
                    //
                }
            }

            //
            //
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
            return nResult;
        }

        //────────────────────────────────────────
        #endregion



    }
}
