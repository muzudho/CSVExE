using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using Xenon.Syntax;
using Xenon.Middle;//HValidator

namespace Xenon.Controls
{
    /// <summary>
    /// ラベルのカスタム・コントロール。
    /// </summary>
    public partial class CustomcontrolPicturebox : PictureBox, Customcontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public CustomcontrolPicturebox()
        {
            this.controlCommon__ = new ControlCommonImpl();

            this.list_Expressionv_Validator = new List<Expressionv_Validator_Old>();
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロール用共通メソッド。
        /// </summary>
        public void Clear()
        {
            // ．ＩｍａｇｅＬｏｃａｔｉｏｎは、画像読込みが遅いので使わない。
            this.Image = null;
        }

        /// <summary>
        /// イベントハンドラーを全て除去します。
        /// </summary>
        public void ClearAllEventhandlers(Log_Reports log_Reports)
        {
            Remover_AllEventhandlers remover = new Remover_AllEventhandlersImpl(
                this,
                this.ControlCommon.Owner_MemoryApplication,
                log_Reports
                );

            remover.Suppress(
                this.ControlCommon.Owner_MemoryApplication,
                log_Reports
                );

            //            remover.Resume(log_Reports);
        }

        //────────────────────────────────────────

        public void Destruct(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Destruct(10)",log_Reports);
            //
            //

            this.ClearAllEventhandlers(log_Reports);

            //
            // 破棄フラグを立てます。
            //
            this.ControlCommon.BDestructed = true;

            this.Clear();

            //
            //
            //
            //
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// データソースから値を取得し、コントロールに取り込みます。
        /// 
        /// データソースが設定されていない場合は、フォームのクリアーになります。
        /// </summary>
        public void RefreshData(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "RefreshData",log_Reports);
            //
            //

            List<Expression_Node_String> ecList_Data = this.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_DATA, false, Request_SelectingImpl.Unconstraint, log_Reports);
            List<Expression_Node_String> ecList_DataSource = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(ecList_Data, PmNames.S_ACCESS.Name_Pm, ValuesAttr.S_FROM, false, Request_SelectingImpl.First_Exist, log_Reports);
            if (!log_Reports.Successful)
            {
                goto gt_EndMethod;
            }
            Expression_Node_String ec_DataSource = ecList_DataSource[0];

            if (null == ec_DataSource)
            {
                // データソースが設定されていないとき
                //.WriteLine(this.GetType().Name + "#RefreshData: データソースが設定されていません。");

                this.Clear();
            }
            else
            {

                if (log_Reports.Successful)
                {

                    this.ControlCommon.BAutomaticinputting = true;

                    //
                    // 最初の１件。なければ空文字列。
                    //
                    Request_SelectingBuilderImpl requestItems = new Request_SelectingBuilderImpl();
                    requestItems.EnumHitcount = EnumHitcount.First_Exist_Or_Zero;



                    this.UsercontrolText = ec_DataSource.Execute_OnExpressionString(requestItems.ToObject(log_Reports), log_Reports);

                    //if ("" != this.sText)
                    //{
                    //    FileStream fs = null;
                    //    try
                    //    {
                    //        fs = new FileStream(this.sText, FileMode.Open, FileAccess.Read);
                    //        this.Image = Image.FromStream(fs);
                    //    }
                    //    catch (Exception)
                    //    {
                    //        this.Image = null;
                    //    }
                    //    finally
                    //    {
                    //        if (null != fs)
                    //        {
                    //            fs.Close();
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    this.Image = null;
                    //}

                    this.ControlCommon.BAutomaticinputting = false;
                }

            }

            goto gt_EndMethod;
        //
        //
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        public void UsercontrolToMemory(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "UsercontrolToMemory",log_Reports);
            //
            //

            if (null == this.ControlCommon.Expression_Control)
            {
                // このコントロールに対応づくテーブル等の設定がなく、ただの空箱の場合。
                // Visual Studio のビジュアルエディターで直接置いただけの時は、ここに来ます。

                // 何もせず終了。
                goto gt_EndMethod;
            }


