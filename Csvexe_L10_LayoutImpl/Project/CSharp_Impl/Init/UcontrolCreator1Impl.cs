using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;//Form

using Xenon.Syntax;//Log_TextIndented
using Xenon.Controls;
using Xenon.Middle;//Usercontrol
using Xenon.Expr;

namespace Xenon.Layout
{



    public class UsercontrolCreator1Impl : UsercontrolCreator1
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public UsercontrolCreator1Impl()
        {
            this.dictionary_UsercontrolCreator = new Dictionary<string, UsercontrolCreator2>();

            //
            // メイン・ウィンドウ
            this.dictionary_UsercontrolCreator.Add(NamesF.S_MAINWND,new UsercontrolCreator2_MainwndImpl());

            //
            // ウィンドウ
            this.dictionary_UsercontrolCreator.Add(NamesF.S_WND, new UsercontrolCreator2_WndImpl());

            //
            // タブ ペーン
            this.dictionary_UsercontrolCreator.Add(NamesF.S_TBP, new UsercontrolCreator2_TbpImpl());

            //
            // タブ ページ
            this.dictionary_UsercontrolCreator.Add(NamesF.S_TBG, new UsercontrolCreator2_TbgImpl());

            //
            // パネル
            this.dictionary_UsercontrolCreator.Add(NamesF.S_PNL, new UsercontrolCreator2_PnlImpl());

            //
            // エリアベース
            this.dictionary_UsercontrolCreator.Add(NamesF.S_ARA, new UsercontrolCreator2_AraImpl());

            //
            // テキストボックス
            this.dictionary_UsercontrolCreator.Add(NamesF.S_TXT, new UsercontrolCreator2_TxtImpl());

            //
            // 数上下ボックス
            this.dictionary_UsercontrolCreator.Add(NamesF.S_NUM, new UsercontrolCreator2_NumImpl());

            //
            // テキストエリア
            this.dictionary_UsercontrolCreator.Add(NamesF.S_TXA, new UsercontrolCreator2_TxaImpl());

            //
            // リストボックス
            this.dictionary_UsercontrolCreator.Add(NamesF.S_LST, new UsercontrolCreator2_LstImpl());

            //
            // ドロップ・ダウン・リスト・ボックス
            this.dictionary_UsercontrolCreator.Add(NamesF.S_DDL, new UsercontrolCreator2_DdlImpl());

            //
            // チェックボックス
            this.dictionary_UsercontrolCreator.Add(NamesF.S_CHK, new UsercontrolCreator2_ChkImpl());

            //
            // ラジオボタン
            this.dictionary_UsercontrolCreator.Add(NamesF.S_RDI, new UsercontrolCreator2_RdiImpl());

            //
            // ボタン
            this.dictionary_UsercontrolCreator.Add(NamesF.S_BTN, new UsercontrolCreator2_BtnImpl());

            //
            // ラベル
            this.dictionary_UsercontrolCreator.Add(NamesF.S_LBL, new UsercontrolCreator2_LblImpl());

            //
            // 画像
            this.dictionary_UsercontrolCreator.Add(NamesF.S_PIC, new UsercontrolCreator2_PicImpl());

            //
            // スライダーバー
            this.dictionary_UsercontrolCreator.Add(NamesF.S_SLI, new UsercontrolCreator2_SliImpl());
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 『レイアウト設定ファイル』をもとに、
        /// コントロール（UserControl）を作成します。
        /// 
        /// 作成できなかった、または作成しなかった場合はヌル。
        /// 
        /// プロパティーの設定は、この時点では、名前だけ行います。
        /// </summary>
        /// <param name="fo_Record"></param>
        /// <param name="bRequired">未定義の設定があったときに、エラーにするなら真。</param>
        /// <param name="pg_Logging"></param>
        public Usercontrol Create(
            RecordUserformconfig fo_Record,
            bool bRequired_NotUse,// TODO:必ず真でいいのでは？
            MemoryApplication owner_MemoryApplication,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_LayoutImpl.Name_Library, this, "Create",pg_Logging);
            //
            //


            string sName_Control;
            fo_Record.TryGetString(out sName_Control, NamesFld.S_NAME, true, "", owner_MemoryApplication, pg_Logging);

            //
            // コントロール名　レコード→Ec
            Expression_Node_StringImpl ec_Name_Control = new Expression_Node_StringImpl(null,fo_Record.Parent_TableUserformconfig.Cur_Configurationtree);
            ec_Name_Control.AppendTextNode(
                sName_Control,
                fo_Record.Parent_TableUserformconfig.Cur_Configurationtree,
                pg_Logging
                );


            Usercontrol ucontrol = null;

            string sType_Control;
            fo_Record.TryGetString(out sType_Control, NamesFld.S_TYPE, true, "", owner_MemoryApplication, pg_Logging);
            if (null == sType_Control)
            {
                goto gt_Error_Type;
            }
            else if (!this.Dictionary_UsercontrolCreator.ContainsKey(sType_Control))//TODO:設定ミス時への対応。フィールド名がヌル？
            {
                goto gt_Error_FName;
            }

            UsercontrolCreator2 uctCreator = this.Dictionary_UsercontrolCreator[sType_Control];
            ucontrol = uctCreator.Perform(ec_Name_Control, owner_MemoryApplication);


            if (null != ucontrol)
            {
                // ヌル オブジェクトを設定。
                ucontrol.ControlCommon.Expression_Control = new Expression_ControlImpl(
                    null,
                    new Configurationtree_NodeImpl(NamesNode.S_HARDCODING_CONTROL, null),
                    ucontrol,
                    owner_MemoryApplication
                    );


                ucontrol.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;
            }
            else
            {
                goto gt_Error_NullUsercontrol;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullUsercontrol:
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー356！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("ucontrolがヌルでした。");
                s.Newline();
                s.Newline();

                // ヒント
                s.Append(r.Message_Configurationtree(fo_Record.Parent_TableUserformconfig.Cur_Configurationtree));

                r.Message = s.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Type:
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー355！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("コントロールの型が指定されていません。");
                s.Newline();
                s.Newline();

                s.Append("　『レイアウト設定』をもとに、コントロールを作成しているときに、");
                s.Newline();
                s.Append("　エラーが発生しました。");
                s.Newline();


                // ヒント
                s.Append(r.Message_Configurationtree(fo_Record.Parent_TableUserformconfig.Cur_Configurationtree));

                r.Message = s.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_FName:
            // テーブルタイプが「Form」で、"TREE" フィールドがないとき。
            // （Form_lstタイプには、TREEフィールドは要らない）
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー354！", pg_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("　『レイアウト設定』をもとに、コントロールを作成しているときに、");
                t.Newline();
                t.Append("　エラーが発生しました。");
                t.Newline();
                t.Newline();

                t.Append("　　指定の型=[");
                t.Append(sType_Control);
                t.Append("]は未定義のコントロールの型です。");

                // ヒント
                t.Append(r.Message_Configurationtree(fo_Record.Parent_TableUserformconfig.Cur_Configurationtree));

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
            return ucontrol;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<string, UsercontrolCreator2> dictionary_UsercontrolCreator;

        /// <summary>
        /// コントロールを生成するオブジェクトのディクショナリー。
        /// </summary>
        public Dictionary<string, UsercontrolCreator2> Dictionary_UsercontrolCreator
        {
            get
            {
                return dictionary_UsercontrolCreator;
            }
            set
            {
                dictionary_UsercontrolCreator = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
