using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;

namespace Xenon.Lib
{



    #region 用意
    //────────────────────────────────────────

    public delegate void DELEGATE_OnPngOpened(string filepathabsolute, Form form );

    public delegate void DELEGATE_OnCsvOpened(string filepathabsolute, Form form);

    public delegate void DELEGATE_OnErrorFilechooser(Form form);

    //────────────────────────────────────────

    public delegate void DELEGATE_OnSave();

    //────────────────────────────────────────

    public delegate void DELEGATE_OnPopupExplain();

    //────────────────────────────────────────

    public delegate void DELEGATE_OnRequestPaintBackground(Graphics g, bool bOnWindow, float scale2);

    public delegate void DELEGATE_OnRequestPaintListsprite(Graphics g, bool bOnWindow, float scale2);

    public delegate void DELEGATE_OnRequestWriteCsv( out string out_ErrorMessage, string filepathabsolute_Csv);

    //────────────────────────────────────────

    /// <summary>
    /// 何かを編集したとき。
    /// </summary>
    public delegate void DELEGATE_OnChanged_SomeContents();

    /// <summary>
    /// 何かファイルを開いたとき。
    /// </summary>
    public delegate void DELEGATE_OnOpened_SomeFiles();

    //────────────────────────────────────────
    #endregion



    public interface Memory1Application_Partsnumput
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 読み込むファイルを選択します。
        /// </summary>
        /// <param name="form1"></param>
        void ChooseFile_PngCsv( Form form1 );

        //────────────────────────────────────────

        void Save();

        //────────────────────────────────────────

        /// <summary>
        /// 番号を追加します。
        /// </summary>
        /// <param name="mNum"></param>
        void AddPartsnumbersprite(Memory4bSpritePartsnumber memSpritePartnum, bool bLoadingNow, Memory1Application_Partsnumput memoryApplication_Partsnumput);

        void RemovePartsnumberspriteAt(int selectedIndex, Memory1Application_Partsnumput memoryApplication_Partsnumput);

        void MovePartsnumbersprite(Memory4bSpritePartsnumber memSpritePartnum, float dx, float dy, float nScale, Memory1Application_Partsnumput memoryApplication_Partsnumput);

        void SetText_SpritePartsnumber(Memory4bSpritePartsnumber memSpritePartnum, string sText, Memory1Application_Partsnumput memoryApplication_Partsnumput);

        //────────────────────────────────────────

        void AddNewLayer(out int nNewLayer);

        void ClearNumbers(bool bLoadingNow, Memory1Application_Partsnumput memoryApplication_Partsnumput);

        //────────────────────────────────────────

        void PaintSprite(
            Graphics g, Memory4bSpritePartsnumber memSprNum, bool isOnWindow, float scale2);

        /// <summary>
        /// [乗せる画像]の描画
        /// </summary>
        /// <param name="g"></param>
        /// <param name="bOnWindow"></param>
        /// <param name="scale2"></param>
        void PaintListsprite(Graphics g, bool bOnWindow, float scale2);

        void DirtyAllNums();

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────
        //
        // コントロール
        //

        /// <summary>
        /// ファイルオープン・ダイアログ。
        /// </summary>
        OpenFileDialog ControldialogOpenfileBg
        {
            get;
        }

        Form Form
        {
            get;
            set;
        }

        //────────────────────────────────────────
        //
        // デリゲーター
        //

        DELEGATE_OnPngOpened Delegate_OnPngOpened
        {
            get;
            set;
        }

        //────────────────────────────────────────

        DELEGATE_OnCsvOpened Delegate_OnCsvOpened
        {
            get;
            set;
        }

        //────────────────────────────────────────

        DELEGATE_OnErrorFilechooser Delegate_OnErrorFilechooser
        {
            get;
            set;
        }

        //────────────────────────────────────────

        DELEGATE_OnSave Delegate_OnSave
        {
            get;
            set;
        }

        //────────────────────────────────────────

        DELEGATE_OnPopupExplain Delegate_OnPopupExplain
        {
            get;
            set;
        }

        //────────────────────────────────────────

