using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;

namespace Xenon.Middle
{
    /// <summary>
    /// UserControlを継承して作った自作コントロールに付けるインターフェース。
    /// 
    /// 各コントロールのクラス名に付ける接頭辞に限り、略称は「Uct」とする。
    /// </summary>
    public interface Usercontrol : Customcontrol
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// フォーカスを持ったとき。
        /// </summary>
        event EventHandler UsercontroleventhandlerFocusEnter;

        /// <summary>
        /// フォーカスが外れたとき。
        /// </summary>
        event EventHandler UsercontroleventhandlerFocusLeave;

        /// <summary>
        /// テキストが変更されたとき。
        /// </summary>
        event EventHandler UsercontroleventhandlerTextChanged;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// 内容を消去します。
        /// </summary>
        void Clear();

        /// <summary>
        /// 構成カスタム・コントロールを全て破棄します。
        /// </summary>
        void DestractAllCustomcontrols(Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// レイアウト_レコードを元に、コントロールのスタイルを設定します。
        /// </summary>
        /// <param name="fo_Record"></param>
        /// <param name="log_Reports"></param>
        void SetupStyle(
            RecordUserformconfig fo_Record,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ＜ｅｖｅｎｔ＞要素の内、イベントハンドラーを作っておくべきものは、イベントハンドラーを作ります。
        /// 全ての＜ｅｖｅｎｔ＞要素が、イベントハンドラーになるわけではありません。
        /// </summary>
        /// <param name="gcavToExpr"></param>
        /// <param name="nActionCollection"></param>
        /// <param name="log_Reports"></param>
        /// <returns>該当なければヌル。</returns>
        Functionlist CreateFunctionlist(
            GivechapterandverseToExpression_Event gcavToExpr,
            MemoryApplication owner_MoApplication,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 子コントロールを追加します。
        /// </summary>
        /// <param name="fcUc"></param>
        void AppendChild(
            Usercontrol fcUc,
            Log_Reports log_Reports
                );

        /// <summary>
        /// 再描画の要求。
        /// </summary>
        void Refresh();

        /// <summary>
        /// 再描画のタイミングで、データの再読込をさせる指定をします。
        /// </summary>
        void Dirty(Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        string UsercontrolChkvaluetype
        {
            get;
        }

        int UsercontrolPiczoom
        {
            get;
        }

        string UsercontrolBackcolor
        {
            get;
        }

        int UsercontrolItemheightpx
        {
            get;
        }

        string UsercontrolItemdisplayformat
        {
            get;
        }

        string UsercontrolListvaluefield
        {
            get;
        }

        //────────────────────────────────────────

        bool UsercontrolReadonly
        {
            get;
        }

        bool UsercontrolWordwrap
        {
            get;
        }

        string UsercontrolNewline
        {
            get;
        }

        //────────────────────────────────────────

        float UsercontrolFontsizept
        {
            get;
        }

        int UsercontrolTabindex
        {
            get;
        }

        ScrollBars UsercontrolScrollbars
        {
            get;
            set;
        }

        //────────────────────────────────────────

        int UsercontrolXlt
        {
            get;
        }

        int UsercontrolYlt
        {
            get;
        }

        int UsercontrolWidth
        {
            get;
        }

        int UsercontrolHeight
        {
            get;
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロールに、人間オペレーターが入力をできるか否か。
        /// </summary>
        bool UsercontrolEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// コントロールが、表示されているか否か。
        /// </summary>
        bool UsercontrolVisible
        {
            get;
            set;
        }

        /// <summary>
        /// カスタム コンポーネントを返します。
        /// </summary>
        /// <returns></returns>
        List<Customcontrol> List_Customcontrol
        {
            get;
        }

        /// <summary>
        /// テキスト
        /// 
        /// LabelコントロールのTextプロパティは、思ったとおりの挙動をしないので、
        /// テキスト プロパティを自作します。
        /// </summary>
        string UsercontrolText
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
