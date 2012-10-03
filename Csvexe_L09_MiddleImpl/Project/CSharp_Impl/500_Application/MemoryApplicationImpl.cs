using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Table;
using Xenon.Controls;
using Xenon.Operating;
using Xenon.Middle;

namespace Xenon.MiddleImpl
{
    public class MemoryApplicationImpl : MemoryApplication
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryApplicationImpl()
        {
            this.memoryBackup = new MemoryBackupImpl(this);
            this.memoryValidators = new MemoryValidatorsImpl(this);
            this.memoryTogethers = new MemoryTogethersImpl(this);
            this.memoryTables = new MemoryTablesImpl(this);
            this.memoryCodefiles = new MemoryCodefilesImpl(this);
            this.memoryFunctions = new MemoryFunctionsImpl(this);
            this.memoryVariables = new MemoryVariablesImpl(this);
            this.memoryForms = new MemoryFormsImpl(this);
            this.memoryStyles = new MemoryStylesImpl();
            this.memoryLogwriter = new MemoryLogwriterImpl();
            this.memoryBrushes = new MemoryBrushesImpl();
            this.memoryAatoolxml = new MemoryAatoolxmlImpl(this);
            this.memoryRecordset = new MemoryRecordsetImpl();
        }


        /// <summary>
        /// 使う前に、実装インスタンスを設定してください。
        /// </summary>
        /// <param oVariableName="nActionCollection"></param>
        public void InitializeBeforeUse(
            Mainwnd_FormWrapping mainwnd_FormWrapping,
            ConfigurationtreeToFunction gcavToFunc,
            Form_Toolwindow form_Toolwindow,
            MemoryAatoolxmlDialog moAatoolxmlDialog,
            UsercontrolStyleSetter ucontrolStyleSetter,
            UsercontrolCreator1 ucontrolCreator1,
            XToMemory_Form xToM_FormImpl
            )
        {
            this.MemoryForms.InitializeBeforeUse(
                mainwnd_FormWrapping,
                gcavToFunc,
                form_Toolwindow,
                moAatoolxmlDialog,
                ucontrolStyleSetter,
                ucontrolCreator1,
                xToM_FormImpl
                );
        }

        //────────────────────────────────────────

