using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using Xenon.Syntax;

namespace Xenon.SpeedCoder
{



    public class OptionlineTemplateImpl
    {




        #region 生成と破棄
        //────────────────────────────────────────

        public OptionlineTemplateImpl()
        {
            this.Comment = "";
            this.NameOption = "";
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        public void Parse(string line)
        {
            //    %cat% CAP_LOW //2行目はアイテム2です。
            //    %ball% //3行目はアイテム3です。

            //string matchPattern = @"^\s*(.+?)\s*=\s*(.+?)\s*(//\.*)?$";
            string matchPattern = @"^\s*(.+?)\s*=\s*(.+?)\s*(//.*)?$";
            Match m1 = Regex.Match(line, matchPattern);
            if (m1.Success)
            {
                // オプション名
                this.NameOption = m1.Groups[1].Value;

                // 値
                this.Value = m1.Groups[2].Value;

                // コメント
                this.Comment = m1.Groups[3].Value;
            }
            else
            {
                //エラー
                this.NameOption = "エラー： matchPattern=[" + matchPattern + "] line=[" + line + "]";
                this.Comment = "";
            }

        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー

        //────────────────────────────────────────

        private string nameOption;

        public string NameOption
        {
            get
            {
                return this.nameOption;
            }
            set
            {
                this.nameOption = value;
            }
        }

        //────────────────────────────────────────

        private string value;

        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        //────────────────────────────────────────

        private string comment;

        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }



}
