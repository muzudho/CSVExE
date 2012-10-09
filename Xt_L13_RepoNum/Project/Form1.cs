using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.RepoNum
{
    public partial class Form1 : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Form1()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 設定最新表示。（ただし、ロードは行わない）
        /// </summary>
        private void RefreshCnf()
        {
            // 報告者名
            this.pctxtUser.Text = this.Stamp.SUser;

            // 制作物のバージョン名
            this.pctxtVer.Text = this.Stamp.SVer;

            // 次の報告番号
            this.pctxtNum.Text = this.Stamp.Num.ToString();

            // ユーザー設定ファイルパス
            this.pctxtUserCnf.Text = this.Stamp.GetUserCnf();
            this.pctxtUserCnf.SelectionStart = this.pctxtUserCnf.Text.Length;

            // エンジン設定ファイルパス
            this.pctxtEngineCnf.Text = this.Engine.GetEngineCnf();
            this.pctxtEngineCnf.SelectionStart = this.pctxtEngineCnf.Text.Length;
        }

        /// <summary>
        /// 報告番号の最新表示。（ただし、ロードは行わない）
        /// </summary>
        private void RefreshNum()
        {
            // 次の報告番号
            this.pctxtNum.Text = this.Stamp.Num.ToString();
        }

        //────────────────────────────────────────

        private void Save()
        {
            string sErrorMsg;
            this.stamp.SaveUserCnf(out sErrorMsg);
            if ("" != sErrorMsg)
            {
                this.pctxtSaveStatus.Text = sErrorMsg;
            }
            else
            {
                StringBuilder s = new StringBuilder();
                DateTime now = System.DateTime.Now;//保存時刻
                s.Append("保存完了 ");
                s.Append(now.Hour);
                s.Append(":");
                s.Append(now.Minute);
                s.Append(":");
                s.Append(now.Second);

                this.pctxtSaveStatus.Text = s.ToString();
                this.pctxtStatusDescription.Text = s.ToString();
            }
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Form1_Load(object sender, EventArgs e)
        {
            this.stamp = new StampImpl();
            this.engine = new EngineImpl();

            //
            // ユーザー設定ファイル読取
            string sErrorMsg;
            stamp.LoadUserCnf(out sErrorMsg);
            if ("" != sErrorMsg)
            {
                goto error_read;
            }

            //
            // エンジン設定ファイル読取
            engine.LoadEngineCnf(out sErrorMsg);
            if ("" != sErrorMsg)
            {
                goto error_read;
            }

            //
            // 宛先タグ名のリスト
            foreach (TagElmImpl sTag in engine.TargetTagList)
            {
                this.pclstTarget.Items.Add(sTag);
            }

            //
            // ステータス_タグ名のリスト
            foreach (TagElmImpl sTag in engine.StatusTagList)
            {
                this.pclstStatus.Items.Add(sTag);
            }

            // 設定最新表示
            this.RefreshCnf();

            goto process_end;


            //
        // エラー
        error_read:
            {
                this.pctxtStamp.Text = sErrorMsg;
            }
            goto process_end;

            //
        //
        //
        //
        process_end:
            return;
        }

        //────────────────────────────────────────

        /// <summary>
        /// [最新表示]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcbtnLoad_Click(object sender, EventArgs e)
        {
            this.RefreshCnf();
        }

        //────────────────────────────────────────

        /// <summary>
        /// [設定保存]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcbtnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        /// <summary>
        /// [次の番号のスタンプを作る]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcbtnNext_Click(object sender, EventArgs e)
        {
            this.Stamp.Num++;
            this.RefreshNum();

            this.pctxtStamp.Text = this.Stamp.ToString();
            this.pctxtPng.Text = this.Stamp.ToPngName();
            Clipboard.SetText(this.pctxtStamp.Text);

            this.Save();
        }

        /// <summary>
        /// [クリップボードにコピー]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcbtnStampCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.pctxtStamp.Text);
        }

        /// <summary>
        /// [クリップボードにコピー]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcbtnPngCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.pctxtPng.Text);
        }

        /// <summary>
        /// 宛先タグを付ける
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pclstTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox pclst = (ListBox)sender;

            if (this.pclstTarget.SelectedIndex < 0)
            {
                this.stamp.STarget = "";
            }
            else
            {
                this.stamp.STarget = ((TagElmImpl)pclst.Items[pclst.SelectedIndex]).SValue;
            }

            this.pctxtStamp.Text = this.Stamp.ToString();
            this.pctxtPng.Text = this.Stamp.ToPngName();
            Clipboard.SetText(this.pctxtStamp.Text);
        }

        /// <summary>
        /// [ステータスタグを付ける]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pclstStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox pclst = (ListBox)sender;

            if (this.pclstStatus.SelectedIndex < 0)
            {
                this.stamp.SStatus = "";
                this.pctxtStatusDescription.Text = "";
            }
            else
            {
                TagElmImpl tag = (TagElmImpl)pclst.Items[pclst.SelectedIndex];
                this.stamp.SStatus = tag.SValue;
                this.pctxtStatusDescription.Text = tag.SDescription;
            }

            this.pctxtStamp.Text = this.Stamp.ToString();
            this.pctxtPng.Text = this.Stamp.ToPngName();
            Clipboard.SetText(this.pctxtStamp.Text);
        }

        /// <summary>
        /// [報告者名]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctxtUser_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            this.Stamp.SUser = pctxt.Text;
        }

        /// <summary>
        /// [制作物のバージョン番号]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctxtVer_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            this.Stamp.SVer = pctxt.Text;
        }

        /// <summary>
        /// [次の報告番号]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctxtNum_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int num = 0;
            int.TryParse(pctxt.Text, out num);
            this.Stamp.Num = num;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected StampImpl stamp;

        /// <summary>
        /// 報告スタンプ。
        /// </summary>
        public StampImpl Stamp
        {
            get
            {
                return stamp;
            }
        }

        //────────────────────────────────────────

        protected EngineImpl engine;

        /// <summary>
        /// エンジン。
        /// </summary>
        public EngineImpl Engine
        {
            get
            {
                return engine;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
