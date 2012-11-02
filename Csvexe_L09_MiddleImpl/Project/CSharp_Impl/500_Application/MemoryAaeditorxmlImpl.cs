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
    /// 
    /// (Model Of Project Config Implementation)
    /// </summary>
    public class MemoryAaeditorxmlImpl : MemoryAaeditorxml
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="tcProject"></param>
        public MemoryAaeditorxmlImpl(MemoryAaeditorxml_Editor aaeditor_Editor, MemoryApplication owner_MemoryApplication)
        {
            this.memoryAaeditorxml_Editor = aaeditor_Editor;

            this.Clear(owner_MemoryApplication);
        }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryAaeditorxmlImpl( MemoryApplication owner_MemoryApplication)
        {
            this.Clear(owner_MemoryApplication);
        }

        //────────────────────────────────────────

        /// <summary>
        /// クリアー
        /// </summary>
        public void Clear(MemoryApplication owner_MemoryApplication)
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "Clear", log_Reports_ThisMethod);
            //

            this.owner_MemoryApplication = owner_MemoryApplication;

            this.cur_Configurationtree = new Configurationtree_NodeImpl("<clear>", null);
            if (null == this.memoryAaeditorxml_Editor)
            {
                this.memoryAaeditorxml_Editor = new MemoryAaeditorxml_EditorImpl(null);
            }
            else
            {
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("「エディター設定ファイル・モデル」をクリアーします。");
                }

                this.memoryAaeditorxml_Editor.Clear();
            }


            goto gt_EndMethod;
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports_ThisMethod);
            log_Reports_ThisMethod.EndLogging(log_Method);
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// システム変数を、自動類推して、自動登録します。
        /// </summary>
        /// <param name="ec_Fopath_Editor"></param>
        /// <param name="log_Reports"></param>
        public void Load_AutoSystemVariable(
            Expression_Node_Filepath ec_Fopath_Editor,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "Load_AutoSystemVariable",log_Reports);
            //
            //

            // 「エディター・フォルダー」パス
            string sFopath_Editor = ec_Fopath_Editor.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

            //
            // Engine フォルダー
            //
            if (log_Reports.Successful)
            {

                string sNamevar = NamesVar.S_SP_ENGINE;
                string sValue = sFopath_Editor + System.IO.Path.DirectorySeparatorChar + NamesFile.S_ENGINE;
                Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("L09自動類推", ec_Fopath_Editor.Cur_Configuration);
                cf_Fpath.InitPath(sValue, log_Reports);
                this.Owner_MemoryApplication.MemoryVariables.PutFilepath(
                    sNamevar,
                    new Expression_Node_FilepathImpl(cf_Fpath),
                    false,//重複登録可。
                    log_Reports
                    );
            }

            //
            // Forms フォルダー
            //
            if (log_Reports.Successful)
            {
                string sNamevar = NamesVar.S_SP_FORMS;
                string sValue = sFopath_Editor + System.IO.Path.DirectorySeparatorChar + NamesFile.S_FORMS;
                Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("L09自動類推", ec_Fopath_Editor.Cur_Configuration);
                cf_Fpath.InitPath(sValue, log_Reports);
                this.Owner_MemoryApplication.MemoryVariables.PutFilepath(
                    sNamevar,
                    new Expression_Node_FilepathImpl(cf_Fpath),
                    false,//重複登録可。
                    log_Reports
                    );
            }

            //
            // Logs フォルダー
            //
            if (log_Reports.Successful)
            {
                string sNamevar = NamesVar.S_SP_LOGS;
                string sValue = sFopath_Editor + System.IO.Path.DirectorySeparatorChar + NamesFile.S_LOGS;
                Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("L09自動類推", ec_Fopath_Editor.Cur_Configuration);
                cf_Fpath.InitPath(sValue, log_Reports);
                this.Owner_MemoryApplication.MemoryVariables.PutFilepath(
                    sNamevar,
                    new Expression_Node_FilepathImpl(cf_Fpath),
                    false,//重複登録可。
                    log_Reports
                    );
            }

            //
            // Aa_Files.csv ファイル
            //
            if (log_Reports.Successful)
            {
                string sNamevar = NamesVar.S_SP_FILES;
                string sValue = sFopath_Editor + System.IO.Path.DirectorySeparatorChar + NamesFile.S_ENGINE + System.IO.Path.DirectorySeparatorChar + NamesFile.S_AA_FILES_CSV;
                Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("L09自動類推", ec_Fopath_Editor.Cur_Configuration);
                cf_Fpath.InitPath(sValue, log_Reports);
                this.Owner_MemoryApplication.MemoryVariables.PutFilepath(
                    sNamevar,
                    new Expression_Node_FilepathImpl(cf_Fpath),
                    false,//重複登録可。
                    log_Reports
                    );

                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("「エディター設定ファイル」の Dic に S_SP_FILES を登録します。 sValue=[" + sValue + "]");
                }
            }

            goto gt_EndMethod;
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        /// <summary>
        /// ＜ｆ－ｓｅｔ－ｖａｒ＞読み込み。
        /// </summary>
        /// <param name="oProjectConfigFilePath"></param>
        public void LoadFile(
            Expression_Node_Filepath ec_Fopath_Editor,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "LoadFile1",log_Reports);
            //
            //

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole("「エディター設定ファイル」を読み込みます。システム変数の自動類推も行います。");
            }


            // 「エディター・フォルダー」パス
            string sFopath_Editor = ec_Fopath_Editor.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);


            Configurationtree_Node cf_Auto = null;
            if (log_Reports.Successful)
            {
                //
                // 「エディター・フォルダー」から、「Engine」「Forms」「Logs」のフォルダーパスを類推します。
                // これは「エディター設定ファイル」で上書き可能です。日本語フォルダー名に置き換えることもできます。
                //

                cf_Auto = new Configurationtree_NodeImpl("!ハードコーディング自動補完", null);//todo:親ノード
            }







            string sFpatha_AaEditorXml = "";
            if (log_Reports.Successful)
            {
                //
                // @Editor.xml へのファイルパス。
                //
                // 「エディター・フォルダー」パス　→　「@Editor.xml ファイルパス」へ変換。
                sFpatha_AaEditorXml = sFopath_Editor + System.IO.Path.DirectorySeparatorChar + NamesFile.S_AA_EDITOR_XML;
            }


            //
            // 変数の読取りを開始します。
            //
            Exception err_Exception;
            if (log_Reports.Successful)
            {
                XmlDocument xDoc = new XmlDocument();

                try
                {

                    // 正常時

                    xDoc.Load(sFpatha_AaEditorXml);

                    // ルート要素を取得
                    XmlElement xRoot = xDoc.DocumentElement;

                    // スクリプトファイルのバージョンチェック。（エディター設定ファイル）
                    ValuesAttr.Test_Codefileversion(
                        xRoot.GetAttribute(PmNames.S_CODEFILE_VERSION.Name_Attribute),
                        log_Reports,
                        new Configurationtree_NodeImpl(sFpatha_AaEditorXml, null),
                        NamesNode.S_CODEFILE_EDITOR
                        );


                    //＜ｆ－ｓｅｔ－ｖａｒ＞要素を列挙
                    System.Xml.XmlNodeList xNl_Fsetvar = xRoot.GetElementsByTagName(NamesNode.S_F_SET_VAR);

                    for (int nIndex_Fsetvar = 0; nIndex_Fsetvar < xNl_Fsetvar.Count; nIndex_Fsetvar++)
                    {
                        XmlNode xNode_Fsetvar = xNl_Fsetvar.Item(nIndex_Fsetvar);

                        if (XmlNodeType.Element == xNode_Fsetvar.NodeType)
                        {
                            // ＜ｆ－ｓｅｔ－ｖａｒ＞要素
                            XmlElement x_Fsetvar = (XmlElement)xNode_Fsetvar;
                            Configurationtree_NodeImpl s_Fsetvar = new Configurationtree_NodeImpl(NamesNode.S_F_SET_VAR, null);//todo:親ノード

                            string sNamevar = x_Fsetvar.GetAttribute(PmNames.S_NAME_VAR.Name_Attribute);
                            string sFolder = x_Fsetvar.GetAttribute(PmNames.S_FOLDER.Name_Attribute);
                            string sValue = x_Fsetvar.GetAttribute(PmNames.S_VALUE.Name_Attribute);
                            string sDescription = x_Fsetvar.GetAttribute(PmNames.S_DESCRIPTION.Name_Attribute);

                            s_Fsetvar.Dictionary_Attribute.Set(PmNames.S_NAME_VAR.Name_Pm, sNamevar, log_Reports);
                            s_Fsetvar.Dictionary_Attribute.Set(PmNames.S_FOLDER.Name_Pm, sFolder, log_Reports);
                            s_Fsetvar.Dictionary_Attribute.Set(PmNames.S_VALUE.Name_Pm, sValue, log_Reports);
                            s_Fsetvar.Dictionary_Attribute.Set(PmNames.S_DESCRIPTION.Name_Pm, sDescription, log_Reports);

                            this.MemoryAaeditorxml_Editor.Dictionary_Fsetvar_Configurationtree.List_Child.Add(s_Fsetvar, log_Reports);
                        }
                    }

                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    // エラー
                    err_Exception = ex;
                    goto gt_Error_DirectoryNotFound;
                }
                catch (System.Exception ex)
                {
                    // エラー
                    err_Exception = ex;
                    goto gt_Error_Exception;
                }

                //
                // 変数の読取りは終わった。
                //
            }


            //
            // @Editor.xml へのファイルパス。
            //
            if (log_Reports.Successful)
            {
                // 「エディター・フォルダー」パス　→　「@Editor.xml ファイルパス」へ変換。
                string sFpath_EditorXml = sFopath_Editor + System.IO.Path.DirectorySeparatorChar + NamesFile.S_AA_EDITOR_XML;

                this.cur_Configurationtree = new Configurationtree_NodeImpl("(L09Mid読取)", ec_Fopath_Editor.Cur_Configuration);
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_DirectoryNotFound:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー111！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定されたファイルパスを読み取れませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("『エディター設定ファイル』読み取り中。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("もしかして？：　ファイルパスを確認してください。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                //
                // ヒント
                s.Append(err_Exception.Message);

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー112！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("『エディター設定ファイル』読み取り中に、何らかのエラーが発生しました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("もしかして？：　XMLのencoding指定が間違っている？この読取プログラムの期待するエンコードでないかも？");
                s.Append(Environment.NewLine);
                s.Append("もしかして？：　それ以外の理由？");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                //
                // ヒント
                s.Append(err_Exception.Message);

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

        private MemoryAaeditorxml_Editor memoryAaeditorxml_Editor;

        /// <summary>
        /// プロジェクト要素。
        /// </summary>
        public MemoryAaeditorxml_Editor MemoryAaeditorxml_Editor
        {
            get
            {
                return memoryAaeditorxml_Editor;
            }
            set
            {
                memoryAaeditorxml_Editor = value;
            }
        }

        //────────────────────────────────────────
        #endregion



        }
}
