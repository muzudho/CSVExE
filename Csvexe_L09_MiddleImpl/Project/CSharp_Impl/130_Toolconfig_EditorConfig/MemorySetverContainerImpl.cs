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
    /// Aa_Tool.xml/＜editor＞要素と、Aa_Editor.xml/＜ルート＞要素がこれにあたる。
    /// </summary>
    public abstract class MemorySetverContainerImpl : MemorySetvarContainer
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="parent_Cf">親設定。</param>
        public MemorySetverContainerImpl(Givechapterandverse_Node parent_Cf)
        {
            this.parent_Givechapterandverse = parent_Cf;
            this.dictionary_Fsetvar_Givechapterandverse = new Dictionary_Fsetvar_GivechapterandverseImpl();
        }

        //────────────────────────────────────────

        /// <summary>
        /// クリアー。
        /// </summary>
        public abstract void Clear();

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 『Aa_Tool.xml/＜editor＞要素』または、『Aa_Editor.xml/＜ルート＞要素』を読み取ります。
        /// ＜ｆ－ｓｅｔ－ｖａｒ＞を読み取った場合、逐次、変数モデルに追加していきます。
        /// </summary>
        public void LoadFile_Aaxml(
            Expression_Node_Filepath ec_Fpath_Aaxml,
            MemoryVariables moVariables,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "LoadFile_Aaxml",log_Reports);

            string sFpatha;
            {
                sFpatha = ec_Fpath_Aaxml.Execute_OnExpressionString(
                    Request_SelectingImpl.Unconstraint,
                    log_Reports//out sErrorMsg
                    );//絶対ファイルパス
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }

            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();

            Exception err_Excp;
            try
            {

                xDoc.Load(sFpatha);

                // ルート要素を取得
                System.Xml.XmlElement xRoot = xDoc.DocumentElement;


                // ＜ｆ－ｓｅｔ－ｖａｒ＞要素を列挙
                XmlNodeList xNl_Fsetvar = xRoot.GetElementsByTagName(NamesNode.S_F_SET_VAR);

                foreach (XmlNode xNode_Fsetvar in xNl_Fsetvar)
                {
                    if (XmlNodeType.Element == xNode_Fsetvar.NodeType)
                    {
                        //＜ｆ－ｓｅｔ－ｖａｒ＞要素
                        XmlElement xFsetvar = (XmlElement)xNode_Fsetvar;

                        //ｎａｍｅ－ｖａｒ属性
                        string sNamevar = xFsetvar.GetAttribute(PmNames.S_NAME_VAR.SName_Attr);

                        //ｆｏｌｄｅｒ属性
                        string sFolder = xFsetvar.GetAttribute(PmNames.S_FOLDER.SName_Attr);

                        //ｖａｌｕｅ属性
                        string sValue = xFsetvar.GetAttribute(PmNames.S_VALUE.SName_Attr);

                        //ｄｅｓｃｒｉｐｔｉｏｎ属性
                        string sDescription = xFsetvar.GetAttribute(PmNames.S_DESCRIPTION.SName_Attr);

                        Givechapterandverse_Node cf_Fsetvar = new Givechapterandverse_NodeImpl(NamesNode.S_F_SET_VAR,
                            null//todo:親ノード
                            );
                        cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_NAME_VAR.SName_Pm, sNamevar, log_Reports);
                        cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_FOLDER.SName_Pm, sFolder, log_Reports);
                        cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_VALUE.SName_Pm, sValue, log_Reports);
                        cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_DESCRIPTION.SName_Pm, sDescription, log_Reports);


                        this.Dictionary_Fsetvar_Givechapterandverse.List_ChildGivechapterandverse.Add(cf_Fsetvar, log_Reports);

                        //変数への追加
                        {
                            if (
                                NamesVar.Test_Filepath(sNamevar)
                                )
                            {
                                // ファイルパスの場合
                                Givechapterandverse_Filepath cf_Fpath = new Givechapterandverse_FilepathImpl("name-var=[" + sNamevar + "]", ec_Fpath_Aaxml.Cur_Givechapterandverse);
                                cf_Fpath.InitPath(
                                    sValue,
                                    log_Reports
                                    );
                                if ("" != sFolder)
                                {
                                    Expression_Node_Filepath ec_Folder = moVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(sFolder, ec_Fpath_Aaxml, cf_Fsetvar), true, log_Reports);

                                    if (log_Reports.BSuccessful)
                                    {
                                        cf_Fpath.SetSDirectory_Base(
                                            ec_Folder.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports)
                                            //sFolder
                                            );
                                    }
                                }

                                if (log_Reports.BSuccessful)
                                {
                                    Expression_Node_Filepath ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath);
                                    moVariables.PutFilepath(
                                        sNamevar,
                                        ec_Fpath,
                                        true,
                                        log_Reports
                                        );
                                }
                            }
                            else
                            {
                                // ファイルパスでない場合
                                moVariables.PutString(
                                    sNamevar,
                                    sValue,
                                    log_Reports
                                    );
                            }

                        }
                    }


                    if (!log_Reports.BSuccessful)
                    {
                        //既エラー
                        break;
                    }
                }




                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }
            catch (System.IO.IOException ex)
            {
                // 既エラー。
                err_Excp = ex;
                goto gt_Error_IOException;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_IOException:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー283！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("エディター設定ファイルが見つかりません。：" + err_Excp.Message);

                //ヒント
                s.Append(r.Message_Givechapterandverse(ec_Fpath_Aaxml.Cur_Givechapterandverse));

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
        /// ＜ｆ－ｓｅｔ－ｖａｒ＞要素の名前を指定して、値を取り出します。（ファイル・パスとします）
        /// 該当がなければヌルを返します。
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="bRequired">該当がない場合にエラー扱いにするなら真</param>
        /// <returns></returns>
        public Expression_Node_Filepath GetFilepathByFsetvarname(
            string sNamevar_Expected,
            MemoryVariables moVariables,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "GetFilepathByFsetvarname",log_Reports);
            //
            //

            Expression_Node_Filepath ec_Fpath = null;

            //各＜ｆ－ｓｅｔ－ｖａｒ＞
            this.Dictionary_Fsetvar_Givechapterandverse.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node s_Fsetvar, ref bool bBreak)
            {
                //ｎａｍｅ－ｖａｒ属性
                string sNamevar_Cur;
                s_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME_VAR, out sNamevar_Cur, true, log_Reports);

                if (sNamevar_Cur == sNamevar_Expected)
                {
                    string sFolder;
                    s_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_FOLDER, out sFolder, false, log_Reports);

                    string sValue;
                    s_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                    {
                        Givechapterandverse_Filepath cf_Fpath = new Givechapterandverse_FilepathImpl("『エディター設定ファイル』の[" + sNamevar_Expected + "]要素_L09Mid_2[" + sValue + "]", this.Parent_Givechapterandverse);
                        cf_Fpath.InitPath(
                            sValue,
                            log_Reports
                        );

                        if ("" != sFolder)
                        {
                            //フォルダーパス変数名の指定有り
                            Expression_Node_String ec_Namevar_Folder = new Expression_Leaf_StringImpl(sFolder, null, cf_Fpath);

                            log_Reports.Log_Callstack.Push(log_Method, "②");
                            Expression_Node_Filepath ec_Fpath_Folder = moVariables.GetExpressionfilepathByVariablename(ec_Namevar_Folder, true, log_Reports);
                            log_Reports.Log_Callstack.Pop(log_Method, "②");

                            if (log_Reports.BSuccessful)
                            {
                                string sDirectory = ec_Fpath_Folder.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                                if (log_Method.CanDebug(1))
                                {
                                    log_Method.WriteDebug_ToConsole("folder=[" + sFolder + "] directory=[" + sDirectory + "]");
                                }
                                cf_Fpath.SetSDirectory_Base(
                                    sDirectory
                                    );
                            }
                        }

                        if (!log_Reports.BSuccessful)
                        {
                            // 既エラー。
                            bBreak = true;
                            goto gt_EndMethod2;
                        }

                        ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath);
                    }
                }

                goto gt_EndMethod2;
                //
                //
            gt_EndMethod2:
                ;
            });



            if (null == ec_Fpath)
            {
                if (bRequired)
                {
                    // エラーとして扱います。
                    goto gt_Error_NotFoundFsetvar;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundFsetvar:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("Er:003;", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("次の要素は必要でしたが、記述されていませんでした。<" + NamesNode.S_EDITOR + ">要素の中に。");
                s.NewLine();
                s.NewLine();

                s.Append("<" + NamesNode.S_F_SET_VAR + " name=\"" + sNamevar_Expected + "\" >");
                s.NewLine();
                s.NewLine();

                s.Append("もしかして？");
                s.NewLine();

                s.Append("　・『設定ファイル』に、必要な内容が書けていない？");
                s.NewLine();

                s.Append("　・設定ファイル情報:");
                s.Append(r.Message_Givechapterandverse(this.Parent_Givechapterandverse));
                s.NewLine();
                s.NewLine();

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
            return ec_Fpath;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 内容をデバッグ出力。
        /// </summary>
        public void WriteDebug_ToConsole(Dictionary_Fsetvar_Givechapterandverse stDic_Project, Log_Reports log_Reports)
        {
            System.Console.WriteLine(this.GetType().Name + "#DebugWrite: 【デバッグ出力】 input要素の個数？=[" + stDic_Project.List_ChildGivechapterandverse.NCount + "]");

            stDic_Project.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node s_Fsetvar, ref bool bBreak)
            {
                string sNamevar;
                s_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME_VAR, out sNamevar, true, log_Reports);

                string sValue;
                s_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                string sDescription;
                s_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_DESCRIPTION, out sDescription, true, log_Reports);

                System.Console.WriteLine(this.GetType().Name + "#DebugWrite: 【デバッグ出力】 名=[" + sNamevar + "] value=[" + sValue + "] 説明=[" + sDescription + "]");
            });

        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected Dictionary_Fsetvar_Givechapterandverse dictionary_Fsetvar_Givechapterandverse;

        /// <summary>
        /// input要素の名前つきリスト
        /// </summary>
        public Dictionary_Fsetvar_Givechapterandverse Dictionary_Fsetvar_Givechapterandverse
        {
            get
            {
                return dictionary_Fsetvar_Givechapterandverse;
            }
            set
            {
                dictionary_Fsetvar_Givechapterandverse = value;
            }
        }

        //────────────────────────────────────────

        protected Givechapterandverse_Node parent_Givechapterandverse;

        /// <summary>
        /// 親要素。
        /// 
        /// 「ツール設定ファイル」なら MoToolConfig を返す。
        /// 「エディター設定ファイル」なら MoProjectConfig を返す。
        /// 
        /// Clearしたらヌルになる。
        /// 親要素がない場合もヌルになる。
        /// </summary>
        public Givechapterandverse_Node Parent_Givechapterandverse
        {
            get
            {
                return parent_Givechapterandverse;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}