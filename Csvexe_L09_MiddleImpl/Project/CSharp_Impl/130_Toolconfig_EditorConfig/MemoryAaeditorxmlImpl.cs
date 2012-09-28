﻿using System;
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
        public MemoryAaeditorxmlImpl(MemoryAaeditorxml_Editor aaeditor_Editor)
        {
            this.cur_Givechapterandverse = new Givechapterandverse_NodeImpl( "<init>", null);
            this.memoryAaeditorxml_Editor = aaeditor_Editor;
        }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryAaeditorxmlImpl()
        {
            this.cur_Givechapterandverse = new Givechapterandverse_NodeImpl( "<init>", null);
            this.memoryAaeditorxml_Editor = new MemoryAaeditorxml_EditorImpl(null);
        }

        //────────────────────────────────────────

        /// <summary>
        /// クリアー
        /// </summary>
        public void Clear(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "Clear",log_Reports);
            //

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole("「エディター設定ファイル・モデル」をクリアーします。");
            }

            this.cur_Givechapterandverse = new Givechapterandverse_NodeImpl("<clear>", null);
            this.memoryAaeditorxml_Editor.Clear();


            goto gt_EndMethod;
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// システム変数を、自動類推して、自動登録します。
        /// </summary>
        /// <param name="ec_Fopath_Editor"></param>
        /// <param name="moApplication"></param>
        /// <param name="log_Reports"></param>
        public void Load_AutoSystemVariable(
            Expression_Node_Filepath ec_Fopath_Editor,
            MemoryApplication moApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "Load_AutoSystemVariable",log_Reports);
            //
            //

            // 「エディター・フォルダー」パス
            string sFopath_Editor = ec_Fopath_Editor.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

            //
            // Engine フォルダー
            //
            if (log_Reports.BSuccessful)
            {

                string sNamevar = NamesVar.S_SP_ENGINE;
                string sValue = sFopath_Editor + System.IO.Path.DirectorySeparatorChar + NamesFile.S_ENGINE;
                Givechapterandverse_Filepath cf_Fpath = new Givechapterandverse_FilepathImpl("L09自動類推", ec_Fopath_Editor.Cur_Givechapterandverse);
                cf_Fpath.InitPath(sValue, log_Reports);
                moApplication.MemoryVariables.PutFilepath(
                    sNamevar,
                    new Expression_Node_FilepathImpl(cf_Fpath),
                    false,//重複登録可。
                    log_Reports
                    );
            }

            //
            // Forms フォルダー
            //
            if (log_Reports.BSuccessful)
            {
                string sNamevar = NamesVar.S_SP_FORMS;
                string sValue = sFopath_Editor + System.IO.Path.DirectorySeparatorChar + NamesFile.S_FORMS;
                Givechapterandverse_Filepath cf_Fpath = new Givechapterandverse_FilepathImpl("L09自動類推", ec_Fopath_Editor.Cur_Givechapterandverse);
                cf_Fpath.InitPath(sValue, log_Reports);
                moApplication.MemoryVariables.PutFilepath(
                    sNamevar,
                    new Expression_Node_FilepathImpl(cf_Fpath),
                    false,//重複登録可。
                    log_Reports
                    );
            }

            //
            // Logs フォルダー
            //
            if (log_Reports.BSuccessful)
            {
                string sNamevar = NamesVar.S_SP_LOGS;
                string sValue = sFopath_Editor + System.IO.Path.DirectorySeparatorChar + NamesFile.S_LOGS;
                Givechapterandverse_Filepath cf_Fpath = new Givechapterandverse_FilepathImpl("L09自動類推", ec_Fopath_Editor.Cur_Givechapterandverse);
                cf_Fpath.InitPath(sValue, log_Reports);
                moApplication.MemoryVariables.PutFilepath(
                    sNamevar,
                    new Expression_Node_FilepathImpl(cf_Fpath),
                    false,//重複登録可。
                    log_Reports
                    );
            }

            //
            // Aa_Files.csv ファイル
            //
            if (log_Reports.BSuccessful)
            {
                string sNamevar = NamesVar.S_SP_FILES;
                string sValue = sFopath_Editor + System.IO.Path.DirectorySeparatorChar + NamesFile.S_ENGINE + System.IO.Path.DirectorySeparatorChar + NamesFile.S_AA_FILES_CSV;
                Givechapterandverse_Filepath cf_Fpath = new Givechapterandverse_FilepathImpl("L09自動類推", ec_Fopath_Editor.Cur_Givechapterandverse);
                cf_Fpath.InitPath(sValue, log_Reports);
                moApplication.MemoryVariables.PutFilepath(
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
            MemoryApplication moApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "LoadFile1",log_Reports);
            //
            //

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole("「エディター設定ファイル」を読み込みます。システム変数の自動類推も行います。");
            }


            // 「エディター・フォルダー」パス
            string sFopath_Editor = ec_Fopath_Editor.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);


            Givechapterandverse_Node cf_Auto = null;
            if (log_Reports.BSuccessful)
            {
                //
                // 「エディター・フォルダー」から、「Engine」「Forms」「Logs」のフォルダーパスを類推します。
                // これは「エディター設定ファイル」で上書き可能です。日本語フォルダー名に置き換えることもできます。
                //

                cf_Auto = new Givechapterandverse_NodeImpl("!ハードコーディング自動補完", null);//todo:親ノード
            }







            string sFpatha_AaEditorXml = "";
            if (log_Reports.BSuccessful)
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
            if (log_Reports.BSuccessful)
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
                        xRoot.GetAttribute(PmNames.S_CODEFILE_VERSION.SName_Attr),
                        log_Reports,
                        new Givechapterandverse_NodeImpl(sFpatha_AaEditorXml, null),
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
                            Givechapterandverse_NodeImpl s_Fsetvar = new Givechapterandverse_NodeImpl(NamesNode.S_F_SET_VAR, null);//todo:親ノード

                            string sNamevar = x_Fsetvar.GetAttribute(PmNames.S_NAME_VAR.SName_Attr);
                            string sFolder = x_Fsetvar.GetAttribute(PmNames.S_FOLDER.SName_Attr);
                            string sValue = x_Fsetvar.GetAttribute(PmNames.S_VALUE.SName_Attr);
                            string sDescription = x_Fsetvar.GetAttribute(PmNames.S_DESCRIPTION.SName_Attr);

                            s_Fsetvar.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_NAME_VAR.SName_Pm, sNamevar, log_Reports);
                            s_Fsetvar.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_FOLDER.SName_Pm, sFolder, log_Reports);
                            s_Fsetvar.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_VALUE.SName_Pm, sValue, log_Reports);
                            s_Fsetvar.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_DESCRIPTION.SName_Pm, sDescription, log_Reports);

                            this.MemoryAaeditorxml_Editor.Dictionary_Fsetvar_Givechapterandverse.List_ChildGivechapterandverse.Add(s_Fsetvar, log_Reports);
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
            if (log_Reports.BSuccessful)
            {
                // 「エディター・フォルダー」パス　→　「@Editor.xml ファイルパス」へ変換。
                string sFpath_EditorXml = sFopath_Editor + System.IO.Path.DirectorySeparatorChar + NamesFile.S_AA_EDITOR_XML;

                this.cur_Givechapterandverse = new Givechapterandverse_NodeImpl("(L09Mid読取)",ec_Fopath_Editor.Cur_Givechapterandverse);
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_DirectoryNotFound:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
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

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
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
        #endregion

        

        #region プロパティー
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