        /// <summary>
        /// 使わなくなったら呼び出してください。
        /// </summary>
        public void Dispose()
        {
            this.MemoryBrushes.Dispose();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void CreateErrorReport(
            string errorSymbol,
            Builder_TexttemplateP1p texttemplateBuilder_ParameterSetted,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "CreateErrorReport", log_Reports);
            //

            int errorNumber;
            {
                string tempErrorSymbol = errorSymbol;
                if (tempErrorSymbol.StartsWith("Er:"))
                {
                    tempErrorSymbol = tempErrorSymbol.Substring(3);
                    if (tempErrorSymbol.EndsWith(";"))
                    {
                        tempErrorSymbol = tempErrorSymbol.Substring(0, tempErrorSymbol.Length - 1);
                        if (int.TryParse(tempErrorSymbol, out errorNumber))
                        {
                        }
                        else
                        {
                            goto gt_Error_Symbol;
                        }
                    }
                    else
                    {
                        goto gt_Error_Symbol;
                    }
                }
                else
                {
                    goto gt_Error_Symbol;
                }
            }

            if (log_Reports.CanCreateReport)
            {
                string strTypedata = ValuesTypeData.S_TABLE_ERRORMESSAGES;
                Configurationtree_Node cur_Ct = new Configurationtree_NodeImpl(log_Method.Fullname, null);
                List<XenonTable> tables = this.MemoryTables.GetXenonTableByTypedata(
                    new Expression_Leaf_StringImpl(strTypedata, null, cur_Ct), true, log_Reports);

                bool hit = false;
                foreach (XenonTable table in tables)
                {
                    foreach (DataRow dataRow in table.DataTable.Rows)
                    {
                        XenonValue_IntImpl xenonValue_Int = (XenonValue_IntImpl)dataRow["ID"];

                        int valueInt;
                        xenonValue_Int.TryGet(out valueInt);

                        if (valueInt == errorNumber)
                        {
                            //ヒット
                            hit = true;

                            Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                            r.SetTitle("Er:" + errorNumber + ";", log_Method);

                            XenonValue_StringImpl xenonValue_String = (XenonValue_StringImpl)dataRow["MESSAGE"];

                            string valueStr;
                            xenonValue_String.TryGet(out valueStr);

                            texttemplateBuilder_ParameterSetted.Text = valueStr;
                            r.Message = texttemplateBuilder_ParameterSetted.Compile(log_Reports).Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                            //log_Method.WriteDebug_ToConsole(texttemplateBuilder_ParameterSetted.Compile(log_Reports).Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));

                            goto gt_EndLoop1;
                        }
                    }
                }
            gt_EndLoop1:

                if (!hit)
                {
                    //エラーメッセージの登録がない。

                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("Er:0;", log_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();
                    s.Append("エラーメッセージテーブルに、エラーメッセージの登録がありませんでした。\n%1%=[%2%]\nテーブル数=[%3%]");

                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl(s.ToString());
                    tmpl.SetParameter(1, NamesFld.S_TYPE_DATA,log_Reports);
                    tmpl.SetParameter(2, strTypedata,log_Reports);
                    tmpl.SetParameter(3, tables.Count.ToString(),log_Reports);

                    r.Message = tmpl.Compile(log_Reports).Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                }

                log_Reports.EndCreateReport();
            }

            goto gt_EndMethod;
            //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Symbol:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー204！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("エラーシンボルがおかしい。[" + errorSymbol + "]。プログラムのミス？");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 設定されている内容を空っぽにします。
        /// 
        /// todo:イベントハンドラーを外してから、フォームを外すこと。リストボックスが誤挙動を起こしている。
        /// </summary>
        public void ClearProject(
            Control.ControlCollection formControls,
            Log_Reports log_Reports
            )
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "ClearProject",log_Reports);
            //
            //


            //
            // クリアー：　form1の、コントロール：
            //
            this.MemoryForms.ClearForms(
                formControls,
                log_Reports
                );

            //
            // クリアー：　バックアップ情報を空っぽにします。
            //
            this.MemoryBackup.Clear(this);

            //
            // クリアー：　関数を空っぽにします。
            //
            this.MemoryFunctions.Clear(this);

            //
            // クリアー：　変数を空っぽにします。
            //
            this.MemoryVariables.Clear(this);

            //
            // クリアー：　テーブルを空っぽにします。
            //
            this.MemoryTables.Clear(this);

            //
            // クリアー：　リローディング設定ファイルを空っぽにします。
            //
            this.MemoryTogethers.Clear(this);//.Cf_RfrCnf.List_Child.Clear(log_Reports);

            //
            // クリアー：　スクリプトファイル一覧を空っぽにします。
            //
            this.MemoryCodefiles.Clear(this);

            //
            // クリアー：　バリデーター一覧を空っぽにします。
            //
            this.MemoryValidators.Clear(this);


            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion


        
        #region プロパティー
        //────────────────────────────────────────
        //
        // バックアップ関連
        //
        //────────────────────────────────────────

        private MemoryBackup memoryBackup;

        /// <summary>
        /// 日付別バックアップ設定。
        /// </summary>
        public MemoryBackup MemoryBackup
        {
            get
            {
                return memoryBackup;
            }
        }

        //────────────────────────────────────────

        private MemoryValidators memoryValidators;

        /// <summary>
        /// バリデーター設定。
        /// </summary>
        public MemoryValidators MemoryValidators
        {
            get
            {
                return memoryValidators;
            }
        }

        //────────────────────────────────────────

        private MemoryTogethers memoryTogethers;

        /// <summary>
        /// トゥゲザー設定。
        /// </summary>
        public MemoryTogethers MemoryTogethers
        {
            get
            {
                return memoryTogethers;
            }
        }

        //────────────────────────────────────────

        private MemoryTables memoryTables;

        /// <summary>
        /// テーブルを格納したもの。
        /// </summary>
        public MemoryTables MemoryTables
        {
            get
            {
                return memoryTables;
            }
        }

        //────────────────────────────────────────

        private MemoryCodefiles memoryCodefiles;

        /// <summary>
        /// スクリプトファイル情報を格納したもの。
        /// </summary>
        public MemoryCodefiles MemoryCodefiles
        {
            get
            {
                return memoryCodefiles;
            }
        }

        //────────────────────────────────────────

        private MemoryFunctions memoryFunctions;

        /// <summary>
        /// ユーザー定義関数を格納したもの。
        /// </summary>
        public MemoryFunctions MemoryFunctions
        {
            get
            {
                return memoryFunctions;
            }
            set
            {
                memoryFunctions = value;
            }
        }

        //────────────────────────────────────────

        private MemoryVariables memoryVariables;

        /// <summary>
        /// 変数モデル。
        /// </summary>
        public MemoryVariables MemoryVariables
        {
            get
            {
                return this.memoryVariables;
            }
        }

        //────────────────────────────────────────

        private MemoryForms memoryForms;

        /// <summary>
        /// コントロール集モデル。
        /// </summary>
        public MemoryForms MemoryForms
        {
            get
            {
                return memoryForms;
            }
        }

        //────────────────────────────────────────

        private MemoryStyles memoryStyles;

        /// <summary>
        /// スタイルシート設定ファイルで記述された内容。
        /// </summary>
        public MemoryStyles MemoryStyles
        {
            get
            {
                return memoryStyles;
            }
        }

        //────────────────────────────────────────

        private MemoryLogwriter memoryLogwriter;

        /// <summary>
        /// スタイルシート設定ファイルで記述された内容。
        /// </summary>
        public MemoryLogwriter MemoryLogwriter
        {
            get
            {
                return memoryLogwriter;
            }
        }

        //────────────────────────────────────────

        private MemoryBrushes memoryBrushes;

        /// <summary>
        /// 各種ブラシ。
        /// </summary>
        public MemoryBrushes MemoryBrushes
        {
            get
            {
                return memoryBrushes;
            }
            set
            {
                memoryBrushes = value;
            }
        }

        //────────────────────────────────────────

        private MemoryRecordset memoryRecordset;

        public MemoryRecordset MemoryRecordset
        {
            get
            {
                return this.memoryRecordset;
            }
        }

        //────────────────────────────────────────

        private MemoryAatoolxml memoryAatoolxml;

        /// <summary>
        /// 『ツール設定ファイル』の内容。
        /// </summary>
        public MemoryAatoolxml MemoryAatoolxml
        {
            get
            {
                return memoryAatoolxml;
            }
            set
            {
                memoryAatoolxml = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
