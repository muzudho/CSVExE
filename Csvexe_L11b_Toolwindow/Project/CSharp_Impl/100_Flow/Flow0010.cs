using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//Control

using Xenon.Syntax;

namespace Xenon.Toolwindow
{
    /// <summary>
    /// [エディター設定ファイルへのパス]の値が変更されたとき
    /// </summary>
    public class Flow0010
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// tool-saveファイルへの絶対パスを取得します。
        /// 取得できなかった場合、空文字列を返します。
        /// </summary>
        /// <returns></returns>
        public string GetFilepathabsolute(
            string sFpath,
            bool bRequired,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Toolwindow.Name_Library, this, "GetFilepathabsolute", pg_Logging);

            string sFpatha_xml;

            if (pg_Logging.Successful)
            {
                // 正常時

                // ツールの設定のファイルパス
                Configurationtree_Node parent_Cf = new Configurationtree_NodeImpl("!ハードコーディング_Flow0010#GetFileAbsPath", null);

                Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L09TcDlg_1", parent_Cf);
                cf_Fpath.InitPath(
                    sFpath,
                    pg_Logging
                    );
                if (!pg_Logging.Successful)
                {
                    // 既エラー。
                    sFpatha_xml = "";
                    goto gt_EndMethod;
                }

                Expression_Node_Filepath ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath);
                sFpatha_xml = ec_Fpath.Execute_OnExpressionString(
                    EnumHitcount.Unconstraint, pg_Logging);
                if (!pg_Logging.Successful)
                {
                    // 既エラー。
                    sFpatha_xml = "";
                    goto gt_EndMethod;
                }
            }
            else
            {
                // 既エラー。
                sFpatha_xml = "";
                goto gt_EndMethod;
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
            return sFpatha_xml;
        }

        //────────────────────────────────────────
        #endregion



    }
}
