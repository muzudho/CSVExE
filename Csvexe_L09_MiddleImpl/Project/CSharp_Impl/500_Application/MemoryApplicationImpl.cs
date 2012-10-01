using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
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
            this.memoryBackup = new MemoryBackupImpl();
            this.memoryValidators = new MemoryValidatorsImpl();
            this.memoryTogethers = new MemoryTogethersImpl();
            this.memoryTables = new MemoryTablesImpl();
            this.memoryCodefiles = new MemoryCodefilesImpl();
            this.memoryFunctions = new MemoryFunctionsImpl();
            this.memoryVariables = new MemoryVariablesImpl();
            this.memoryForms = new MemoryFormsImpl();
            this.memoryStyles = new MemoryStylesImpl();
            this.memoryLogwriter = new MemoryLogwriterImpl();
            this.memoryBrushes = new MemoryBrushesImpl();
            this.memoryAatoolxml = new MemoryAatoolxmlImpl();
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
                this,
                log_Reports
                );

            //
            // クリアー：　バックアップ情報を空っぽにします。
            //
            this.MemoryBackup.Clear();

            //
            // クリアー：　関数を空っぽにします。
            //
            this.MemoryFunctions.Clear();

            //
            // クリアー：　変数を空っぽにします。
            //
            this.MemoryVariables.Clear(log_Reports);

            //
            // クリアー：　テーブルを空っぽにします。
            //
            this.MemoryTables.Clear();

            //
            // クリアー：　リローディング設定ファイルを空っぽにします。
            //
            this.MemoryTogethers.Clear();//.Cf_RfrCnf.List_Child.Clear(log_Reports);

            //
            // クリアー：　スクリプトファイル一覧を空っぽにします。
            //
            this.MemoryCodefiles.Clear();

            //
            // クリアー：　バリデーター一覧を空っぽにします。
            //
            this.MemoryValidators.Clear();


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