            List<Expression_Node_String> ecList_Data = this.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_DATA, false, Request_SelectingImpl.Unconstraint, log_Reports);
            List<Expression_Node_String> ecList_DataTarget = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(ecList_Data, PmNames.S_ACCESS.Name_Pm, ValuesAttr.S_TO, false, Request_SelectingImpl.First_Exist, log_Reports);
            if (!log_Reports.Successful)
            {
                goto gt_EndMethod;
            }
            Expression_Node_String ec_DataTarget = ecList_DataTarget[0];


            if (null == ec_DataTarget)
            {
                // エラー：     データターゲットが未設定のとき
                goto gt_Error_NullDatatarget;
            }
            else
            {
                //this……イベントハンドラーのsender引数と一致すること。

                // TODO 数値型テキストボックスで空白を出力しようとしたときにエラーになるのはバグなので修正したい。

                // 特にトリムは行いません。

                ToMemory_Performer nDataTargetUpdater = new ExpressionDataTargetUpdaterImpl();

                nDataTargetUpdater.ToMemory(
                    this.UsercontrolText,//【特殊】．ＩｍａｇｅＬｏｃａｔｉｏｎ替わり。
                    this.ControlCommon.Expression_Control,
                    this.ControlCommon.Owner_MemoryApplication,
                    log_Reports
                    );

                if (log_Reports.Successful)
                {
                    // 成功時
                    this.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    // 設定失敗時。
                    this.BackColor = Color.Yellow;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullDatatarget:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, this.Name, log_Reports);//コントロール名

                this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:510;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        public void AddValidator(
            Expressionv_Validator_Old ecv_Validator,
            Log_Reports log_Reports
            )
        {
            if (ecv_Validator is Expressionv_Validator_Old)
            {
                this.list_Expressionv_Validator.Add((Expressionv_Validator_Old)ecv_Validator);
            }
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// 妥当性を判定します。
        /// </summary>
        public void JudgeValidity(
            Log_Reports log_Reports
            )
        {
            // 未実装 TODO 実装すること。
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 画像のファイルパス。
        /// </summary>
        private string sFcText;

        //────────────────────────────────────────

        private ControlCommon controlCommon__;

        /// <summary>
        /// コントロールの共通プロパティー、およびロジックが含まれているクラスです。
        /// 
        /// C#では多重継承ができないので、共通のプロパティー、ロジックがあれば、ここに含めます。
        /// </summary>
        public ControlCommon ControlCommon
        {
            get
            {
                return controlCommon__;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 妥当性判定項目のリスト。
        /// </summary>
        private List<Expressionv_Validator_Old> list_Expressionv_Validator;

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("ピクチャーのテキストです。"),
        Browsable(true)
            //EditorBrowsable(EditorBrowsableState.Always)
        ]
        public string UsercontrolText
        {
            set
            {
                // ピクチャーボックスの ＩｍａｇｅＬｏｃａｔｉｏｎ は、読込みが遅いので、別の方法にする。

                this.sFcText = value;
                if ("" != this.sFcText)
                {
                    // ファイル名が指定されていれば。

                    if (File.Exists(this.sFcText))
                    {
                        // ファイルが存在すれば。
                        FileStream fs = null;
                        try
                        {
                            fs = new FileStream(this.sFcText, FileMode.Open, FileAccess.Read);
                            this.Image = Image.FromStream(fs, false, false);
                        }
                        catch (Exception)
                        {
                            this.Image = null;
                        }
                        finally
                        {
                            if (null != fs)
                            {
                                fs.Close();
                            }
                        }
                    }
                    else
                    {
                        // #警告。 ファイルが存在しなければ。
                        System.Console.WriteLine(Info_Controls.Name_Library + ":" + this.GetType().Name + "#FcText set: 指定された、存在しない画像ファイルパス=[" + this.sFcText + "]");
                        this.Image = null;
                    }

                }
                else
                {
                    this.Image = null;
                }
            }
            get
            {
                return this.sFcText;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
