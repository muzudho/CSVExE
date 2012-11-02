using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Functions
{


    #region 用意
    //────────────────────────────────────────

    public delegate void DELEGATE_Filesystementries(string filesystementry, ref bool isBreak2, Log_Reports log_Reports2);

    //────────────────────────────────────────
    #endregion



    public class FilesystemreportImpl : Filesystemreport
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public FilesystemreportImpl()
        {
            this.list_Filepath = new List<string>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void ForEach(DELEGATE_Filesystementries delegate_Records1, Log_Reports log_Reports )
        {
            bool isBreak = false;
            foreach (string filepath in this.List_Filepath)
            {
                delegate_Records1(filepath, ref isBreak, log_Reports);

                if (isBreak)
                {
                    break;
                }
            }
        }

        public void Add(string filepath)
        {
            this.list_Filepath.Add(filepath);
        }

        public void AddList(List<string> list_Filepath)
        {
            this.list_Filepath.AddRange( list_Filepath);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private List<string> list_Filepath;

        private List<string> List_Filepath
        {
            get
            {
                return this.list_Filepath;
            }
        }

        //────────────────────────────────────────

        private DELEGATE_Filesystementries delegate_Filesystementries;

        public DELEGATE_Filesystementries Delegate_Filesystementries
        {

            get
            {
                return this.delegate_Filesystementries;
            }
            set
            {
                this.delegate_Filesystementries = value;
            }
        }

        //────────────────────────────────────────
        #endregion




    }
}
