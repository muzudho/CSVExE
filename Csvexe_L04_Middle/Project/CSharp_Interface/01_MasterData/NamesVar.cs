using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Middle
{



    /// <summary>
    /// システム変数名。
    /// </summary>
    abstract public class NamesVar
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 頭文字
        //

        public const string S_SP_ = "Sp:";

        public const string S_UP_ = "Up:";

        public const string S_SS_ = "Ss:";

        public const string S_US_ = "Us:";


        //────────────────────────────────────────
        //
        // ツール・コンフィグ関連
        //

        /// <summary>
        /// 例：「C:\Xenon_Project\作品01\meta\Editor-config\MnsEdi」相当。
        /// エディターのホーム・フォルダー。
        /// このパスに「\@Editor.xml」が加えられて使われる。
        /// 
        /// TODO:「@Tables.csv」の「FILE」列の指定でのベース・ディレクトリーとなる。
        /// </summary>
        public const string S_SP_EDITOR = "Sp:Editor;";

        //────────────────────────────────────────
        //
        // エディター設定関連
        //

        /// <summary>
        /// エディター設定ファイルに記載する、エディターの表示タイトル。
        /// </summary>
        public const string S_SS_TITLE_EDITOR = "Ss:TitleEditor;";

        /// <summary>
        /// 
        /// </summary>
        public const string S_SP_ENGINE = "Sp:Engine;";

        /// <summary>
        /// 
        /// </summary>
        public const string S_SP_FORMS = "Sp:Forms;";

        /// <summary>
        /// 
        /// </summary>
        public const string S_SP_LOGS = "Sp:Logs;";

        /// <summary>
        /// 例：「meta\Editor-config\MNS_EDI\Engine\Aa_Files.csv」相当のファイルパス。
        /// 旧："Sp:Tables;"
        /// </summary>
        public const string S_SP_FILES = "Sp:Files;";

        public const string S_SP_VARIABLES = "Sp:Variables;";

        //────────────────────────────────────────
        //
        // テーブル関連
        //

        /// <summary>
        /// 変数設定CSVファイルを指す。
        /// </summary>
        public const string S_ST_VARIABLES2 = "St:Variables;";

        public const string S_ST_STYLESHEET = "St:Stylesheet;";

        /// <summary>
        /// Aa_Files.csvを指すために、プログラム内部で利用しているだけ。
        /// </summary>
        public const string S_ST_FILES = "St:Files;";

        public const string S_ST_AA_FORMS = "St:Aa_Forms;";

        //────────────────────────────────────────
        //
        // スクリプト関連
        //

        //────────────────────────────────────────
        //
        // 日別バックアップ関連　TODO:モンスターレギオンエディターの独自実装を汎用化したい。
        //

        public const string S_SP_BACKUP_FOLDER = "Sp:Backup_Folder;";

        public const string S_SS_BACKUP_NAME_MY_FOLDER = "Ss:Backup_Name_MyFolder;";

        public const string S_SI_BACKUP_KEPT_BACKUPS = "Si:Backup_KeptBackups;";

        //────────────────────────────────────────
        //
        // その他
        //

        public const string S_SS_DEBUGMODE_PROGRAMMER = "Ss:DebugMode_Programmer;";

        public const string S_SS_DEBUGMODE_FORM = "Ss:DebugMode_Form;";

        /// <summary>
        /// 最初の画面。
        /// </summary>
        public const string S_SS_FORM_START = "Ss:Form_Start;";

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// ファイルパス変数なら真。
        /// </summary>
        /// <param name="sNamevar"></param>
        /// <returns></returns>
        public static bool Test_Filepath(string sNamevar)
        {

            return sNamevar.StartsWith(NamesVar.S_SP_) ||
                    sNamevar.StartsWith(NamesVar.S_UP_);
        }

        /// <summary>
        /// 文字列変数なら真。
        /// </summary>
        /// <param name="sNamevar"></param>
        /// <returns></returns>
        public static bool Test_String(string sNamevar)
        {

            return sNamevar.StartsWith(NamesVar.S_SS_) ||
                    sNamevar.StartsWith(NamesVar.S_US_);
        }

        //────────────────────────────────────────
        #endregion



    }
}
