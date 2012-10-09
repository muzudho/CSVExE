using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.NumPut
{
    public partial class UsercontrolGraphList : UserControl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public UsercontrolGraphList()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void LoadDirectory(string sFopath)
        {
            string[] sFileArray = System.IO.Directory.GetFiles(sFopath, "*.*");//csv,*.png

            Dictionary<string, MemoryFilesetImpl> moDir = new Dictionary<string, MemoryFilesetImpl>();

            foreach (string sFile in sFileArray)
            {
                string sName = System.IO.Path.GetFileNameWithoutExtension(sFile);
                string sFilenameLower = System.IO.Path.GetFileName(sFile).ToLower();

                if (sFilenameLower.EndsWith(".csv"))
                {
                    //ystem.Console.WriteLine("(.csv) sName=" + sName);
                    MemoryFilesetImpl moFileset;
                    if (moDir.ContainsKey(sName))
                    {
                        moFileset = moDir[sName];
                    }
                    else
                    {
                        moFileset = new MemoryFilesetImpl();
                        moFileset.SName = sName;
                        moDir.Add(sName, moFileset);
                    }
                    moFileset.SFpathCsv = sFile;
                }
                else if (sFilenameLower.EndsWith("#graph.png"))
                {
                    string sName2 = sName.Substring(0, sName.Length - "#Graph".Length);

                    MemoryFilesetImpl moFileset;
                    if (moDir.ContainsKey(sName2))
                    {
                        //ystem.Console.WriteLine("(#graph.phg) 既存 sName2=" + sName2);
                        moFileset = moDir[sName2];
                    }
                    else
                    {
                        //ystem.Console.WriteLine("(#graph.phg) 新規 sName2=" + sName2);
                        moFileset = new MemoryFilesetImpl();
                        moFileset.SName = sName2;
                        moDir.Add(sName2, moFileset);
                    }
                    moFileset.SFpathPngGraph = sFile;
                }
                else if (sFilenameLower.EndsWith(".png"))
                {
                    //ystem.Console.WriteLine("(.png) sName=" + sName);

                    MemoryFilesetImpl moFileset;
                    if (moDir.ContainsKey(sName))
                    {
                        moFileset = moDir[sName];
                    }
                    else
                    {
                        moFileset = new MemoryFilesetImpl();
                        moFileset.SName = sName;
                        moDir.Add(sName, moFileset);
                    }
                    moFileset.SFpathPng = sFile;
                }

            }

            this.pclst1.Items.Clear();
            foreach (MemoryFilesetImpl moFileset in moDir.Values)
            {
                this.pclst1.Items.Add(moFileset);
                //this.pclst1.Items.Add(moFileset.SName);
            }

            //StringBuilder s = new StringBuilder();
            //s.Append(System.IO.Path.GetDirectoryName(sFpatha));
            //s.Append(System.IO.Path.DirectorySeparatorChar);
            //s.Append(System.IO.Path.GetFileNameWithoutExtension(sFpatha));
            //s.Append(".png");

        }

        //────────────────────────────────────────

        private void SizeFit()
        {
            //int nBtnHeight = 40;
            int nZureHeight = 10;

            int nThumbnailHeight = 50;

            this.pclst1.Bounds = new Rectangle(
                0,
                0,
                this.Size.Width,
                this.Size.Height - nThumbnailHeight - nZureHeight// - nBtnHeight
                );

            this.pcpicThumbnail.Bounds = new Rectangle(
                0,
                this.Size.Height - nThumbnailHeight - 2 * nZureHeight,// - nBtnHeight
                this.Size.Width,
                nThumbnailHeight
                );
            this.CreateThumbnail();

            //this.pcbtnOpen.Bounds = new Rectangle(
            //    0,
            //    this.Size.Height - nBtnHeight - nZureHeight,
            //    this.Size.Width,
            //    nBtnHeight - (int)(1.5*nZureHeight)
            //    );

        }

        //────────────────────────────────────────

        private void Open()
        {
            object obj = this.pclst1.SelectedItem;
            if (null != obj && obj is MemoryFilesetImpl)
            {
                MemoryFilesetImpl moFileset = (MemoryFilesetImpl)obj;

                Form1 form1 = (Form1)this.ParentForm;

                // 選択レイヤー番号
                int nSelectedLayer_Old = form1.UcCanvas.MoApplication.MoProject.MoContents.NSelectedLayer;
                //ystem.Console.WriteLine("nSelectedLayer_Old=" + nSelectedLayer_Old);

                string sFopath = "";
                if ("" != moFileset.SFpathPng)
                {
                    form1.UcCanvas.MoApplication.MoProject.MoContents.SFpath_BgPng = moFileset.SFpathPng;
                    form1.UcCanvas.OpenBg();
                    sFopath = System.IO.Path.GetDirectoryName(moFileset.SFpathPng);
                }

                if ("" != moFileset.SFpathCsv)
                {
                    form1.UcCanvas.MoApplication.MoProject.MoContents.SFpath_Csv = moFileset.SFpathCsv;
                    form1.UcCanvas.OpenCsv();
                    sFopath = System.IO.Path.GetDirectoryName(moFileset.SFpathCsv);
                }

                if ("" != sFopath)
                {
                    //this.LoadDirectory(sFopath);
                    form1.OnOpened();
                }

                form1.UcCanvas.MoApplication.MoProject.MoContents.NSelectedLayer = nSelectedLayer_Old;

                List<int> intList = new List<int>();
                foreach (int nLayer in form1.UcCanvas.PclstLayer.Items)
                {
                    intList.Add(nLayer);
                }

                int nIx = 0;
                form1.UcCanvas.PclstLayer.SelectedIndex = -1;
                foreach (int nLayer in intList)
                {
                    if (nLayer == nSelectedLayer_Old)
                    {
                        form1.UcCanvas.PclstLayer.SelectedIndex = nIx;
                    }
                    nIx++;
                }

                if (-1 == form1.UcCanvas.PclstLayer.SelectedIndex)
                {
                    form1.UcCanvas.PclstLayer.Items.Add(nSelectedLayer_Old);
                    form1.UcCanvas.PclstLayer.SelectedIndex = nIx;
                }
            }
        }

        private void CreateThumbnail()
        {
            object obj = this.pclst1.SelectedItem;
            if (null != obj && obj is MemoryFilesetImpl)
            {
                MemoryFilesetImpl moFileset = (MemoryFilesetImpl)obj;

                if ("" != moFileset.SFpathPngGraph)
                {
                    Image image = Image.FromFile(moFileset.SFpathPngGraph);

                    if (this.pcpicThumbnail.Width <= image.Width && this.pcpicThumbnail.Height <= image.Height)
                    {
                        // 縦幅、横幅ともにオーバーしている場合

                        // サムネイル画像は縦幅の方が短いと想定して、欄の縦幅を１００としてリサイズ。
                        float nPer = (float)this.pcpicThumbnail.Height / (float)image.Height;
                        int nResizeWidth = (int)((float)image.Width * nPer);

                        this.pcpicThumbnail.Image = image.GetThumbnailImage(
                            nResizeWidth,
                            this.pcpicThumbnail.Height,
                            delegate { return false; },
                            IntPtr.Zero
                            );
                    }
                    else if (this.pcpicThumbnail.Height <= image.Height)
                    {
                        // 縦幅だけがオーバーしている場合。

                        // 欄の縦幅を１００としてリサイズ。
                        float nPer = (float)this.pcpicThumbnail.Height / (float)image.Height;
                        int nResizeWidth = (int)((float)image.Width * nPer);

                        this.pcpicThumbnail.Image = image.GetThumbnailImage(
                            nResizeWidth,
                            this.pcpicThumbnail.Height,
                            delegate { return false; },
                            IntPtr.Zero
                            );
                    }
                    else if (this.pcpicThumbnail.Width <= image.Width)
                    {
                        // 横幅だけがオーバーしている場合

                        // 欄の横幅を１００としてリサイズ。
                        float nPer = (float)this.pcpicThumbnail.Width / (float)image.Width;
                        int nResizeHeight = (int)((float)image.Height * nPer);

                        this.pcpicThumbnail.Image = image.GetThumbnailImage(
                            this.pcpicThumbnail.Width,
                            nResizeHeight,
                            delegate { return false; },
                            IntPtr.Zero
                            );
                    }
                    else
                    {
                        this.pcpicThumbnail.Image = image.GetThumbnailImage(
                            this.pcpicThumbnail.Width,
                            this.pcpicThumbnail.Height,
                            delegate { return false; },
                            IntPtr.Zero
                            );
                    }

                }
            }
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void UcGraphList_SizeChanged(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        //────────────────────────────────────────

        private void pclst1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Open();

            this.CreateThumbnail();
        }

        //────────────────────────────────────────
        #endregion



    }
}
