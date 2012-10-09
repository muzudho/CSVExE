using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Xenon.NumPut
{
    public interface Memory3Contents
    {
        


        #region アクション
        //────────────────────────────────────────

        void Save(Form1 form1);

        //────────────────────────────────────────

        /// <summary>
        /// 番号を追加します。
        /// </summary>
        /// <param name="mNum"></param>
        void AddNum(MemoryNum mNum, bool bLoadingNow);

        void RemoveNumAt(int selectedIndex);

        void MoveNum(MemoryNum mNum, float dx, float dy, float nScale, UsercontrolCanvas ucCanvas);

        void SetNumText(MemoryNum mNum, string sText);

        //────────────────────────────────────────

        void AddNewLayer(out int nNewLayer);

        void ClearNums(bool bLoadingNow);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────
        //
        // マウス操作
        //

        EnumMousedragmode MouseDragModeEnum
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
        /// 背景画像の点XY。
        /// </summary>
        PointF BgLocationScaled
        {
            get;
            set;
        }

        /// <summary>
        /// 拡大率。
        /// </summary>
        float ScaleImg
        {
            get;
            set;
        }

        /// <summary>
        /// 変更前の拡大率。
        /// </summary>
        float PreScale
        {
            get;
            set;
        }

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
        /// [Ctrl]キーが押されていれば真。
        /// </summary>
        bool BCtrlKey
        {
            get;
            set;
        }

        /// <summary>
        /// [Shift]キーが押されていれば真。
        /// </summary>
        bool BShiftKey
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 連番
        /// </summary>
        int CreatesCount
        {
            get;
            set;
        }

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
        /// 現在選択中のスプライト。未選択ならヌル。
        /// </summary>
        MemoryNumImpl SelectedMoSprite
        {
            get;
            set;
        }

        //────────────────────────────────────────

        string SFpath_Csv
        {
            get;
            set;
        }

        string SFpath_BgPng
        {
            get;
            set;
        }

        //────────────────────────────────────────

        Dictionary<string, MemoryGroupImpl> MoGroupImplDic
        {
            get;
        }

        //────────────────────────────────────────

        /// <summary>
        /// マウスが指している番号。なければヌル。
        /// </summary>
        MemoryNum MouseTargetNum
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// グルーピング
        /// </summary>
        void Grouping();

        string[] SGroupNameArray
        {
            get;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 内容を変更したら真。
        /// </summary>
        bool BChangedContents
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 偽…そのまま表示
        /// 真…加算表示
        /// </summary>
        bool BDisplayExecute
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 番号スプライトのレイヤー別リスト。
        /// </summary>
        Dictionary<int, List<MemoryNum>> LayerDic
        {
            get;
        }

        int NSelectedLayer
        {
            get;
            set;
        }

        List<MemoryNum> VisibleNumList
        {
            get;
        }

        //────────────────────────────────────────

        int CountNum
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
