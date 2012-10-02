using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.MiddleImpl
{
    public class MemoryLogwriterImpl : MemoryLogwriter
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// エラーログを出力します。（エラーが発生したときに呼び出してください）
        /// </summary>
        /// <param oVariableName="output_d_Logging"></param>
        /// <param name="runningHintName">このメソッドが呼び出された場所が分かるようなヒント。</param>
        public void WriteErrorLog(
            MemoryApplication moApplication,
            Log_Reports log_ReportsBuffer_Output,
            string sRunningHintName
                )
        {

            Log_Method log_Method = new Log_MethodImpl(0);
            // メタ。
            Log_Reports log_Reports_Meta = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "WriteErrorLog",log_Reports_Meta);

            //
            //
            //
            //

            //
            // 書き出すテキスト
            //
            string sOutput;
            {
                sOutput = log_ReportsBuffer_Output.ToMessage();
            }

            //
            // 書き出し先ファイルへのパス
            //
            Expression_Node_Filepath ec_Fpath;
            if (log_Reports_Meta.Successful)
            {
                XenonName o_Name_Variable = new XenonNameImpl(NamesVar.S_SP_LOGS, new Configurationtree_NodeImpl("!ハードコーディング_MoOpyopyoImpl#WriteLog", null));

                // 変数名。
                Expression_Leaf_StringImpl ec_Atom = new Expression_Leaf_StringImpl(null, o_Name_Variable.Cur_Configurationtree);
                ec_Atom.SetString(
                    o_Name_Variable.SValue,
                    log_Reports_Meta
                );

                // ファイルパス。
                log_Reports_Meta.Log_Callstack.Push(log_Method, "③");
                ec_Fpath = moApplication.MemoryVariables.GetExpressionfilepathByVariablename(
                    ec_Atom,
                    true,
                    log_Reports_Meta
                    );
                log_Reports_Meta.Log_Callstack.Pop(log_Method, "③");
            }
            else
            {
                ec_Fpath = null;
            }


            //
            // ファイルの書き出し
            //
            string err_SFpatha;
            {
                //this.WriteErrorLog2(
                //    sOutput,
                //    ec_Fpath,
                //    log_Reports_Meta,
                //    sRunningHintName_NotUse
                //    );


                string sFpatha;

                if (log_Reports_Meta.Successful)
                {
                    // フォルダーへの絶対パス
                    string sFopatha_Logs = ec_Fpath.Execute_OnExpressionString(
                        Request_SelectingImpl.Unconstraint, log_Reports_Meta);
                    if (!log_Reports_Meta.Successful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }

                    Expression_Node_Filepath ec_Fpath2;
                    {
                        Configurationtree_Node parent_Cf = new Configurationtree_NodeImpl("!ハードコーディング_MoOpyopyoImpl#WriteLog", null);

                        Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L09Mid_6", parent_Cf);
                        cf_Fpath.InitPath(
                            sFopatha_Logs,
                            "error-log.txt",
                            log_Reports_Meta
                            );
                        if (!log_Reports_Meta.Successful)
                        {
                            // 既エラー。
                            goto gt_EndMethod;
                        }

                        ec_Fpath2 = new Expression_Node_FilepathImpl(cf_Fpath);
                    }

                    sFpatha = ec_Fpath2.Execute_OnExpressionString(
                        Request_SelectingImpl.Unconstraint, log_Reports_Meta);
                }
                else
                {
                    sFpatha = "＜エラー＞";
                }


                if (log_Reports_Meta.Successful)
                {

                    try
                    {
                        System.IO.File.WriteAllText(sFpatha, sOutput, Encoding.Default);

                        //#正常な、エラー出力
                        StringBuilder sb = new StringBuilder();
                        sb.Append("エラーが発生しました！");
                        sb.Append(Environment.NewLine);
                        sb.Append(Environment.NewLine);
                        sb.Append("アプリケーションは正常に動作していない可能性があります。");
                        sb.Append(Environment.NewLine);
                        sb.Append(Environment.NewLine);
                        sb.Append("エラーログを書き出しました。");
                        sb.Append(Environment.NewLine);
                        sb.Append("[");
                        sb.Append(sFpatha);
                        sb.Append("]");
                        sb.Append(Environment.NewLine);
                        sb.Append(Environment.NewLine);
                        sb.Append("このアプリケーションの開発者にエラーログをお知らせください。");

                        MessageBox.Show(
                            sb.ToString(),
                            "▲エラーが発生しました！ " + Info_MiddleImpl.Name_Library + ":" + this.GetType().Name + "#WriteErrorLog");
                    }
                    catch (Exception)
                    {
                        err_SFpatha = sFpatha;
                        goto gt_Error_CanNotWriteErrorLog;
                    }
                }
                else
                {
                    // メタのロガーが、エラーを検知。
                    goto gt_Error_MetaNotSuccessful;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_CanNotWriteErrorLog:
            {
                StringBuilder s = new StringBuilder();

                s.Append("▲312！エラーが発生しましたが、エラーログを出力できませんでした。（");
                s.Append(Info_MiddleImpl.Name_Library);
                s.Append("）　ファイルパス＝[");
                s.Append(err_SFpatha);
                s.Append("]");

                MessageBox.Show(sOutput, s.ToString());
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_MetaNotSuccessful:
            {
                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("エラーが発生しましたが、エラーログを出力できませんでした。");
                s.Newline();
                s.Newline();

                s.Append("もしかして？");
                s.Newline();

                s.Append("　・設定ファイルの「エラーログの書出し先」を読み込む前に、エラーが出てしまった？");
                s.Newline();
                s.Append("　・「ログファイル書き出し先」は指定されていますか？");
                s.Newline();
                s.Newline();

                s.Append("実行箇所ヒント：");
                s.Newline();
                s.Append("　・");
                s.Append(sRunningHintName);
                s.Newline();
                s.Newline();

                MessageBox.Show(
                    s.ToString(), //sOutput,
                    "▲エラー！【Er:101;】（" + log_Method.Fullname + "）");
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports_Meta);
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
        #endregion



    }
}