        DELEGATE_OnRequestPaintBackground Delegate_OnRequestPaintBackground
        {
            get;
            set;
        }

        DELEGATE_OnRequestPaintListsprite Delegate_OnRequestPaintListsprite
        {
            get;
            set;
        }

        DELEGATE_OnRequestWriteCsv Delegate_OnRequestWriteCsv
        {
            get;
            set;
        }

        DELEGATE_OnChanged_SomeContents Delegate_OnChanged_SomeContents
        {
            get;
            set;
        }

        DELEGATE_OnOpened_SomeFiles Delegate_OnOpened_SomeFiles
        {
            get;
            set;
        }

        //────────────────────────────────────────
        //
        // デリゲーター以外
        //

        /// <summary>
        /// 背景画像の不透明度。0.0F～1.0F。
        /// </summary>
        float BgOpaque
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 背景画像。
        /// </summary>
        Bitmap Bitmap_Bg
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 内容を変更したら真。
        /// </summary>
        bool IsChangedContents
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 偽…そのまま表示
        /// 真…加算表示
        /// </summary>
        bool IsDisplayExecute
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 拡大率。
        /// </summary>
        float ScaleImg
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 背景画像の点XY。
        /// </summary>
        PointF BgLocationScaled
        {
            get;
            set;
        }

        //────────────────────────────────────────

        Dictionary<string, int> NameValueDic
        {
            get;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 操作モード。
        /// </summary>
        Memory2Operationmode MemoryOperationmode
        {
            get;
            set;
        }

        //────────────────────────────────────────
        //
        // マウス操作
        //

        EnumMousedragmode EnumMousedragmode
        {
            get;
        }

        /// <summary>
        /// マウスのドラッグをこれから始める最初なら真。
        /// </summary>
        bool MouseDraggingNone
        {
            get;
            set;
        }

        /// <summary>
        /// マウスをドラッグ中なら真。
        /// </summary>
        bool MouseDragging
        {
            get;
            set;
        }

        /// <summary>
        /// マウス押下点XY。
        /// </summary>
        PointF MouseDownLocation
        {
            get;
            set;
        }

        /// <summary>
        /// 1つ前のドラッグ点XY。
        /// </summary>
        PointF PreDragLocation
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 変更前の拡大率。
        /// </summary>
        float PreScale
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// [Ctrl]キーが押されていれば真。
        /// </summary>
        bool IsControlkey
        {
            get;
            set;
        }

        /// <summary>
        /// [Shift]キーが押されていれば真。
        /// </summary>
        bool IsShiftkey
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 連番
        /// </summary>
        int Count_Creates
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 現在選択中のスプライト。未選択ならヌル。
        /// </summary>
        Memory4bSpritePartsnumberImpl SelectedMemoryPartsnumbersprite
        {
            get;
            set;
        }

        //────────────────────────────────────────

        string Filepath_Csv
        {
            get;
            set;
        }

        string Filepath_BgPng
        {
            get;
            set;
        }

        //────────────────────────────────────────

        Dictionary<string, Memory4aPartsnumbersymbolspritesImpl> Dictionary_MemoryPartsnumbergroupImpl
        {
            get;
        }

        //────────────────────────────────────────

        /// <summary>
        /// マウスが指している番号。なければヌル。
        /// </summary>
        Memory4bSpritePartsnumber MouseTargetNum
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// グルーピング
        /// </summary>
        void Grouping(Memory1Application_Partsnumput memoryApplication_Partsnumput);

        string[] Array_NameGroup
        {
            get;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 番号スプライトのレイヤー別リスト。
        /// </summary>
        Dictionary<int, List<Memory4bSpritePartsnumber>> DictionaryLayer
        {
            get;
            set;
        }

        int SelectedLayer
        {
            get;
            set;
        }

        List<Memory4bSpritePartsnumber> List_VisiblePartsnumbersprite
        {
            get;
        }

        //────────────────────────────────────────

        int Count_Partsnumbersprite
        {
            get;
        }

        //────────────────────────────────────────
        #endregion


    }
}
