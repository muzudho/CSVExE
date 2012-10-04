using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Xml;
using Xenon.Syntax;
using Xenon.Table;
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
        public MemoryAatoolxmlImpl(MemoryApplication owner_MemoryApplication)
        {
            this.Clear(owner_MemoryApplication);
        }

        /// <summary>
        /// new した直後の内容に戻します。
        /// </summary>
        public void Clear(MemoryApplication owner_MemoryApplication)
        {
            this.owner_MemoryApplication = owner_MemoryApplication;
            this.cur_Configurationtree = new Configurationtree_NodeImpl("<clear>", null);
            this.Name_DefaultEditor = "";

            if (null == this.dictionary_Editor)
            {
                this.dictionary_Editor = new Dictionary_AatoolxmlEditorImpl(this);
            }
            else
            {
                this.Dictionary_Editor.Dictionary_Item.Clear();
            }
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 定型処理。
        /// </summary>
        public void P101_LoadAatoolxml(
            Configurationtree_Node cf_CallerMethod,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "P101_LoadAatoolxml", log_Reports);
            //
            //

            this.Owner_MemoryApplication.MemoryAatoolxml.Clear(this.Owner_MemoryApplication);

            if (log_Reports.Successful)
            {
                // ツール設定ファイルへのパスは固定とします。
                Expression_Node_Filepath ec_Fpath;
                {
                    Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L09Mid_5", cf_CallerMethod);
                    cf_Fpath.InitPath(
                        ValuesAttr.S_FPATHR_AATOOLXML,
                        log_Reports);
                    if (!log_Reports.Successful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }

                    ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath);
                }

                this.Owner_MemoryApplication.MemoryAatoolxml.LoadFile(ec_Fpath, log_Reports);
                if (!log_Reports.Successful)
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
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "LoadFile",log_Reports);
            //

            Exception err_Excp;


            string sFpatha_Aatoolxml = "";
            if (log_Reports.Successful)
            {
                //
                // 『ツール設定』をクリアー。
                //
                this.Clear(this.Owner_MemoryApplication);

                sFpatha_Aatoolxml = ec_Fpath_Aatoolxml.Execute4_OnExpressionString(
                    EnumHitcount.Unconstraint,
                    log_Reports
                    );//絶対ファイルパス
            }

            if (log_Reports.Successful)
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
                        xRoot.GetAttribute(PmNames.S_CODEFILE_VERSION.Name_Attribute),
                        log_Reports,
                        new Configurationtree_NodeImpl(sFpatha_Aatoolxml, null),
                        NamesNode.S_CODEFILE_TOOL
                        );


                    if (log_Reports.Successful)
                    {
                        // デフォルト・エディター名
                        this.Name_DefaultEditor = xRoot.GetAttribute(PmNames.S_DEFAULT_EDITOR.Name_Attribute);

                        // エディター要素を列挙
                        System.Xml.XmlNodeList xNl_Editor = xRoot.GetElementsByTagName(NamesNode.S_EDITOR);

                        foreach (XmlNode x_EditorNode in xNl_Editor)
                        {
                            if (XmlNodeType.Element == x_EditorNode.NodeType)
                            {
                                //
                                // エディター要素
                                //
                                MemoryAatoolxml_Editor aatool_Editor = new MemoryAatoolxml_EditorImpl(this.cur_Configurationtree);

                                //
                                // エディター要素
                                //
                                XmlElement xEditor = (XmlElement)x_EditorNode;

                                // ツール設定ファイルに記載されている、エディター名
                                try
                                {
                                    aatool_Editor.Name = xEditor.GetAttribute(PmNames.S_NAME.Name_Attribute);

                                    this.Dictionary_Editor.Dictionary_Item.Add(aatool_Editor.Name, aatool_Editor);
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
                                        Configurationtree_Node cf_Fsetvar = new Configurationtree_NodeImpl(NamesNode.S_F_SET_VAR, ec_Fpath_Aatoolxml.Cur_Configurationtree);

                                        //＜ｆ－ｓｅｔ－ｖａｒ＞要素
                                        XmlElement xFsetvar = (XmlElement)xNode_Fsetvar;

                                        string sNamevar = xFsetvar.GetAttribute(PmNames.S_NAME_VAR.Name_Attribute);
                                        string sFolder = xFsetvar.GetAttribute(PmNames.S_FOLDER.Name_Attribute);
                                        string sValue = xFsetvar.GetAttribute(PmNames.S_VALUE.Name_Attribute);
                                        string sDescription = xFsetvar.GetAttribute(PmNames.S_DESCRIPTION.Name_Attribute);


                                        cf_Fsetvar.Dictionary_Attribute.Set(PmNames.S_NAME_VAR.Name_Pm, sNamevar, log_Reports);
                                        cf_Fsetvar.Dictionary_Attribute.Set(PmNames.S_FOLDER.Name_Pm, sFolder, log_Reports);
                                        cf_Fsetvar.Dictionary_Attribute.Set(PmNames.S_VALUE.Name_Pm, sValue, log_Reports);
                                        cf_Fsetvar.Dictionary_Attribute.Set(PmNames.S_DESCRIPTION.Name_Pm, sDescription, log_Reports);

                                        aatool_Editor.Dictionary_Fsetvar_Configurationtree.List_Child.Add(cf_Fsetvar, log_Reports);
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

            if (log_Reports.Successful)
            {
                this.cur_Configurationtree = ec_Fpath_Aatoolxml.Cur_Configurationtree;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_DuplicatedEditorName:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー204！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("『ツール設定ファイル』（tool config）読み取り中に、何らかのエラーが発生しました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("もしかして？：　<" + NamesNode.S_EDITOR + ">要素の" + PmNames.S_NAME.Name_Attribute + "属性が重複している？");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // 例外メッセージ
                s.Append(r.Message_SException(err_Excp));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NothingFile:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, ValuesAttr.S_FPATHR_AATOOLXML,log_Reports);
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Exception(err_Excp),log_Reports);

                this.Owner_MemoryApplication.CreateErrorReport( "Er:1;", tmpl, log_Reports );
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
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

                r.Message = s.ToString();
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
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "GetEditorByName",log_Reports);
            //
            //

            MemoryAatoolxml_Editor result = null;

            if (log_Reports.Successful)
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
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー002！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定されたプロジェクトは存在しませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("プロジェクト名=[");
                s.Append(sName_Editor);
                s.Append("]");
                s.Append(Environment.NewLine);

                r.Message = s.ToString();
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
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "GetFirstEditor",log_Reports);
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
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("Er:002;", log_Method);

                StringBuilder sb = new StringBuilder();
                sb.Append("『ツール設定ファイル』に、<" + NamesNode.S_EDITOR + ">要素が１つも記述されていませんでした。");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                r.Message = sb.ToString();
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
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "GetDefaultEditor",log_Reports);
            //
            //

            MemoryAatoolxml_Editor aatool_DefaultEditor = null;

            string sDefaultProjectName = this.Name_DefaultEditor.Trim();
            if ("" != sDefaultProjectName)
            {
                aatool_DefaultEditor = this.GetEditorByName(sDefaultProjectName, bRequired, log_Reports);
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }
            else
            {
                aatool_DefaultEditor = this.GetFirstEditor(bRequired, log_Reports);
                if (!log_Reports.Successful)
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

        private MemoryApplication owner_MemoryApplication;

        /// <summary>
        /// このオブジェクトを所有するオブジェクト。
        /// </summary>
        public MemoryApplication Owner_MemoryApplication
        {
            get
            {
                return owner_MemoryApplication;
            }
            set
            {
                owner_MemoryApplication = value;
            }
        }

        //────────────────────────────────────────

        private string name_DefaultEditor;

        /// <summary>
        /// デフォルトで選択されているプロジェクトの名前
        /// </summary>
        public string Name_DefaultEditor
        {
            get
            {
                return name_DefaultEditor;
            }
            set
            {
                name_DefaultEditor = value;
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

        private Configurationtree_Node cur_Configurationtree;

        /// <summary>
        /// 利用者に、修正箇所を伝える情報。
        /// 
        /// 基本的に、LoadFileを使ったときに引数に入れられるファイルパスが入る。
        /// </summary>
        public Configurationtree_Node Cur_Configurationtree
        {
            get
            {
                return cur_Configurationtree;
            }
            set
            {
                cur_Configurationtree = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
