using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Lib
{


    /// <summary>
    /// パーツ番号CSV、背景画像、番号記入済み画像のファイルパス３点セットです。
    /// </summary>
    public class Memory3FilesetImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター
        /// </summary>
        public Memory3FilesetImpl()
        {
            this.Name_Fileset = "";
            this.Filepath_CsvPartsnumber = "";
            this.Filepath_Png = "";
            this.Filepath_PngGraph = "";
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(this.name_Fileset);
            if ("" == this.Filepath_Png)
            {
                s.Append(" 絵☓");
            }

            if ("" == this.Filepath_CsvPartsnumber)
            {
                s.Append(" 表☓");
            }

            if ("" == this.Filepath_PngGraph)
            {
                s.Append(" 見☓");
            }

            return s.ToString();
        }

        //────────────────────────────────────────
        #endregion

        

        #region プロパティー
        //────────────────────────────────────────

        private string name_Fileset;

        public string Name_Fileset
        {
            get
            {
                return this.name_Fileset;
            }
            set
            {
                this.name_Fileset = value;
            }
        }

        //────────────────────────────────────────

        private string filepath_CsvPartsnumber;

        public string Filepath_CsvPartsnumber
        {
            get
            {
                return this.filepath_CsvPartsnumber;
            }
            set
            {
                this.filepath_CsvPartsnumber = value;
            }
        }

        //────────────────────────────────────────

        private string filepath_Png;

        public string Filepath_Png
        {
            get
            {
                return this.filepath_Png;
            }
            set
            {
                this.filepath_Png = value;
            }
        }

        //────────────────────────────────────────

        private string filepath_PngGraph;

        public string Filepath_PngGraph
        {
            get
            {
                return this.filepath_PngGraph;
            }
            set
            {
                this.filepath_PngGraph = value;
            }
        }

        //────────────────────────────────────────
        #endregion
        


    }
}
