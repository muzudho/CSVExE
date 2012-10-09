using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;

namespace Xenon.NumPut
{
    public class Memory3ContentsImpl : Memory3Contents
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター
        /// </summary>
        public Memory3ContentsImpl()
        {
            this.mouseDragModeEnum = EnumMousedragmode.None;
            this.layerDic = new Dictionary<int, List<MemoryNum>>();
            this.sGroupNameList = new List<string>();
            this.moGroupImplDic = new Dictionary<string, MemoryGroupImpl>();
            this.nameValueDic = new Dictionary<string, int>();
            this.sGroupNameArray = new string[0];
            this.sFpath_Csv = "";
            this.sFpath_BgPng = "";
            this.BgOpaque = 0.5F;
            this.BgLocationScaled = new Point();
            this.ScaleImg = 1;
            this.PreScale = 1;
            this.CreatesCount = 1;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void Save(Form1 form1)
        {
            UsercontrolCanvas ucCanvas = form1.UcCanvas;

            if (form1.ToolStripMenuItem_Save.Enabled && null != ucCanvas.MoApplication.MoProject.MoContents.Bitmap_Bg)
            {
                // ファイル名を適当に作成。
                string sFileName;
                {
                    StringBuilder s = new StringBuilder();
                    DateTime now = System.DateTime.Now;
                    s.Append(now.Year);
                    s.Append("_");
                    s.Append(now.Month);
                    s.Append("_");
                    s.Append(now.Day);
                    s.Append("_");
                    s.Append(now.Hour);
                    s.Append("_");
                    s.Append(now.Minute);
                    s.Append("_");
                    s.Append(now.Second);
                    s.Append("_");
                    s.Append(now.Millisecond);
                    //拡張子は付けない。
                    sFileName = s.ToString();
                }

                // 原画PNG
                {
                    Bitmap bmSrc = new Bitmap(ucCanvas.MoApplication.MoProject.MoContents.Bitmap_Bg.Width, ucCanvas.MoApplication.MoProject.MoContents.Bitmap_Bg.Height);

                    Graphics g = Graphics.FromImage(bmSrc);

                    float nOldOpaque = ucCanvas.MoApplication.MoProject.MoContents.BgOpaque;
                    ucCanvas.MoApplication.MoProject.MoContents.BgOpaque = 1.0F;
                    ucCanvas.PaintBg(g, false, 1.0F);//等倍
                    ucCanvas.MoApplication.MoProject.MoContents.BgOpaque = nOldOpaque;

                    g.Dispose();

                    // 原画PNGファイル名
                    StringBuilder sPngSrc = new StringBuilder();
                    {
                        sPngSrc.Append(Application.StartupPath);
                        // .exeの入っているフォルダーに Save フォルダーを置くこと。
                        sPngSrc.Append("\\Save\\");

                        sPngSrc.Append(sFileName);
                        sPngSrc.Append(".png");
                    }

                    // 画像の保存
                    try
                    {
                        bmSrc.Save(sPngSrc.ToString(), System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "エラー");
                    }
                }

                // 結合PNG
                {
                    // TODO 拡大のし過ぎに注意。
                    float scale2 = ucCanvas.MoApplication.MoProject.MoContents.ScaleImg;
                    if (2.0 < scale2)
                    {
                        scale2 = 2.0f;
                    }

                    Bitmap bmDst = new Bitmap(
                        ucCanvas.MoApplication.MoProject.MoContents.Bitmap_Bg.Width * (int)scale2,
                        ucCanvas.MoApplication.MoProject.MoContents.Bitmap_Bg.Height * (int)scale2
                        );

                    //imgのGraphicsオブジェクトを取得
                    Graphics g = Graphics.FromImage(bmDst);

                    ucCanvas.PaintBg(g, false, scale2);

                    ucCanvas.PaintSpList(g, false, scale2);

                    g.Dispose();


                    // 結合PNGファイル名
                    StringBuilder sPngDst = new StringBuilder();
                    {
                        sPngDst.Append(Application.StartupPath);
                        // .exeの入っているフォルダーに Save フォルダーを置くこと。
                        sPngDst.Append("\\Save\\");

                        sPngDst.Append(sFileName);
                        sPngDst.Append("#Graph.png");
                    }

                    // 画像の保存
                    try
                    {
                        bmDst.Save(sPngDst.ToString(), System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "エラー");
                    }
                }

                // CSV
                {
                    // CSVファイル名
                    StringBuilder sCsv = new StringBuilder();
                    {
                        sCsv.Append(Application.StartupPath);
                        // .exeの入っているフォルダーに Save フォルダーを置くこと。
                        sCsv.Append("\\Save\\");

                        sCsv.Append(sFileName);
                        sCsv.Append(".csv");
                    }

                    // CSVの保存
                    Memory3Contents moContents = ucCanvas.MoApplication.MoProject.MoContents;
                    bool bDisplayExecute_old = moContents.BDisplayExecute;
                    ucCanvas.MoApplication.MoProject.MoContents.BDisplayExecute = false;
                    Subaction001 a1 = new Subaction001();
                    a1.In_SFpatha = sCsv.ToString();
                    a1.Perform(moContents);
                    moContents.BDisplayExecute = bDisplayExecute_old;

                    if ("" != a1.Out_errorMsg)
                    {
                        MessageBox.Show(a1.Out_errorMsg, "エラー");
                    }
                    else
                    {
                        this.BChangedContents = false;
                    }
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 番号を追加します。
        /// </summary>
        /// <param name="mNum"></param>
        public void AddNum(MemoryNum mNum, bool bLoadingNow)
        {
            if (!this.LayerDic.ContainsKey(mNum.NLayer))
            {
                List<MemoryNum> mNumList = new List<MemoryNum>();
                mNumList.Add(mNum);
                this.LayerDic.Add(mNum.NLayer, mNumList);
            }
            else
            {
                this.LayerDic[mNum.NLayer].Add(mNum);
            }


            if (!bLoadingNow)
            {
                this.BChangedContents = true;
            }
        }

        public void ClearNums(bool bLoadingNow)
        {
            this.layerDic.Clear();
            if (!bLoadingNow)
            {
                this.BChangedContents = true;
            }
        }

        public int CountNum
        {
            get
            {
                int nTotal = 0;
                foreach (List<MemoryNum> mList in this.layerDic.Values)
                {
                    nTotal += mList.Count;
                }
                return nTotal;
            }
        }

        //────────────────────────────────────────

        public void RemoveNumAt(int selectedIndex)
        {
            this.VisibleNumList.RemoveAt(selectedIndex);
            this.BChangedContents = true;
        }

        //────────────────────────────────────────

        public void SetNumText(MemoryNum mNum, string sText)
        {
            if (mNum.SText != sText)
            {
                mNum.SText = sText;
                this.BChangedContents = true;
            }
        }

        //────────────────────────────────────────

        public void MoveNum(MemoryNum mNum, float dx, float dy, float nScale, UsercontrolCanvas ucCanvas)
        {
            // 背景画像上のスプライト位置
            mNum.LocationOnBgActual = new PointF(
                mNum.LocationOnBgActual.X + dx / nScale,
                mNum.LocationOnBgActual.Y + dy / nScale
                );
            //ystem.Console.WriteLine("移動前("+old.X+","+old.Y+")　移動後("+mNum.LocationOnBgActual.X+","+mNum.LocationOnBgActual.Y+")");

            mNum.RefreshData(nScale, ucCanvas);
            this.BChangedContents = true;
        }

        //────────────────────────────────────────

        public void AddNewLayer(out int nNewLayer)
        {
            List<int> numbers = new List<int>();

            foreach (int nLayer in this.LayerDic.Keys)
            {
                numbers.Add(nLayer);
            }

            int[] array = numbers.ToArray();
            Array.Sort(array);

            nNewLayer = 0;
            foreach (int nL in array)
            {
                if (nL < 0)
                {
                    // 無視
                }
                else if (nNewLayer == nL)
                {
                    nNewLayer++;
                }
            }

            this.LayerDic.Add(nNewLayer, new List<MemoryNum>());
        }

        //────────────────────────────────────────

        /// <summary>
        /// グルーピング
        /// </summary>
        public void Grouping()
        {
            this.sGroupNameList.Clear();
            this.moGroupImplDic.Clear();
            foreach (MemoryNum mNum in this.VisibleNumList)
            {
                // 書式からグループ分け。
                if (mNum.BNameDefine)
                {
                    // 「a=1000」など。
                    if (moGroupImplDic.ContainsKey(mNum.SName))
                    {
                        // 既に登録されていた場合。
                        MemoryGroupImpl moGroup = moGroupImplDic[mNum.SName];
                        moGroup.MNameDefine = mNum;
                    }
                    else
                    {
                        MemoryGroupImpl moGroup = new MemoryGroupImpl();
                        moGroup.MNameDefine = mNum;
                        moGroupImplDic.Add(mNum.SName, moGroup);
                        sGroupNameList.Add(mNum.SName);
                    }
                }
                else
                {
                    // 「b+1」など。
                    MemoryGroupImpl moGroup;
                    if (moGroupImplDic.ContainsKey(mNum.SName))
                    {
                        moGroup = moGroupImplDic[mNum.SName];
                    }
                    else
                    {
                        moGroup = new MemoryGroupImpl();
                        moGroupImplDic.Add(mNum.SName, moGroup);
                        sGroupNameList.Add(mNum.SName);
                    }

                    moGroup.MNumList.Add(mNum);
                }
            }

            this.sGroupNameArray = this.SGroupNameList.ToArray();
            Array.Sort(sGroupNameArray);

            // 数値計算
            foreach (string sGroupName in this.SGroupNameArray)
            {
                MemoryGroupImpl moGroup = this.MoGroupImplDic[sGroupName];

                // 名前定義
                if (this.BDisplayExecute)
                {
                    moGroup.MNameDefine.ParseValueExecute(this);
                }

                // Num要素
                foreach (MemoryNum mNum in moGroup.MNumList)
                {
                    if (this.BDisplayExecute)
                    {
                        mNum.ParseValueExecute(this);
                    }
                }

            }

        }

        //────────────────────────────────────────
        #endregion
        


        #region プロパティー
        //────────────────────────────────────────

        protected EnumMousedragmode mouseDragModeEnum;

        public EnumMousedragmode MouseDragModeEnum
        {
            get
            {
                return this.mouseDragModeEnum;
            }
        }

        //────────────────────────────────────────

        protected bool mouseDraggingNone;

        /// <summary>
        /// マウスのドラッグをこれから始める最初なら真。
        /// </summary>
        public bool MouseDraggingNone
        {
            get
            {
                return this.mouseDraggingNone;
            }
            set
            {
                this.mouseDraggingNone = value;
            }
        }

        //────────────────────────────────────────

        protected bool mouseDragging;

        /// <summary>
        /// マウスをドラッグ中なら真。
        /// </summary>
        public bool MouseDragging
        {
            get
            {
                return this.mouseDragging;
            }
            set
            {
                this.mouseDragging = value;
            }
        }

        //────────────────────────────────────────

        protected PointF mouseDownLocation;

        /// <summary>
        /// マウス押下点XY。
        /// </summary>
        public PointF MouseDownLocation
        {
            get
            {
                return this.mouseDownLocation;
            }
            set
            {
                this.mouseDownLocation = value;
            }
        }

        //────────────────────────────────────────

        #region マウス操作

        protected PointF preDragLocation;

        /// <summary>
        /// 1つ前のドラッグ点XY。
        /// </summary>
        public PointF PreDragLocation
        {
            get
            {
                return this.preDragLocation;
            }
            set
            {
                this.preDragLocation = value;
            }
        }

        #endregion

        //────────────────────────────────────────

        protected bool bShiftKey;

        /// <summary>
        /// [Shift]キーが押されていれば真。
        /// </summary>
        public bool BShiftKey
        {
            get
            {
                return bShiftKey;
            }
            set
            {
                bShiftKey = value;
            }
        }

        //────────────────────────────────────────

        protected bool bCtrlKey;

        /// <summary>
        /// [Ctrl]キーが押されていれば真。
        /// </summary>
        public bool BCtrlKey
        {
            get
            {
                return bCtrlKey;
            }
            set
            {
                bCtrlKey = value;
            }
        }

        //────────────────────────────────────────

        protected int createsCount;

        /// <summary>
        /// 連番
        /// </summary>
        public int CreatesCount
        {
            get
            {
                return createsCount;
            }
            set
            {
                createsCount = value;
            }
        }

        //────────────────────────────────────────

        protected float preScale;

        /// <summary>
        /// 変更前の拡大率。
        /// </summary>
        public float PreScale
        {
            get
            {
                return this.preScale;
            }
            set
            {
                this.preScale = value;
            }
        }

        //────────────────────────────────────────

        protected float bgOpaque;

        /// <summary>
        /// 背景画像の不透明度。0.0F～1.0F。
        /// </summary>
        public float BgOpaque
        {
            get
            {
                return this.bgOpaque;
            }
            set
            {
                this.bgOpaque = value;
            }
        }

        //────────────────────────────────────────

        protected PointF bgLocationScaled;

        /// <summary>
        /// 背景画像の点XY。
        /// </summary>
        public PointF BgLocationScaled
        {
            get
            {
                return bgLocationScaled;
            }
            set
            {
                bgLocationScaled = value;
            }
        }

        //────────────────────────────────────────

        protected float scaleImg;

        /// <summary>
        /// 拡大率。
        /// </summary>
        public float ScaleImg
        {
            get
            {
                return scaleImg;
            }
            set
            {
                this.scaleImg = value;
            }
        }

        //────────────────────────────────────────

        protected Bitmap bitmap_Bg;

        /// <summary>
        /// 背景画像。
        /// </summary>
        public Bitmap Bitmap_Bg
        {
            get
            {
                return this.bitmap_Bg;
            }
            set
            {
                bitmap_Bg = value;
            }
        }

        //────────────────────────────────────────

        protected MemoryNumImpl selectedMoSprite;

        /// <summary>
        /// 現在選択中のスプライト。未選択ならヌル。
        /// </summary>
        public MemoryNumImpl SelectedMoSprite
        {
            get
            {
                return selectedMoSprite;
            }
            set
            {
                selectedMoSprite = value;
            }
        }

        //────────────────────────────────────────

        private string sFpath_Csv;

        public string SFpath_Csv
        {
            get
            {
                return this.sFpath_Csv;
            }
            set
            {
                this.sFpath_Csv = value;
            }
        }

        //────────────────────────────────────────

        private string sFpath_BgPng;

        public string SFpath_BgPng
        {
            get
            {
                return this.sFpath_BgPng;
            }
            set
            {
                this.sFpath_BgPng = value;
            }
        }

        //────────────────────────────────────────

        private bool bChangedContents;

        /// <summary>
        /// 内容を変更したら真。セーブしたら偽。
        /// </summary>
        public bool BChangedContents
        {
            get
            {
                return this.bChangedContents;
            }
            set
            {
                this.bChangedContents = value;
            }
        }

        //────────────────────────────────────────

        private MemoryNum mouseTargetNum;

        /// <summary>
        /// マウスが指している番号。なければヌル。
        /// </summary>
        public MemoryNum MouseTargetNum
        {
            get
            {
                return this.mouseTargetNum;
            }
            set
            {
                this.mouseTargetNum = value;
            }
        }

        //────────────────────────────────────────

        private bool bDisplayExecute;

        /// <summary>
        /// 偽…そのまま表示
        /// 真…加算表示
        /// </summary>
        public bool BDisplayExecute
        {
            get
            {
                return this.bDisplayExecute;
            }
            set
            {
                this.bDisplayExecute = value;
            }
        }

        //────────────────────────────────────────

        private int nSelectedLayer;

        public int NSelectedLayer
        {
            get
            {
                return this.nSelectedLayer;
            }
            set
            {
                this.nSelectedLayer = value;
            }
        }

        //────────────────────────────────────────

        protected Dictionary<int, List<MemoryNum>> layerDic;

        /// <summary>
        /// 番号スプライトのレイヤー別リスト。
        /// </summary>
        public Dictionary<int, List<MemoryNum>> LayerDic
        {
            get
            {
                return layerDic;
            }
            set
            {
                layerDic = value;
            }
        }

        //────────────────────────────────────────

        public List<MemoryNum> VisibleNumList
        {
            get
            {
                List<MemoryNum> moNumList;
                if (this.LayerDic.ContainsKey(this.NSelectedLayer))
                {
                    moNumList = this.LayerDic[this.NSelectedLayer];
                }
                else
                {
                    moNumList = new List<MemoryNum>();
                    this.LayerDic.Add(this.NSelectedLayer, moNumList);
                }

                return moNumList;
            }
        }

        //────────────────────────────────────────

        private List<string> sGroupNameList;

        public List<string> SGroupNameList
        {
            get
            {
                return this.sGroupNameList;
            }
        }

        //────────────────────────────────────────

        private Dictionary<string, MemoryGroupImpl> moGroupImplDic;

        public Dictionary<string, MemoryGroupImpl> MoGroupImplDic
        {
            get
            {
                return this.moGroupImplDic;
            }
        }

        //────────────────────────────────────────

        private Dictionary<string, int> nameValueDic;

        public Dictionary<string, int> NameValueDic
        {
            get
            {
                return this.nameValueDic;
            }
        }

        //────────────────────────────────────────

        private string[] sGroupNameArray;

        public string[] SGroupNameArray
        {
            get
            {
                return this.sGroupNameArray;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
