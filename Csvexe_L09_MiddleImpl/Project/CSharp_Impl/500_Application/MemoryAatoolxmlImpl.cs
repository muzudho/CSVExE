using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.MiddleImpl
{

    /// <summary>
    /// ツール設定ファイルの内容を保持。
    /// </summary>
    public class MemoryAatoolxmlImpl : MemoryAatoolxml
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryAatoolxmlImpl()
        {
            this.cur_Givechapterandverse = new Givechapterandverse_NodeImpl( "<init>", null);
            this.sDefaultEditor = "";
            this.dictionary_Editor = new Dictionary_AatoolxmlEditorImpl(this);
        }

        /// <summary>
        /// new した直後の内容に戻します。
        /// </summary>
        public void Clear()
        {
            this.cur_Givechapterandverse = new Givechapterandverse_NodeImpl("<clear>", null);
            this.SDefaultEditor = "";
            this.Dictionary_Editor.Dictionary_Item.Clear();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 定型処理。
        /// </summary>
        public void P101_LoadAatoolxml(
            MemoryApplication moApplication,
            Givechapterandverse_Node cf_CallerMethod,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "P101_LoadAatoolxml", log_Reports);
            //
            //

            moApplication.MemoryAatoolxml.Clear();

            if (log_Reports.BSuccessful)
            {
                // ツール設定ファイルへのパスは固定とします。
                Expression_Node_Filepath ec_Fpath;
                {
                    Givechapterandverse_Filepath cf_Fpath = new Givechapterandverse_FilepathImpl("ファイルパス出典未指定L09Mid_5", cf_CallerMethod);
                    cf_Fpath.InitPath(
                        ValuesAttr.S_FPATHR_AATOOLXML,
                        log_Reports);
                    if (!log_Reports.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }

                    ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath);
                }

                moApplication.MemoryAatoolxml.LoadFile(ec_Fpath, log_Reports);
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }
            else
            {
                // エラー終了処理
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ファイル読み込み。
        /// </summary>
        /// <param name="ec_Fpath_Aatoolxml"></param>
        public void LoadFile(
            Expression_Node_Filepath ec_Fpath_Aatoolxml,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "LoadFile",log_Reports);
            //
            //

            Exception err_Excp;


            string sFpatha_Aatoolxml = "";
            if (log_Reports.BSuccessful)
            {
                //
                // 『ツール設定』をクリアー。
                //
                this.Clear();

                sFpatha_Aatoolxml = ec_Fpath_Aatoolxml.Execute_OnExpressionString(
                    Request_SelectingImpl.Unconstraint,
                    log_Reports
                    );//絶対ファイルパス
            }

            if (log_Reports.BSuccessful)
            {
                XmlDocument xDoc = new XmlDocument();

                try
                {

                    // 正常時

                    xDoc.Load(sFpatha_Aatoolxml);

                    // ルート要素を取得
                    XmlElement xRoot = xDoc.DocumentElement;

                    // スクリプトファイルのバージョンチェック。（バリデーター登録ファイル）
                    ValuesAttr.Test_Codefileversion(
                        xRoot.GetAttribute(PmNames.S_CODEFILE_VERSION.SName_Attr),
                        log_Reports,
                        new Givechapterandverse_NodeImpl(sFpatha_Aatoolxml, null),
                        NamesNode.S_CODEFILE_TOOL
                        );


                    if (log_Reports.BSuccessful)
                    {
                        // デフォルト・エディター名
                        this.SDefaultEditor = xRoot.GetAttribute(PmNames.S_DEFAULT_EDITOR.SName_Attr);

                        // エディター要素を列挙
                        System.Xml.XmlNodeList xNl_Editor = xRoot.GetElementsByTagName(NamesNode.S_EDITOR);

                        foreach (XmlNode x_EditorNode in xNl_Editor)
                        {
                            if (XmlNodeType.Element == x_EditorNode.NodeType)
                            {
                                //
                                // エディター要素
                                //
                                MemoryAatoolxml_Editor aatool_Editor = new MemoryAatoolxml_EditorImpl(this.cur_Givechapterandverse);

                                //
                                // エディター要素
                                //
                                XmlElement xEditor = (XmlElement)x_EditorNode;

                                // ツール設定ファイルに記載されている、エディター名
                                try
                                {
                                    aatool_Editor.SName = xEditor.GetAttribute(PmNames.S_NAME.SName_Attr);

                                    this.Dictionary_Editor.Dictionary_Item.Add(aatool_Editor.SName, aatool_Editor);
                                }
                                catch (ArgumentException ex)
                                {
                                    err_Excp = ex;
                                    goto gt_Error_DuplicatedEditorName;
                                }


                                // ＜ｆ－ｓｅｔ－ｖａｒ＞要素を列挙
                                System.Xml.XmlNodeList xNl_Fsetvar = xEditor.GetElementsByTagName(NamesNode.S_F_SET_VAR);

                                for (int nIndex_Fsetvar = 0; nIndex_Fsetvar < xNl_Fsetvar.Count; nIndex_Fsetvar++)
                                {
                                    XmlNode xNode_Fsetvar = xNl_Fsetvar.Item(nIndex_Fsetvar);

                                    if (XmlNodeType.Element == xNode_Fsetvar.NodeType)
                                    {
                                        //＜ｆ－ｓｅｔ－ｖａｒ＞要素
                                        Givechapterandverse_Node cf_Fsetvar = new Givechapterandverse_NodeImpl(NamesNode.S_F_SET_VAR, ec_Fpath_Aatoolxml.Cur_Givechapterandverse);

                                        //＜ｆ－ｓｅｔ－ｖａｒ＞要素
                                        XmlElement xFsetvar = (XmlElement)xNode_Fsetvar;

                                        string sNamevar = xFsetvar.GetAttribute(PmNames.S_NAME_VAR.SName_Attr);
                                        string sFolder = xFsetvar.GetAttribute(PmNames.S_FOLDER.SName_Attr);
                                        string sValue = xFsetvar.GetAttribute(PmNames.S_VALUE.SName_Attr);
                                        string sDescription = xFsetvar.GetAttribute(PmNames.S_DESCRIPTION.SName_Attr);


                                        cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_NAME_VAR.SName_Pm, sNamevar, log_Reports);
                                        cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_FOLDER.SName_Pm, sFolder, log_Reports);
                                        cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_VALUE.SName_Pm, sValue, log_Reports);
                                        cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_DESCRIPTION.SName_Pm, sDescription, log_Reports);

                                        aatool_Editor.Dictionary_Fsetvar_Givechapterandverse.List_ChildGivechapterandverse.Add(cf_Fsetvar, log_Reports);
                                    }
                                }
                            }
                        }
                    }

                }
                catch (System.IO.FileNotFoundException ex)
                {
                    err_Excp = ex;
                    goto gt_Error_NothingFile;
                }
                catch (System.Exception ex)
                {
                    err_Excp = ex;
                    goto gt_Error_Exception;
                }
            }

            if (log_Reports.BSuccessful)
            {
                this.cur_Givechapterandverse = ec_Fpath_Aatoolxml.Cur_Givechapterandverse;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_DuplicatedEditorName:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー204！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("『ツール設定ファイル』（tool config）読み取り中に、何らかのエラーが発生しました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("もしかして？：　<" + NamesNode.S_EDITOR + ">要素の" + PmNames.S_NAME.SName_Attr + "属性が重複している？");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                //
                // 例外メッセージ
                s.Append(r.Message_SException(err_Excp));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NothingFile:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("Er:001;", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("『ツール設定ファイル』が見つかりません。");
                s.NewLine();
                s.NewLine();

                s.Append("ヒント");
                s.NewLine();
                s.Append("・ファイルが存在しない？");
                s.NewLine();
                s.Append("・『ツール設定ファイル』を、決まった場所「" + ValuesAttr.S_FPATHR_AATOOLXML + "」に置いていない？");
                s.NewLine();
                s.Append("・ファイル名が間違っている？");
                s.NewLine();
                s.NewLine();

                //ヒント
                s.Append(r.Message_SException(err_Excp));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }

            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー203！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("『ツール設定ファイル』（tool config）読み取り中に、何らかのエラーが発生しました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("もしかして？：　XMLのencoding指定が間違っている？この読取プログラムの期待するエンコードでないかも？");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                //
                // 例外メッセージ
                s.Append(r.Message_SException(err_Excp));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return;
        }

        //────────────────────────────────────────

        /// <summary>
        /// プロジェクトを返します。
        /// 該当がなければヌルを返します。
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="bRequired">該当がない場合にエラー扱いにするなら真</param>
        /// <returns></returns>
        public MemoryAatoolxml_Editor GetEditorByName(
            string sName_Editor, bool bRequired, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "GetEditorByName",log_Reports);
            //
            //

            MemoryAatoolxml_Editor result = null;

            if (log_Reports.BSuccessful)
            {
                if (this.dictionary_Editor.Dictionary_Item.ContainsKey(sName_Editor))
                {
                    result = this.dictionary_Editor.Dictionary_Item[sName_Editor];
                }
                else
                {
                    result = null;

                    if (bRequired)
                    {
                        // エラーとして扱います。
                        goto gt_Error_NotFound;
                    }

                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFound:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー002！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定されたプロジェクトは存在しませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("プロジェクト名=[");
                s.Append(sName_Editor);
                s.Append("]");
                s.Append(Environment.NewLine);

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 『ツール設定ファイル』に最初に記述されているプロジェクトを返します。
        /// 該当がなければヌルを返します。
        /// </summary>
        /// <param name="bRequired">該当がない場合にエラー扱いにするなら真</param>
        /// <returns></returns>
        public MemoryAatoolxml_Editor GetFirstEditor(
            bool bRequired, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "GetFirstEditor",log_Reports);
            //
            //

            MemoryAatoolxml_Editor result = null;

            foreach (MemoryAatoolxml_Editor aatool_Editor in this.Dictionary_Editor.Dictionary_Item.Values)
            {
                result = aatool_Editor;
                break;
            }

            if (null == result)
            {
                if (bRequired)
                {
                    // エラーとして扱います。
                    goto gt_Error_NothingEditor;
                }
            }

            goto gt_EndMethod;
            //
            //
        gt_Error_NothingEditor:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("Er:002;", log_Method);

                StringBuilder sb = new StringBuilder();
                sb.Append("『ツール設定ファイル』に、<" + NamesNode.S_EDITOR + ">要素が１つも記述されていませんでした。");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                r.SMessage = sb.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// デフォルト・プロジェクト名が指定されていれば、デフォルト・プロジェクトを返す。
        ///
        /// デフォルト・プロジェクト名が指定されていない場合、
        /// ツール設定ファイルの最初に記述されているプロジェクトを返す。
        /// 
        /// 該当がなければヌルを返します。
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        public MemoryAatoolxml_Editor GetDefaultEditor(
            bool bRequired, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "GetDefaultEditor",log_Reports);
            //
            //

            MemoryAatoolxml_Editor aatool_DefaultEditor = null;

            string sDefaultProjectName = this.SDefaultEditor.Trim();
            if ("" != sDefaultProjectName)
            {
                aatool_DefaultEditor = this.GetEditorByName(sDefaultProjectName, bRequired, log_Reports);
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }
            else
            {
                aatool_DefaultEditor = this.GetFirstEditor(bRequired, log_Reports);
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return aatool_DefaultEditor;
        }

        //────────────────────────────────────────
        #endregion





        #region プロパティー
        //────────────────────────────────────────

        private string sDefaultEditor;

        /// <summary>
        /// デフォルトで選択されているプロジェクトの名前
        /// </summary>
        public string SDefaultEditor
        {
            get
            {
                return sDefaultEditor;
            }
            set
            {
                sDefaultEditor = value;
            }
        }

        //────────────────────────────────────────

        private Dictionary_AatoolxmlEditor dictionary_Editor;

        /// <summary>
        /// project要素の名前つきリスト
        /// </summary>
        public Dictionary_AatoolxmlEditor Dictionary_Editor
        {
            get
            {
                return dictionary_Editor;
            }
            set
            {
                dictionary_Editor = value;
            }
        }

        //────────────────────────────────────────

        private Givechapterandverse_Node cur_Givechapterandverse;

        /// <summary>
        /// 利用者に、修正箇所を伝える情報。
        /// 
        /// 基本的に、LoadFileを使ったときに引数に入れられるファイルパスが入る。
        /// </summary>
        public Givechapterandverse_Node Cur_Givechapterandverse
        {
            get
            {
                return cur_Givechapterandverse;
            }
            set
            {
                cur_Givechapterandverse = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
